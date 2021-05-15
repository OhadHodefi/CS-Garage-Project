using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class GasCar : Car
    {
        private const float k_MaxEngineCapacity = 45f; // 45 litres 
        private const float k_MaxWheelPressure = 30f;
        private GasEngine m_Engine;

        public GasCar(string i_ModelName,
                      string i_LicenceNumber,
                      string i_WheelManufacturer)
            : base(i_ModelName,
                   i_LicenceNumber,
                   k_MaxWheelPressure,
                   i_WheelManufacturer)
        {
            m_Engine = new GasEngine(GasEngine.eFuelTypes.Octan95, k_MaxEngineCapacity);
        }

        public GasEngine.eFuelTypes FuelType
        {
            get { return m_Engine.FuelType; }
        }

        public override Engine Engine
        {
            get { return m_Engine; }
        }

        public float CurrentFuel
        {
            get { return m_Engine.CurrentCapacity; }
        }

        public float MaxFuel
        {
            get { return m_Engine.MaxCapacity; }
        }

        public override string ToString()
        {
            StringBuilder resString = new StringBuilder(base.ToString());
            resString.Append(m_Engine.ToString());
            return resString.ToString();
        }
    }
}
