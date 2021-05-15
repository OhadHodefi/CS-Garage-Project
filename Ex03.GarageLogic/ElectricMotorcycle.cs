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

        public ElectricMotorcycle(string i_ModelName,
                                  string i_LicenceNumber,
                                  string i_WheelManufacturer)
            : base(i_ModelName,
                   i_LicenceNumber,
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
