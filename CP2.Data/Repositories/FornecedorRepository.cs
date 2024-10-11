using CP2.Data.AppData;
using CP2.Domain.Entities;
using CP2.Domain.Interfaces;

namespace CP2.Data.Repositories
{
    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly ApplicationContext _context;

        public FornecedorRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<FornecedorEntity> ObterTodos() =>
            _context.Fornecedor.ToList();

        public FornecedorEntity? ObterPorId(int id) =>
            _context.Fornecedor.Find(id);

        public FornecedorEntity Salvar(FornecedorEntity fornecedor)
        {
            _context.Fornecedor.Add(fornecedor);
            _context.SaveChanges();
            return fornecedor;
        }

        public FornecedorEntity Editar(FornecedorEntity fornecedor)
        {
            _context.Fornecedor.Update(fornecedor);
            _context.SaveChanges();
            return fornecedor;
        }

        public FornecedorEntity? DeletarDados(int id)
        {
            var fornecedor = _context.Fornecedor.Find(id);
            if (fornecedor == null) return null;

            _context.Fornecedor.Remove(fornecedor);
            _context.SaveChanges();
            return fornecedor;
        }
    }

}
