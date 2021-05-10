using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    abstract class GasVehicle : Vehicle
    {
        public enum eGasTypes{ Soler, Octan95, Octan96, Octan98 }

        private readonly eGasTypes m_GasType;
        private float m_CurrentAmountGas;
        private readonly float m_MaxAmountGas;

        public GasVehicle(eGasTypes i_GasType, float i_CurrentAmountGas, float i_MaxAmountGas, string i_ModelName, string i_LicenceNumber, int i_WheelsNumber)
            :base(i_ModelName, i_LicenceNumber, (i_CurrentAmountGas / i_MaxAmountGas) * 100 ,i_WheelsNumber)
        {
            m_GasType = i_GasType;
            m_CurrentAmountGas = i_CurrentAmountGas;
            m_MaxAmountGas = i_MaxAmountGas;
        }
        
        protected eGasTypes GasType
        {
            get { return m_GasType; }
        }

        protected float CurrentAmountGas
        {
            get { return m_CurrentAmountGas; }
            set
            {
                if (value + m_CurrentAmountGas > m_MaxAmountGas)
                {
                    // throw self made exception
                }

                value = m_CurrentAmountGas + m_MaxAmountGas;
            }
        }
    }
}
