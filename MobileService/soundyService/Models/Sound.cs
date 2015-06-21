using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace soundyService.Models
{
    public class Sound : Entity
    {
        public string FilePath { get; set; }
        public virtual User Creator { get; set; }
        public Sound()
        {

        }
    }
}