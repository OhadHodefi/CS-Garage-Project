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

        public static void AddVehicle()
        {
            string name, phoneNumber;

        }

        






























        public static void AddVehicle()
        {
            string name, phoneNumber, modelName, licenseNumber;

            GetPersonalInfo(out name, out phoneNumber);
            GetVehicleInfo(out modelName, out licenseNumber);



            Console.WriteLine("Please enter your model name of car:");
            phoneNumber = Console.ReadLine();

            Console.WriteLine("Please enter your model name of license number:");
            phoneNumber = Console.ReadLine();


            chooseVehiclesType();
        }




        public static void chooseVehiclesType()
        {
            Console.WriteLine(@"Please enter your vehicale type:");
            Console.WriteLine(Garage.getVehickesTyps());
            string vehicleType = Console.ReadLine();

        }

        public static void ShowInputMessage(StringBuilder i_Message, string i_FirstMessage, string i_SecondMessage)
        {
            i_Message.Clear();
            i_Message.AppendFormat(i_FirstMessage, i_SecondMessage);
            Console.WriteLine(i_Message);
        }

        public static void GetPersonalInfo(out string io_Name, out string io_PhoneNumber)
        {
            Console.WriteLine("Please enter your name:");
            io_Name = Console.ReadLine();

            Console.WriteLine("Please enter your phone number:");
            io_PhoneNumber = Console.ReadLine();
        }

        public static Vehicle GetVehicleInfo(out string io_modelName, out string io_licenseNumber)
        {
            Console.WriteLine("Please enter model name:");
            io_modelName = Console.ReadLine();

            Console.WriteLine("Please enter license number:");
            io_licenseNumber = Console.ReadLine();

            Wheel wheel = GetWheelInfo();

            Console.WriteLine("Please enter vehicle type:");
            Console.WriteLine(Garage.getVehickesTyps());
            string vehicleType = Console.ReadLine();


            Console.WriteLine("Please enter engine type:");
            Console.WriteLine(Garage.getOptionOfEngine(vehicleType));
            string engineType = Console.ReadLine();
            Engine engine = Garage.addEngine(engineType, vehicleType);

            Vehicle vehicle = Garage.addVehicle(io_modelName, io_licenseNumber, wheel, engine, vehicleType);


            licenseNumber = Console.ReadLine();



            return new Vehicle(;
            
        }

        public static Garage.getOptionOfEngine(vehicleType);

        public static Wheel GetWheelInfo()
        {
            string manufacturerName;
            Console.WriteLine("Please enter manufacturer name:");
            manufacturerName = Console.ReadLine();

            Console.WriteLine("Please enter current PSI:");
            float currentPSI = Convert.ToSingle(Console.ReadLine());

            Console.WriteLine("Please enter max PSI in wheel:");
            float maxPSI = Convert.ToSingle(Console.ReadLine());

            return new Wheel(manufacturerName, maxPSI);
        }




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

        public static VehicleFactory.eVehicleTypes GetVehicleType()
        {
            Console.WriteLine(Messages.k_InputMessages[(int)Messages.eInputQueries.VehicleType]);
            Console.WriteLine(VehicleFactory.chooseTypeOfVehicle());

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
