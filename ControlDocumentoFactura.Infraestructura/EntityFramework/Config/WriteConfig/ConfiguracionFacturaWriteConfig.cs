using ControlDocumentoFactura.Dominio.Models.Facturas.ValueObjetcs;
using ControlDocumentoFactura.Dominio.Models.Facturas;
using ControlDocumentoFactura.Dominio.Models.ValueObjects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Infraestructura.EntityFramework.Config.WriteConfig
{
	public class ConfiguracionFacturaWriteConfig : IEntityTypeConfiguration<ConfiguracionFactura>
	{
		public void Configure(EntityTypeBuilder<ConfiguracionFactura> builder)
		{
			builder.ToTable("ConfiguracionFactura");
			builder.HasKey(x => x.Id);

			//-----------------------------------

			builder.Property(x => x.Fecha)
					.HasColumnName("fecha")
					.HasColumnType("datetime");
			//-----------------------------------

			var nitFacturaConverter = new ValueConverter<NitFacturaValue, string>(
				nitFacturaValue => nitFacturaValue.Value,
				nitFactura => new NitFacturaValue(nitFactura)
			);

			builder.Property(x => x.NitProveedor)
				.HasColumnName("nitProveedor")
				.HasConversion(nitFacturaConverter)
				.HasMaxLength(25);
			//-------------------------------
			var razonSocialConverter = new ValueConverter<RazonSocialValue, string>(
					razonSocialValue => razonSocialValue.Value,
					razonSocial => new RazonSocialValue(razonSocial)
				);


			builder.Property(x => x.RazonSocialProveedor)
				.HasColumnName("razonSocialProveedor")
				.HasConversion(razonSocialConverter)
				.HasMaxLength(25);
			//-------------------------------
			var numeroAutorizacionConverter = new ValueConverter<NumeroAutorizacionValue, string>(
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



		}
	}
}
