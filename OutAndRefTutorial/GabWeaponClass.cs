using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace OutAndRefTutorial
{
    public class GabWeaponClass
    {
        List<ChamberInformation.ChamberInformationClass> _ChamberData;

        

        public List<ChamberInformation.ChamberInformationClass> ChamberData { get { return _ChamberData; } }

        public GabEnums.FlightStatus WeaponFlightStatus { get; set; }

        /// <summary>
        /// Fire weapon.  Chaneg flight status to InFlight and get the intital Telemerty
        /// </summary>
        public GabWeaponClass()
        {
            this.WeaponFlightStatus = GabEnums.FlightStatus.InFlight;
            _ChamberData = new List<ChamberInformation.ChamberInformationClass>();
            _ChamberData.Add(GenerateInitialTelemetry());
        }

        private ChamberInformation.ChamberInformationClass GenerateInitialTelemetry()

            ChamberInformation.ChamberInformationClass CIC = EngineTelemetry.GenerateInitialEngineTelemetry();



            return CIC;
        }

    }
}
