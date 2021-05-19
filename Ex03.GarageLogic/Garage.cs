using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private Dictionary<string, VehicleInformation> m_GarageVehicles;

        public Garage()
        {
            m_GarageVehicles = new Dictionary<string, VehicleInformation>();
        }

        public bool AddVehicle(Vehicle i_Vehicle, string i_OwnerName, string i_OwnerPhone)
        {
            bool added = false;

            if (!m_GarageVehicles.ContainsKey(i_Vehicle.LicenseNumber))
            {
                added = true;
                m_GarageVehicles.Add(
                                i_Vehicle.LicenseNumber,
                                new VehicleInformation(i_Vehicle, i_OwnerName, i_OwnerPhone));
            }
            else
            {
                m_GarageVehicles[i_Vehicle.LicenseNumber].CurrentState = VehicleInformation.eVehicleState.Repairing;
            }

            return added;
        }

        public bool IsExists(string i_LicenseNumber)
        {
            return m_GarageVehicles.ContainsKey(i_LicenseNumber);
        }

        public string GetLicenseNumbers(VehicleInformation.eVehicleState? i_State)
        {
            StringBuilder licenses = new StringBuilder(string.Empty);
            int licenseCount = 1;

            foreach (KeyValuePair<string, VehicleInformation> vehicle in m_GarageVehicles)
            {
                // No filtering
                if (i_State == null)
                {
                    licenses.AppendFormat(
                            @"{0}. {1}{2}",
                            licenseCount++,
                            vehicle.Value.GetVehicle.LicenseNumber,
                            Environment.NewLine);
                }
                else if (vehicle.Value.CurrentState == i_State) 
                {
                    // Filter by received state
                    licenses.AppendFormat(
                            @"{0}. {1}{2}",
                            licenseCount++,
                            vehicle.Value.GetVehicle.LicenseNumber,
                            Environment.NewLine);
                }
            }

            if(string.IsNullOrEmpty(licenses.ToString()))
            {
                licenses.Append("No licenses to show.");
            }

            return licenses.ToString();
        }

        public void ChangeVehicleState(VehicleInformation.eVehicleState i_NewState, string i_LicenseNumber)
        {
            if (!m_GarageVehicles.ContainsKey(i_LicenseNumber))
            {
                throw new ArgumentException("No matching vehicle found in the garage");
            }

            m_GarageVehicles[i_LicenseNumber].CurrentState = i_NewState;
        }

        public void InflateWheels(string i_LicenseNumber)
        {
            if (!m_GarageVehicles.ContainsKey(i_LicenseNumber))
            {
                throw new ArgumentException("No matching vehicle found in the garage");
            }

            List<Wheel> wheels = m_GarageVehicles[i_LicenseNumber].GetVehicle.Wheels;
            foreach (Wheel wheel in wheels)
            {
                wheel.Inflate();
            }
        }

        public void InflateWheels(Vehicle i_Vehicle, float i_PSIToAdd)
        {
            List<Wheel> wheels = i_Vehicle.Wheels;
            foreach (Wheel wheel in wheels)
            {
                wheel.Inflate(i_PSIToAdd);
            }
        }

        public void AddCurrentWheelPSIAndEnergyAmount(Vehicle i_Vehicle, float i_WheelPSI, float i_EnergyAmount)
        {
            InflateWheels(i_Vehicle, i_WheelPSI);
            if(i_Vehicle.Engine is GasEngine)
            {
                (i_Vehicle.Engine as GasEngine).Fuel(
                                                (i_Vehicle.Engine as GasEngine).FuelType,
                                                i_EnergyAmount,
                                                i_Vehicle);
            }
            else
            {
                // Electric engine
                (i_Vehicle.Engine as ElectricEngine).Charge(i_EnergyAmount, i_Vehicle);
            }
        }

        public void FuelVehicle(float i_ToAdd, GasEngine.eFuelTypes i_FuelType, string i_LicenseNumber)
        {
            if(!m_GarageVehicles.ContainsKey(i_LicenseNumber))
            {
                throw new ArgumentException("No matching vehicle found in the garage");
            }

            Vehicle toFuel = m_GarageVehicles[i_LicenseNumber].GetVehicle;
            if(toFuel.Engine is GasEngine)
            {
                (toFuel.Engine as GasEngine).Fuel(i_FuelType, i_ToAdd, toFuel);
            }
            else
            {
                throw new ArgumentException("Vehicle requested is not fuel operated");
            }
        }

        public void ChargeVehicle(float i_ToAdd, string i_LicenseNumber)
        {
            if (!m_GarageVehicles.ContainsKey(i_LicenseNumber))
            {
                throw new ArgumentException("No matching vehicle found in the garage");
            }

            Vehicle toFuel = m_GarageVehicles[i_LicenseNumber].GetVehicle;
            if (toFuel.Engine is ElectricEngine)
            {
                (toFuel.Engine as ElectricEngine).Charge(i_ToAdd, toFuel);
            }
            else
            {
                throw new ArgumentException("Vehicle requested is not electrically operated");
            }
        }

        public string GetFullVehicleInfo(string i_LicenseNumber)
        {
            if (!m_GarageVehicles.ContainsKey(i_LicenseNumber))
            {
                throw new ArgumentException("No matching vehicle found in the garage");
            }

            VehicleInformation toShow = m_GarageVehicles[i_LicenseNumber];
            StringBuilder vehicleInfo = new StringBuilder();
            vehicleInfo.AppendFormat(
                        @"===========================
Information for {0}'s vehicle
===========================
Phone number - {1}
State - {2}{3}",
                        toShow.OwnerName,
                        toShow.OwnerPhone,
                        toShow.CurrentState,
                        Environment.NewLine);

            vehicleInfo.Append(toShow.GetVehicle.ToString());
            return vehicleInfo.ToString();
        }

        public class VehicleInformation
        {
            public enum eVehicleState
            {
                Repairing = 1,
                Repaired,
                Paid
            }

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
}
