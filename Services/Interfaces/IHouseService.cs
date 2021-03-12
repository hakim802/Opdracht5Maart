using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Opdracht5Maart.Models;

namespace Opdracht5Maart.Services
{
    public interface IHouseService
    {
        House CreateHouse(House house);
        List<House> GetHouses();
        List<House> GetHousesByPostal(int Postal);
    }
}
