using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SGBenefic.API.Data;
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
    public class AlunoController : ControllerBase
    {
        private readonly DataContext _context;
        public AlunoController(DataContext context)
        {
            _context = context;
        }
        

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Alunos);
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = _context.Alunos.FirstOrDefault(x => x.Id == id);
            if (aluno == null) return BadRequest("Aluno não encontrado");

            return Ok(aluno);
        }

        [HttpGet("GetByName")]
        public IActionResult GetByName(string nome, string sobrenome)
        {
            var aluno = _context.Alunos.FirstOrDefault(x =>
                x.Nome.ToLower().Contains(nome.ToLower())
                && x.SobreNome.ToLower().Contains(sobrenome.ToLower())
             );
            if (aluno == null) return BadRequest("Aluno não encontrado");

            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Aluno aluno)
        {
            _context.Add(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Aluno aluno)
        {
            var _aluno = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (_aluno == null) return BadRequest("Aluno não encontrado");

            _context.Update(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody] Aluno aluno)
        {
            var _aluno = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (_aluno == null) return BadRequest("Aluno não encontrado");

            _context.Update(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null) return BadRequest("Aluno não encontrado");

            _context.Remove(aluno);
            return Ok();
        }
    }
}
