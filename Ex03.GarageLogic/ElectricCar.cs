using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ElectricCar : Car
    {
        private ElectricEngine m_Engine;

        public ElectricCar(ElectricEngine i_Engine, eColor i_Color, int i_DoorsNumber, float i_MaxTimebattery, string i_ModelName, string i_LicenceNumber)
            : base(i_Color, i_DoorsNumber, i_ModelName, i_LicenceNumber, 0)
        {
            m_Engine = i_Engine;
        }

        public float MinutesLeftInEngine
        {
            get { return m_Engine.MinutesLeft; }
        }

        public float HoursLeftInEngine
        {
            get { return m_Engine.HoursLeft; }
        }

        public void Charge(float i_TimeToCharge)
        {
            m_Engine.Charge(i_TimeToCharge);
            this.EnergyRemaining = (MinutesLeftInEngine / m_Engine.MaxCapacity) * 100;
        }
        

    }
}
