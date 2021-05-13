using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class GasEngine : Engine
    {
        public enum eFuelTypes { Soler, Octan95, Octan96, Octan98 };
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

        internal void Fuel(eFuelTypes i_FuelType, float i_ToFuel)
        {
            if(i_FuelType != r_FuelType)
            {
                throw new ArgumentException("Mismatch in fuel type");
            }    
            if(this.CurrentCapacity + i_ToFuel > this.MaxCapacity || i_ToFuel < 0)
            {
                throw new ValueOutOfRangeException(0, this.MaxCapacity);
            }

            this.CurrentCapacity += i_ToFuel;
        }
    }
}
