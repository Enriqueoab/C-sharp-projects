using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpToRent.Models
{
    public class House

    {
        public int Id { get; set; }
        public String Direction { get; set; }
        public float Price { get; set; }

        public Bill Bills { get => Bills; private set => Bills = value; }

        public float Deposit { get; set; }
        public int ContractPeriod { get; set; }
        public String ContactName { get; set; }

        public House ()
	{

	}

        public House(int id, string direction, float price, Bill bills, float deposit, int contractPeriod, string contactName)
        {
            Id = id;
            Direction = direction;
            Price = price;
            Bills = bills;
            Deposit = deposit;
            ContractPeriod = contractPeriod;
            ContactName = contactName;
        }
    }
}
