using System;
using System.Collections.Generic;
using System.Linq;

namespace Soundy.Models
{
    public class User : Entity
	{
		public string UserName { get; set; }
		public int Energy { get; set; }
		public virtual List<Track> Tracks { get; set; }
        public string Hash { get; set; }
        public int Salt { get; set; }

        public override string ToString()
        {
            return UserName;
        }
	}
}