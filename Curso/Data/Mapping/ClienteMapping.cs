﻿using CursoEFCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CursoEFCore.Data.Mapping
{
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable(Constantes.Constantes.Tabelas.Cliente, Constantes.Constantes.Schemas.Sistema);

            builder.HasKey(cliente => cliente.Id);

            builder.Property(cliente => cliente.Nome).HasColumnType("VARCHAR(80)").IsRequired();
            builder.Property(cliente => cliente.Telefone).HasColumnType("CHAR(11)");
            builder.Property(cliente => cliente.CEP).HasColumnType("CHAR(8)").IsRequired();
            builder.Property(cliente => cliente.Cidade).HasColumnType("CHAR(2)").IsRequired();
            builder.Property(cliente => cliente.Estado).HasMaxLength(60).IsRequired();

            builder.HasIndex(i => i.Telefone).HasName("idx_cliente_telefone");
        }
    }
}
