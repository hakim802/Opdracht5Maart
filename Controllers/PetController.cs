using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Opdracht5Maart.Models;
using Opdracht5Maart.Services;
using Opdracht5Maart.DTO;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace Opdracht5Maart.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly IPetService _PetService;
        private readonly IMapper _mapper;
        public PetController(IMapper mapper, IPetService petService)
        {
            _mapper = mapper;
            _PetService = petService;
        }

        [HttpPost]
        public ActionResult CreateNewPet(CreatePetDTO createPetDTO)
        {
            Pet pet = _mapper.Map<Pet>(createPetDTO);
            _PetService.CreatePet(pet);           
            return Ok();
        }

        [HttpGet("one")]
        public ActionResult<Pet> GetPet(int Id)
        {
            var pet = _PetService.GetPet(Id);
            if (pet == null)
            {
                return NotFound();
            }
            return Ok(pet);
        }
        [HttpGet("many")]
        public ActionResult<List<Pet>> GetAllPets()
        {
            var Pets = _PetService.GetPets();
            return Ok(Pets);
        }

        [HttpGet("manyByType")]
        public List<Pet> GetPetByType(PetTypes Type)
        {
            var pets = _PetService.GetPetByType(Type).ToList();
            
            return pets.ToList();;
        }

        [HttpPut("ChangeOwner")]
        public ActionResult<Pet> ChangeOwnerById(int currentOwnerId, ChangePetOwnerDTO NewOwner)
        {
            var petOwnerToChange = new Pet();
            petOwnerToChange.PersonId = NewOwner.PersonId;
            var pet = _PetService.ChangeOwner(currentOwnerId, petOwnerToChange);
            return Ok();
        }
    }
}
