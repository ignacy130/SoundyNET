using System;
using System.Collections.Generic;
using System.Linq;
using System.Web; 

namespace SoundyAPI.Models
{
    public class User : Entity
	{
		public string UserName { get; set; }
		public int Energy { get; set; }
		public virtual List<Track> Tracks { get; set; }
		public User(string name, int energy)
		{
			this.UserName = name;
			this.Energy = energy;
		}
	}
}