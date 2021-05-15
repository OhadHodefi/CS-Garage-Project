using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class Truck : Motorcycle
    {
        private bool m_IsTransportHazardousMaterials;
        private float m_MaxCarryingWeight;
        public Truck(bool i_IsTransportHazardousMaterials, float i_MaxCarryingWeight, eGasTypes i_GasType, float i_CurrentAmountGas, float i_MaxAmountGas, string i_ModelName, string i_LicenceNumber, int i_WheelsNumber)
            : base(i_GasType, i_CurrentAmountGas, i_MaxAmountGas, i_ModelName, i_LicenceNumber, i_WheelsNumber)
        {
            m_IsTransportHazardousMaterials = i_IsTransportHazardousMaterials;
            m_MaxCarryingWeight = i_MaxAmountGas;
        }

        public bool IsTransportHazardousMaterials
        {
            get { return m_IsTransportHazardousMaterials; }
            set { IsTransportHazardousMaterials = value; }
        }

        public float MaxCarryingWeight
        {
            get { return m_MaxCarryingWeight; }
        }
    }
}

