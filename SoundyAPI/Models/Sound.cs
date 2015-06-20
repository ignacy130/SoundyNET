using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace SoundyAPI.Models
{
    public class Sound : Entity
    {
        public string FilePath { get; set; }
        public Guid CreatorId { get; set; }
        public Sound()
        {

        }
    }
}