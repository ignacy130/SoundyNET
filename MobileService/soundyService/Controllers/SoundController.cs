using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.WindowsAzure.Mobile.Service;
using soundyService.Models;

namespace soundyService.Controllers
{
    public class SoundController : TableController<Sound>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            soundyContext context = new soundyContext();
            DomainManager = new EntityDomainManager<Sound>(context, Request, Services);
        }

        // GET tables/Sound
        public IQueryable<Sound> GetAllSound()
        {
            return Query(); 
        }

        // GET tables/Sound/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Sound> GetSound(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Sound/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Sound> PatchSound(string id, Delta<Sound> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Sound
        public async Task<IHttpActionResult> PostSound(Sound item)
        {
            Sound current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Sound/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteSound(string id)
        {
             return DeleteAsync(id);
        }

    }
}