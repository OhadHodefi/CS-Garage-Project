using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class GasEngine : Engine
    {
        public enum eFuelTypes 
        { 
            Soler = 1,
            Octan95,
            Octan96,
            Octan98 
        }

        private readonly eFuelTypes r_FuelType;

        public GasEngine(eFuelTypes i_FuelType, float i_MaxCapacity)
            : base(i_MaxCapacity)
        {
            r_FuelType = i_FuelType;
        }

        internal eFuelTypes FuelType
        {
            get { return r_FuelType; }
        }

        public void Fuel(eFuelTypes i_FuelType, float i_ToFuel, Vehicle i_Vehicle)
        {
            if(i_FuelType != r_FuelType)
            {
                throw new ArgumentException(string.Format(@"Mismatch in fuel type. Type needed is {0}", r_FuelType));
            }    

            if(CurrentCapacity + i_ToFuel > MaxCapacity || i_ToFuel < 0)
            {
                throw new ValueOutOfRangeException(0, MaxCapacity - CurrentCapacity, "Gas Engine");
            }

            CurrentCapacity += i_ToFuel;
            i_Vehicle.EnergyRemaining = this.Percentage;
        }

        public override string ToString()
        {
            return string.Format(
                        @"Engine capacity - {0} litres
Current fuel - {1} litres ({2}%)
Fuel type - {3}
",
                        MaxCapacity,
                        CurrentCapacity,
                        Percentage,
                        FuelType);
        }
    }
}
