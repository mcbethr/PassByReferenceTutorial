using System;
using System.Collections.Generic;
using System.Text;

namespace OutAndRefTutorial
{
	public class AircraftEnums
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
	}
}
