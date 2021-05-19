namespace Ex03.GarageLogic
{
    public class ElectricEngine : Engine
    {
        public ElectricEngine(float i_MaxCapacity) : base(i_MaxCapacity) 
        { 
        }

        internal void Charge(float i_MinutesToCharge, Vehicle i_Vehicle)
        {
            float hoursToCharge = i_MinutesToCharge / 60;
            if (hoursToCharge + CurrentCapacity > MaxCapacity || i_MinutesToCharge < 0)
            {
                throw new ValueOutOfRangeException(0, MaxCapacity - CurrentCapacity, "Electric Engine");
            }

            CurrentCapacity += hoursToCharge;
            i_Vehicle.EnergyRemaining = this.Percentage;
        }

        internal float MaxEngineHours
        {
            get { return MaxCapacity; }
        }

        internal float HoursLeft
        {
            get { return CurrentCapacity; }
        }

        public override string ToString()
        {
            return string.Format(
                          @"Engine capacity - {0} hours
Current charge - {1} hours ({2}%)
",
                          MaxCapacity,
                          CurrentCapacity,
                          Percentage);
        }
    }
}
