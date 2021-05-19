using System;
using System.Text;
using System.Threading;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public static class ConsoleUI
    {
        public static void Run()
        {
            bool quitGarage = false;
            Messages.eMenuQueries userChoice;
            Garage garage = new Garage();

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
                                ShowFullVehicleInfo(garage);
                                break;
                            }

                        default:
                            {
                                quitGarage = true;
                                Console.WriteLine("See you next time!");
                                Thread.Sleep(1500);
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
                    Thread.Sleep(3000);
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


        public static void GetPersonalInfo(out string io_Name, out string io_PhoneNumber)
        {
            Console.WriteLine("Please enter your name:");
            io_Name = Console.ReadLine();

            Console.WriteLine("Please enter your phone number:");
            io_PhoneNumber = Console.ReadLine();
            if(!int.TryParse(io_PhoneNumber, out int _))
            {
                throw new FormatException("Not a valid phone number");
            }
        }

        public static void GetWheelInfo(out string io_ManufacturerName, out float io_CurrentPSI)
        {
            Console.WriteLine("Please enter wheel's manufacturer name:");
            io_ManufacturerName = Console.ReadLine();

            Console.WriteLine("Please enter current wheel's PSI:");
            io_CurrentPSI = float.Parse(Console.ReadLine());
        }

        public static Vehicle GetVehicleInfo(
                                out string io_modelName,
                                out string io_licenseNumber,
                                out string io_WheelManufacturer,
                                out float io_WheelPSI,
                                out float io_EnergyAmount)
        {
            Console.WriteLine("Please enter model name:");
            io_modelName = Console.ReadLine();

            Console.WriteLine("Please enter license number:");
            io_licenseNumber = Console.ReadLine();
            GetWheelInfo(out io_WheelManufacturer, out io_WheelPSI);
            VehicleFactory.eVehicleTypes vehicleType = GetVehicleType();

            Vehicle vehicle = Garage.addVehicle(io_modelName, io_licenseNumber, wheel, engine, vehicleType);
            licenseNumber = Console.ReadLine();

            return new Vehicle(;
        }
        public static void AddVehicle()
        {
            string name, phoneNumber, modelName, licenseNumber;

            GetPersonalInfo(out name, out phoneNumber);
            GetVehicleInfo(out modelName, out licenseNumber);



            chooseVehiclesType();
        }


        public static VehicleFactory.eVehicleTypes GetVehicleType()
        {
            Console.WriteLine("Please choose the type of vehicle: ");
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

        public static void ShowFullVehicleInfo(Garage i_Garage)
        {
            Console.WriteLine("Please enter the vehicle's license number and then press 'enter': ");
            string licenseNumber = Console.ReadLine();
            Console.WriteLine(i_Garage.GetFullVehicleInfo(licenseNumber));
        }
    }
}
