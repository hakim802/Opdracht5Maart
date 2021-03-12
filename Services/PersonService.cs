using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Opdracht5Maart.DTO;
using Opdracht5Maart.Models;
using Opdracht5Maart.Db;
using Microsoft.EntityFrameworkCore;

namespace Opdracht5Maart.Services
{
    public class PersonService : IPersonService
    {
        public void CreatePerson(Person person)
        {
            using (var db = new PersonDbContext())
            {
                db.Persons.Add(person);
                db.SaveChanges();
            }
        }

        public bool Login(string email, string password)
        {
            using var db = new PersonDbContext();
            var personByEmail = db.Persons.FirstOrDefault(person => person.Email == email);
            if (personByEmail == null)
            {
                return false;
            }
            if (personByEmail.Password == password)
            {
                return true;
            }
            return false;
        }

        public void ChangePassword(string email, string currentPAssword, string newPassword)
        {
            using var db = new PersonDbContext();
            var currentUserByEmailAndPw = db.Persons.FirstOrDefault(x => x.Email == email && x.Password == newPassword);
            if (currentUserByEmailAndPw != null)
            {
                currentUserByEmailAndPw.Password = newPassword;
                db.Persons.Update(currentUserByEmailAndPw);
                db.SaveChanges();
            }
            else
            {
                throw new UnauthorizedAccessException("Invalid email and/or currentpassword!");
            }
        }

        public void DeletePerson(int id, string email, string currentPassword)
        {
            using var db = new PersonDbContext();
            var currentUserByEmailAndPwAndId = db.Persons
                .FirstOrDefault(x => x.Email == email && x.Password == currentPassword && x.Id == id);
            if (currentUserByEmailAndPwAndId != null)
            {
                db.Persons.Remove(currentUserByEmailAndPwAndId);
                db.SaveChanges();
            }
            else
            {
                throw new UnauthorizedAccessException("Invalid email and/or currentpassword and/or id");
            }
        }

        public List<Pet> GetMyPets(int personId)
        {
            using var db = new PersonDbContext();
            //get person, join the pets
            Person personWithPets = db.Persons.Include(x => x.Pets).FirstOrDefault(x => x.Id == personId);
            return personWithPets.Pets;

            //haal alle pets met de juiste personId op
            List<Pet> listOpPets = db.Pets.Where(x => x.PersonId == personId).ToList();
            return listOpPets;
        }
    }
}
