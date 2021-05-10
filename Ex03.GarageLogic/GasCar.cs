using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class GasCar : GasVehicle
    {
        public enum eColor { Red, Silver, White, Black }

        private eColor m_Color;
        private int m_DorsNumber;

        public GasCar(eColor i_Color, int i_DorsNumber, eGasTypes i_GasType, float i_CurrentAmountGas, float i_MaxAmountGas, string i_ModelName, string i_LicenceNumber, int i_WheelsNumber)
            : base(i_GasType, i_CurrentAmountGas, i_MaxAmountGas, i_ModelName, i_LicenceNumber, i_WheelsNumber)
        {
            m_Color = i_Color;
            m_DorsNumber = i_DorsNumber;
        }

        public eColor Color
        {
            get { return m_Color; }
            set
            {
                m_Color = value;
            }
        }

        public int DorsNum
        {
            get { return m_DorsNumber; }
        }
    }
}
