using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_ManufacturerName;
        private float m_CurrentAirPressure;
        private float m_MaxAirPressure;

        public Wheel(string i_ManufacturerName, float i_MaxPressure)
        {
            m_ManufacturerName = i_ManufacturerName;
            m_MaxAirPressure = i_MaxPressure;
            m_CurrentAirPressure = 0;
        }

        public string ManufacturerName
        {
            get { return m_ManufacturerName; }
        }

        public float CurrentPressure
        {
            get { return m_CurrentAirPressure; }
        }

        public float MaxPressure
        {
            get { return m_MaxAirPressure; }
        }

        public bool IsEmptyPressure
        {
            get { return m_CurrentAirPressure == 0; }
        }

        public void Inflate(float i_AirToAdd)
        {
            if (m_CurrentAirPressure + i_AirToAdd > m_MaxAirPressure || i_AirToAdd < 0)
            {
                throw new ValueOutOfRangeException(0, m_MaxAirPressure, "Wheel");
            }

            m_CurrentAirPressure += i_AirToAdd;
        }

        public void Inflate()
        {
            m_CurrentAirPressure = m_MaxAirPressure;
        }

        public Wheel DeepClone()
        {
            return new Wheel(this.ManufacturerName, this.MaxPressure);
        }
        public override string ToString()
        {
            return string.Format(@"Wheels Manufacturer - {0}
Wheels PSI - {1} out of {2}
",
                          m_ManufacturerName,
                          m_CurrentAirPressure,
                          m_MaxAirPressure);
        }
    }
}
