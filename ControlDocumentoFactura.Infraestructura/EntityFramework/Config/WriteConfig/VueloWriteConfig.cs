using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ControlDocumentoFactura.Dominio.Models.ValueObjects;
using ControlDocumentoFactura.Dominio.Models.Vuelos;
using ControlDocumentoFactura.Infraestructura.EntityFramework.ReadModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Infraestructura.EntityFramework.Config.WriteConfig {
		public class VueloWriteConfig:IEntityTypeConfiguration<Vuelo> {
				public void Configure(EntityTypeBuilder<Vuelo> builder) {
						builder.ToTable("Vuelo");
						builder.HasKey(x => x.Id);

						builder.Property(x => x.Cantidad)
							 .HasColumnName("cantidad");

						builder.Property(x => x.Detalle)
							.HasColumnName("detalle")
							.HasMaxLength(25);
						//--------------------------------
						var montoConverter = new ValueConverter<MontoValue,decimal>(
							 precioValue => precioValue.Value,
							 precio => new MontoValue(precio)
						 );
						builder.Property(x => x.PrecioPasaje)
							.HasColumnName("precioPasaje")
							.HasConversion(montoConverter)
							.HasPrecision(12,2);
						//-----------------------------------


				}
		}
}
