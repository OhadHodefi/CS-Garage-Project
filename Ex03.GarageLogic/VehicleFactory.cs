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

        // Motorcycle constant properties
        internal const float k_MotorcycleMaxWheelPressure = 30f; // same wheel pressure for both types of motorcycles
        internal const float k_MotorcycleMaxBatteryCapacity = 1.8f; // 1.8 hours
        internal const float k_MotorcycleMaxEngineCapacity = 6f; // 6 litres

        // Car constant properties
        internal const float k_ElectricCarMaxWheelPressure = 32f;
        internal const float k_CarMaxBatteryCapacity = 3.2f; // 3.2 hours
        internal const float k_GasCarMaxWheelPressure = 30f;
        internal const float k_CarMaxEngineCapacity = 45f; // 45 litres 

        // Truck constant properties
        internal const float k_TruckMaxWheelPressure = 26f;
        internal const float k_TruckMaxEngineCapacity = 120f; // 120 litres

        public static string[] VehicleTypes
        {
            get { return Enum.GetNames(typeof(eVehicleTypes)); }
        }

        public static Vehicle MakeVehicle(
                              eVehicleTypes i_VehicleType,  
                              string i_LicenseNumber,
                              string i_ModelName,
                              string i_WheelManufacturer)
        {
            Vehicle newVehicle = null;

            switch (i_VehicleType)
            {
                case eVehicleTypes.GasMotorcycle:
                    {
                        newVehicle = new Motorcycle(
                                     new GasEngine(GasEngine.eFuelTypes.Octan98, k_MotorcycleMaxEngineCapacity),
                                     i_ModelName,
                                     i_LicenseNumber,
                                     new Wheel(i_WheelManufacturer, k_MotorcycleMaxWheelPressure));
                        break;
                    }

                case eVehicleTypes.ElectricMotorcycle:
                    {
                        newVehicle = new Motorcycle(
                                     new ElectricEngine(k_MotorcycleMaxBatteryCapacity),
                                     i_ModelName,
                                     i_LicenseNumber,
                                     new Wheel(i_WheelManufacturer, k_MotorcycleMaxWheelPressure));
                        break;
                    }

                case eVehicleTypes.GasCar:
                    {
                        newVehicle = new Car(
                                     new GasEngine(GasEngine.eFuelTypes.Octan95, k_CarMaxEngineCapacity),
                                     i_ModelName,
                                     i_LicenseNumber,
                                     new Wheel(i_WheelManufacturer, k_GasCarMaxWheelPressure));
                        break;
                    }

                case eVehicleTypes.ElectricCar:
                    {
                        newVehicle = new Car(
                                     new ElectricEngine(k_CarMaxBatteryCapacity),
                                     i_ModelName,
                                     i_LicenseNumber,
                                     new Wheel(i_WheelManufacturer, k_ElectricCarMaxWheelPressure));
                        break;
                    }

                case eVehicleTypes.Truck:
                    {
                        newVehicle = new Truck(
                                     new GasEngine(GasEngine.eFuelTypes.Soler, k_TruckMaxEngineCapacity),
                                     i_ModelName,
                                     i_LicenseNumber,
                                     new Wheel(i_WheelManufacturer, k_TruckMaxWheelPressure));
                        break;
                    }

                default:
                    {
                        throw new ArgumentException("Invalid vehicle type");
                    }
            }

            return newVehicle;
        }
    }
}
