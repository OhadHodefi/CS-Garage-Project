using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ElectricMotorcycle : Motorcycle
    {
        private ElectricEngine m_Engine;

        public ElectricMotorcycle(ElectricEngine i_Engine, LicenseTypes i_LicenseType, int i_EngineCapacity, string i_ModelName, string i_LicenceNumber, float i_PercentageEnergyRemaining, int i_WheelsNumber)
            : base(i_LicenseType, i_EngineCapacity, i_ModelName, i_LicenceNumber, i_PercentageEnergyRemaining, i_WheelsNumber)
        {
            m_Engine = i_Engine;
        }

        public float EngineCapacity
        {
            get { return m_Engine.MaxCapacity; }
        }
        public float CurrentCapacity
        {
            get { return m_Engine.CurrentCapacity; }
            set { m_Engine.CurrentCapacity = value; }
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
