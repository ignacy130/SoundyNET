using Microsoft.WindowsAzure.Mobile.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace soundyService.Models
{
    public class Sound : EntityData
    {
        public string FilePath { get; set; }
        public virtual User Creator { get; set; }
        public int StepNumber { get; set; }

        [JsonProperty(PropertyName = "containerName")]
        public string ContainerName { get; set; }

        [JsonProperty(PropertyName = "resourceName")]
        public string ResourceName { get; set; }

        [JsonProperty(PropertyName = "sasQueryString")]
        public string SasQueryString { get; set; }

        [JsonProperty(PropertyName = "imageUri")]
        public string ImageUri { get; set; } 

        public Sound()
        {

        }
    }
}