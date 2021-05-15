using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private const short k_WheelNumber = 16;
        private const float k_WheelPressure = 26f;
        private const float k_MaxEngineCapacity = 120f;
        private bool m_IsTransportHazardousMaterials;
        private float m_MaxCarryingWeight;
        private GasEngine m_Engine;

        public Truck(string i_ModelName,
                     string i_LicenceNumber,
                     string i_WheelManufacturer)
            : base(i_ModelName,
                   i_LicenceNumber,
                   k_WheelNumber,
                   k_WheelPressure,
                   i_WheelManufacturer)
        {
            m_Engine = new GasEngine(GasEngine.eFuelTypes.Soler, k_MaxEngineCapacity);
        }

        public bool IsTransportHazardousMaterials
        {
            get { return m_IsTransportHazardousMaterials; }
            set { IsTransportHazardousMaterials = value; }
        }

        public GasEngine.eFuelTypes FuelType
        {
            get { return m_Engine.FuelType; }
        }

        public float MaxCarryingWeight
        {
            get { return m_MaxCarryingWeight; }
            set { m_MaxCarryingWeight = value; }
        }

        public float CurrentFuel
        {
            get { return m_Engine.CurrentCapacity; }
        }

        public float MaxFuel
        {
            get { return m_Engine.MaxCapacity; }
        }

        public override Engine Engine
        {
            get { return m_Engine; }
        }

        //        public override string GetParams()
        //        {
        //            StringBuilder paramStr = new StringBuilder();
        //            paramStr.AppendFormat(@"Transporting hazardous materials?
        //Y / N");
        //            paramStr.AppendFormat(@"Maximum carrying weight (integer):
        //");
        //            return paramStr.ToString();
        //        }

        public override object[] GetParams()
        {
            Type[] types = { m_IsTransportHazardousMaterials.GetType(), m_MaxCarryingWeight.GetType() };
            return types;
        }

        public override string ToString()
        {
            StringBuilder resString = new StringBuilder(base.ToString());
            resString.AppendFormat(@"No. of wheels - {0}
Transporting hazardous materials  - {1}
Maximum carrying weight - {2}
",
                      k_WheelNumber,
                      m_IsTransportHazardousMaterials ? "Yes" : "No",
                      m_MaxCarryingWeight);
            resString.Append(m_Engine.ToString());
            return resString.ToString();
        }
    }
}

