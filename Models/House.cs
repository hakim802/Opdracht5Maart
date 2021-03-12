using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opdracht5Maart.Models
{
    public class House
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public int HouseNr { get; set; }
        public int Postal { get; set; }
        public string City { get; set; }
        public List<Person> People { get; set; }
    }
}
