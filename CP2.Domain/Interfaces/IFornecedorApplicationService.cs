using CP2.Domain.Entities;
using System.Collections.Generic;

namespace CP2.Domain.Interfaces
{
    public interface IFornecedorApplicationService
    {
        IEnumerable<FornecedorEntity> ObterTodosFornecedores();
        FornecedorEntity? ObterFornecedorPorId(int id);
        FornecedorEntity SalvarDadosFornecedor(FornecedorEntity entity);
        FornecedorEntity EditarDadosFornecedor(int id, FornecedorEntity entity);
        FornecedorEntity? DeletarDadosFornecedor(int id);
    }
}
