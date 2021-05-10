using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class GasMotorcycle : GasVehicle
    {
        public enum LicenseTypes { A, B1, AA, BB }
        
        private LicenseTypes m_LicenseType;
        private int m_EngineCapacity;

        public GasMotorcycle(LicenseTypes i_LicenseType, int i_EngineCapacity, eGasTypes i_GasType, float i_CurrentAmountGas, float i_MaxAmountGas, string i_ModelName, string i_LicenceNumber, int i_WheelsNumber)
            : base(i_GasType, i_CurrentAmountGas, i_MaxAmountGas, i_ModelName, i_LicenceNumber, i_WheelsNumber)
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
