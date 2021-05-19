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
        private bool m_IsTransportHazardousMaterials;
        private float m_MaxCarryingWeight;

        public Truck(Engine i_engine,
                     string i_ModelName,
                     string i_LicenceNumber,
                     Wheel i_Wheel)
            : base(i_ModelName,
                   i_LicenceNumber,
                   k_WheelNumber,
                   i_Wheel,
                   i_engine)
        {   }

        public bool IsTransportHazardousMaterials
        {
            get { return m_IsTransportHazardousMaterials; }
            set { IsTransportHazardousMaterials = value; }
        }

        public GasEngine.eFuelTypes FuelType
        {
            get { return (Engine as GasEngine).FuelType; }
        }

        public float MaxCarryingWeight
        {
            get { return m_MaxCarryingWeight; }
            set { m_MaxCarryingWeight = value; }
        }

        public override string[] GetParams()
        {
            StringBuilder truckParamsString = new StringBuilder();
            string[] truckParams = new string[2];
            truckParamsString.AppendFormat(@"Transporting hazardous materials? Y / N{0}", Environment.NewLine);
            truckParams[0] = truckParamsString.ToString();
            truckParamsString.Clear();
            truckParamsString.AppendFormat(@"Maximum carrying weight (real number): {0}", Environment.NewLine);
            truckParams[1] = truckParamsString.ToString();
            return truckParams;
        }

        public override void InitParams(string i_Params)
        {
            string[] givenParams = i_Params.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            string[] currentParams = GetParams();
            int index = 0;

            foreach (string param in givenParams)
            {
                if (currentParams[index].ToLower().Contains("hazard"))
                {
                    string currentParam = param.ToLower();
                    if(currentParam != "y" && currentParam != "n")
                    {
                        throw new FormatException("Invalid transport choice");
                    }

                    m_IsTransportHazardousMaterials = currentParam == "y" ? true : false;
                }
                else if (currentParams[index].ToLower().Contains("maximum"))
                {
                    if (!float.TryParse(param, out m_MaxCarryingWeight))
                    {
                        throw new FormatException("Invalid cubic capacity");
                    }
                }
                index++;
            }
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
            return resString.ToString();
        }
    }
}

