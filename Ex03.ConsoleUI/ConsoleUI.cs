using System;
using System.Text;

namespace Ex03.ConsoleUI
{
    public static class ConsoleUI
    {
        public static void Run()
        {
            bool quitGarage = false;
            Messages.eMenuQueries userChoice;

            while (!quitGarage)
            {
                ShowMenu();
                int choice = int.Parse(Console.ReadLine());
                userChoice = (Messages.eMenuQueries)choice;

                switch (userChoice)
                {
                    case Messages.eMenuQueries.AddVehicle:
                        {
                            AddVehicle();
                            break;
                        }

                    case Messages.eMenuQueries.ViewLicenseNumbers:
                        {
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

                            break;
                        }

                    default:
                        {
                            quitGarage = true;
                            Console.WriteLine("See you next time!");
                            break;
                        }
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
            int licenseNumber, gasAmount, wheelPSI;
            string name, phoneNumber;
            GetVehicleInfo(out licenseNumber, out gasAmount, out wheelPSI);
            GetPersonalInfo(out name, out phoneNumber);

            /* add vehicle to garage logic*/
        }

        public static void GetVehicleInfo(out int io_LicenseNumber, out int io_GasAmount, out int io_WheelPSI)
        {
            StringBuilder message = new StringBuilder(string.Format(
                                        string.Format(@"We require your {0}.
Please enter the {1}, {2} and {3}.",
                                        Messages.k_InputMessages[(int)Messages.eInputQueries.VehicleInfo],
                                        Messages.k_InputMessages[(int)Messages.eInputQueries.LicenseNumber],
                                        Messages.k_InputMessages[(int)Messages.eInputQueries.GasAmount],
                                        Messages.k_InputMessages[(int)Messages.eInputQueries.WheelPressure])));

            Console.WriteLine(message);
            message.Clear();
            message.AppendFormat(@"Enter the {0} and press 'enter': ", Messages.k_InputMessages[(int)Messages.eInputQueries.LicenseNumber]);
            Console.WriteLine(message);
            io_LicenseNumber = int.Parse(Console.ReadLine());

            message.Clear();
            message.AppendFormat(@"Enter the {0} and press 'enter': ", Messages.k_InputMessages[(int)Messages.eInputQueries.GasAmount]);
            Console.WriteLine(message);
            io_GasAmount = int.Parse(Console.ReadLine());

            message.Clear();
            message.AppendFormat(@"Enter the {0} and press 'enter': ", Messages.k_InputMessages[(int)Messages.eInputQueries.WheelPressure]);
            Console.WriteLine(message);
            io_WheelPSI = int.Parse(Console.ReadLine());
        }

        public static void GetPersonalInfo(out string io_Name, out string io_PhoneNumber)
        {
            StringBuilder message = new StringBuilder(string.Format(@"We also require your {0}.
Please enter your {1} and {2}:",
                                    Messages.k_InputMessages[(int)Messages.eInputQueries.PersonalInfo],
                                    Messages.k_InputMessages[(int)Messages.eInputQueries.Name],
                                    Messages.k_InputMessages[(int)Messages.eInputQueries.PhoneNumber]));
            Console.WriteLine(message);
            message.Clear();
            message.AppendFormat(@"Enter your {0} and press 'enter': ", Messages.k_InputMessages[(int)Messages.eInputQueries.Name]);
            Console.WriteLine(message);
            io_Name = Console.ReadLine();

            message.Clear();
            message.AppendFormat(@"Enter your {0} and press 'enter': ", Messages.k_InputMessages[(int)Messages.eInputQueries.PhoneNumber]);
            Console.WriteLine(message);
            io_PhoneNumber = Console.ReadLine();
        }

    }
}
