using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Projekt
{
    public static class Helper
    {
        static List<Client> lista = new List<Client>();
        public static void Manager_Menu()
        {
            deserialize();
            Console.Clear();

            bool returntomenu = false;
            while (!returntomenu)
            {

                Manager manager = new Manager();
                DisplayMenuM();
                manager menu;

                bool correct = Enum.TryParse<manager>(Console.ReadLine(), out menu);
                if (!correct)
                {
                    Console.WriteLine("Incorrect data!");
                }



                switch (menu)
                {
                    case Projekt.manager.Add_Client:
                        manager.AddClient(lista);
                        Console.WriteLine("Client has been added! ");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case Projekt.manager.Edit_Client:
                        manager.EditClient(lista);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case Projekt.manager.Delete_Client:
                        manager.DelClient(lista);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case Projekt.manager.Display_Client_List:
                        Console.WriteLine("Choose sort metod \n 1 - Sort by Last Name \n 2 - Sort by PESEL");
                        int ans;
                        int.TryParse(Console.ReadLine(), out ans);
                        switch (ans)
                        {
                            case 1:
                                lista.Sort();
                                manager.DisplayClient(lista);
                                break;
                            case 2:
                                lista.Sort(new CompareToPesel());
                                manager.DisplayClient(lista);
                                break;
                            default:
                                break;
                        }

                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case Projekt.manager.Back_To_Login:
                        returntomenu = true;
                        serialize(lista);


                        break;

                    default:
                        Console.WriteLine("Invalid choose, try again !");
                        break;
                }
            }
        }
        public static void Worker_Menu()
        {

            deserialize();
            Console.Clear();
            bool returntomenu = false;
            while (!returntomenu)
            {
                Worker worker = new Worker();
                DisplayMenuw();
                worker menu;
                bool correct = Enum.TryParse<worker>(Console.ReadLine(), out menu);
                if (!correct)
                {
                    Console.WriteLine("Incorrect data!");
                }
                switch (menu)
                {
                    case Projekt.worker.Add_Client:
                        worker.AddClient(lista);
                        Console.WriteLine("Client has been added!"); ;
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case Projekt.worker.Edit_Client:
                        lista = worker.EditClient(lista);
                        Console.WriteLine("Client has been edit");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case
                        Projekt.worker.Display_Client_List:
                        Console.WriteLine("Choose sort metod \n 1 - Sort by Last Name \n 2 - Sort by PESEL");
                        int ans;
                        int.TryParse(Console.ReadLine(), out ans);
                        switch (ans)
                        {
                            case 1:
                                lista.Sort();
                                worker.DisplayClient(lista);
                                break;
                            case 2:
                                lista.Sort(new CompareToPesel());
                                worker.DisplayClient(lista);
                                break;
                            default:
                                break;
                        }
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case Projekt.worker.Back_To_Login:
                        returntomenu = true;
                        serialize(lista);

                        break;

                    default:
                        Console.WriteLine("Invalid choose. Please try again");
                        break;
                }
            }
        }
        public static bool IsValidPESEL(string input)
        {
            int[] weights = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };
            bool result = false;
            if (input.Length == 11)
            {
                int controlSum = CalculateControlSum(input, weights);
                int controlNum = controlSum % 10;
                controlNum = 10 - controlNum;
                if (controlNum == 10)
                {
                    controlNum = 0;
                }
                int lastDigit = int.Parse(input[input.Length - 1].ToString());
                result = controlNum == lastDigit;
            }
            return result;
        }

        private static int CalculateControlSum(string input, int[] weights, int offset = 0)
        {
            int controlSum = 0;
            for (int i = 0; i < input.Length - 1; i++)
            {
                controlSum += weights[i + offset] * int.Parse(input[i].ToString());
            }
            return controlSum;
        }
        public static bool time(string year, string mounth, string day)
        {
            bool yearbool, mounthbool, daybool;
            int yearint, mounthint, dayint;
            yearbool = int.TryParse(year, out yearint);
            mounthbool = int.TryParse(mounth, out mounthint);
            daybool = int.TryParse(day, out dayint);

            if (yearbool == true && mounthbool == true && daybool == true)
            {
                DateTime settime = new DateTime(yearint, mounthint, dayint);
                DateTime realtime = DateTime.Now;
                if (realtime > settime)
                {
                    return false;
                }
                return true;
            }
            return false;
        }

        static void serialize(List<Client> clients)
        {


            XmlSerializer serializer = new XmlSerializer(typeof(List<Client>));

            try
            {
                using (TextWriter writer = new StreamWriter(@"./clients.xml"))
                {
                    serializer.Serialize(writer, clients);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }
        static void deserialize()
        {


            XmlSerializer serializer = new XmlSerializer(typeof(List<Client>));

            lista = new List<Client>();

            try
            {
                using (TextReader reader = new StreamReader(@"./clients.xml"))
                {
                    var obj = serializer.Deserialize(reader);

                    lista = (List<Client>)obj;

                }

            }
            catch (Exception)
            {

            }


        }

        static void DisplayMenuM()
        {
            Console.Clear();
            Console.WriteLine("******* MENU *******");
            Console.WriteLine("[1] Add client");
            Console.WriteLine("[2] Edit client");
            Console.WriteLine("[3] Delete client");
            Console.WriteLine("[4] Display clients list");
            Console.WriteLine("[5] Back to Login");

        }
        static void DisplayMenuw()
        {

            Console.WriteLine("******* MENU  *******");
            Console.WriteLine("[1] Add client");
            Console.WriteLine("[2] Edit client");
            Console.WriteLine("[3] Display clients list");
            Console.WriteLine("[4] Back to Login");

        }


    }
}
