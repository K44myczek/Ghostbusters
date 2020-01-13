using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt
{
    class Worker : Client
    {

        Client client = new Client();


        public void AddClient(List<Client> list)
        {
            string data;
            string pesel;
            long psl;
            string y, m, d;
            Console.WriteLine("Set Name");
            _name = Console.ReadLine();
            Console.WriteLine("Set Lastname");    
            _lastName = Console.ReadLine();

            do
            {
                Console.WriteLine("Set PESEL");
                pesel = Console.ReadLine();
            }

            while (Helper.IsValidPESEL(pesel) == false);

            long.TryParse(pesel, out psl);
            do { Console.WriteLine("Set Room Number"); }
            while (!int.TryParse(Console.ReadLine(), out _room) || _room<1);
            do
            {
                do
                {
                    Console.WriteLine("Check IN");
                    Console.Write("Year ");
                    y = Console.ReadLine();
                    Console.Write("Mounth ");
                    m = Console.ReadLine();
                    Console.Write("Day ");
                    d = Console.ReadLine();
                    data = d + "/" + m + "/" + y;
                }
                while (!DateTime.TryParse(data, out _checkInDate));
                
                do
                {
                    Console.WriteLine("Check OUT");
                    Console.Write("Year ");
                    y = Console.ReadLine();
                    Console.Write("Mounth ");
                    m = Console.ReadLine();
                    Console.Write("Day ");
                    d = Console.ReadLine();
                    data = d + "/" + m + "/" + y;
                }
                while (!DateTime.TryParse(data, out _checkOutDate));
                
            }
            while (_checkOutDate < _checkInDate || _checkInDate < DateTime.Today);
            _pesel = psl;

            
            
            Client c = new Client(_name, _lastName,_pesel, _checkInDate, _checkOutDate, _room);
            list.Add(c);           
          



        }

        public virtual void DisplayClient(List<Client> list)
        {

            foreach (Client client in list)
            {
                TimeSpan remaningDays = client.CheckOutDate - client.CheckInDate;
                Console.WriteLine($"Name {client.Name} Surname {client.LastName}\n Number room {client.Room} \n Day of the end the stay {remaningDays.Days}");

            }
        }

        public virtual List<Client> EditClient(List<Client> lista)
        {
            Console.WriteLine("Choose Client to edit. Give a PID");
            long pID;
            long.TryParse(Console.ReadLine(), out pID);
            {
                for (int i = 0; i < lista.Count; i++)
                {


                    if (lista[i].PESEL == pID)
                    {

                        int room;
                        string imie, nazwisko;
                        Console.WriteLine("Set Name");
                        imie = Console.ReadLine();
                        Console.WriteLine("Set LastName");
                        nazwisko = Console.ReadLine();
                        do { Console.WriteLine("Set Room Number"); }
                        while (!int.TryParse(Console.ReadLine(), out room));
                        Client nowy = new Client(imie, nazwisko, lista[i].PESEL, lista[i].CheckInDate, lista[i].CheckOutDate,room);
                        lista[i] = nowy;
                        return lista;
                    }
                }
            }
            return lista;
        }

       
    }


}

