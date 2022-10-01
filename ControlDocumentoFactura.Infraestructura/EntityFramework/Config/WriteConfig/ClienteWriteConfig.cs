using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ControlDocumentoFactura.Dominio.Models.Clientes;
using ControlDocumentoFactura.Dominio.Models.Clientes.ValueObjects;
using ControlDocumentoFactura.Infraestructura.EntityFramework.ReadModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Infraestructura.EntityFramework.Config.WriteConfig {
		public class ClienteWriteConfig:IEntityTypeConfiguration<Cliente> {
				public void Configure(EntityTypeBuilder<Cliente> builder) {
						builder.ToTable("Cliente");
						builder.HasKey(x => x.Id);
						//------------------------
						var nombreConverter = new ValueConverter<PersonNameValue,String>(
							 nombreValue => nombreValue.Value,
							 nombre => new PersonNameValue(nombre)
						 );
						//-------------------------
						builder.Property(x => x.NombreCompleto)
							.HasMaxLength(500)
							.HasConversion(nombreConverter)
							.HasColumnName("nombreCompleto");
						builder.Property(x => x.Name)
										.HasMaxLength(100)
										.HasConversion(nombreConverter)
										.HasColumnName("name");
						builder.Property(x => x.LastName)
										.HasMaxLength(100)
										.HasConversion(nombreConverter)
										.HasColumnName("lastName");
						//-------------------------
						var datosConverter = new ValueConverter<PersonDataValue, String>(
											dataValue => dataValue.Value,
											data => new PersonDataValue(data)
										);

						//-------------------------
						builder.Property(x => x.Passport)
										.HasMaxLength(100)
										.HasConversion(datosConverter)
										.HasColumnName("passport");
						builder.Property(x => x.NeedAssistance)
										.HasMaxLength(100)
										.HasConversion(datosConverter)
										.HasColumnName("needAssistance");
						builder.Property(x => x.Nit)
										.HasMaxLength(100)
										.HasConversion(datosConverter)
										.HasColumnName("nit");
						builder.Property(x => x.Email)
										.HasMaxLength(100)
										.HasConversion(datosConverter)
										.HasColumnName("email");
						builder.Property(x => x.Phone)
										.HasMaxLength(100)
										.HasConversion(datosConverter)
										.HasColumnName("phone");





		}
		}
}
