using System;
using System.Collections.Generic;
using System.Text;

namespace OutAndRefTutorial
{
	public class GabEnums
	{

		public enum FaultStatus
		{
			Ok,
			Fault
		}

		public enum ActionTaken
        {
			NoAction,
			AddedPressure,
			RemovedPressure
        }

		public enum FlightStatus
        {
			Ready,
			InFlight,
			Terminal,
			SelfInert,
			Terminated

        }
	}
}
