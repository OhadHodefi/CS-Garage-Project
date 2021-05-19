using System;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        public enum eColors 
        { 
            Red = 1,
            Silver,
            White,
            Black 
        }

        public enum eDoors 
        { 
            Two = 1,
            Three,
            Four,
            Five
        }

        private const short k_WheelNumber = 4;

        private eDoors m_DoorsNumber;
        private eColors m_Color;

        public Car(
            Engine i_engine,
            string i_ModelName,
            string i_LicenceNumber,
            Wheel i_Wheel)
        : base(
            i_ModelName,
            i_LicenceNumber,
            k_WheelNumber,
            i_Wheel,
            i_engine)
        {   
        }

        public eColors Color
        {
            get { return m_Color; }
            set
            {
                m_Color = value;
            }
        }

        public eDoors DoorsNumber
        {
            get { return m_DoorsNumber; }
            set { m_DoorsNumber = value; }
        }

        public override string[] GetParams()
        {
            StringBuilder carParamsString = new StringBuilder();
            string[] carParams = new string[2];
            carParamsString.AppendFormat(@"Colors: {0}", Environment.NewLine);
            string[] options = Enum.GetNames(typeof(eColors));
            int choiceCount = 1;
            foreach(string color in options)
            {
                carParamsString.AppendFormat(@"{0} - {1}{2}", choiceCount++, color, Environment.NewLine);
            }

            carParams[0] = carParamsString.ToString();
            carParamsString.Clear();
            choiceCount = 1;
            carParamsString.AppendFormat(@"Doors: {0}", Environment.NewLine);
            options = Enum.GetNames(typeof(eDoors));
            foreach (string door in options)
            {
                carParamsString.AppendFormat(@"{0} - {1}{2}", choiceCount++, door, Environment.NewLine);
            }

            carParams[1] = carParamsString.ToString();
            return carParams;
        }

        public override void InitParams(string i_Params)
        {
            string[] givenParams = i_Params.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            string[] currentParams = GetParams();
            int index = 0;

            foreach(string param in givenParams)
            {
                if(currentParams[index].ToLower().Contains("colors"))
                {
                    if(!Enum.TryParse(param, out m_Color))
                    {
                        throw new FormatException("Invalid color option");
                    }
                }
                else if(currentParams[index].ToLower().Contains("doors"))
                {
                    if(!Enum.TryParse(param, out m_DoorsNumber))
                    {
                        throw new FormatException("Invalid door option");
                    }
                }

                index++;
            }
        }

        public override string ToString()
        {
            StringBuilder resString = new StringBuilder(base.ToString());
            resString.AppendFormat(
                    @"No. of wheels - {0}
Color - {1}
No. of doors - {2}
",
                      k_WheelNumber,
                      m_Color,
                      m_DoorsNumber);
            return resString.ToString();
        }
    }
}
