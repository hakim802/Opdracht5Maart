using System.Collections.Generic;
using Opdracht5Maart.Models;

namespace Opdracht5Maart.Services
{
    public interface IPersonService
    {
        void ChangePassword(string email, string currentPAssword, string newPassword);
        void CreatePerson(Person person);
        void DeletePerson(int id, string email, string currentPassword);
        List<Pet> GetMyPets(int personId);
        bool Login(string email, string password);
    }
}