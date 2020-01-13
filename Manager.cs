using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt
{
	class Manager : Worker
	{
	
			public List<Client> DelClient(List<Client> list)
			{
				Console.WriteLine("Choose Client to delete. Give a PID");
				long pID;
				long.TryParse(Console.ReadLine(), out pID);
			for (int i = 0; i < list.Count; i++)
					{
						if (pID==list[i].PESEL)
						{
                    list.RemoveAt(i);
							Console.WriteLine("Client has been delete!");

							return list;
						}
						
					}
					return list;

			}
		public override void DisplayClient(List<Client> list)
			{
				foreach (Client client in list)
				{               
                TimeSpan remaningDays= client.CheckOutDate - client.CheckInDate;
                Console.WriteLine($"Name {client.Name} Surname {client.LastName}\n PID {client.PESEL}\n Number room {client.Room} \n Day of the end the stay {remaningDays.Days}");
                
            }
			}
			public override List<Client> EditClient(List<Client> list)
			{
            string data;
            DateTime date;
            DateTime date1;
            string y, m, d;
            Console.WriteLine("Give a PID");
				long pID;
				long.TryParse(Console.ReadLine(), out pID);
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i].PESEL == pID)
				{
                    string PIDvalid;

                    Console.WriteLine("Set new name");
					string newName = Console.ReadLine();
					Console.WriteLine("Set new last name");
					string newLastName = Console.ReadLine();
                    do
                    {
                        Console.WriteLine("Set new PESEL");
                         PIDvalid = Console.ReadLine();
                    }
                    while (Helper.IsValidPESEL(PIDvalid) == false);
                    long nPID;
					long.TryParse(PIDvalid, out nPID);
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
                        while (!DateTime.TryParse(data, out date));

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
                        while (!DateTime.TryParse(data, out date1));

                    }
                    while (date1 < date || date < DateTime.Today);
                    list[i] = new Client(newName, newLastName, nPID, date, date1, default);


				}
			}
				return list;
			}		
	}
	}
