﻿// <auto-generated />
using System;
using ControlDocumentoFactura.Infraestructura.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ControlDocumentoFactura.Infraestructura.EF.Migrations
{
    [DbContext(typeof(ReadDbContext))]
    [Migration("20220904011715_InitialStructure")]
    partial class InitialStructure
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ControlDocumentoFactura.Infraestructura.EntityFramework.ReadModel.ClienteReadModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NombreCompleto")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("nombreCompleto");

                    b.HasKey("Id");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("ControlDocumentoFactura.Infraestructura.EntityFramework.ReadModel.FacturaReadModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ClienteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Estado")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("estado");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime")
                        .HasColumnName("fecha");

                    b.Property<decimal>("Importe")
                        .HasPrecision(12, 2)
                        .HasColumnType("decimal(12,2)")
                        .HasColumnName("importe");

                    b.Property<string>("Lugar")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasColumnName("lugar");

                    b.Property<decimal>("Monto")
                        .HasPrecision(12, 2)
                        .HasColumnType("decimal(12,2)")
                        .HasColumnName("monto");

                    b.Property<string>("NitBeneficiario")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasColumnName("nitBeneficiario");

                    b.Property<string>("NitProveedor")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasColumnName("nitProveedor");

                    b.Property<string>("NroAutorizacion")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasColumnName("nroAutorizacion");

                    b.Property<string>("NroFactura")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasColumnName("nroFactura");

                    b.Property<string>("RazonSocialBeneficiario")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasColumnName("razonSocialBeneficiario");

                    b.Property<string>("RazonSocialProveedor")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasColumnName("razonSocialProveedor");

                    b.Property<Guid?>("ReservaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("VueloId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("ReservaId");

                    b.HasIndex("VueloId");

                    b.ToTable("Factura");
                });

            modelBuilder.Entity("ControlDocumentoFactura.Infraestructura.EntityFramework.ReadModel.ReservaReadModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ClienteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CodReserva")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasColumnName("codReserva");

                    b.Property<decimal>("Deuda")
                        .HasPrecision(12, 2)
                        .HasColumnType("decimal(12,2)")
                        .HasColumnName("deuda");

                    b.Property<string>("EstadoReserva")
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)")
                        .HasColumnName("estadoReserva");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime")
                        .HasColumnName("fecha");

                    b.Property<decimal>("Monto")
                        .HasPrecision(12, 2)
                        .HasColumnType("decimal(12,2)")
                        .HasColumnName("monto");

                    b.Property<string>("TipoReserva")
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)")
                        .HasColumnName("tipoReserva");

                    b.Property<Guid?>("VueloId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("VueloId");

                    b.ToTable("Reserva");
                });

            modelBuilder.Entity("ControlDocumentoFactura.Infraestructura.EntityFramework.ReadModel.VueloReadModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int")
                        .HasColumnName("cantidad");

                    b.Property<string>("Detalle")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasColumnName("detalle");

                    b.Property<decimal>("PrecioPasaje")
                        .HasPrecision(12, 2)
                        .HasColumnType("decimal(12,2)")
                        .HasColumnName("precioPasaje");

                    b.HasKey("Id");

                    b.ToTable("Vuelo");
                });

            modelBuilder.Entity("ControlDocumentoFactura.Infraestructura.EntityFramework.ReadModel.FacturaReadModel", b =>
                {
                    b.HasOne("ControlDocumentoFactura.Infraestructura.EntityFramework.ReadModel.ClienteReadModel", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId");

                    b.HasOne("ControlDocumentoFactura.Infraestructura.EntityFramework.ReadModel.ReservaReadModel", "Reserva")
                        .WithMany()
                        .HasForeignKey("ReservaId");

                    b.HasOne("ControlDocumentoFactura.Infraestructura.EntityFramework.ReadModel.VueloReadModel", "Vuelo")
                        .WithMany()
                        .HasForeignKey("VueloId");

                    b.Navigation("Cliente");

                    b.Navigation("Reserva");

                    b.Navigation("Vuelo");
                });

            modelBuilder.Entity("ControlDocumentoFactura.Infraestructura.EntityFramework.ReadModel.ReservaReadModel", b =>
                {
                    b.HasOne("ControlDocumentoFactura.Infraestructura.EntityFramework.ReadModel.ClienteReadModel", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId");

                    b.HasOne("ControlDocumentoFactura.Infraestructura.EntityFramework.ReadModel.VueloReadModel", "Vuelo")
                        .WithMany()
                        .HasForeignKey("VueloId");

                    b.Navigation("Cliente");

                    b.Navigation("Vuelo");
                });
#pragma warning restore 612, 618
        }
    }
}
