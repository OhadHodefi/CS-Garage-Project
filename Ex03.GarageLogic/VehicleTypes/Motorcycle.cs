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
        private const short k_WheelNumber = 2;
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

        public override string[] GetParams()
        {
            StringBuilder motorcycleParamsString = new StringBuilder();
            string[] motorcycleParams = new string[2];
            motorcycleParamsString.AppendFormat(@"License types: {0}", Environment.NewLine);
            string[] options = Enum.GetNames(typeof(eLicenseTypes));
            int choiceCount = 1;
            foreach (string license in options)
            {
                motorcycleParamsString.AppendFormat(@"{0} - {1}{2}", choiceCount++, license, Environment.NewLine);
            }

            motorcycleParams[0] = motorcycleParamsString.ToString();
            motorcycleParamsString.Clear();
            motorcycleParamsString.AppendFormat(@"Cubic capacity (integer): {0}", Environment.NewLine);
            motorcycleParams[1] = motorcycleParamsString.ToString();
            return motorcycleParams;
        }

        public override void InitParams(string i_Params)
        {
            string[] givenParams = i_Params.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            string[] currentParams = GetParams();
            int index = 0;

            foreach (string param in givenParams)
            {
                if (currentParams[index].ToLower().Contains("license"))
                {
                    if (!Enum.TryParse(param, out m_LicenseType))
                    {
                        throw new FormatException("Invalid license option");
                    }
                }
                else if (currentParams[index].ToLower().Contains("cubic"))
                {
                    if (!int.TryParse(param, out m_CubicCapacity))
                    {
                        throw new FormatException("Invalid cubic capacity");
                    }
                }
                index++;
            }
        }

        public override string ToString()
        {
            StringBuilder resString = new StringBuilder(base.ToString());
            resString.AppendFormat(@"No. of wheels - {0}
License type - {1}
Cubic capacity (CC) - {2}",
                      k_WheelNumber,
                      m_LicenseType,
                      m_CubicCapacity);
            return resString.ToString();
        }
    }
}
