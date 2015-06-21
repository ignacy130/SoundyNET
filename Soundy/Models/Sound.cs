using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Soundy
{
    public class Sound
    {
        public int StepNumber { get; set; }

        public string FilePath { get; set; }
        public Guid CreatorId { get; set; }
        public Sound()
        {

        }
    }
}