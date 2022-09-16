using ControlDocumentoFactura.Dominio.Events.Facturas;
using ControlDocumentoFactura.Dominio.Models.Facturas;
using ControlDocumentoFactura.Dominio.Repositories.Facturas;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Configuration;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

namespace ControlDocumentoFactura.Aplicacion.UsesCases.Commands.Facturas.EntregarFactura {
	public class EntregarFacturaHandler:INotificationHandler<FacturaCreadoEvent> {
		private readonly IFacturaRepository _facturaRepository;

		public EntregarFacturaHandler(IFacturaRepository facturaRepository) {
			_facturaRepository = facturaRepository;
		}


		public async Task Handle(FacturaCreadoEvent notification,CancellationToken cancellationToken) {
			Factura objProducto = await _facturaRepository.FindByIdAsync(notification.FacturaId);
			Console.WriteLine("Enviando Email Factura....." + notification.FacturaId);
		}
	}
}
