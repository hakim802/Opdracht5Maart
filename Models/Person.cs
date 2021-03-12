using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Opdracht5Maart.Models
{
    public class Person
    {
        public Person()
        {

        }
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Pet> Pets { get; set; }
        public int? HouseId { get; set; }
        public virtual House House { get; set; }
    }
}
