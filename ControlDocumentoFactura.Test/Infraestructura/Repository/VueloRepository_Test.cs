using ControlDocumentoFactura.Dominio.Models.Vuelos;
using ControlDocumentoFactura.Infraestructura.EntityFramework.Contexts;
using ControlDocumentoFactura.Infraestructura.EntityFramework.Repository;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ControlDocumentoFactura.Test.Infraestructura.Repository
{
	public class VueloRepository_Test
	{
		private readonly Mock<DbSet<Vuelo>> _vuelos;
		private readonly Mock<WriteDbContext> context;

		public VueloRepository_Test()
		{
			_vuelos = new Mock<DbSet<Vuelo>>();
			context = new Mock<WriteDbContext>();


		}
		/*[Fact]
		public Task CreateAsync_Test()
		{
			//context.Setup(x => x.Vuelo).Returns(_vuelos.Object);
			/*
			Vuelo obj = new Vuelo();
			VueloRepository vRepositoryTest = new VueloRepository(context.Object);
			Assert.NotNull(obj);
			return Task.CompletedTask;
		}*/
	}
}
