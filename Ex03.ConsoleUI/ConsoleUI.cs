using System;
using System.Text;
using System.Threading;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public static class ConsoleUI
    {
        static Garage garage = new Garage();

        public static void Run()
        {
            bool quitGarage = false;
            Messages.eMenuQueries userChoice;

            while (!quitGarage)
            {
                try
                {
                    Console.Clear();
                    ShowMenu();
                    int choice = int.Parse(Console.ReadLine());
                    userChoice = (Messages.eMenuQueries)choice;
                    Console.Clear();

                    switch (userChoice)
                    {
                        case Messages.eMenuQueries.AddVehicle:
                            {
                                AddVehicle();
                                break;
                            }

                        case Messages.eMenuQueries.ViewLicenseNumbers:
                            {
                                ShowLicenseNumber();
                                break;
                            }

                        case Messages.eMenuQueries.ChangeState:
                            {
                                break;
                            }

                        case Messages.eMenuQueries.InflateTires:
                            {
                                break;
                            }

                        case Messages.eMenuQueries.FuelVehicle:
                            {
                                break;
                            }

                        case Messages.eMenuQueries.ChargeVehicle:
                            {
                                break;
                            }

                        case Messages.eMenuQueries.ViewInfoByLicense:
                            {
                                ShowFullVehicleInfo();
                                break;
                            }

                        case Messages.eMenuQueries.Exit:
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
                    Console.WriteLine(@"{0}
{1}",
                            ex.Source,
                            ex.Message);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(@"{0}
{1}",
                            ex.ParamName,
                            ex.Message);
                }
                catch (ValueOutOfRangeException ex)
                {
                    Console.WriteLine(@"{0}
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
            for (int i = 0; i < Messages.k_MenuMessages.Length; ++i)
            {
                Console.WriteLine(Messages.k_MenuMessages[i], i);
            }
        }

        public static void ContinueIfKeyPressed()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        public static void AddVehicle()
        {
            string name, phoneNumber, modelName, licenseNumber, wheelManufacturer;
            float wheelPSI, energyAmount;

            GetVehicleInfo(out modelName, out licenseNumber, out wheelManufacturer, out wheelPSI, out energyAmount);
            GetPersonalInfo(out name, out phoneNumber);
            Console.Clear();
            VehicleFactory.eVehicleTypes vehicleType = GetVehicleType();

            Vehicle toAdd = VehicleFactory.MakeVehicle(vehicleType, licenseNumber, modelName, wheelManufacturer);
            string[] moreParams = toAdd.GetParams();
            StringBuilder answer = new StringBuilder();
            Console.Clear();
            Console.WriteLine("{0}Please choose the extra properties of the vehicle: ", Environment.NewLine);

            foreach (string param in moreParams)
            {
                Console.WriteLine(param);
                answer.AppendLine(Console.ReadLine());
                Console.WriteLine(answer.Length);
            }

            toAdd.InitParams(answer.ToString());
            garage.AddVehicle(toAdd, name, phoneNumber);
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
            Console.WriteLine("Please enter license number and then press 'enter':");
            io_licenseNumber = Console.ReadLine();
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

        }

        public static void ShowFullVehicleInfo()
        {
            Console.WriteLine("Please enter the vehicle's license number and then press 'enter': ");
            string licenseNumber = Console.ReadLine();
            Console.WriteLine(garage.GetFullVehicleInfo(licenseNumber));
        }
    }
}
