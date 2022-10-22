using ControlDocumentoFactura.Infraestructura.EntityFramework.ReadModel;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Infraestructura.EntityFramework.Config.ReadConfig
{
	public class ConfiguracionFacturaReadConfig : IEntityTypeConfiguration<ConfiguracionFacturaReadModel>
	{
		public void Configure(EntityTypeBuilder<ConfiguracionFacturaReadModel> builder)
		{
			builder.ToTable("ConfiguracionFactura");
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Fecha)
					.HasColumnName("fecha")
					.HasColumnType("datetime");

			builder.Property(x => x.NitProveedor)
					.HasColumnName("nitProveedor")
					.HasMaxLength(25);

			builder.Property(x => x.RazonSocialProveedor)
					.HasColumnName("razonSocialProveedor")
					.HasMaxLength(25);

			builder.Property(x => x.NroAutorizacion)
					.HasColumnName("nroAutorizacion")
					.HasMaxLength(25);

			builder.Property(x => x.Estado)
					.HasColumnName("estado")
					.HasMaxLength(10);

		}
	}
}
