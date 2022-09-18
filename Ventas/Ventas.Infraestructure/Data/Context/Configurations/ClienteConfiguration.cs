﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using Ventas.Infraestructure.Data.Context;
using Ventas.Infraestructure.Data.Entities;

namespace Ventas.Infraestructure.Data.Context.Configurations
{
    public partial class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> entity)
        {
            entity.HasKey(e => e.IdCliente)
                .HasName("PK__cliente__885457EE03317E3D");

            entity.ToTable("cliente");

            entity.Property(e => e.IdCliente).HasColumnName("idCliente");

            entity.Property(e => e.Apellidos)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("apellidos");

            entity.Property(e => e.Celular)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("celular")
                .IsFixedLength();

            entity.Property(e => e.Nombres)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("nombres");

            entity.Property(e => e.NroDoc)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("nroDoc")
                .IsFixedLength();

            entity.Property(e => e.Telefono)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("telefono")
                .IsFixedLength();

            entity.Property(e => e.TipoDoc)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("tipoDoc")
                .IsFixedLength();

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Cliente> entity);
    }
}