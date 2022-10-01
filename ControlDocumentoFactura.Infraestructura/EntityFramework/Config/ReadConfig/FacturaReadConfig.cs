using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ControlDocumentoFactura.Infraestructura.EntityFramework.ReadModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Infraestructura.EntityFramework.Config.ReadConfig {
		public class FacturaReadConfig:IEntityTypeConfiguration<FacturaReadModel> {
				public void Configure(EntityTypeBuilder<FacturaReadModel> builder) {
						builder.ToTable("Factura");
						builder.HasKey(x => x.Id);

						builder.Property(x => x.NroFactura)
							.HasColumnName("nroFactura")
							.HasMaxLength(25);

						builder.Property(x => x.Monto)
							.HasColumnName("monto")
							.HasColumnType("decimal")
							.HasPrecision(12,2);

						builder.Property(x => x.Importe)
							.HasColumnName("importe")
							.HasColumnType("decimal")
							.HasPrecision(12,2);

						builder.Property(x => x.Fecha)
							 .HasColumnName("fecha")
							 .HasColumnType("datetime");

						builder.Property(x => x.Lugar)
							 .HasColumnName("lugar")
							 .HasMaxLength(25);

						builder.Property(x => x.TipoNit)
											.HasColumnName("tipoNit")
											.HasMaxLength(25);

						builder.Property(x => x.NitBeneficiario)
							 .HasColumnName("nitBeneficiario")
							 .HasMaxLength(25);

						builder.Property(x => x.RazonSocialBeneficiario)
							 .HasColumnName("razonSocialBeneficiario")
							 .HasMaxLength(25);

						builder.Property(x => x.NroAutorizacion)
							 .HasColumnName("nroAutorizacion")
							 .HasMaxLength(25);

						builder.Property(x => x.Estado)
							 .HasColumnName("estado")
							 .HasMaxLength(10);


						/*

							public String NroAutorizacion { get; set; }
							public ReservaReadModel Reserva { get; set; }
							public ClienteReadModel Cliente { get; set; }
							public VueloReadModel Vuelo { get; set; }
									 */
				}
		}
}