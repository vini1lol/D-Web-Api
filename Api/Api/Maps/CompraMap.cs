using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Maps
{
    public class CompraMap : IEntityTypeConfiguration<Compra>
    {
        public void Configure(EntityTypeBuilder<Compra> builder)
        {
            builder.HasKey(x => x.CompraId);
            builder.Property(x => x.Quantidade).IsRequired();
            builder.Property(x => x.DataCadastro).IsRequired();
            builder.Property(x => x.UserId).IsRequired();
        }
    }
}
