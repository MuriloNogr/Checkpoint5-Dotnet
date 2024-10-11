using CP2.Domain.Entities;
using System.Collections.Generic;

namespace CP2.Domain.Interfaces
{
    public interface IVendedorRepository
    {
        IEnumerable<VendedorEntity> ObterTodos();
        VendedorEntity? ObterPorId(int id);
        VendedorEntity Salvar(VendedorEntity vendedor);
        VendedorEntity Editar(VendedorEntity vendedor);
        VendedorEntity? DeletarDados(int id);
    }
}
