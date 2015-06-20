using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace SoundyAPI.Models
{
    public class Sound : Entity
    {
        public int StepNumber { get; set; }
        public string FilePath { get; set; }
        public virtual User Creator { get; set; }
        public Sound()
        {

        }
    }
}