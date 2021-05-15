using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Car : Vehicle
    {
        public enum eColors { Red = 1, Silver, White, Black }
        public enum eDoors { Two = 1, Three, Four, Five}
        private const short k_WheelNumber = 4;
        private eDoors m_DoorsNumber;
        private eColors m_Color;

        public Car(string i_ModelName,
                   string i_LicenceNumber,
                   float i_MaxWheelPressure,
                   string i_WheelManufacturer)
        : base(i_ModelName,
               i_LicenceNumber,
               k_WheelNumber,
               i_MaxWheelPressure,
               i_WheelManufacturer)
        {
        }

        public eColors Color
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
            set { m_DoorsNumber = value; }
        }

        public override object[] GetParams()
        {
            //StringBuilder paramStr = new StringBuilder();
            //string[] doors = Enum.GetNames(typeof(eDoors));
            //string[] colors = Enum.GetNames(typeof(eColors));
            //paramStr.Append("Door options: " + Environment.NewLine);
            //int optionNumber = 1;
            //foreach (string door in doors)
            //{
            //    paramStr.AppendFormat(@"{0} - {1}{2}", optionNumber, door, Environment.NewLine);
            //}

            //paramStr.Append("Color options: " + Environment.NewLine);
            //optionNumber = 1;
            //foreach (string color in colors)
            //{
            //    paramStr.AppendFormat(@"{0} - {1}{2}", optionNumber, color, Environment.NewLine);
            //}

            ////return paramStr.ToString();
            Type[] types = { typeof(eDoors), typeof(eColors) };
            return types;
        }

        public override string ToString()
        {
            StringBuilder resString = new StringBuilder(base.ToString());
            resString.AppendFormat(@"No. of wheels - {0}
Color - {1}
No. of doors - {2}
",
                      k_WheelNumber,
                      m_Color,
                      m_DoorsNumber);
            return resString.ToString();
        }
    }
}
