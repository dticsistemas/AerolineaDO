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
				}
		}
}
