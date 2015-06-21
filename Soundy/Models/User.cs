using System;
using System.Collections.Generic;
using System.Linq;

namespace Soundy.Models
{
    public class User : Entity
	{
		public string UserName { get; set; }
		public DateTime TimeOfLastPowerChange { get; set; } 
		public int batteryRestInSec = 10;
		private int maxEnergy = 3;
		private int _energy;
		public int Energy { 
			get
			{
				//each time you get this Value it will refresh energy value
				RefreshTimeOfBatteryLastUpdate();
				return _energy;
			}
			set 
			{
				//energy must be in energyRange (0 - maxEnergy)
				if (value >= 0 && value <= maxEnergy)
				{
					TimeOfLastPowerChange = DateTime.Now;
					_energy = value;
				} 
			}
		}
		public virtual List<Track> Tracks { get; set; }
        public string Hash { get; set; }
        public int Salt { get; set; }

        public override string ToString()
        {
            return UserName;
        }
		 
		private void RefreshTimeOfBatteryLastUpdate()
		{
			TimeSpan diff = DateTime.Now - TimeOfLastPowerChange;
			while (Energy < maxEnergy && diff.TotalSeconds > batteryRestInSec)
			{
				Energy++;
				diff = DateTime.Now - TimeOfLastPowerChange; 
			}
		}

	}
}