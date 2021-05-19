using System;
using System.Text;
using System.Threading;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public static class ConsoleUI
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

        private static readonly string[] k_MenuMessages =
        {
            @"===================
Garage Manager 2021
===================
",
            @"{0}. Add a new vehicle to the garage
",
            @"{0}. View license numbers of vehicles currently in the garage
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

        private static Garage garage = new Garage();

        public static void Run()
        {
            bool quitGarage = false;
            eMenuQueries userChoice;

            while (!quitGarage)
            {
                try
                {
                    Console.Clear();
                    ShowMenu();
                    int choice = int.Parse(Console.ReadLine());
                    userChoice = (eMenuQueries)choice;
                    Console.Clear();

                    switch (userChoice)
                    {
                        case eMenuQueries.AddVehicle:
                            {
                                AddVehicle();
                                break;
                            }

                        case eMenuQueries.ViewLicenseNumbers:
                            {
                                ShowLicenseNumber();
                                break;
                            }

                        case eMenuQueries.ChangeState:
                            {
                                ChangeVehicleState();
                                break;
                            }

                        case eMenuQueries.InflateTires:
                            {
                                InflateTiresToMax();
                                break;
                            }

                        case eMenuQueries.FuelVehicle:
                            {
                                FuelVehicle();
                                break;
                            }

                        case eMenuQueries.ChargeVehicle:
                            {
                                ChargeVehicle();
                                break;
                            }

                        case eMenuQueries.ViewInfoByLicense:
                            {
                                ShowFullVehicleInfo();
                                break;
                            }

                        case eMenuQueries.Exit:
                            {
                                quitGarage = true;
                                Console.WriteLine("See you next time!");
                                Thread.Sleep(1500);
                                break;
                            }

                        default:
                            {
                                Console.WriteLine("Invalid menu choice.");
                                break;
                            }
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(
                            @"{0}
{1}",
                            ex.Source,
                            ex.Message);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(
                            @"{0}
{1}",
                            ex.ParamName,
                            ex.Message);
                }
                catch (ValueOutOfRangeException ex)
                {
                    Console.WriteLine(
                            @"{0}
{1}",
                            ex.Source,
                            ex.Message);
                }
                finally
                {
                    ContinueIfKeyPressed();
                }
            }
        }

        public static void ShowMenu()
        {
            for (int i = 0; i < k_MenuMessages.Length; ++i)
            {
                Console.WriteLine(k_MenuMessages[i], i);
            }
        }

        public static void ContinueIfKeyPressed()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
        
        public static string LicenseQuery()
        {
            Console.WriteLine("Please enter the vehicle's license number and then press 'enter': ");
            return Console.ReadLine();
        }

        public static Garage.VehicleInformation.eVehicleState GetVehicleState()
        {
            Garage.VehicleInformation.eVehicleState vehicleState;

            if (!Enum.TryParse(Console.ReadLine(), out vehicleState))
            {
                throw new FormatException("Invalid vehicle state");
            }

            if (!Enum.IsDefined(typeof(Garage.VehicleInformation.eVehicleState), vehicleState))
            {
                throw new FormatException("Invalid vehicle state");
            }

            return vehicleState;
        }

        public static void AddVehicle()
        {
            string name, phoneNumber, modelName, licenseNumber, wheelManufacturer;
            float wheelPSI, energyAmount;

            GetVehicleInfo(out modelName, out licenseNumber, out wheelManufacturer, out wheelPSI, out energyAmount);
            GetPersonalInfo(out name, out phoneNumber);
            Console.Clear();

            VehicleFactory.eVehicleTypes vehicleType = GetVehicleType();
            Vehicle vehicleToAdd = VehicleFactory.MakeVehicle(vehicleType, licenseNumber, modelName, wheelManufacturer);
            garage.AddCurrentWheelPSIAndEnergyAmount(vehicleToAdd, wheelPSI, energyAmount);

            string[] moreParams = vehicleToAdd.GetParams();
            StringBuilder answer = new StringBuilder();
            Console.Clear();
            Console.WriteLine("{0}Please choose the extra properties of the vehicle: ", Environment.NewLine);
            foreach (string param in moreParams)
            {
                Console.WriteLine(param);
                answer.AppendLine(Console.ReadLine());
            }

            vehicleToAdd.InitParams(answer.ToString());
            garage.AddVehicle(vehicleToAdd, name, phoneNumber);
            Console.Clear();
            Console.WriteLine("Thanks {0}, your vehicle with license no. {1} was added successfully.", name, licenseNumber);
        }

        public static void GetPersonalInfo(out string io_Name, out string io_PhoneNumber)
        {
            Console.WriteLine("{0}Please enter your name:", Environment.NewLine);
            io_Name = Console.ReadLine();

            Console.WriteLine("{0}Please enter your phone number:", Environment.NewLine);
            io_PhoneNumber = Console.ReadLine();
            if(!long.TryParse(io_PhoneNumber, out long _))
            {
                throw new FormatException("Not a valid phone number");
            }
        }

        public static void GetVehicleInfo(
                                out string io_modelName,
                                out string io_licenseNumber,
                                out string io_WheelManufacturer,
                                out float io_WheelPSI,
                                out float io_EnergyAmount)
        {
            io_licenseNumber = LicenseQuery();
            if(garage.IsExists(io_licenseNumber))
            {
                garage.ChangeVehicleState(Garage.VehicleInformation.eVehicleState.Repairing, io_licenseNumber);
                throw new ArgumentException("This vehicle already exists in the garage. Changed state to repairing");
            }

            Console.WriteLine("{0}Please enter model name and then press 'enter':", Environment.NewLine);
            io_modelName = Console.ReadLine();
            
            GetWheelInfo(out io_WheelManufacturer, out io_WheelPSI);
            Console.WriteLine("{0}Please enter energy(fuel / charge) left in the vehicle and then press 'enter':", Environment.NewLine);
            io_EnergyAmount = float.Parse(Console.ReadLine());
        }

        public static void GetWheelInfo(out string io_ManufacturerName, out float io_CurrentPSI)
        {
            Console.WriteLine("{0}Please enter wheel's manufacturer name and then press 'enter':", Environment.NewLine);
            io_ManufacturerName = Console.ReadLine();

            Console.WriteLine("{0}Please enter current wheel's PSI and then press 'enter':", Environment.NewLine);
            io_CurrentPSI = float.Parse(Console.ReadLine());
        }

        public static VehicleFactory.eVehicleTypes GetVehicleType()
        {
            Console.WriteLine("{0}Please choose the type of vehicle: ", Environment.NewLine);
            string[] vehicleTypes = VehicleFactory.VehicleTypes;
            StringBuilder message = new StringBuilder();
            int choiceCount = 1;
            foreach (string type in vehicleTypes)
            {
                message.AppendFormat(@"{0} - {1}{2}", choiceCount++, type, Environment.NewLine);
            }

            Console.WriteLine(message);
            VehicleFactory.eVehicleTypes choiceType;
            if (!Enum.TryParse(Console.ReadLine(), out choiceType))
            {
                throw new FormatException("Invalid vehicle choice");
            }

            return choiceType;
        }

        public static void ShowLicenseNumber()
        {
            Garage.VehicleInformation.eVehicleState? stateToFilter = null;
            Console.WriteLine("Do you want to filter by vehicle state? (Y / N)");
            string filterAnswer = Console.ReadLine().ToLower();
            if (filterAnswer == "y")
            {
                string[] vehicleStates = Enum.GetNames(typeof(Garage.VehicleInformation.eVehicleState));
                int choiceNumber = 1;
                StringBuilder message = new StringBuilder();

                Console.WriteLine("Please choose the state to filter by: ");
                foreach(string state in vehicleStates)
                {
                    message.AppendFormat(@"{0} - {1}{2}", choiceNumber++, state, Environment.NewLine);
                }

                Console.WriteLine(message);
                stateToFilter = GetVehicleState();
            }
            else if(filterAnswer != "n")
            {
                throw new FormatException("Invalid choice.");
            }

            Console.WriteLine(garage.GetLicenseNumbers(stateToFilter));
        }

        public static void ChangeVehicleState()
        {
            string licenseNumber = LicenseQuery();
            string[] vehicleStates = Enum.GetNames(typeof(Garage.VehicleInformation.eVehicleState));
            int choiceNumber = 1;
            if (garage.IsExists(licenseNumber))
            {
                Garage.VehicleInformation.eVehicleState vehicleState;
                StringBuilder message = new StringBuilder();

                Console.WriteLine("Please choose the new state: ");
                foreach (string state in vehicleStates)
                {
                    message.AppendFormat(@"{0} - {1}{2}", choiceNumber++, state, Environment.NewLine);
                }

                Console.WriteLine(message);
                vehicleState = GetVehicleState();
                garage.ChangeVehicleState(vehicleState, licenseNumber);
                Console.WriteLine("Vehicle with license no. '{0}' updated to {1}.", licenseNumber, vehicleState);
            }
            else
            {
                Console.WriteLine("No matching vehicle found in the garage.");
            }
        }

        public static void InflateTiresToMax()
        {
            string liceneNumber = LicenseQuery();
            garage.InflateWheels(liceneNumber);
            Console.WriteLine("Vehicle with license no. {0} tires inflated to max.", liceneNumber);
        }

        public static GasEngine.eFuelTypes GetFuelType()
        {
            GasEngine.eFuelTypes fuelType;
            if(!Enum.TryParse(Console.ReadLine(), out fuelType))
            {
                throw new FormatException("Invalid fuel type");
            }

            if(!Enum.IsDefined(typeof(GasEngine.eFuelTypes), fuelType))
            {
                throw new FormatException("Invalid fuel type");
            }

            return fuelType;
        }

        public static void FuelVehicle()
        {
            string liceneNumber = LicenseQuery();
            if(!garage.IsExists(liceneNumber))
            {
                Console.WriteLine("No matching vehicle found in the garage.");
            }
            else
            {
                string[] fuelTypes = Enum.GetNames(typeof(GasEngine.eFuelTypes));
                int choiceNumber = 1;
                StringBuilder message = new StringBuilder();
                GasEngine.eFuelTypes fuelType;
                Console.WriteLine("Please choose fuel type:");
                foreach (string type in fuelTypes)
                {
                    message.AppendFormat(@"{0} - {1}{2}", choiceNumber++, type, Environment.NewLine);
                }

                Console.WriteLine(message);
                fuelType = GetFuelType();
                Console.WriteLine("Enter amount of fuel to add and then press 'enter': ");
                float fuelToAdd = float.Parse(Console.ReadLine());
                garage.FuelVehicle(fuelToAdd, fuelType, liceneNumber);
                Console.WriteLine("Added {0} fuel to vehicle with license no. '{1}'.", fuelToAdd, liceneNumber);
            }
        }

        public static void ChargeVehicle()
        {
            string liceneNumber = LicenseQuery();
            if (!garage.IsExists(liceneNumber))
            {
                Console.WriteLine("No matching vehicle found in the garage.");
            }
            else
            {
                Console.WriteLine("Please enter the amount in minutes to charge and press 'enter': ");
                float minutesToAdd = float.Parse(Console.ReadLine());
                garage.ChargeVehicle(minutesToAdd, liceneNumber);
                Console.WriteLine("Added {0} minutes to vehicle with license no. '{1}'.", minutesToAdd, liceneNumber);
            }
        }

        public static void ShowFullVehicleInfo()
        {
            string licenseNumber = LicenseQuery();
            Console.WriteLine(garage.GetFullVehicleInfo(licenseNumber));
        }
    }
}
