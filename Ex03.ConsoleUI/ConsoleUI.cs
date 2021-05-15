using System;
using System.Text;
using System.Threading;

namespace Ex03.ConsoleUI
{
    public static class ConsoleUI
    {
        public static void Run()
        {
            bool quitGarage = false;
            Messages.eMenuQueries userChoice;
            GarageLogic.Garage garage = new GarageLogic.Garage();

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
                catch (GarageLogic.ValueOutOfRangeException ex)
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

        public static void AddVehicle()
        {
            float energyAmount, wheelPSI;
            string name, phoneNumber, licenseNumber, wheelManufacturer, modelName;
            GetPersonalInfo(out name, out phoneNumber, out licenseNumber);
            GarageLogic.VehicleFactory.eVehicleTypes vehicleType = GetVehicleType();
            GetVehicleInfo(out energyAmount, out wheelPSI, out wheelManufacturer, out modelName);
            GarageLogic.Vehicle vehicle= GarageLogic.VehicleFactory.MakeVehicle(vehicleType, licenseNumber, modelName, wheelManufacturer);

        }

        public static void ShowInputMessage(StringBuilder i_Message, string i_FirstMessage, string i_SecondMessage)
        {
            i_Message.Clear();
            i_Message.AppendFormat(i_FirstMessage, i_SecondMessage);
            Console.WriteLine(i_Message);
        }


        public static void GetPersonalInfo(out string io_Name, out string io_PhoneNumber, out string io_LicenseNumber)
        {
            StringBuilder message = new StringBuilder(
                                        string.Format(@"We require your {0}.{1}",
                                        Messages.k_InputMessages[(int)Messages.eInputQueries.PersonalInfo],
                                        Environment.NewLine));
            Console.WriteLine(message);
            ShowInputMessage(message,
                            Messages.k_InputMessages[(int)Messages.eInputQueries.Request],
                            Messages.k_InputMessages[(int)Messages.eInputQueries.Name]);
            io_Name = Console.ReadLine();

            ShowInputMessage(message,
                            Messages.k_InputMessages[(int)Messages.eInputQueries.Request],
                            Messages.k_InputMessages[(int)Messages.eInputQueries.PhoneNumber]);
            io_PhoneNumber = Console.ReadLine();

            ShowInputMessage(message,
                            Messages.k_InputMessages[(int)Messages.eInputQueries.Request],
                            Messages.k_InputMessages[(int)Messages.eInputQueries.LicenseNumber]);
            io_LicenseNumber = Console.ReadLine();
        }

        public static void GetVehicleInfo(out float io_EnergyAmount, out float io_WheelPSI, out string io_WheelManufacturer, out string io_ModelName)
        {
            StringBuilder message = new StringBuilder(
                                        string.Format(@"We also require your {0}.{1}", 
                                        Messages.k_InputMessages[(int)Messages.eInputQueries.VehicleInfo],
                                        Environment.NewLine));

            Console.WriteLine(message);
            ShowInputMessage(message,
                            Messages.k_InputMessages[(int)Messages.eInputQueries.Request],
                            Messages.k_InputMessages[(int)Messages.eInputQueries.EnergyAmount]);
            io_EnergyAmount = float.Parse(Console.ReadLine());

            ShowInputMessage(message,
                            Messages.k_InputMessages[(int)Messages.eInputQueries.Request],
                            Messages.k_InputMessages[(int)Messages.eInputQueries.WheelPressure]);
            io_WheelPSI = float.Parse(Console.ReadLine());

            ShowInputMessage(message,
                            Messages.k_InputMessages[(int)Messages.eInputQueries.Request],
                            Messages.k_InputMessages[(int)Messages.eInputQueries.WheelManufacturer]);
            io_WheelManufacturer = Console.ReadLine();

            ShowInputMessage(message,
                            Messages.k_InputMessages[(int)Messages.eInputQueries.Request],
                            Messages.k_InputMessages[(int)Messages.eInputQueries.ModelName]);
            io_ModelName = Console.ReadLine();
        }

        public static GarageLogic.VehicleFactory.eVehicleTypes GetVehicleType()
        {
            Console.WriteLine(Messages.k_InputMessages[(int)Messages.eInputQueries.VehicleType]);
            string[] vehicleTypes = GarageLogic.VehicleFactory.VehicleTypes;
            StringBuilder message = new StringBuilder();
            int choiceCount = 1;
            GarageLogic.VehicleFactory.eVehicleTypes choiceType;

            foreach (string type in vehicleTypes)
            {
                message.AppendFormat(@"{0} - {1}{2}", choiceCount++, type, Environment.NewLine);
            }

            Console.WriteLine(message);
            if (!Enum.TryParse(Console.ReadLine(), out choiceType))
            {
                throw new FormatException("Invalid vehicle choice");
            }

            return choiceType;
        }

        public static void ShowLicenseNumber()
        {

        }

        



        public static void ShowFullVehicleInfo(GarageLogic.Garage i_Garage)
        {
            StringBuilder message = new StringBuilder();
            ShowInputMessage(
                    message, 
                    Messages.k_InputMessages[(int)Messages.eInputQueries.Request],
                    Messages.k_InputMessages[(int)Messages.eInputQueries.LicenseNumber]);

            string licenseNumber = Console.ReadLine();
            Console.WriteLine(i_Garage.GetFullVehicleInfo(licenseNumber));
        }
    }
}
