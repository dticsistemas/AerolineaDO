
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ControlDocumentoFactura.Dominio.Models.Facturas;
using ControlDocumentoFactura.Dominio.Models.Facturas.ValueObjetcs;
using ControlDocumentoFactura.Dominio.Models.ValueObjects;
using ControlDocumentoFactura.Infraestructura.EntityFramework.ReadModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Infraestructura.EntityFramework.Config.WriteConfig {
		public class FacturaWriteConfig:IEntityTypeConfiguration<Factura> {
				public void Configure(EntityTypeBuilder<Factura> builder) {
						builder.ToTable("Factura");
						builder.HasKey(x => x.Id);


						//-------------------------------
						var nroFacturaConverter = new ValueConverter<NumeroFacturaValue,string>(
							nroFacturaValue => nroFacturaValue.Value,
							nroFactura => new NumeroFacturaValue(nroFactura)
						);
						builder.Property(x => x.NroFactura)
							.HasColumnName("nroFactura")
							.HasConversion(nroFacturaConverter)
							.HasMaxLength(25);
						//-------------------------------

						var montoConverter = new ValueConverter<MontoValue,decimal>(
							 precioValue => precioValue.Value,
							 precio => new MontoValue(precio)
						 );
						builder.Property(x => x.Monto)
							.HasColumnName("monto")
							.HasConversion(montoConverter)
							.HasPrecision(12,2);
						builder.Property(x => x.Importe)
							.HasColumnName("importe")
							.HasConversion(montoConverter)
							.HasPrecision(12,2);
						//-----------------------------------

						builder.Property(x => x.Fecha)
							 .HasColumnName("fecha")
							 .HasColumnType("datetime");
						//-----------------------------------
						var lugarConverter = new ValueConverter<DescripcionLugarValue,string>(
							lugarValue => lugarValue.Value,
							lugar => new DescripcionLugarValue(lugar)
						);
						builder.Property(x => x.Lugar)
							.HasColumnName("lugar")
							.HasConversion(lugarConverter)
							.HasMaxLength(25);
						//-------------------------------
						var nitFacturaConverter = new ValueConverter<NitFacturaValue,string>(
							nitFacturaValue => nitFacturaValue.Value,
							nitFactura => new NitFacturaValue(nitFactura)
						);
						builder.Property(x => x.NitProveedor)
							.HasColumnName("nitProveedor")
							.HasConversion(nitFacturaConverter)
							.HasMaxLength(25);
						builder.Property(x => x.NitBeneficiario)
							.HasColumnName("nitBeneficiario")
							.HasConversion(nitFacturaConverter)
							.HasMaxLength(25);
						//-------------------------------
						var razonSocialConverter = new ValueConverter<RazonSocialValue,string>(
							 razonSocialValue => razonSocialValue.Value,
							 razonSocial => new RazonSocialValue(razonSocial)
						 );
						builder.Property(x => x.RazonSocialProveedor)
							.HasColumnName("razonSocialProveedor")
							.HasConversion(razonSocialConverter)
							.HasMaxLength(25);

						builder.Property(x => x.RazonSocialBeneficiario)
							.HasColumnName("razonSocialBeneficiario")
							.HasConversion(razonSocialConverter)
							.HasMaxLength(25);
						//-------------------------------
						var numeroAutorizacionConverter = new ValueConverter<NumeroAutorizacionValue,string>(
							nroAutorizacionValue => nroAutorizacionValue.Value,
							nroAutorizacion => new NumeroAutorizacionValue(nroAutorizacion)
						);
						builder.Property(x => x.NroAutorizacion)
							.HasColumnName("nroAutorizacion")
							.HasConversion(numeroAutorizacionConverter)
							.HasMaxLength(25);
						//-------------------------------
						builder.Property(x => x.Estado)
							.HasColumnName("estado");
						//-------------------------------
						builder.Property(x => x.ClienteId)
							.HasColumnName("clienteId");
						//-------------------------------

						builder.Property(x => x.VueloId)
							.HasColumnName("vueloId");
						//-------------------------------
						builder.Property(x => x.ReservaId)
							.HasColumnName("reservaId");

				}
		}
}
