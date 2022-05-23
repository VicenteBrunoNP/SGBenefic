using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SGBenefic.API.Data.Interfaces;
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
        private readonly IBeneficitRepository _repo;
        private readonly IMapper _mapper;


        public BeneficitController(IBeneficitRepository repo, 
                               IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Get(string cpfCnpj = "", string codigoBeneficio = "")
        {
            var beneficities = _repo.GetAllBeneficit();

            if (!string.IsNullOrEmpty(cpfCnpj))
                beneficities = beneficities.FindAll(x =>
                    x.CpfCnpj.ToLower().Replace(".", "").Replace("-", "").Replace("/", "") == cpfCnpj.ToLower().Replace(".", "").Replace("-", "").Replace("/", ""));

            if (!string.IsNullOrEmpty(codigoBeneficio))
                beneficities = beneficities.FindAll(x =>
                    x.CodigoBeneficio == codigoBeneficio);

            if (beneficities.Count == 0)
                return Ok(_mapper.Map<IEnumerable<BeneficitDto>>(new List<Beneficit>()));

            return Ok(_mapper.Map<IEnumerable<BeneficitDto>>(beneficities));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {

            var beneficit = _repo.GetBeneficitById(id);
            if (beneficit == null) return BadRequest("Benefício não encontrado");

            var beneficitDto = _mapper.Map<BeneficitDto>(beneficit);

            return Ok(beneficitDto);
        }

        [HttpGet("GetOnlyBeneficits")]
        public IActionResult GetOnlyBeneficits()
        {
            var beneficities = _repo.GetAllBeneficit().Select(p => new { p.CodigoBeneficio, p.Beneficio }).Distinct().ToList();

            var list = new List<Value>();
            foreach (var item in beneficities)
            {
                list.Add(new Value { Id = item.CodigoBeneficio, Description =item.Beneficio });;
            }

            list.Add(new Value { Id = "", Description = " - " });
            list.OrderBy(x => x.Description);           

            return Ok(list);
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
            var beneficit = _repo.GetBeneficitById(id);
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
            var beneficit = _repo.GetBeneficitById(id);
            if (beneficit == null) return BadRequest("Benefício não encontrado");

            _repo.Delete(beneficit);
            if (_repo.SaveChanges())
                return Ok("Benefício Deletado");

            return BadRequest("Benefício não deletado");
        }
    }
}
