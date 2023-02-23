using AutoMapper;
using Data.Interface;
using Entities;
using EntitiesDto;
using Microsoft.AspNetCore.Mvc;
using pruebaTriidy.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace pruebaTriidy.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        readonly ICityData Repo;
        readonly IMapper Mapper;
        readonly ITokenProvider Token;
        public CitiesController(ICityData repo, IMapper mapper, ITokenProvider token)
        {
            Repo = repo;
            Token = token;
            Mapper = mapper;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<CityDto>>> GetByIdContry(int id)
        {
            List<City> cities = await Repo.GetByIdContry(id);
            var citiesDto = Mapper.Map<List<CityDto>>(cities);


            var token = new JsonWebToken()
            {
                Access_Token = Token.CreateToken( DateTime.UtcNow.AddHours(10)),
                Expires_In = 480,
                StatusCode = 200
            };
            return Ok(new  { data= citiesDto, token  = token });
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Create(CityDto cityDto)
        {
            var city = Mapper.Map<City>(cityDto);
            bool result = await Repo.Create(city);
            if (result)
                return Ok(result);
            else
                return BadRequest(result);
        }
        [HttpPut]
        public async Task<ActionResult<bool>> Update(CityDto cityDto)
        {
            var city = Mapper.Map<City>(cityDto);
            bool result = await Repo.Update(city);
            if (result)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            bool result = await Repo.Delete(id);
            if (result)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}
