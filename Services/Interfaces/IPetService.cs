using System.Collections.Generic;
using Opdracht5Maart.Models;

namespace Opdracht5Maart.Services
{
    public interface IPetService
    {
        Pet ChangeOwner(int currentOwnerId, Pet NewOwnerId);
        Pet CreatePet(Pet pet);
        Pet GetPet(int Id);
        List<Pet> GetPetByType(PetTypes Type);
        List<Pet> GetPets();
    }
}