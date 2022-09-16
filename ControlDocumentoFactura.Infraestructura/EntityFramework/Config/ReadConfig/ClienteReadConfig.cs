using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ControlDocumentoFactura.Infraestructura.EntityFramework.ReadModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Infraestructura.EntityFramework.Config.ReadConfig {
		public class ClienteReadConfig:IEntityTypeConfiguration<ClienteReadModel> {
				public void Configure(EntityTypeBuilder<ClienteReadModel> builder) {
						builder.ToTable("Cliente");
						builder.HasKey(x => x.Id);

						builder.Property(x => x.NombreCompleto)
							.HasMaxLength(500)
							.HasColumnName("nombreCompleto");
				}
		}
}
