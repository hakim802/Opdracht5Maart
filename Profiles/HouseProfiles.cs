using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Opdracht5Maart.DTO;
using Opdracht5Maart.Models;
using AutoMapper;

namespace Opdracht5Maart.Profiles
{
    public class HouseProfiles : Profile
    {
        public HouseProfiles()
        {
            CreateMap<House, CreateHouseDTO>().ReverseMap();
        } 
    }
}
