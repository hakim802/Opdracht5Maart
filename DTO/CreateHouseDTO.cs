using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opdracht5Maart.DTO
{
    public class CreateHouseDTO
    {
        public string Street { get; set; }
        public int HouseNr { get; set; }
        public int Postal { get; set; }
        public string City { get; set; }
    }
}
