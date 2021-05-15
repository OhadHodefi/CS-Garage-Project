using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class Truck : Vehicle
    {
        private const short k_WheelNumber = 16;
        private const float k_WheelPressure = 26f;
        private const float k_MaxEngineCapacity = 120f;
        private bool m_IsTransportHazardousMaterials;
        private readonly float m_MaxCarryingWeight;
        private GasEngine m_Engine;

        public Truck(bool i_IsTransportHazardousMaterials,
                     float i_MaxCarryingWeight,
                     float i_CurrentAmountGas,
                     float i_MaxAmountGas,
                     string i_ModelName,
                     string i_LicenceNumber,
                     string i_WheelManufacturer)
            : base(i_ModelName,
                   i_LicenceNumber,
                   0,
                   k_WheelNumber,
                   k_WheelPressure,
                   i_WheelManufacturer)
        {
            m_IsTransportHazardousMaterials = i_IsTransportHazardousMaterials;
            m_MaxCarryingWeight = i_MaxAmountGas;
            m_Engine = new GasEngine(GasEngine.eFuelTypes.Soler, k_MaxEngineCapacity);
        }

        public bool IsTransportHazardousMaterials
        {
            get { return m_IsTransportHazardousMaterials; }
            set { IsTransportHazardousMaterials = value; }
        }

        public GasEngine.eFuelTypes FuelType
        {
            get { return m_Engine.FuelType; }
        }

        public float MaxCarryingWeight
        {
            get { return m_MaxCarryingWeight; }
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

