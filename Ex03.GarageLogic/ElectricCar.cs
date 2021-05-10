using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class ElectricCar:ElectricVehicle
    {
        public enum eColor { Red, Silver, White, Black }

        private eColor m_Color;
        private int m_DorsNumber;

        public ElectricCar(eColor i_Color, int i_DorsNumber, float i_TimeLeftbattery, float i_MaxTimebattery, string i_ModelName, string i_LicenceNumber, float i_PercentageEnergyRemaining, int i_WheelsNumber)
            : base(i_TimeLeftbattery, i_MaxTimebattery, i_ModelName, i_LicenceNumber, i_PercentageEnergyRemaining, i_WheelsNumber)
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
