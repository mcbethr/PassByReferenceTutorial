using System;
using System.Collections.Generic;
using System.Text;

namespace OutAndRefTutorial
{
	public class Tire
	{ 
		public int TirePressure { get; set; }

		public Tire(int TirePressure)
        {
			this.TirePressure = TirePressure;
        }
	}
}
