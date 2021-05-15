using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class GasMotorcycle : Motorcycle
    {
        private GasEngine m_Engine;

        public GasMotorcycle(GasEngine i_Engine, LicenseTypes i_LicenseType, int i_EngineCapacity, string i_ModelName, string i_LicenceNumber, float i_PercentageEnergyRemaining, int i_WheelsNumber)
        : base(i_LicenseType, i_EngineCapacity, i_ModelName, i_LicenceNumber, i_PercentageEnergyRemaining, i_WheelsNumber)
        {
            m_Engine = i_Engine;
        }


        internal GasEngine.eFuelTypes FuelType
        {
            get { return m_Engine.FuelType; }
        }

        internal void Fuel(GasEngine.eFuelTypes i_FuelType, float i_ToFuel)
        {
            m_Engine.Fuel(i_FuelType, i_ToFuel);
        }

        public float MaxCapacity
        {
            get { return m_Engine.MaxCapacity; }
        }

        public float CurrentCapacity
        {
            get { return m_Engine.CurrentCapacity; }
            set { m_Engine.CurrentCapacity = value; }
        }
    }
}
