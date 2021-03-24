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
			RemovedPressire
        }

		public enum FlightStatus
        {
			Ready,
			InFlight,
			Terminated

        }
	}
}
