using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ElectricMotorcycle : Motorcycle
    {
        private const float k_MaxBatteryCapacity = 108f; // 108 minutes -> 1.8 hours
        private ElectricEngine m_Engine;

        public ElectricMotorcycle(eLicenseTypes i_LicenseType,
                                  int i_CubicCapacity,
                                  string i_ModelName,
                                  string i_LicenceNumber,
                                  float i_PercentageEnergyRemaining,
                                  string i_WheelManufacturer)
            : base(i_LicenseType,
                   i_CubicCapacity,
                   i_ModelName,
                   i_LicenceNumber,
                   i_PercentageEnergyRemaining,
                   i_WheelManufacturer)
        {
            m_Engine = new ElectricEngine(k_MaxBatteryCapacity, 0);
        }

        public float EngineCapacity
        {
            get { return m_Engine.MaxEngineHours; }
        }

        public float HoursLeftInEngine
        {
            get { return m_Engine.HoursLeft; }
        }

        public void Charge(float i_TimeToCharge)
        {
            m_Engine.Charge(i_TimeToCharge);
            this.EnergyRemaining = (m_Engine.CurrentCapacity / m_Engine.MaxCapacity) * 100;
        }
    }
}
