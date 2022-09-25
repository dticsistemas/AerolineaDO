using ControlDocumentoFactura.Dominio.Models.Reservas;
using ControlDocumentoFactura.Dominio.Models.ValueObjects;
using ShareKernel.Cores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Dominio.Models.Ventas
{
	public class Venta : AggregateRoot<Guid>
	{

		public String Estado;
		public MontoValue Monto;
		public DateTime Fecha;
		public int Tipo;
		public Guid ClienteId;
		public Guid VueloId;

		public Venta()
		{
			Id = Guid.NewGuid();
			Monto = new MontoValue(0m);
			Fecha = DateTime.Now;
			Estado = "C";
			Tipo = 0;
		}
		public void CrearVenta(decimal monto,Guid clienteId, Guid vueloId)
		{
			Monto = monto;			
			ClienteId = clienteId;
			VueloId = vueloId;			
			Estado = "P";

		}


	}
}
