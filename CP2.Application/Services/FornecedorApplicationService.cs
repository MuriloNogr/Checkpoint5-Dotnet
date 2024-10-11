using CP2.Domain.Entities;
using CP2.Domain.Interfaces;
using System.Collections.Generic;

namespace CP2.Application.Services
{
    public class FornecedorApplicationService : IFornecedorApplicationService
    {
        private readonly IFornecedorRepository _repository;

        public FornecedorApplicationService(IFornecedorRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<FornecedorEntity> ObterTodosFornecedores()
        {
            return _repository.ObterTodos();
        }

        public FornecedorEntity? ObterFornecedorPorId(int id)
        {
            return _repository.ObterPorId(id);
        }

        public FornecedorEntity SalvarDadosFornecedor(FornecedorEntity fornecedor)
        {
            // Aqui você pode realizar a validação do FornecedorEntity, se necessário.
            return _repository.Salvar(fornecedor);
        }

        public FornecedorEntity EditarDadosFornecedor(int id, FornecedorEntity fornecedor)
        {
            var fornecedorExistente = _repository.ObterPorId(id);
            if (fornecedorExistente == null)
            {
                throw new Exception("Fornecedor não encontrado");
            }

            // Atualiza os dados do fornecedor existente com os novos dados.
            fornecedorExistente.Nome = fornecedor.Nome;
            fornecedorExistente.CNPJ = fornecedor.CNPJ;
            fornecedorExistente.Endereco = fornecedor.Endereco;
            fornecedorExistente.Telefone = fornecedor.Telefone;
            fornecedorExistente.Email = fornecedor.Email;

            return _repository.Editar(fornecedorExistente);
        }

        public FornecedorEntity? DeletarDadosFornecedor(int id)
        {
            return _repository.DeletarDados(id);
        }
    }
}
