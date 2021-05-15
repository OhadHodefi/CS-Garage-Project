using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class GasMotorcycle : Motorcycle
    {
        private const float k_MaxEngineCapacity = 6f;
        private GasEngine m_Engine;

        public GasMotorcycle(eLicenseTypes i_LicenseType,
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
            m_Engine = new GasEngine(GasEngine.eFuelTypes.Octan98, k_MaxEngineCapacity);
        }


        internal GasEngine.eFuelTypes FuelType
        {
            get { return m_Engine.FuelType; }
        }

        public float MaxFuel
        {
            get { return m_Engine.MaxCapacity; }
        }

        public float CurrentFuel
        {
            get { return m_Engine.CurrentCapacity; }
        }

        internal void Fuel(GasEngine.eFuelTypes i_FuelType, float i_ToFuel)
        {
            m_Engine.Fuel(i_FuelType, i_ToFuel);
        }
    }
}
