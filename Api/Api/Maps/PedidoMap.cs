using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Maps
{
    public class PedidoMap : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasKey(x => x.PedidoId);
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(200);
            builder.Property(x => x.DataHoraCadastro).IsRequired();
            builder.Property(x => x.ClienteId).IsRequired();
        }
    }
}
