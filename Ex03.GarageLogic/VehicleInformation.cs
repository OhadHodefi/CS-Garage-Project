namespace Ex03.GarageLogic
{
    public class VehicleInformation
    {
        public enum eVehicleState { Repairing, Repaired, Paid}
        private Vehicle m_Vehicle;
        private string m_OwnerName;
        private string m_OwnerPhone;
        private eVehicleState m_CurrentState;

        public VehicleInformation(Vehicle i_Vehicle, string i_OwnerName, string i_OwnerPhone)
        {
            m_Vehicle = i_Vehicle;
            m_OwnerName = i_OwnerName;
            m_OwnerPhone = i_OwnerPhone;
            m_CurrentState = eVehicleState.Repairing;
        }

        public eVehicleState CurrentState
        {
            get { return m_CurrentState; }
            set { m_CurrentState = value; }
        }

        public Vehicle GetVehicle
        {
            get { return m_Vehicle; }
        }

        public string OwnerName
        {
            get { return m_OwnerName; }
            set { m_OwnerName = value; }
        }

        public string OwnerPhone
        {
            get { return m_OwnerPhone; }
            set { m_OwnerPhone = value; }
        }
    }
}
