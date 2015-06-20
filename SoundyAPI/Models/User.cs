using System;
using System.Collections.Generic;
using System.Linq;
using System.Web; 

namespace SoundyAPI.Models
{
	public class User	
	{
		public Guid ID { get; set; }
		public string UserName { get; set; }
		public int Energy { get; set; }
		public List<Track> Tracks { get; set; }
		public User(Guid id, string name, int energy)
		{
			this.ID = id;
			this.UserName = name;
			this.Energy = energy;
		}


	}
}