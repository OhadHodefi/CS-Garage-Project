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
        public GasCar(eColor i_Color,
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
            m_Engine = new GasEngine(GasEngine.eFuelTypes.Octan95, k_MaxEngineCapacity);
        }

        public GasEngine.eFuelTypes FuelType
        {
            get { return m_Engine.FuelType; }
        }

        public float CurrentFuel
        {
            get { return m_Engine.CurrentCapacity; }
        }

        public float MaxFuel
        {
            get { return m_Engine.MaxCapacity; }
        }

        public void Fuel(GasEngine.eFuelTypes i_FuelType, float i_ToFuel)
        {
            m_Engine.Fuel(i_FuelType, i_ToFuel);
            this.EnergyRemaining = (m_Engine.CurrentCapacity / m_Engine.MaxCapacity) * 100;
        }
    }
}
