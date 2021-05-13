using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Car : Vehicle
    {
        public enum eColor { Red, Silver, White, Black }
        private eColor m_Color;
        private readonly int m_DoorsNumber;

        public Car(eColor i_Color, int i_DoorsNumber, string i_ModelName, string i_LicenceNumber, float i_PercentageEnergyRemaining)
        : base(i_ModelName, i_LicenceNumber, i_PercentageEnergyRemaining, 4)
        {
            /// we need to throw exception for the num of doors?
            m_Color = i_Color;
            m_DoorsNumber = i_DoorsNumber;
        }

        public eColor Color
        {
            get { return m_Color; }
            set
            {
                m_Color = value;
            }
        }

        public int DoorsNumber
        {
            get { return m_DoorsNumber; }
        }
    }
}
