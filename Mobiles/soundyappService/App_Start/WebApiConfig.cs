using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Http;
using Microsoft.WindowsAzure.Mobile.Service;
using soundyappService.DataObjects;
using soundyappService.Models;
using soundyService.Models;

namespace soundyappService
{
    public static class WebApiConfig
    {
        public static void Register()
        {
            // Use this class to set configuration options for your mobile service
            ConfigOptions options = new ConfigOptions();

            // Use this class to set WebAPI configuration options
            HttpConfiguration config = ServiceConfig.Initialize(new ConfigBuilder(options));

            // To display errors in the browser during development, uncomment the following
            // line. Comment it out again when you deploy your service for production use.
            // config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
            
            Database.SetInitializer(new soundyappInitializer());
        }
    }

    public class soundyappInitializer : ClearDatabaseSchemaIfModelChanges<soundyappContext>
    {
        protected override void Seed(soundyappContext context)
        {
            List<Sound> sounds = new List<Sound>
            {
                new Sound { Id = Guid.NewGuid().ToString()},
                new Sound { Id = Guid.NewGuid().ToString()},
            };

            foreach (Sound todoItem in sounds)
            {
                context.Set<Sound>().Add(todoItem);
            }

            base.Seed(context);
        }
    }
}

