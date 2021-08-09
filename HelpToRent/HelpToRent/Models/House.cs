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
        public int Bills { get; set; }//Should be a class? are they in the rent or not, some of them?, gas, internet, electricity
        public float Deposit { get; set; }
        public int ContractPeriod { get; set; }
        public String ContactName { get; set; }
        public House ()
	{

	}

    }
}
