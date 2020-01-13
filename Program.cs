using System;
using System.Collections.Generic;

namespace Projekt
{
	enum worker { Add_Client = 1, Edit_Client = 2, Display_Client_List = 3, Back_To_Login = 4}
	enum manager { Add_Client = 1, Edit_Client = 2, Delete_Client = 3, Display_Client_List = 4, Back_To_Login = 5}
	class Program
    {
        public static void Login()
        {
            bool exit = false;
            string login;

            while (!exit)
            {
                Console.WriteLine("Choose option \n 1 Login \n 2 exit");
                int option;
                int.TryParse(Console.ReadLine(), out option);
                switch (option)
                {
                    case 1:
                        Console.Write("Set login and password\n");
                        Console.Write("Login ");
                        login = Console.ReadLine();
                        Console.Write("Password ");
                        string pass = "";
                        do
                        {
                            ConsoleKeyInfo key = Console.ReadKey(true);
                            
                            if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                            {
                                pass += key.KeyChar;
                                Console.Write("*");
                            }
                            else
                            {                                                                          
                                if (key.Key == ConsoleKey.Backspace && pass.Length > 0)
                                {
                                    pass = pass.Substring(0, (pass.Length - 1));
                                    Console.Write("\b \b");
                                }
                                else if (key.Key == ConsoleKey.Enter)
                                {
                                    break;
                                }
                            }
                        } while (true);
                        if (login == "worker" && pass == "worker123")
                        {
                            Helper.Worker_Menu();
                        }
                        else if (login == "manager" && pass == "manager123")
                        {
                            {
                                Helper.Manager_Menu();


                            }
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid data!");


                        }
                        break;
                    case 2:
                        Console.WriteLine("If you want exit press 'Y'");
                        string odp = Console.ReadLine();
                        if (odp.ToUpper() == "Y")
                        {
                            exit = true;
                        }
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Inwalid option, try again");
                        break;

                }
            }

        }


        static void Main(string[] args)
        {
            Login();
        }
       
    }
}

