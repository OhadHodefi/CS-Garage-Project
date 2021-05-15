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

        public ElectricCar(string i_ModelName,
                           string i_LicenceNumber,
                           string i_WheelManufacturer)
            : base(i_ModelName,
                   i_LicenceNumber,
                   k_MaxWheelPressure,
                   i_WheelManufacturer)
        {
            m_Engine = new ElectricEngine(k_MaxBatteryCapacity);
        }

        public float EngineCapacity
        {
            get { return m_Engine.MaxEngineHours; }
        }

        public float HoursLeftInEngine
        {
            get { return m_Engine.HoursLeft; }
        }

        public override Engine Engine
        {
            get { return m_Engine; }
        }

        public override string ToString()
        {
            StringBuilder resString = new StringBuilder(base.ToString());
            resString.Append(m_Engine.ToString());
            return resString.ToString();
        }
    }
}
