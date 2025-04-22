using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Services
{
    public class ClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<List<Cliente>> ListarClientesAsync()
        {
            return await _clienteRepository.GetAllAsync();
        }

        public async Task<Cliente> ObterClienteAsync(Guid id)
        {
            return await _clienteRepository.GetByIdAsync(id);
        }

        public async Task AdicionarClienteAsync(ClienteDto dto)
        {
            var cliente = new Cliente
            {
                Nome = dto.Nome,
                Email = dto.Email,
                Telefone = dto.Telefone,
                Endereco = dto.Endereco
            };

            await _clienteRepository.AddAsync(cliente);
        }

        public async Task AtualizarClienteAsync(Guid id, ClienteDto dto)
        {
            var cliente = await _clienteRepository.GetByIdAsync(id);
            if (cliente == null) return;

            cliente.Nome = dto.Nome;
            cliente.Email = dto.Email;
            cliente.Telefone = dto.Telefone;
            cliente.Endereco = dto.Endereco;

            await _clienteRepository.UpdateAsync(cliente);
        }

        public async Task RemoverClienteAsync(Guid id)
        {
            await _clienteRepository.DeleteAsync(id);
        }
    }
}
