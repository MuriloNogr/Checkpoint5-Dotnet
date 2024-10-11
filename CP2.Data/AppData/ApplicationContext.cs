using CP2.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CP2.Data.AppData
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        // DbSets representam as tabelas no banco de dados
        public DbSet<FornecedorEntity> Fornecedor { get; set; }
        public DbSet<VendedorEntity> Vendedor { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuração para a entidade Fornecedor
            modelBuilder.Entity<FornecedorEntity>(entity =>
            {
                entity.ToTable("tb_fornecedor");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nome).IsRequired().HasMaxLength(100);
                entity.Property(e => e.CNPJ).IsRequired().HasMaxLength(14);
                entity.Property(e => e.Endereco).HasMaxLength(200);
                entity.Property(e => e.Telefone).HasMaxLength(15);
                entity.Property(e => e.Email).HasMaxLength(255);
                entity.Property(e => e.CriadoEm).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            // Configuração para a entidade Vendedor
            modelBuilder.Entity<VendedorEntity>(entity =>
            {
                entity.ToTable("tb_vendedor");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nome).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Email).HasMaxLength(255);
                entity.Property(e => e.Telefone).HasMaxLength(15);
                entity.Property(e => e.Endereco).HasMaxLength(200);
                entity.Property(e => e.ComissaoPercentual).HasColumnType("decimal(5, 2)");
                entity.Property(e => e.MetaMensal).HasColumnType("decimal(15, 2)");
                entity.Property(e => e.CriadoEm).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });
        }
    }
}
