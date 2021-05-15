using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class GasCar : Car
    {
        private GasEngine m_Engine;
        public GasCar(GasEngine i_Engine, eColor i_Color, GasEngine.eFuelTypes i_FuelType, int i_DoorsNumber, float i_FuelCapacity, string i_ModelName, string i_LicenceNumber)
            : base(i_Color, i_DoorsNumber, i_ModelName, i_LicenceNumber, 0)
        {
            m_Engine = i_Engine;
        }

        public GasEngine.eFuelTypes FuelType
        {
            get { return m_Engine.FuelType; }
        }

        public float CurrentFuel
        {
            get { return m_Engine.CurrentCapacity; }
        }

        public void Fuel(GasEngine.eFuelTypes i_FuelType, float i_ToFuel)
        {
            m_Engine.Fuel(i_FuelType, i_ToFuel);
            this.EnergyRemaining = (m_Engine.CurrentCapacity / m_Engine.MaxCapacity) * 100;
        }
    }
}
