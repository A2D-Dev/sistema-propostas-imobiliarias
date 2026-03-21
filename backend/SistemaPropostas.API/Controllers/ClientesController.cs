using Microsoft.AspNetCore.Mvc;
using SistemaPropostas.API.DTOs;
using SistemaPropostas.API.Models;
using SistemaPropostas.API.Services;

namespace SistemaPropostas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly ClienteService _service;

        public ClientesController(ClienteService service)
        {
            _service = service;
        }

        // POST: api/clientes
        [HttpPost]
        public IActionResult CriarCliente(ClienteCreateDTO dto)
        {
            var cliente = _service.Create(dto);
            return Ok(cliente);            
        }
        

        // GET ALL: api/clientes por lista
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.GetAll());
        }

        // GET BY ID: api/cliente por id
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var cliente = _service.GetById(id);

            if (cliente == null)
                return NotFound();

            return Ok(cliente);
        }

        
        [HttpPut("{id}")]
        public IActionResult Update(int id, ClienteUpdateDTO dto)
        {
            var cliente = _service.GetById(id);

            if (cliente == null)
                return NotFound();

            return Ok(cliente);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var sucesso = _service.Delete(id);

            if (!sucesso)
                return NotFound();
            return Ok(new { mensagem = "Cliente deletado com sucesso" });
        }

    }
}