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
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repo;
        private readonly IMapper _mapper;


        public UserController(IUserRepository repo, 
                               IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Get(string valueFind = "")
        {
            var users = _repo.GetAllUser();

            if (!string.IsNullOrEmpty(valueFind))
                users = users.FindAll(x =>
                    x.Name.ToLower().Trim().Contains(valueFind.ToLower().Trim()) || 
                    x.Email.ToLower().Trim() == valueFind.ToLower().Trim());

            if (users.Count == 0)
                return Ok(_mapper.Map<IEnumerable<UserDto>>(new List<User>()));

            return Ok(_mapper.Map<IEnumerable<UserDto>>(users));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {

            var user = _repo.GetUserById(id);
            if (user == null) return BadRequest("Usuário não encontrado");

            var userDto = _mapper.Map<UserDto>(user);

            return Ok(userDto);
        }

        [HttpPost]
        public IActionResult Post([FromBody] UserDto model)
        {
            var user = _mapper.Map<UserDto>(model);

            _repo.Add(user);
            if (_repo.SaveChanges())
                return Created($"/api/user/{model.Id}", _mapper.Map<UserDto>(user));

            return BadRequest("Usuário não cadastrado");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UserDto model)
        {
            var user = _repo.GetUserById(id);
            if (user == null) return BadRequest("Usuário não encontrado");

            _mapper.Map(model, user);

            _repo.Update(user);
            if (_repo.SaveChanges())
                return Created($"/api/user/{model.Id}", _mapper.Map<UserDto>(user));

            return BadRequest("Usuário não atualizado");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = _repo.GetUserById(id);
            if (user == null) return BadRequest("Usuário não encontrado");

            _repo.Delete(user);
            if (_repo.SaveChanges())
                return Ok("Usuário Deletado");

            return BadRequest("Usuário não deletado");
        }
    }
}
