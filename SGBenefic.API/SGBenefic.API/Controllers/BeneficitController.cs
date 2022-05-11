using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SGBenefic.API.Data;
using SGBenefic.API.Dtos;
using SGBenefic.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SGBenefic.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeneficitController : ControllerBase
    {
        private readonly IRepository _repo;
        private readonly IMapper _mapper;


        public BeneficitController(IRepository repo, 
                               IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var beneficities = _repo.GetAllBeneficit();

            return Ok(_mapper.Map<IEnumerable<BeneficitDto>>(beneficities));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {

            var beneficit = _repo.GetAllBeneficitById(id);
            if (beneficit == null) return BadRequest("Benefício não encontrado");

            var beneficitDto = _mapper.Map<BeneficitDto>(beneficit);

            return Ok(beneficitDto);
        }

        [HttpPost]
        public IActionResult Post([FromBody] BeneficitDto model)
        {
            var beneficit = _mapper.Map<Beneficit>(model);

            _repo.Add(beneficit);
            if (_repo.SaveChanges())
                return Created($"/api/beneficit/{model.Id}", _mapper.Map<BeneficitDto>(beneficit));

            return BadRequest("Benefício não cadastrado");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] BeneficitDto model)
        {
            var beneficit = _repo.GetAllBeneficitById(id);
            if (beneficit == null) return BadRequest("Benefício não encontrado");

            _mapper.Map(model, beneficit);

            _repo.Update(beneficit);
            if (_repo.SaveChanges())
                return Created($"/api/beneficit/{model.Id}", _mapper.Map<BeneficitDto>(beneficit));

            return BadRequest("Benefício não atualizado");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var beneficit = _repo.GetAllBeneficitById(id);
            if (beneficit == null) return BadRequest("Benefício não encontrado");

            _repo.Delete(beneficit);
            if (_repo.SaveChanges())
                return Ok("Benefício Deletado");

            return BadRequest("Benefício não deletado");
        }
    }
}
