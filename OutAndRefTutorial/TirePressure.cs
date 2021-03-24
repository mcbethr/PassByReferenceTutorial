using System;
using System.Collections.Generic;
using System.Text;

namespace OutAndRefTutorial
{
	public class TirePressure
	{
		public int CurrentPressure { get; set; }
		public int RequiredPressure { get; set; }
		public AircraftEnums.FaultStatus Fault { get; set; }

		public TirePressure(int CurrentPressure,int RequiredPressure, AircraftEnums.FaultStatus Fault)
        {
			this.CurrentPressure = CurrentPressure;
			this.RequiredPressure = RequiredPressure;
			this.Fault = Fault;

        }
	}
}
