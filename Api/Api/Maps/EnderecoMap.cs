using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Maps
{
    public class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(x => x.EnderecoId);
            builder.Property(x => x.CEP).IsRequired().HasMaxLength(8);
            builder.Property(x => x.Logradouro).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Numero).IsRequired();
            builder.Property(x => x.Bairro).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Cidade).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Estado).IsRequired().HasMaxLength(2);
            builder.Property(x => x.ClienteId).IsRequired();
        }
    }
}
