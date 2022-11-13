﻿using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Maps
{
    public class CompraMap : IEntityTypeConfiguration<Compra>
    {
        public void Configure(EntityTypeBuilder<Compra> builder)
        {
            builder.HasKey(x => x.CompraId);
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(200);
            builder.Property(x => x.DataCadastro).IsRequired();
            builder.Property(x => x.UserId).IsRequired();
        }
    }
}
