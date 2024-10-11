using CP2.Domain.Entities;
using System.Collections.Generic;

namespace CP2.Domain.Interfaces
{
    public interface IFornecedorRepository
    {
        IEnumerable<FornecedorEntity> ObterTodos();
        FornecedorEntity? ObterPorId(int id);
        FornecedorEntity Salvar(FornecedorEntity fornecedor);
        FornecedorEntity Editar(FornecedorEntity fornecedor);
        FornecedorEntity? DeletarDados(int id);
    }
}
