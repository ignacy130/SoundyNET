using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoundyAPI.Models
{
	public class Track
	{
		public Guid Id { get; set; }
		public List<Guid> Owners { get; set; }
		public string Name { get; set; }
		public List<Sound> Sounds { get; set; } 
		public Guid NextUserId { get; set; }

		public Track()
		{ 
		}
	}
}