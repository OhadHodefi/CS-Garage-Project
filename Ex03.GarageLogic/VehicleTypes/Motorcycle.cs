using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        public enum eLicenseTypes { A = 1, B1, AA, BB }
        private const float k_MaxWheelPressure = 30f; // same wheel pressure for both types of motorcycles
        private const short k_WheelNumber = 2;
        
        private Engine m_Engine;
        private eLicenseTypes m_LicenseType;
        private int m_CubicCapacity;

        public Motorcycle(Engine i_Engine,
                          string i_ModelName,
                          string i_LicenceNumber,
                          Wheel i_Wheel)
            : base(i_ModelName,
                   i_LicenceNumber,
                   k_WheelNumber,
                   i_Wheel,
                   i_Engine)
        {   }

        public eLicenseTypes LicenseType
        {
            get { return m_LicenseType; }
            set { m_LicenseType = value; }
        }

        public int CubicCapacity
        {
            get { return m_CubicCapacity; }
            set { m_CubicCapacity = value; }
        }

        //        public override string GetParams()
        //        {
        //            StringBuilder paramStr = new StringBuilder();
        //            string[] licenses = Enum.GetNames(typeof(eLicenseTypes));
        //            paramStr.Append("License options: " + Environment.NewLine);
        //            int optionNumber = 1;
        //            foreach (string license in licenses)
        //            {
        //                paramStr.AppendFormat(@"{0} - {1}{2}", optionNumber, license, Environment.NewLine);
        //            }

        //            paramStr.AppendFormat(@"Cubic capacity (integer):
        //");
        //            return paramStr.ToString();
        //        }

        public override object[] GetParams()
        {
            Type[] types = { typeof(eLicenseTypes), m_CubicCapacity.GetType() };
            return types;
        }
        public override string ToString()
        {
            StringBuilder resString = new StringBuilder(base.ToString());
            resString.AppendFormat(@"No. of wheels - {0}
License type - {1}
Cubic capacity (CC) - {2}",
                      k_WheelNumber,
                      m_LicenseType,
                      m_LicenseType);
            return resString.ToString();
        }
    }
}
