using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Http;
using Microsoft.WindowsAzure.Mobile.Service;
using soundyService.Models;

namespace soundyService
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
            
            Database.SetInitializer(new soundyInitializer());
        }
    }

    public class soundyInitializer : ClearDatabaseSchemaIfModelChanges<soundyContext>
    {
        protected override void Seed(soundyContext context)
        {
            List<User> Users = new List<User>
            {
                new User { Id = Guid.NewGuid().ToString(), UserName = "First item" },
                new User { Id = Guid.NewGuid().ToString(), UserName = "Second item" },
            };

            foreach (User user in Users)
            {
                context.Set<User>().Add(user);
            }

            base.Seed(context);
        }
    }
}

