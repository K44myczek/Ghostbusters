using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Projekt
{
	[Serializable]
	[XmlRoot("Client")]
	public class Client :IComparable<Client>

	{
		public Client()
		{

		}
		public Client(string name, string lastName, long pesel, DateTime checkInDate, DateTime checkOutDate, int room)
		{
			_name = name;
			_lastName = lastName;
			_pesel = pesel;
			_checkInDate = checkInDate;
			_checkOutDate = checkOutDate;
			_room = room;
		}
		protected string _name;
		protected string _lastName;
		protected long _pesel;
		protected int _room;
		protected DateTime _checkInDate;
		protected DateTime _checkOutDate;

		
		[XmlElement("Room Number")]
		public int Room { get => _room; set => _room = value; }

		[XmlElement("Check in Date")]
		public DateTime CheckInDate { get => _checkInDate; set => _checkInDate = value; }
		[XmlElement("Check out Date")]
		public DateTime CheckOutDate { get => _checkOutDate; set => _checkOutDate = value; }
		[XmlAttribute("Name")]
		public string Name { get => _name; set => _name = value; }
		[XmlAttribute("Last Name")]
		public string LastName { get => _lastName; set => _lastName = value; }
		[XmlAttribute("PESEL")]
		public long PESEL { get => _pesel; set => _pesel = value; }

		public int CompareTo(Client other)
		{
			int result = LastName.CompareTo(other.LastName);
			if (result == 0)
				result = Name.CompareTo(other.Name);

			return result;
		}
		
			
		
	}	
	
	public class CompareToPesel : IComparer<Client>
	{
		public int Compare(Client x, Client y)
		{
			if (x == null || y == null) return -1;
			return x.PESEL.CompareTo(y.PESEL);
		}

		
	}
}


