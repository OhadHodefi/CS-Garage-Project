namespace Ex03.GarageLogic
{
    public class ElectricEngine: Engine
    {
        public ElectricEngine(float i_MaxCapacity, float i_CurrentCapacity) : base(i_MaxCapacity)
        { }

        internal void Charge(float i_MinutesToCharge)
        {
            if(i_MinutesToCharge + this.CurrentCapacity > this.MaxCapacity || i_MinutesToCharge < 0)
            {
                throw new ValueOutOfRangeException(0, base.MaxCapacity);
            }

            this.CurrentCapacity += i_MinutesToCharge;
        }

        internal float MaxEngineHours
        {
            get { return this.MaxCapacity / 60; }
        }

        internal float HoursLeft
        {
            get { return this.CurrentCapacity / 60; }
        }

        internal string TimeLeftString
        {
            get { return string.Format(@"{0}:{1}",
                                this.HoursLeft,
                                this.CurrentCapacity % 60); }
        }
    }
}
