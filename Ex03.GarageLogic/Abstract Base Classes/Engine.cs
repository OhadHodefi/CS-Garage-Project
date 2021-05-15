namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        private readonly float r_MaxCapacity;
        private float m_CurrentCapacity;

        public Engine(float i_MaxCapacity)
        {
            r_MaxCapacity = i_MaxCapacity;
        }

        public float MaxCapacity
        {
            get { return r_MaxCapacity; }
        }

        public float CurrentCapacity
        {
            get { return m_CurrentCapacity; }
            set 
            {
                if (value > r_MaxCapacity || value < 0)
                {
                    throw new ValueOutOfRangeException(0, r_MaxCapacity);
                }

                m_CurrentCapacity = value;
            }
        }
    }
}
