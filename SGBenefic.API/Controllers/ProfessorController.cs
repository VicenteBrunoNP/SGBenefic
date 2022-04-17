using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SGBenefic.API.Data;
using SGBenefic.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGBenefic.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly IRepository _repo;

        public ProfessorController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _repo.GetAllProfessores(true);
            return Ok(result);
        }
    

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var professor = _repo.GetAllProfessorById(id, false);
            if (professor == null) return BadRequest("Professor não encontrado");

            return Ok(professor);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Professor professor)
        {
            _repo.Add(professor);
            if (_repo.SaveChanges())
                return Ok(professor);

            return BadRequest("Professor não cadastrado");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Professor professor)
        {
            var _professor = _repo.GetAllProfessorById(id);
            if (_professor == null) return BadRequest("Professor não encontrado");

            _repo.Update(professor);
            if (_repo.SaveChanges())
                return Ok(professor);

            return BadRequest("Professor não atualizado");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody] Professor professor)
        {
            var _professor = _repo.GetAllProfessorById(id);
            if (_professor == null) return BadRequest("Professor não encontrado");

            _repo.Update(professor);
            if (_repo.SaveChanges())
                return Ok(professor);

            return BadRequest("Professor não atualizado");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var professor = _repo.GetAllProfessorById(id);
            if (professor == null) return BadRequest("Professor não encontrado");

            _repo.Delete(professor);
            if (_repo.SaveChanges())
                return Ok("Professor Deletado");

            return BadRequest("Professor não deletado");
        }
    }
}
