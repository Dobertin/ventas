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
    public partial class VentaConfiguration : IEntityTypeConfiguration<Venta>
    {
        public void Configure(EntityTypeBuilder<Venta> entity)
        {
            entity.HasKey(e => e.IdVenta)
                .HasName("PK__ventas__077D56140AD2A005");

            entity.ToTable("ventas");

            entity.Property(e => e.IdVenta).HasColumnName("idVenta");

            entity.Property(e => e.EstadoRegistro).HasColumnName("estado_registro");

            entity.Property(e => e.FechaVenta)
                .HasColumnType("datetime")
                .HasColumnName("fechaVenta")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.IdAsesor).HasColumnName("idAsesor");

            entity.Property(e => e.IdCliente).HasColumnName("idCliente");

            entity.Property(e => e.IdProducto).HasColumnName("idProducto");

            entity.Property(e => e.MontoDesembolsado)
                .HasColumnType("decimal(10, 4)")
                .HasColumnName("montoDesembolsado");

            entity.Property(e => e.Periodo)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("periodo")
                .IsFixedLength();

            entity.Property(e => e.PuntosObtenidos).HasColumnName("puntosObtenidos");

            entity.HasOne(d => d.IdAsesorNavigation)
                .WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdAsesor)
                .HasConstraintName("FK__ventas__idAsesor__0DAF0CB0");

            entity.HasOne(d => d.IdClienteNavigation)
                .WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__ventas__idClient__0EA330E9");

            entity.HasOne(d => d.IdProductoNavigation)
                .WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("FK__ventas__idProduc__0F975522");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Venta> entity);
    }
}
