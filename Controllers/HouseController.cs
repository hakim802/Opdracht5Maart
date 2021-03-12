using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Opdracht5Maart.Models;
using Opdracht5Maart.Services;
using Opdracht5Maart.DTO;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace Opdracht5Maart.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public partial class HouseController : ControllerBase
    {
        private readonly IHouseService _HouseService;
        private readonly IMapper _mapper;
        public HouseController(IMapper mapper ,IHouseService houseService)
        {
            _mapper = mapper;
            _HouseService = houseService;
        }

        [HttpPost("Create")]
        public ActionResult CreateNewHouse(CreateHouseDTO createHouseDTO)
        {
            House house = _mapper.Map<House>(createHouseDTO);
            _HouseService.CreateHouse(house);
            return Ok();
        }

        [HttpGet("Postal")]
        public ActionResult<House> GetProduct(int postal)
        {
            var Houses = _HouseService.GetHousesByPostal(postal);
            if (Houses == null)
            {
                return NotFound();
            }
            return Ok(Houses);
        }
    }
}
