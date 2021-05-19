﻿using System;
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

        internal const float k_MotorcycleMaxBatteryCapacity = 108f; // 108 minutes -> 1.8 hours
        internal const float k_MotorcycleMaxEngineCapacity = 6f; // 6 litres
        internal const float k_CarMaxBatteryCapacity = 192f; // 192 minutes -> 3.2 hours
        internal const float k_CarMaxEngineCapacity = 45f; // 45 litres 
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
                                    new Wheel(i_WheelManufacturer, );
                        break;
                    }

                case eVehicleTypes.ElectricMotorcycle:
                    {
                        newVehicle = new Motorcycle(
                                    new ElectricEngine(k_MotorcycleMaxBatteryCapacity),
                                    i_ModelName,
                                    i_LicenseNumber,
                                    new Wheel(i_WheelManufacturer, );
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





    }
}
