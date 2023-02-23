using AutoMapper;
using Data.Interface;
using Entities;
using EntitiesDto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace pruebaTriidy.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    [AutoValidateAntiforgeryToken]
    public class ContriesController : ControllerBase
    {
        readonly ICitiesData Repo;
        readonly IMapper Mapper;
        public ContriesController(ICitiesData repo , IMapper mapper)
        {
            Repo = repo;
            Mapper = mapper;
        }
        // GET: api/<ContriesController>
        [HttpGet]
        public async Task<ActionResult<List<ContryDto>>> Get()
        {
            List<Contry> Contries = await Repo.Get();
            var contryDto = Mapper.Map<List<ContryDto>>(Contries);

            return contryDto;
        }

       

        // POST api/<ContriesController>
        [HttpPost]
        public async Task<ActionResult<bool>> Create(ContryDto contryDto)
        {
            var contry = Mapper.Map<Contry>(contryDto);
            bool result = await Repo.Create(contry);
            if (result)
                return Ok(result);
            else
                return BadRequest(result);
        }

        // PUT api/<ContriesController>/5
        [HttpPut]
        public async Task<ActionResult<bool>> Update(ContryDto contryDto)
        {
            var contry = Mapper.Map<Contry>(contryDto);
            bool result = await Repo.Update(contry);
            if (result)
                return Ok(result);
            else
                return BadRequest(result);
        }

        // DELETE api/<ContriesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id )
        {
            bool result = await Repo.Delete(id);
            if (result)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}
