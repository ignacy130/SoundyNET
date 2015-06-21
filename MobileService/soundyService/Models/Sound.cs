using Microsoft.WindowsAzure.Mobile.Service;
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

        public string ContainerName { get; set; }
        public string ResourceName { get; set; }
        public string SasQueryString { get; set; }
        public string Uri { get; set; } 

        public Sound()
        {

        }
    }
}