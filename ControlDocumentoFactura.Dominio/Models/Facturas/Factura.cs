using ControlDocumentoFactura.Dominio.Events.Facturas;
using ControlDocumentoFactura.Dominio.Models.Facturas.ValueObjetcs;
using ControlDocumentoFactura.Dominio.Models.ValueObjects;
using ShareKernel.Cores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Dominio.Models.Facturas {
	public class Factura:AggregateRoot<Guid> {

		public MontoValue Monto { get; private set; }
		public MontoValue Importe { get; private set; }
		public DateTime Fecha { get; private set; }
		public NumeroFacturaValue NroFactura { get; private set; }
		public DescripcionLugarValue Lugar { get; private set; }

		public NitFacturaValue NitProveedor { get; private set; }
		public RazonSocialValue RazonSocialProveedor { get; private set; }
		public NitFacturaValue NitBeneficiario { get; private set; }
		public RazonSocialValue RazonSocialBeneficiario { get; private set; }
		public NumeroAutorizacionValue NroAutorizacion { get; private set; }

		public Guid ReservaId { get; private set; }
		public Guid ClienteId { get; private set; }

		public Guid VueloId { get; private set; }

		public string Estado { get; private set; }




		private Factura() { }
		public Factura(String nroFactura) {
			Id = Guid.NewGuid();
			Monto = new MontoValue(0m);
			Importe = new MontoValue(0m);
			NroFactura = nroFactura;

		}
		public void CrearFactura(decimal monto,decimal importe,string lugar,string nitBeneficiario,string razonSocialBeneficiario,Guid clienteId,Guid vueloId,Guid reservaId) {
			Monto = monto;
			Importe = importe;
			Fecha = DateTime.Now;
			ReservaId = reservaId;
			ClienteId = clienteId;
			VueloId = vueloId;
			Lugar = lugar;
			NitProveedor = "1241545";
			RazonSocialProveedor = "AEROPRO";
			NitBeneficiario = nitBeneficiario;
			RazonSocialBeneficiario = razonSocialBeneficiario;
			NroAutorizacion = "1";
			Estado = "P";

		}

		public void EntregaFactura() {
			var evento = new FacturaCreadoEvent(Monto,Id,ClienteId,ReservaId);
			AddDomainEvent(evento);
		}

		public void UpddateEstadoFacturaEntregado() {
			Estado = "E"; ;
		}
		public string GetNroFactura() {
			return NroFactura;
		}

	}
}
