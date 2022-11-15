
using LocacaoImoveis.Business.Models;
using LocacaoImoveis.Domain.v1.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LocacaoImoveis.Infrastructure.Context
{
    public class ImovelContext : DbContext
    {

        public ImovelContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Imovel> Imoveis { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Imagem> Imagens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //se esquecer de mapear algum campo do tipo string no banco vira como varchar(100) como default, e nao varchar(max)
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                    .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ImovelContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            base.OnModelCreating(modelBuilder);
        }


    }
}
