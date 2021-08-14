using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpToRent.Models
{
    public class Bill
    {
        public Bill()
        {}

        public Bill(int houseId, bool allBillsIncluded, string billComment)
        {
            this.AllBillsIncluded = allBillsIncluded;
            this.BillComment = billComment;
            this.Id = houseId;
        }

        public Bill(bool allBillsIncluded, int houseId)
        {
            this.AllBillsIncluded = allBillsIncluded;
            this.Id = houseId;
        }


        public Boolean AllBillsIncluded { get; set; }
        public String BillComment { get; set; }
        public int Id { get; set; }
    }
}
        