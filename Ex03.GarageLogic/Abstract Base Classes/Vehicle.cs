using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private string m_ModelName;
        private string m_LicenceNumber;
        private float m_PercentageEnergyRemaining = 0;
        private List<Wheel> m_Wheels;
        private Engine m_Engine;

        public Vehicle(string i_ModelName, string i_LicenceNumber, short i_WheelsNumber, Wheel i_Wheel, Engine i_Engine)
        {
            m_ModelName = i_ModelName;
            m_LicenceNumber = i_LicenceNumber;
            m_Wheels = new List<Wheel>(i_WheelsNumber);
            i_Engine = m_Engine;

            for (int i = 0; i < i_WheelsNumber; i++)
            {
                m_Wheels.Add(i_Wheel.DeepClone());
            }
        }

        public string Model
        {
            get { return m_ModelName; }
        }

        public string LicenseNumber
        {
            get { return m_ModelName; }
            set { m_LicenceNumber = value; }
        }

        public List<Wheel> Wheels
        {
            get { return m_Wheels; }
        }

        //public abstract Engine Engine
        //{
        //    get;
        //}

        public float EnergyRemaining
        {
            get { return m_PercentageEnergyRemaining; }
            set
            {
                if (value > 100 || value < 0)
                {
                    throw new ValueOutOfRangeException(0, 100, "Vehicle");
                }

                m_PercentageEnergyRemaining = value;
            }
        }


        public abstract object[] GetParams();

        public override string ToString()
        {
            StringBuilder resString = new StringBuilder(
                                      string.Format(@"License number - {0}
Model - {1}
",
                        m_LicenceNumber,
                        m_ModelName));
            resString.Append(m_Wheels[0].ToString());
            return resString.ToString();
        }
    }
}
