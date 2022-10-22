using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ControlDocumentoFactura.Infraestructura.EntityFramework.ReadModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Infraestructura.EntityFramework.Config.ReadConfig
{
	public class VueloReadConfig : IEntityTypeConfiguration<VueloReadModel>
	{
		public void Configure(EntityTypeBuilder<VueloReadModel> builder)
		{
			builder.ToTable("Vuelo");
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Flight_program_id)
					.HasColumnName("flight_program_id");

			builder.Property(x => x.Source_airport_code)
				.HasColumnName("source_airport_code")
				.HasMaxLength(100);
			builder.Property(x => x.Destiny_airport_code)
				.HasColumnName("destiny_airport_code")
				.HasMaxLength(100);
			builder.Property(x => x.Status)
							.HasColumnName("status")
							.HasMaxLength(100);
			builder.Property(x => x.Information)
							.HasColumnName("information")
							.HasMaxLength(300);



		}
	}
}
