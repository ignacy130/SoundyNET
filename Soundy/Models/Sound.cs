using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Soundy.Models
{
    public class Sound
    {
        public string FilePath { get; set; }
        public virtual User Creator { get; set; }
        public int StepNumber { get; set; }
        public Sound()
        {

        }
    }
}