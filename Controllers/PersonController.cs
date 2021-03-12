using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Opdracht5Maart.Models;
using Opdracht5Maart.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Opdracht5Maart.DTO;
using AutoMapper;

namespace Opdracht5Maart.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public partial class PersonController : ControllerBase
    {
        private readonly IPersonService _PersonService;
        private readonly IMapper _mapper;
        public PersonController(IMapper mapper, IPersonService personServices)
        {
            _mapper = mapper;
            _PersonService = personServices;
        }
        
        [HttpPost("Create")]
        public ActionResult CreatePerson(CreatePersonDTO createPersonDTO)
        {
            var personFromDTO = _mapper.Map<Person>(createPersonDTO);
            _PersonService.CreatePerson(personFromDTO);
            return Ok();
        }

        [HttpGet("Login")]
        public ActionResult<bool> Login( string email, string password)
        {

            return Ok(_PersonService.Login(email, password));           
        }

        [HttpPut("ChangePassword")]
        public ActionResult ChangePassByEmail(string email, string currentPassword, string newPassword)
        {
            try
            {
                _PersonService.ChangePassword(email, currentPassword, newPassword);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }
            return Ok();
        }

        [HttpDelete("Delete")]
        public ActionResult Delete(int Id, string email, string password)
        {
            try
            {
                _PersonService.DeletePerson(Id, email, password);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }
            return Ok();
        }
        //[HttpGet("GetMyPets")]
        //public ActionResult<List<ResponsePersonWithPetsDTO>> GetMyPets(int UserId)
        //{
        //    //var pets = _PersonService.GetMyPets(UserId);
        //    //var listOfMyPets = new ResponsePersonWithPetsDTO();
        //    //listOfMyPets.Pets = _PetService.pets.ToList();

        //    //foreach (Pet pet in)
        //    //{

        //    //}
        //    return Ok();
        //}





    }
}
