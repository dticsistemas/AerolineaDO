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
	public class VentaReadConfig : IEntityTypeConfiguration<VentaReadModel>
	{
		public void Configure(EntityTypeBuilder<VentaReadModel> builder)
		{
			builder.ToTable("Reserva");
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Estado)
				.HasColumnName("estadoReserva")
				.HasMaxLength(6);

			builder.Property(x => x.Monto)
				.HasColumnName("monto")
				.HasColumnType("decimal")
				.HasPrecision(12, 2);

			builder.Property(x => x.Fecha)
				.HasColumnName("fecha")
				.HasColumnType("datetime");

			builder.Property(x => x.Tipo)
				.HasColumnName("tipoReserva")
				.HasMaxLength(6);


			/* builder.Property(x => x.ClienteId)
									.HasColumnName("clienteId");

							builder.Property(x => x.VueloId)
									.HasColumnName("vueloId");
						*/


		}
	}
}
