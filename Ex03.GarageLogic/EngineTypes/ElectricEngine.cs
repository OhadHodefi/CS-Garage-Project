namespace Ex03.GarageLogic
{
    public class ElectricEngine: Engine
    {
        public ElectricEngine(float i_MaxCapacity) : base(i_MaxCapacity)
        { }

        internal void Charge(float i_MinutesToCharge, Vehicle i_Vehicle)
        {
            if(i_MinutesToCharge + CurrentCapacity > MaxCapacity || i_MinutesToCharge < 0)
            {
                throw new ValueOutOfRangeException(0, MaxCapacity - CurrentCapacity, "Electric Engine");
            }

            CurrentCapacity += i_MinutesToCharge;
            i_Vehicle.EnergyRemaining = this.Percentage;
        }

        internal float MaxEngineHours
        {
            get { return MaxCapacity / 60; }
        }

        internal float HoursLeft
        {
            get { return CurrentCapacity / 60; }
        }

        internal string TimeLeftString
        {
            get { return string.Format(@"{0}:{1}",
                                HoursLeft,
                                CurrentCapacity % 60); }
        }

        public override string ToString()
        {
            return string.Format(@"Engine capacity - {0} hours
Current charge - {1} hours ({2}%)
",
                      MaxCapacity,
                      CurrentCapacity,
                      Percentage);
        }
    }
}
