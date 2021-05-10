using System;
using System.Text;

namespace Ex03.ConsoleUI
{
    static public class Messages
    {
        internal enum eMenuQueries
        {
            AddVehicle = 1,
            ViewLicenseNumbers,
            ChangeState,
            InflateTires,
            FuelVehicle,
            ChargeVehicle,
            ViewInfoByLicense,
            Exit
        }

        internal static readonly string[] k_MenuMessages =
        {
            @"===================
Garage Manager 2021
===================
",
            @"{0}. Add a new vehicle to the garage
",
            @"{0}. View license numbers of vehicles currently in the garge
",
            @"{0}. Change vehicle state
",
            @"{0}. Fully inflate vehicle tires
",
            @"{0}. Add fuel to a vehicle
",
            @"{0}. Charge a vehicle
",
            @"{0}. View information of a vehicle
",
            @"{0}. Exit
"
        };

        public static string GetMenuMessage(int i_MenuChoice)
        {
            return k_MenuMessages[i_MenuChoice];
        }

        internal enum eInputQueries
        {
            VehicleInfo,
            State,
            LicenseNumber,
            Energy,
            WheelPressure,
            PersonalInfo,
            Name,
            PhoneNumber,
            GasType,
            GasAmount,
            ChargeTime,
        }

        internal static readonly string[] k_InputMessages =
        {
            "vehicle details",
            "vehicle state",
            "vehicle's license number",
            "current amount of energy (gas/electricity left)",
            "current wheels pressure",
            "personal info",
            "name",
            "phone number",
            "type of gas",
            "amount to fill",
            "minutes to charge"
        };
    }
}
