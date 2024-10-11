using CP2.Domain.Entities;
using CP2.Domain.Interfaces;
using System.Collections.Generic;

namespace CP2.Application.Services
{
    public class VendedorApplicationService : IVendedorApplicationService
    {
        private readonly IVendedorRepository _repository;

        public VendedorApplicationService(IVendedorRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<VendedorEntity> ObterTodosVendedores()
        {
            return _repository.ObterTodos();
        }

        public VendedorEntity? ObterVendedorPorId(int id)
        {
            return _repository.ObterPorId(id);
        }

        public VendedorEntity SalvarDadosVendedor(VendedorEntity vendedor)
        {
            // Aqui você pode realizar a validação do VendedorEntity, se necessário.
            return _repository.Salvar(vendedor);
        }

        public VendedorEntity EditarDadosVendedor(int id, VendedorEntity vendedor)
        {
            var vendedorExistente = _repository.ObterPorId(id);
            if (vendedorExistente == null)
            {
                throw new Exception("Vendedor não encontrado");
            }

            // Atualiza os dados do vendedor existente com os novos dados.
            vendedorExistente.Nome = vendedor.Nome;
            vendedorExistente.Email = vendedor.Email;
            vendedorExistente.Telefone = vendedor.Telefone;
            vendedorExistente.DataNascimento = vendedor.DataNascimento;
            vendedorExistente.Endereco = vendedor.Endereco;
            vendedorExistente.DataContratacao = vendedor.DataContratacao;
            vendedorExistente.ComissaoPercentual = vendedor.ComissaoPercentual;
            vendedorExistente.MetaMensal = vendedor.MetaMensal;

            return _repository.Editar(vendedorExistente);
        }

        public VendedorEntity? DeletarDadosVendedor(int id)
        {
            return _repository.DeletarDados(id);
        }
    }
}
