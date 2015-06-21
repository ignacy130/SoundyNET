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
<<<<<<< HEAD
        public string Hash { get; set; }
        public int Salt { get; set; }
=======
		public User(string name, int energy)
		{
			this.UserName = name;
			this.Energy = energy;
		}

		/// <summary>
		/// if return true - success added new track
		/// if not - you dont have enough energy
		/// </summary>
		/// <param name="newTrack"></param>
		/// <returns></returns>
		public bool CreateNewTrack(Track newTrack)
		{
			bool hasEnergy = Energy > 0;
			if (Energy == 0) {
				//TODO Inform user, dont have enough power to create new track
			} else {
				Tracks.Add(newTrack);
				Energy--;
			}
			Energy -= Energy == 0 ? 0 : 1;
			return hasEnergy;
		}
>>>>>>> c7761d348597bd484e80621732a0fbc05e1f7d4c
	}
}