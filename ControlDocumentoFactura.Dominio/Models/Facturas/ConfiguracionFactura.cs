using ControlDocumentoFactura.Dominio.Models.Clientes;
using ControlDocumentoFactura.Dominio.Models.Facturas.ValueObjetcs;
using ControlDocumentoFactura.Dominio.Models.Reservas;
using ControlDocumentoFactura.Dominio.Models.ValueObjects;
using ControlDocumentoFactura.Dominio.Models.Vuelos;
using ShareKernel.Cores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Dominio.Models.Facturas
{
	public class ConfiguracionFactura : AggregateRoot<Guid>
	{

		public DateTime Fecha { get; private set; }
		public NitFacturaValue NitProveedor { get; private set; }
		public RazonSocialValue RazonSocialProveedor { get; private set; }
		public NumeroAutorizacionValue NroAutorizacion { get; private set; }
		public string Estado { get; private set; }
		public ConfiguracionFactura()
		{
			Id = Guid.NewGuid();
			Estado = "A";


		}
		public void CrearConfiguracionFactura(string nitProveedor, string razonSocialProveedor, string nroAutorizacion)
		{
			Fecha = DateTime.Now;
			NitProveedor = nitProveedor;
			RazonSocialProveedor = razonSocialProveedor;
			Estado = "A";
			NroAutorizacion = nroAutorizacion;


		}
		public void UpddateEstadoConfiguracionFacturaInactivo()
		{
			Estado = "I"; ;
		}

	}
}