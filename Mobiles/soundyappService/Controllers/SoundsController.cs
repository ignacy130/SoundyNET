﻿using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.WindowsAzure.Mobile.Service;
using soundyappService.DataObjects;
using soundyappService.Models;
using soundyService.Models;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using Microsoft.WindowsAzure.Storage.Auth;

namespace soundyappService.Controllers
{
    public class SoundsController : TableController<Sound>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            soundyappContext context = new soundyappContext();
            DomainManager = new EntityDomainManager<Sound>(context, Request, Services);
        }

        // GET tables/TodoItem
        public IQueryable<Sound> GetAllSounds()
        {
            return Query();
        }

        // GET tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Sound> GetSound(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Sound> PatchSound(string id, Delta<Sound> patch)
        {
            return UpdateAsync(id, patch);
        }

        // POST tables/TodoItem
        public async Task<IHttpActionResult> PostSound(Sound sound)
        {
            string storageAccountName;
            string storageAccountKey;

            // Try to get the Azure storage account token from app settings.  
            if (!(Services.Settings.TryGetValue("STORAGE_ACCOUNT_NAME", out storageAccountName) |
            Services.Settings.TryGetValue("STORAGE_ACCOUNT_ACCESS_KEY", out storageAccountKey)))
            {
                Services.Log.Error("Could not retrieve storage account settings.");
            }

            // Set the URI for the Blob Storage service.
            Uri blobEndpoint = new Uri(string.Format("https://{0}.blob.core.windows.net", storageAccountName));

            // Create the BLOB service client.
            CloudBlobClient blobClient = new CloudBlobClient(blobEndpoint,
                new StorageCredentials(storageAccountName, storageAccountKey));

            if (sound.ContainerName != null)
            {
                // Set the BLOB store container name on the item, which must be lowercase.
                sound.ContainerName = sound.ContainerName.ToLower();

                // Create a container, if it doesn't already exist.
                CloudBlobContainer container = blobClient.GetContainerReference(sound.ContainerName);
                await container.CreateIfNotExistsAsync();

                // Create a shared access permission policy. 
                BlobContainerPermissions containerPermissions = new BlobContainerPermissions();

                // Enable anonymous read access to BLOBs.
                containerPermissions.PublicAccess = BlobContainerPublicAccessType.Blob;
                container.SetPermissions(containerPermissions);

                // Define a policy that gives write access to the container for 5 minutes.                                   
                SharedAccessBlobPolicy sasPolicy = new SharedAccessBlobPolicy()
                {
                    SharedAccessStartTime = DateTime.UtcNow,
                    SharedAccessExpiryTime = DateTime.UtcNow.AddMinutes(5),
                    Permissions = SharedAccessBlobPermissions.Write
                };

                // Get the SAS as a string.
                sound.SasQueryString = container.GetSharedAccessSignature(sasPolicy);

                // Set the URL used to store the image.
                sound.ImageUri = string.Format("{0}{1}/{2}", blobEndpoint.ToString(),
                    sound.ContainerName, sound.ResourceName);
            }

            // Complete the insert operation.
            Sound current = await InsertAsync(sound);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteSound(string id)
        {
            return DeleteAsync(id);
        }
    }
}