using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpToRent.Models
{
    public class House

    {
        public int Id { get; set; }
        public String Url { get; set; }

        public Direction Directions { get => Directions; set => Directions = value; }



        public String Price { get; set; }
        public Bill Bill { get => Bill; set => Bill = value; }


        public String Availability { get; set; }
        public int ContractPeriod { get; set; }
        public String ContactName { get; set; }

        public House ()
	{

	}

        public House(int id, string url, Direction directions, string price, Bill bill, string availability, int contractPeriod, string contactName)
        {
            Id = id;
            Url = url;
            Directions = directions;
            Price = price;
            Bill = bill;
            Availability = availability;
            ContractPeriod = contractPeriod;
            ContactName = contactName;
        }
    }
}
