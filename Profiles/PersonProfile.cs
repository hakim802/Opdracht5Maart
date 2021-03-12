using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Opdracht5Maart.DTO;
using Opdracht5Maart.Models;

namespace Opdracht5Maart.Profiles
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<CreatePersonDTO, Person>();//.ReverseMap(); // reversemap?
        }
        
    }
}
