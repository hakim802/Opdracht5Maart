using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Opdracht5Maart.Db;
using Opdracht5Maart.Models;

namespace Opdracht5Maart.Services
{
    public class HouseService : IHouseService
    {
        public House CreateHouse(House house)
        {
            using (var db = new PersonDbContext())
            {
                // Create
                db.Houses.Add(house);
                db.SaveChanges();
                return house;
            }
        }

        public List<House> GetHouses()
        {
            throw new NotImplementedException();
        }

        public List<House> GetHousesByPostal(int postal)
        {
            using var db = new PersonDbContext();
            List<House> listOpPostal = db.Houses.Where(x => x.Postal == postal).ToList();
            return listOpPostal;
        }

        //public List<Pet> GetMyPets(int personId)
        //{
        //    using var db = new PersonDbContext();
        //    //get person, join the pets
        //    Person personWithPets = db.Persons.Include(x => x.Pets).FirstOrDefault(x => x.Id == personId);
        //    return personWithPets.Pets;

        //    //haal alle pets met de juiste personId op
        //    List<Pet> listOpPets = db.Pets.Where(x => x.PersonId == personId).ToList();
        //    return listOpPets;
        //}
    }
}
