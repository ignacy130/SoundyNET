using System;
using System.Collections.Generic;
using System.Linq;

namespace Soundy
{
    public class Track
    {
        public virtual List<Guid> Owners { get; set; }
        public string Name { get; set; }
        public virtual List<Sound> Sounds { get; set; }
        public Guid NextUserId { get; set; }

        public Track()
        {
        }
    }
}