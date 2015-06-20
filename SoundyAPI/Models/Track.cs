using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoundyAPI.Models
{
    public class Track : Entity
    {
        public virtual List<User> Owners { get; set; }
        public string Name { get; set; }
        public virtual List<Sound> Sounds { get; set; }
        public virtual User NextUser { get; set; }

        public Track()
        {
        }
    }
}