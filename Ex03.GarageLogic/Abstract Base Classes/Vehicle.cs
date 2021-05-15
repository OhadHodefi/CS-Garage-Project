using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private string m_ModelName;
        private string m_LicenceNumber;
        private float m_PercentageEnergyRemaining;
        private List<Wheel> m_Wheels;

        public Vehicle(string i_ModelName, string i_LicenceNumber, float i_PercentageEnergyRemaining, short i_WheelsNumber, float i_WheelsPressure, string i_WheelManufacturer)
        {
            m_ModelName = i_ModelName;
            m_LicenceNumber = i_LicenceNumber;
            m_PercentageEnergyRemaining = i_PercentageEnergyRemaining;
            m_Wheels = new List<Wheel>(i_WheelsNumber);
            for(int i = 0; i < m_Wheels.Count; i++)
            {
                m_Wheels[i] = new Wheel(i_WheelManufacturer, i_WheelsPressure);
            }
        }

        protected string Model
        {
            get { return m_ModelName; }
        }

        protected string LicenseNumber
        {
            get { return m_ModelName; }
            set { m_LicenceNumber = value; }
        }

        protected List<Wheel> Wheels
        {
            get { return m_Wheels; }
        }

        protected float EnergyRemaining
        {
            get { return m_PercentageEnergyRemaining; }
            set 
            {   
                if(value > 100 || value < 0)
                {
                    throw new ValueOutOfRangeException(0 ,100);
                }

                m_PercentageEnergyRemaining = value;
            }
        }
    }
}
