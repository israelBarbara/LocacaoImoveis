using LocacaoImoveis.Domain.v1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocacaoImoveis.Infrastructure.Mappings
{
    public class ImagemMapping : IEntityTypeConfiguration<Imagem>
    {
        public void Configure(EntityTypeBuilder<Imagem> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(c => c.CaminhoImagem)
                    .IsRequired()
                    .HasColumnType("varchar(300)");
            builder.ToTable("IMAGEM");
        }

    }

}
