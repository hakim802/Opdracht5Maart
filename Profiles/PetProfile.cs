using System;
using Opdracht5Maart.DTO;
using Opdracht5Maart.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace Opdracht5Maart.Profiles
{
    public class PetProfile : Profile
    {
        public PetProfile()
        {
            CreateMap<Pet, GetPetDTO>().ReverseMap();
            CreateMap<Pet, CreatePetDTO>().ReverseMap();
        }
    }
}
