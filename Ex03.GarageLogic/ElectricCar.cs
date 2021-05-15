using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ElectricCar : Car
    {
        private const float k_MaxBatteryCapacity = 192f; // 192 minutes -> 3.2 hours
        private const float k_MaxWheelPressure = 32f;
        private ElectricEngine m_Engine;

        public ElectricCar(eColor i_Color,
                           eDoors i_DoorsNumber,
                           string i_ModelName,
                           string i_LicenceNumber,
                           string i_WheelManufacturer)
            : base(i_Color,
                   i_DoorsNumber,
                   i_ModelName,
                   i_LicenceNumber,
                   0,
                   k_MaxWheelPressure,
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
