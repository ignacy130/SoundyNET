using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using Soundy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;

namespace Soundy.Models
{
    public static class Dao<T> where T : Entity
    {
        public async static void Delete(T user)
        {
            await App.MobileService.GetTable<T>().DeleteAsync(user);
        }

        public async static Task<List<T>> GetAll()
        {
            return await App.MobileService.GetTable<T>().ToListAsync();
        }

        public async static Task Insert(T item)
        {
            await App.MobileService.GetTable<T>().InsertAsync(item);
        }

        public async static void Update(T user)
        {
            await App.MobileService.GetTable<T>().UpdateAsync(user);
        }
    }

    public class SoundsHelper
    {
        public static async Task<Sound> InsertSound(Sound sound, StorageFile media)
        {
            string errorString = string.Empty;

            if (media != null)
            {
                // Set blob properties of TodoItem.
                sound.ContainerName = "todoitemimages";
                sound.ResourceName = media.Name;
            }
                   string StorageConnectionString = 
            "DefaultEndpointsProtocol=https;AccountName=soundy;" +
            "AccountKey=SmroUKj1Y40J/fEV7FrzHenFy3UXLw+AzluNe3cnvAhi+2Nc5bM3yHSSr/rA6rRYmvNsNAJ6+rcFVRwY+Oyraw==";

            // Retrieve storage account from connection string.
            var storageAccount =
 CloudStorageAccount.Parse(StorageConnectionString);


            // Create the blob client.
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            // Retrieve reference to a previously created container.
            CloudBlobContainer container = blobClient.GetContainerReference("mycontainer");

            await container.SetPermissionsAsync(
                new BlobContainerPermissions
                {
                    PublicAccess = BlobContainerPublicAccessType.Blob
                });
            // Create the container if it doesn't already exist.
            await container.CreateIfNotExistsAsync();

            // Retrieve reference to a blob named "myblob".
            CloudBlockBlob blockBlob = container.GetBlockBlobReference("myblob");

                await blockBlob.UploadFromFileAsync(media);

            // Send the item to be inserted. When blob properties are set this
            // generates an SAS in the response.
            //await Dao<Sound>.Insert(sound);

            // If we have a returned SAS, then upload the blob.
          //  if (!string.IsNullOrEmpty(sound.SasQueryString))
            //{
                // Get the URI generated that contains the SAS 
                // and extract the storage credentials.
                //StorageCredentials cred = new StorageCredentials(sound.SasQueryString);
                //var imageUri = new Uri(sound.ImageUri);

                //// Instantiate a Blob store container based on the info in the returned item.
                //CloudBlobContainer container2 = new CloudBlobContainer(
                //    new Uri(string.Format("https://{0}/{1}",
                //        imageUri.Host,
                //        sound.ContainerName)), cred);

                //await container2.SetPermissionsAsync(
                //new BlobContainerPermissions
                //{
                //    PublicAccess = BlobContainerPublicAccessType.Blob
                //});
                // Get the new image as a stream.
                //using (var fileStream = await media.OpenReadAsync())
                //{
                //    // Upload the new image as a BLOB from the stream.
                //    CloudBlockBlob blobFromSASCredential =
                //        container.GetBlockBlobReference(sound.ResourceName);
                //    await blobFromSASCredential.UploadFromStreamAsync(fileStream.GetInputStreamAt(0));
                //}

                // When you request an SAS at the container-level instead of the blob-level,
                // you are able to upload multiple streams using the same container credentials.
         //   }

            // Add the new item to the collection.
            return sound;
        }
    }
}
