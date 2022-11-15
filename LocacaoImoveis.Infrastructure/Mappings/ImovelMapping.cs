
using LocacaoImoveis.Domain.v1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocacaoImoveis.Infrastructure.Mappings
{
    public class ImovelMapping : IEntityTypeConfiguration<Imovel>
    {
        public void Configure(EntityTypeBuilder<Imovel> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.NomProprietario)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasColumnType("varchar(200)");


            builder.HasOne(f => f.Endereco)
                .WithOne(e => e.Imovel);

            builder.HasMany(f => f.Imagem)
                 .WithOne(p => p.Imovel)
                 .HasForeignKey(p => p.ImovelId);

            builder.ToTable("IMOVEL");
        }

    }
}
