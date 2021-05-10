using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class ElectricMotorcycle : ElectricVehicle
    {

        public enum LicenseTypes { A, B1, AA, BB }

        private LicenseTypes m_LicenseType;
        private int m_EngineCapacity;

        public ElectricMotorcycle(LicenseTypes i_LicenseType, int i_EngineCapacity, float i_TimeLeftbattery, float i_MaxTimebattery, string i_ModelName, string i_LicenceNumber, float i_PercentageEnergyRemaining, int i_WheelsNumber)
            : base(i_TimeLeftbattery, i_MaxTimebattery, i_ModelName, i_LicenceNumber, i_PercentageEnergyRemaining, i_WheelsNumber)
        {
            m_LicenseType = i_LicenseType;
            m_EngineCapacity = i_EngineCapacity;
        }
        public LicenseTypes LicenseType
        {
            get { return m_LicenseType; }
        }

        public int EngineCapacity
        {
            get { return m_EngineCapacity; }
        }
    }
}
