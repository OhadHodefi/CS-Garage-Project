using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Motorcycle : Vehicle
    {
        public enum eLicenseTypes { A, B1, AA, BB }
        private const float k_MaxWheelPressure = 30f; // same wheel pressure for both types of motorcycles
        private const short k_WheelNumber = 2;
        private eLicenseTypes m_LicenseType;
        private readonly int m_CubicCapacity;

        public Motorcycle(eLicenseTypes i_LicenseType,
                          int i_CubicCapacity,
                          string i_ModelName,
                          string i_LicenceNumber,
                          float i_PercentageEnergyRemaining,
                          string i_WheelManufacturer)
            : base(i_ModelName,
                   i_LicenceNumber,
                   i_PercentageEnergyRemaining,
                   k_WheelNumber,
                   k_MaxWheelPressure,
                   i_WheelManufacturer)
        {
            m_LicenseType = i_LicenseType;
            m_CubicCapacity = i_CubicCapacity;
        }

        public eLicenseTypes LicenseType
        {
            get { return m_LicenseType; }
        }

        public int CubicCapacity
        {
            get { return m_CubicCapacity; }
        }
    }
}
