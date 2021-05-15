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
        public enum eDoors { Two = 2, Three, Four, Five}
        private const short k_WheelNumber = 4;
        private readonly eDoors m_DoorsNumber;
        private eColor m_Color;

        public Car(eColor i_Color,
                   eDoors i_DoorsNumber,
                   string i_ModelName,
                   string i_LicenceNumber,
                   float i_PercentageEnergyRemaining,
                   float i_MaxWheelPressure,
                   string i_WheelManufacturer)
        : base(i_ModelName,
               i_LicenceNumber,
               i_PercentageEnergyRemaining,
               k_WheelNumber,
               i_MaxWheelPressure,
               i_WheelManufacturer)
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

        public eDoors DoorsNumber
        {
            get { return m_DoorsNumber; }
        }
    }
}
