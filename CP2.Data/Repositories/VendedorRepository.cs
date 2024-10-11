using CP2.Data.AppData;
using CP2.Domain.Entities;
using CP2.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CP2.Data.Repositories
{
    public class VendedorRepository : IVendedorRepository
    {
        private readonly ApplicationContext _context;

        public VendedorRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<VendedorEntity> ObterTodos() =>
            _context.Vendedor.ToList();

        public VendedorEntity? ObterPorId(int id) =>
            _context.Vendedor.Find(id);

        public VendedorEntity Salvar(VendedorEntity vendedor)
        {
            _context.Vendedor.Add(vendedor);
            _context.SaveChanges();
            return vendedor;
        }

        public VendedorEntity Editar(VendedorEntity vendedor)
        {
            _context.Vendedor.Update(vendedor);
            _context.SaveChanges();
            return vendedor;
        }

        public VendedorEntity? DeletarDados(int id)
        {
            var vendedor = _context.Vendedor.Find(id);
            if (vendedor == null) return null;

            _context.Vendedor.Remove(vendedor);
            _context.SaveChanges();
            return vendedor;
        }
    }
}
