using System;
using System.Collections.Generic;
using System.Text;
using static OutAndRefTutorial.ChamberInformation;

namespace OutAndRefTutorial
{
    /// <summary>
    /// Fires a Gab weapon using a pass by reference structure
    /// </summary>
    public class GabWeaponStruct
    {


        ChamberInformationStruct[] _ChamberData = new ChamberInformationStruct[3600];

        public ChamberInformationStruct[] ChamberData { get { return _ChamberData; } }

        public ChamberInformationStruct LastChamberData { get { return _ChamberData[_ChamberData.Length - 1]; } }

    }
}
