using SistemaPropostas.API.Data;
using SistemaPropostas.API.Models;
using SistemaPropostas.API.DTOs;

namespace SistemaPropostas.API.Services
{
    public class ClienteService
    {
        private readonly AppDbContext _context; //guarda a conexão com o banco

        public ClienteService(AppDbContext context) // é o injeção de dependência (Dependency Injection) e o .NET entrega o banco pronto pra você
        {
            _context = context;
        }

        public ClienteDTO Create(ClienteCreateDTO dto)
        {
            if (dto.Documento.Length < 11)
                throw new Exception("Documento inválido");

            var existe = _context.Clientes
                .Any(c => c.Documento == dto.Documento);

            if (existe)
                throw new Exception("Documento já cadastrado");

            var cliente = new Cliente
            {
                Nome = dto.Nome,
                Documento = dto.Documento,
                TipoPessoa = dto.TipoPessoa
            };

            _context.Clientes.Add(cliente);
            _context.SaveChanges();

            return new ClienteDTO
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Documento = cliente.Documento,
                TipoPessoa = cliente.TipoPessoa
            };
        }

        public List<ClienteDTO> GetAll()
        {
            return _context.Clientes
                .Select(c => new ClienteDTO
                {
                    Id = c.Id,
                    Nome = c.Nome,
                    Documento = c.Documento,
                    TipoPessoa = c.TipoPessoa
                })
                .ToList();
        }

        public ClienteDTO? GetById(int id)
        {
            var cliente = _context.Clientes.FirstOrDefault(c => c.Id == id);

            if (cliente == null)
                return null;

            return new ClienteDTO
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Documento = cliente.Documento,
                TipoPessoa = cliente.TipoPessoa
            };
        }

        public ClienteDTO? Update(int id, ClienteUpdateDTO dto)
        {
            var cliente = _context.Clientes.FirstOrDefault(c => c.Id == id);

            if (cliente == null)
                return null;

            if (!string.IsNullOrEmpty(dto.Documento))
            {
                var existe = _context.Clientes
                    .Any(c => c.Documento == dto.Documento && c.Id != id);

                if (existe)
                    throw new Exception("Documento já cadastrado");

                cliente.Documento = dto.Documento;
            }

            if (!string.IsNullOrEmpty(dto.Nome))
                cliente.Nome = dto.Nome;

            if (!string.IsNullOrEmpty(dto.TipoPessoa))
                cliente.TipoPessoa = dto.TipoPessoa;

            _context.SaveChanges();

            return new ClienteDTO
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Documento = cliente.Documento,
                TipoPessoa = cliente.TipoPessoa
            };
        }

        public bool Delete(int id)
        {
            var cliente = _context.Clientes.FirstOrDefault(c => c.Id == id);

            if (cliente == null)
                return false;

            _context.Clientes.Remove(cliente);
            _context.SaveChanges();

            return true;
        }
    }
}