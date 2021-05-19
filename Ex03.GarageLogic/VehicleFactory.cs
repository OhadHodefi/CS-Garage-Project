using System;
using System.Text;

namespace Ex03.GarageLogic
{
    public static class VehicleFactory
    {
        public enum eVehicleTypes
        {
            GasMotorcycle = 1,
            ElectricMotorcycle,
            GasCar,
            ElectricCar,
            Truck
        }
        public enum eEngineTypes 
        { 
            FuelEngineType,
            ElectricEngineType
        }


        public static Vehicle MakeVehicle(eVehicleTypes i_VehicleType, eEngineTypes i_EngineType 
                              string i_LicenseNumber,
                              string i_ModelName,
                              string i_WheelManufacturer)
        {
            Vehicle newVehicle = null;

            switch (i_VehicleType)
            {
                case eVehicleTypes.Motorcycle:
                    {
                        switch(i_EngineType)
                        {
                            case eEngineTypes.FuelEngineType:
                                {
                                    newVehicle = new Motorcycle(new FuelEngine());
                                    break;
                                }

                            case eEngineTypes.ElectricEngineType:
                                {
                                    newVehicle = new Motorcycle(new ElectricEngine());
                                    break;
                                }
                        }
                    }
                //case eVehicleTypes.GasMotorcycle:
                //    {
                //        newVehicle = new GasMotorcycle(i_ModelName, i_LicenseNumber, i_WheelManufacturer);
                //        break;
                //    }

                case eVehicleTypes.ElectricMotorcycle:
                    {
                        newVehicle = new ElectricMotorcycle(i_ModelName, i_LicenseNumber, i_WheelManufacturer);
                        break;
                    }

                case eVehicleTypes.GasCar:
                    {
                        newVehicle = new GasCar(i_ModelName, i_LicenseNumber, i_WheelManufacturer);
                        break;
                    }

                case eVehicleTypes.ElectricCar:
                    {
                        newVehicle = new ElectricCar(i_ModelName, i_LicenseNumber, i_WheelManufacturer);
                        break;
                    }

                case eVehicleTypes.Truck:
                    {
                        newVehicle = new Truck(i_ModelName, i_LicenseNumber, i_WheelManufacturer);
                        break;
                    }

                default:
                    {
                        throw new ArgumentException("Invalid vehicle type");
                    }
            }

            return newVehicle;
        }

        public static string[] VehicleTypes
        {
            get { return Enum.GetNames(typeof(eVehicleTypes)); }
        }

        public static void SetCarParams(Car.eDoors i_DoorNumber, Car.eColors i_CarColor, Vehicle i_Vehicle)
        {
            Car toSet = i_Vehicle as Car;

            if(toSet == null)
            {
                throw new ArgumentException("Invalid vehicle type");
            }

            toSet.DoorsNumber = i_DoorNumber;
            toSet.Color = i_CarColor;
        }

        public static void SetMotorcycleParams(int i_CubicCapacity, Motorcycle.eLicenseTypes i_License, Vehicle i_Vehicle)
        {
            Motorcycle toSet = i_Vehicle as Motorcycle;

            if (toSet == null)
            {
                throw new ArgumentException("Invalid vehicle type");
            }

            if(i_CubicCapacity <= 0)
            {
                throw new ValueOutOfRangeException(1, 3000, "Vehicle Factory - Motorcycle");
            }

            toSet.CubicCapacity = i_CubicCapacity;
            toSet.LicenseType = i_License;
        }

        public static void SetTruckParams(bool i_IsHazardous, float i_MaxCarryingWeight, Vehicle i_Vehicle)
        {
            Truck toSet = i_Vehicle as Truck;

            if (toSet == null)
            {
                throw new ArgumentException("Invalid vehicle type");
            }

            if(i_MaxCarryingWeight < 0)
            {
                throw new ValueOutOfRangeException(0, float.MaxValue, "Vehicle Factory - Truck");
            }

            toSet.IsTransportHazardousMaterials = i_IsHazardous;
            toSet.MaxCarryingWeight = i_MaxCarryingWeight;
        }

        public static StringBuilder chooseTypeOfVehicle()
        {
            string[] vehicleTypes = VehicleTypes;
            StringBuilder message = new StringBuilder();
            int choiceCount = 1;

            foreach (string type in vehicleTypes)
            {
                message.AppendFormat(@"{0} - {1}{2}", choiceCount++, type, Environment.NewLine);
            }
            return message;
        }



    }
}
