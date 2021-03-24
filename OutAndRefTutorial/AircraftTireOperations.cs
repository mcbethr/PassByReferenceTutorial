using System;
using System.Collections.Generic;
using System.Text;

namespace OutAndRefTutorial
{
	public class AircraftTireOperations
	{
		/// <summary>
		/// Holds tire information for testing
		/// </summary>
		Tire _MyTire;

		#region Lightweight With ref, in and out Parameters		
		public void CalibratePressure(ref int CurrentPressure, in int RequiredPressure, out AircraftEnums.FaultStatus Fault, Tire MyTire)
		{
			_MyTire = MyTire;

			LogPressure(RequiredPressure); ///Log the pressure before adding 
			Fault = ActivatePump(ref CurrentPressure, in RequiredPressure);
			LogPressure(RequiredPressure); ///Log the pressure after adding
		}
        #endregion

        #region Gathering Tire Pressure using a class
        public TirePressure CalibratePressure(TirePressure TP, Tire MyTire)
		{
			_MyTire = MyTire;

			LogPressure(TP.RequiredPressure); ///Log the pressure before adding 
			TP = ActivatePump(TP);
			LogPressure(TP.RequiredPressure); ///Log the pressure after adding
			return TP;
		}
        #endregion

		/// <summary>
		/// This method is for adding tire pressure through ref and in
		/// </summary>
		/// <param name="CurrentPressure"></param>
		/// <param name="RequiredPressure"></param>
		/// <returns></returns>
        private AircraftEnums.FaultStatus ActivatePump(ref int CurrentPressure, in int RequiredPressure)
		{
			if (TestAirPressureSystem() == AircraftEnums.FaultStatus.Fault)
			{
				return AircraftEnums.FaultStatus.Fault;
			}
			else
			{

				if (GetTirePressure() < RequiredPressure)
				{
					CurrentPressure = AddAir(RequiredPressure);


				}
				else if (GetTirePressure() > RequiredPressure)
				{
					CurrentPressure = RemoveAir(RequiredPressure);

				}
				else
				{
					///The pressures are equal.  Do nothing for now but we may need to pass something back later
					//so keep the else for future possible changes.
				}


				return AircraftEnums.FaultStatus.Ok;
			}
		}

		/// <summary>
		/// This method is uses for adding tire pressure through a class
		/// </summary>
		/// <param name="TP"></param>
		/// <returns></returns>
		private TirePressure ActivatePump(TirePressure TP)
		{
			if (TestAirPressureSystem() == AircraftEnums.FaultStatus.Fault)
			{
				TP.Fault = AircraftEnums.FaultStatus.Fault;
				return TP;
			}
			else
			{

				if (GetTirePressure() < TP.RequiredPressure)
				{
					TP.CurrentPressure = AddAir(TP.RequiredPressure);


				}
				else if (GetTirePressure() > TP.RequiredPressure)
				{
					TP.CurrentPressure = RemoveAir(TP.RequiredPressure);

				}
				else
				{
					///The pressures are equal.  Do nothing for now but we may need to pass something back later
					//so keep the else for future possible changes.
				}

				TP.Fault = AircraftEnums.FaultStatus.Ok;
				return TP;
			}
		}

		private AircraftEnums.FaultStatus TestAirPressureSystem()
		{
			///perform air pressure system fault checking
			///right now we're just going to return OK
			AircraftEnums.FaultStatus Fault = AircraftEnums.FaultStatus.Ok;
			return Fault;
		}

		///For returning the fake tire test object
		private int GetTirePressure()
		{
			return _MyTire.TirePressure;
		}

		private int AddAir(in int RequiredPressure)
		{
			///Air is added with a function here.  Return final Pressure
			///For now assume this always succeeeds nad the final pressure is the passed pressure
			return RequiredPressure;
		}

		private int RemoveAir(in int RequiredPeessure)
		{

			//Air is removed with some function here.  Return final pressure
			//for now assume this always succeeds and the final pressure is the passed pressure
			return RequiredPeessure;
		}

		private void LogPressure(int PressureToLog)
		{
			///Log pressure
		}

	}



}
