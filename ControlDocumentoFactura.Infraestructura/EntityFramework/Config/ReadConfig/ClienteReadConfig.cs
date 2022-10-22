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
	public class ClienteReadConfig : IEntityTypeConfiguration<ClienteReadModel>
	{
		public void Configure(EntityTypeBuilder<ClienteReadModel> builder)
		{
			builder.ToTable("Cliente");
			builder.HasKey(x => x.Id);

			builder.Property(x => x.NombreCompleto)
				.HasMaxLength(500)
				.HasColumnName("nombreCompleto");
			builder.Property(x => x.Name)
							.HasMaxLength(100)
							.HasColumnName("name");
			builder.Property(x => x.LastName)
							.HasMaxLength(100)
							.HasColumnName("lastName");
			builder.Property(x => x.Passport)
							.HasMaxLength(100)
							.HasColumnName("passport");
			builder.Property(x => x.NeedAssistance)
							.HasMaxLength(100)
							.HasColumnName("needAssistance");
			builder.Property(x => x.Nit)
							.HasMaxLength(100)
							.HasColumnName("nit");
			builder.Property(x => x.Email)
							.HasMaxLength(100)
							.HasColumnName("email");
			builder.Property(x => x.Phone)
							.HasMaxLength(100)
							.HasColumnName("phone");

		}
	}
}
