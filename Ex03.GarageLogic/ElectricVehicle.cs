using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class ElectricVehicle:Vehicle
    {
        protected float m_TimeLeftbattery;
        protected float m_MaxTimebattery;

        public ElectricVehicle(float i_TimeLeftbattery, float i_MaxTimebattery, string i_ModelName, string i_LicenceNumber, float i_PercentageEnergyRemaining, int i_WheelsNumber)
        : base(i_ModelName, i_LicenceNumber, i_PercentageEnergyRemaining, i_WheelsNumber)
        {
            m_TimeLeftbattery = i_TimeLeftbattery;
            m_MaxTimebattery = i_MaxTimebattery;
        }
        public void CarCharging(float i_AddingHoursToBattery)
        {
            if (i_AddingHoursToBattery + m_MaxTimebattery > m_MaxTimebattery)
            {
                Exception ex = new Exception();
                throw new ValueOutOfRangeException(ex, m_MaxTimebattery);
            }
            m_TimeLeftbattery += i_AddingHoursToBattery;
        }


    }
}
