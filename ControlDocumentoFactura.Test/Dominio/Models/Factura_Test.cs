using ControlDocumentoFactura.Dominio.Events.Facturas;
using ControlDocumentoFactura.Dominio.Models.Facturas;
using ShareKernel.Cores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ControlDocumentoFactura.Test.Dominio.Models
{
	public class Factura_Test
	{
		[Fact]
		public void Factura_CheckPropertiesValid()
		{
			decimal montoTest = new(40.0);
			decimal importe = new(40.0);
			string lugar = "SCZ";
			string nitBeneficiario = "654321";
			string razonSocialBeneficiario = "Juan Perez";
			string tipoNit = "ci";
			Guid clienteId = new();
			Guid vueloId = new();
			Guid reservaId = new();
			Guid configFacturaId = new();
			string nroFacturaTest = "1234567890123";


			var objFactura = new Factura(nroFacturaTest);
			Assert.NotEqual(Guid.Empty, objFactura.Id);
			Assert.Equal(Guid.Empty, objFactura.ClienteId);
			Assert.Equal(Guid.Empty, objFactura.VueloId);
			Assert.Equal(Guid.Empty, objFactura.ReservaId);
			Assert.Equal(new decimal(0.0), (decimal)objFactura.Monto);
			Assert.Equal(new decimal(0.0), (decimal)objFactura.Importe);
			Assert.Equal(nroFacturaTest, objFactura.NroFactura);
			Assert.Null(objFactura.Lugar);
			Assert.Null(objFactura.Estado);
			Assert.Null(objFactura.NitBeneficiario);
			Assert.Null(objFactura.RazonSocialBeneficiario);
			Assert.Equal(DateTime.MinValue, objFactura.Fecha);

			objFactura.CrearFactura(montoTest, lugar, tipoNit, nitBeneficiario, razonSocialBeneficiario, clienteId, vueloId, reservaId, configFacturaId);

			Assert.NotEqual(Guid.Empty, objFactura.Id);
			Assert.Equal(clienteId, objFactura.ClienteId);
			Assert.Equal(vueloId, objFactura.VueloId);
			Assert.Equal(reservaId, objFactura.ReservaId);
			Assert.Equal(montoTest, (decimal)objFactura.Monto);
			Assert.Equal(importe, (decimal)objFactura.Importe);
			Assert.Equal(nroFacturaTest, objFactura.NroFactura);
			Assert.Equal(lugar, objFactura.Lugar);
			Assert.Equal("P", objFactura.Estado);
			Assert.Equal(nitBeneficiario, objFactura.NitBeneficiario);
			Assert.Equal(razonSocialBeneficiario, objFactura.RazonSocialBeneficiario);
			Assert.NotEqual(DateTime.MinValue, objFactura.Fecha);

			objFactura.EntregaFactura();
			var domainEventList = (List<DomainEvent>)objFactura.DomainEvents;
			Assert.IsType<FacturaCreadoEvent>(domainEventList[0]);

			objFactura.UpddateEstadoFacturaEntregado();
			Assert.Equal("E", objFactura.Estado);

			Assert.Equal(nroFacturaTest, objFactura.GetNroFactura());


		}
		[Fact]
		public void EstadoFactura_CheckPropertiesValid()
		{
			string nroFacturaTest = "1234567890123";
			var objFactura = new Factura(nroFacturaTest);
			objFactura.UpddateEstadoFacturaEntregado();
			Assert.Equal(objFactura.Estado, "E");

		}
		[Fact]
		public void NroFactura_CheckPropertiesValid()
		{
			string nroFacturaTest = "1234567890123";
			var objFactura = new Factura(nroFacturaTest);
			Assert.Equal(objFactura.GetNroFactura(), nroFacturaTest);

		}
		[Fact]
		public void TestConstructor_IsPrivate()
		{
			var factura = (Factura)Activator.CreateInstance(typeof(Factura), true);
			Assert.Equal(Guid.Empty, factura.Id);
			Assert.Equal(Guid.Empty, factura.ClienteId);
			Assert.Equal(Guid.Empty, factura.VueloId);
			Assert.Null(factura.NroFactura);
			Assert.Null(factura.Lugar);
			Assert.Null(factura.Estado);
			Assert.Null(factura.NitBeneficiario);
			Assert.Null(factura.RazonSocialBeneficiario);
			Assert.Equal(DateTime.MinValue, factura.Fecha);
		}
		[Fact]
		public void Factura_CheckPropertiesFailValid()
		{
			decimal montoTest = new(40.0);
			decimal importe = new(30.0);
			string lugar = "SCZ";
			string nitBeneficiario = "654321";
			string tipoNit = "ci";
			string razonSocialBeneficiario = "Juan Perez";
			Guid clienteId = new();
			Guid vueloId = new();
			Guid reservaId = new();
			Guid configFacturaId = new();
			string nroFacturaTest = "1234567890123";

			Action testCodigoNroFacturaValido = () => { new Factura("1234567890123"); };

			var exception = Record.Exception(testCodigoNroFacturaValido);
			Assert.Null(exception);


			Action testCodigoNroFacturaNulo = () => { new Factura(null); };

			exception = Record.Exception(testCodigoNroFacturaNulo);
			Assert.NotNull(exception);
			Assert.IsType<BussinessRuleValidationException>(exception);


			Action testCodigoNroFacturaVacio = () => { new Factura(""); };

			exception = Record.Exception(testCodigoNroFacturaVacio);
			Assert.NotNull(exception);
			Assert.IsType<BussinessRuleValidationException>(exception);


			var objFactura = new Factura(nroFacturaTest);

			Action testCodigoLugarNull = () =>
			{
				objFactura.CrearFactura(montoTest, null, tipoNit, nitBeneficiario, razonSocialBeneficiario, clienteId, vueloId, reservaId, configFacturaId);

			};
			exception = Record.Exception(testCodigoLugarNull);
			Assert.NotNull(exception);
			Assert.IsType<BussinessRuleValidationException>(exception);

			String lugarLong = "abcdefghijlmnopqrstuvwxyzabcdefghijklmnopqrdtvuwxyz012345678ABCDEFGHIJLMNOPQRSTVUWXYZ01234567890123567890123456789";
			Action testCodigoLugarlargo = () =>
			{
				objFactura.CrearFactura(montoTest, lugarLong, tipoNit, nitBeneficiario, razonSocialBeneficiario, clienteId, vueloId, reservaId, configFacturaId);

			};
			exception = Record.Exception(testCodigoLugarlargo);
			Assert.NotNull(exception);
			Assert.IsType<BussinessRuleValidationException>(exception);


			Action testCodigoMontoNegativo = () =>
			{
				objFactura.CrearFactura(new decimal(-15.0), null, tipoNit, nitBeneficiario, razonSocialBeneficiario, clienteId, vueloId, reservaId, configFacturaId);

			};
			exception = Record.Exception(testCodigoMontoNegativo);
			Assert.NotNull(exception);
			Assert.IsType<BussinessRuleValidationException>(exception);

			Action testCodigoRazonSocialNull = () =>
			{
				objFactura.CrearFactura(montoTest, lugar, tipoNit, nitBeneficiario, null, clienteId, vueloId, reservaId, configFacturaId);

			};
			exception = Record.Exception(testCodigoRazonSocialNull);
			Assert.NotNull(exception);
			Assert.IsType<BussinessRuleValidationException>(exception);

			String razonSocialLong = "JUAN MARIANO CARLOS DE LAS FUENTE GERARDO JULIO SALVADOR MEDRANOL SUAEZ GALLARDO PEÑARRIETA SUBIRANA MEJIA CESAR PEREZ BORJA JIMENEZ CARRASCO ";
			Action testCodigoRazonSocialLargo = () =>
			{
				objFactura.CrearFactura(montoTest, lugar, tipoNit, nitBeneficiario, razonSocialLong, clienteId, vueloId, reservaId, configFacturaId);

			};
			exception = Record.Exception(testCodigoRazonSocialLargo);
			Assert.NotNull(exception);
			Assert.IsType<BussinessRuleValidationException>(exception);





		}
	}
}
