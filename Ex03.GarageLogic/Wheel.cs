﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class Wheel
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

        public float Pressure
        {
            get { return m_CurrentAirPressure; }
        }

        public bool IsEmptyPressure
        {
            get { return m_CurrentAirPressure == 0; }
        }

        public void Inflate(float i_AirToAdd)
        {
            if (m_CurrentAirPressure + i_AirToAdd > m_MaxAirPressure)
            {
                // throw self made exception
            }

            m_CurrentAirPressure += i_AirToAdd;
        }
    }
}
