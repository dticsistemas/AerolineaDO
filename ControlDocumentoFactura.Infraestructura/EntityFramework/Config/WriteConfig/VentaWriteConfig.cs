using ControlDocumentoFactura.Dominio.Models.Reservas.ValueObjects;
using ControlDocumentoFactura.Dominio.Models.Reservas;
using ControlDocumentoFactura.Dominio.Models.ValueObjects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlDocumentoFactura.Dominio.Models.Ventas;

namespace ControlDocumentoFactura.Infraestructura.EntityFramework.Config.WriteConfig
{
	public class VentaWriteConfig : IEntityTypeConfiguration<Venta>
	{
		public void Configure(EntityTypeBuilder<Venta> builder)
		{
			builder.ToTable("Venta");
			builder.HasKey(x => x.Id);
			//-------------------------------
			var nroReservaConverter = new ValueConverter<CodigoReservaValue, string>(
				nroReservaValue => nroReservaValue.Value,
				nroReserva => new CodigoReservaValue(nroReserva)
			);
			
			//-------------------------------

			builder.Property(x => x.Estado)
				.HasColumnName("estado")
				.HasMaxLength(6);
			//--------------------------------
			var montoConverter = new ValueConverter<MontoValue, decimal>(
					precioValue => precioValue.Value,
					precio => new MontoValue(precio)
				);
			builder.Property(x => x.Monto)
				.HasConversion(montoConverter)
				.HasColumnName("monto")
				.HasPrecision(12, 2);
			//-----------------------------------

			builder.Property(x => x.Fecha)
				.HasColumnName("fecha")
				.HasColumnType("datetime");

			builder.Property(x => x.Tipo)
				.HasColumnName("tipoReserva"); 

			builder.Property(x => x.ClienteId)
				.HasColumnName("clienteId");

			builder.Property(x => x.VueloId)
				.HasColumnName("vueloId");


			builder.Ignore("_domainEvents");
			builder.Ignore(x => x.DomainEvents);
			//builder.Ignore(x => x.ClienteId);
			//builder.Ignore(x => x.VueloId);
		}
	}
}
