using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ControlDocumentoFactura.Infraestructura.EntityFramework.ReadModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Infraestructura.EntityFramework.Config.ReadConfig {
		public class VueloReadConfig:IEntityTypeConfiguration<VueloReadModel> {
				public void Configure(EntityTypeBuilder<VueloReadModel> builder) {
						builder.ToTable("Vuelo");
						builder.HasKey(x => x.Id);

						builder.Property(x => x.Cantidad)
							 .HasColumnName("cantidad");

						builder.Property(x => x.Detalle)
							.HasColumnName("detalle")
							.HasMaxLength(25);

						builder.Property(x => x.PrecioPasaje)
							 .HasColumnName("precioPasaje")
							 .HasColumnType("decimal")
							 .HasPrecision(12,2);


				}
		}
}
