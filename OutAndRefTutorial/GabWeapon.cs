using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace OutAndRefTutorial
{
    public class GabWeapon
    {
        List<FakeFlightControl.ChamberInformationClass> _ChamberData;

        

        public List<FakeFlightControl.ChamberInformationClass> ChamberData { get { return _ChamberData; } }

        public GabEnums.FlightStatus WeaponFlightStatus { get; set; }

        /// <summary>
        /// Fire weapon.  Chaneg flight status to InFlight and get the intital Telemerty
        /// </summary>
        public GabWeapon()
        {
            this.WeaponFlightStatus = GabEnums.FlightStatus.InFlight;
            _ChamberData = new List<FakeFlightControl.ChamberInformationClass>();
            _ChamberData.Add(GenerateInitialTelemetry());
        }

        private FakeFlightControl.ChamberInformationClass GenerateInitialTelemetry()
        {
            FakeFlightControl ffc = new FakeFlightControl();
            (Point Location, int Psi, int Altitude) = ffc.GenerateInitialFakeFlightData();
            FakeFlightControl.ChamberInformationClass CIC = new FakeFlightControl.ChamberInformationClass();
            CIC.Altitude = Altitude;
            CIC.PsiAtReading = Psi;
            CIC.Location = Location;


            return CIC;
        }

    }
}
