using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class GasMotorcycle : Motorcycle
    {
        private const float k_MaxEngineCapacity = 6f;
        private GasEngine m_Engine;

        public GasMotorcycle(string i_ModelName,
                             string i_LicenceNumber,
                             string i_WheelManufacturer)
        : base(i_ModelName,
               i_LicenceNumber,
               i_WheelManufacturer)
        {
            m_Engine = new GasEngine(GasEngine.eFuelTypes.Octan98, k_MaxEngineCapacity);
        }


        internal GasEngine.eFuelTypes FuelType
        {
            get { return m_Engine.FuelType; }
        }

        public float MaxFuel
        {
            get { return m_Engine.MaxCapacity; }
        }

        public float CurrentFuel
        {
            get { return m_Engine.CurrentCapacity; }
        }

        public override Engine Engine
        {
            get { return m_Engine; }
        }

        public override string ToString()
        {
            StringBuilder resString = new StringBuilder(base.ToString());
            resString.Append(m_Engine.ToString());
            return resString.ToString();
        }
    }
}
