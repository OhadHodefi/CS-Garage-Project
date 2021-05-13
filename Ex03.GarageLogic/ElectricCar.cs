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

        public ElectricCar(eColor i_Color, int i_DoorsNumber, float i_MaxTimebattery, string i_ModelName, string i_LicenceNumber)
            : base(i_Color, i_DoorsNumber, i_ModelName, i_LicenceNumber, 0)
        {
            // We assume a new car won't have a charged battery
            m_Engine = new ElectricEngine(i_MaxTimebattery, 0);
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
