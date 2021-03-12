using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Opdracht5Maart.Models;

namespace Opdracht5Maart.DTO
{
    public class GetPetDTO
    {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public PetTypes PetType{ get; set; }   
    }
}
