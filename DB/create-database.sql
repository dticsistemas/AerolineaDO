CREATE DATABASE [FacturasDb]
GO

USE [FacturasDb];
GO

CREATE TABLE product (
    Id INT NOT NULL IDENTITY,
    Name TEXT NOT NULL,
    Description TEXT NOT NULL,
    PRIMARY KEY (Id)
);
GO

CREATE TABLE [dbo].[Cliente](
	[Id] [uniqueidentifier] NOT NULL,
	[nombreCompleto] [nvarchar](500) NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
)ON [PRIMARY];
GO

CREATE TABLE [dbo].[Factura](
	[Id] [uniqueidentifier] NOT NULL,
	[monto] [decimal](12, 2) NOT NULL,
	[importe] [decimal](12, 2) NOT NULL,
	[fecha] [datetime] NOT NULL,
	[nroFactura] [nvarchar](25) NULL,
	[lugar] [nvarchar](25) NULL,
	[nitProveedor] [nvarchar](25) NULL,
	[razonSocialProveedor] [nvarchar](25) NULL,
	[nitBeneficiario] [nvarchar](25) NULL,
	[razonSocialBeneficiario] [nvarchar](25) NULL,
	[nroAutorizacion] [nvarchar](25) NULL,
	[ReservaId] [uniqueidentifier] NULL,
	[ClienteId] [uniqueidentifier] NULL,
	[VueloId] [uniqueidentifier] NULL,
	[estado] [nchar](10) NULL,
 CONSTRAINT [PK_Factura] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY];

GO

CREATE TABLE [dbo].[Pago](
	[Id] [uniqueidentifier] NOT NULL,
	[monto] [decimal](12, 2) NOT NULL,
	[fecha] [datetime] NOT NULL,
	[codComprobante] [nvarchar](25) NULL,
	[ReservaId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Pago] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY];
GO

CREATE TABLE [dbo].[Reserva](
	[Id] [uniqueidentifier] NOT NULL,
	[codReserva] [nvarchar](25) NULL,
	[estadoReserva] [nvarchar](6) NULL,
	[monto] [decimal](12, 2) NOT NULL,
	[deuda] [decimal](12, 2) NOT NULL,
	[fecha] [datetime] NOT NULL,
	[tipoReserva] [nvarchar](6) NULL,
	[ClienteId] [uniqueidentifier] NULL,
	[VueloId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Reserva] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY];
GO
CREATE TABLE [dbo].[Vuelo](
	[Id] [uniqueidentifier] NOT NULL,
	[cantidad] [int] NOT NULL,
	[detalle] [nvarchar](25) NULL,
	[precioPasaje] [decimal](12, 2) NOT NULL,
 CONSTRAINT [PK_Vuelo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY];
GO


INSERT INTO [product] (Name, Description)
VALUES 
('T-Shirt Blue', 'Its blue'),
('T-Shirt Black', 'Its black'); 
GO
INSERT INTO [Vuelo] (Id, cantidad, detalle, precioPasaje)
VALUES 
('3fa85f64-5717-4562-b3fc-2c963f66afa8',125,'SC_LP','45.0'); 
GO
INSERT INTO [Cliente] (Id, nombreCompleto)
VALUES 
('3fa85f64-5717-4562-b3fc-2c963f66afa7', 'Juan Perez Perez'); 
GO
INSERT INTO [Reserva] (Id, codReserva,estadoReserva,monto,deuda,fecha,tipoReserva,ClienteId,VueloId)
VALUES 
('3fa85f64-5717-4562-b3fc-2c963f66afa6', 'ABC123','R','755.0','755.0','2022-01-01 05:00:00','R','3fa85f64-5717-4562-b3fc-2c963f66afa7','3fa85f64-5717-4562-b3fc-2c963f66afa8'); 
GO

/**"ReservaDbConnectionString":"DefaultConnection": "Server=127.0.0.1;Database=DemoApi;User Id=sa;Password=Password123!;"**/