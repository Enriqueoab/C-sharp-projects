using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpToRent.Models
{
    public class Direction
    {
        public Direction()
        {
        }

        public Direction(int houseId, string street, string town, string city)
        {
            Id = houseId;
            Street = street;
            Town = town;
            City = city;
        }

        public int Id { get; set; }
        public String Street { get; set; }
        public String Town { get; set; }
        public String City { get; set; }

    }
}
