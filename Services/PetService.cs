using System.Collections.Generic;
using System.Linq;
using Opdracht5Maart.Models;
using Opdracht5Maart.Db;

namespace Opdracht5Maart.Services
{
    public class PetService : IPetService
    {
        public Pet CreatePet(Pet pet)
        {
            using (var db = new PersonDbContext())
            {
                if (pet.PersonId == 0)
                {
                    return null;
                }
                db.Pets.Add(pet);
                db.SaveChanges();
                return pet;
            }
        }

        public Pet GetPet(int Id)
        {
            using (var db = new PersonDbContext())
            {
                var pet = db.Pets.FirstOrDefault(x => x.Id == Id);
                return pet;
            }
        }

        public List<Pet> GetPets()
        {
            using (var db = new PersonDbContext())
            {
                var listOfPets = db.Pets.ToList();
                return listOfPets;
            }
        }

        public Pet ChangeOwner(int currentOwnerId, Pet NewOwnerId)
        {
            using (var db = new PersonDbContext())
            {
                var petOwnerToChange = db.Pets.First(pet => pet.Id == currentOwnerId);
                petOwnerToChange.PersonId = NewOwnerId.PersonId;
                db.Pets.Update(petOwnerToChange);
                db.SaveChanges();
                return NewOwnerId;
            }
        }

        public List<Pet> GetPetByType(PetTypes Type)
        {
            using var db = new PersonDbContext();

            List<Pet> petsByType = db.Pets.Where(type => type.PetType == Type).ToList();
            return petsByType;

        }
    }
}
