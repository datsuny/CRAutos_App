USE [master]
GO

CREATE DATABASE [CrAutosDB]
GO

USE [CrAutosDB]
GO

/*---------------------------------------------------------------------------------------------------------*/
CREATE TABLE [dbo].[TBExtra](
	[IDExtra] [bigint] IDENTITY(1,1) NOT NULL,
	[NombreExtra] [varchar](255) NOT NULL,
 CONSTRAINT [PK_TBExtra] PRIMARY KEY CLUSTERED 
(
		[IDExtra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/*---------------------------------------------------------------------------------------------------------*/
CREATE TABLE [dbo].[TBMarca](
	[IDMarca] [bigint] IDENTITY(1,1) NOT NULL,
	[NombreMarca] [varchar](255) NOT NULL,
 CONSTRAINT [PK_TBMarca] PRIMARY KEY CLUSTERED 
(
	[IDMarca] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/*---------------------------------------------------------------------------------------------------------*/
CREATE TABLE [dbo].[TBVehiculo](
	[IDVehiculo] [bigint] IDENTITY(1,1) NOT NULL,
	[Matricula] [varchar](50) NOT NULL,
	[IDMarca][bigint] NULL,
	[TipoModelo] [varchar](60) NOT NULL,
 CONSTRAINT [PK_TBVehiculo] PRIMARY KEY CLUSTERED 
(
	[IDVehiculo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/*FK DE LA MARCA PARA EL VEHICULO*/
ALTER TABLE [dbo].[TBVehiculo]  WITH CHECK ADD  CONSTRAINT [FK_IDMarca] FOREIGN KEY([IDMarca])
REFERENCES [dbo].[TBMarca] ([IDMarca])
GO

ALTER TABLE [dbo].[TBVehiculo] CHECK CONSTRAINT [FK_IDMarca]
GO

/*---------------------------------------------------------------------------------------------------------*/
CREATE TABLE [dbo].[TBDetalleVehiculo](
	[IDDetalleVehiculo] [bigint] IDENTITY(1,1) NOT NULL,
	[IDVehiculo] [bigint]  NOT NULL,
	[Kilometraje] [decimal] NOT NULL,
	[Cilindraje] [varchar](50) NOT NULL,
	[Transmision] [varchar](50) NOT NULL,
	[Color] [varchar](50) NOT NULL,
	[NumeroPuertas] [int] NOT NULL,
	[Año] [int] NOT NULL,
	[Combustible] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TBDetalleVehiculo] PRIMARY KEY CLUSTERED 
(
	[IDDetalleVehiculo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/*FK DEL VEHICULO PARA EL DETALLE VEHICULO*/
ALTER TABLE [dbo].[TBDetalleVehiculo]  WITH CHECK ADD  CONSTRAINT [FK_IDVehiculo] FOREIGN KEY([IDVehiculo])
REFERENCES [dbo].[TBVehiculo] ([IDVehiculo])
GO

ALTER TABLE [dbo].[TBDetalleVehiculo] CHECK CONSTRAINT [FK_IDVehiculo]
GO

/*---------------------------------------------------------------------------------------------------------*/
CREATE TABLE [dbo].[TBExtrasVehiculo](
	[IDExtraVehiculo] [bigint] IDENTITY(1,1) NOT NULL,
	[IDVehiculo] [bigint] NOT NULL,
	[IDExtra] [bigint] NOT NULL,
 CONSTRAINT [PK_TBExtrasVehiculo] PRIMARY KEY CLUSTERED 
(
	[IDExtraVehiculo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/*FK DE LAS EXTRAS QUE TIENE EL VEHICULO */
ALTER TABLE [dbo].[TBExtrasVehiculo]  WITH CHECK ADD  CONSTRAINT [FK_IDExtra] FOREIGN KEY([IDExtra])
REFERENCES [dbo].[TBExtra] ([IDExtra])
GO

ALTER TABLE [dbo].[TBExtrasVehiculo] CHECK CONSTRAINT [FK_IDExtra]
GO

/*FK DE EXTRAS PARA EL VEHICULO */
ALTER TABLE [dbo].[TBExtrasVehiculo]  WITH CHECK ADD  CONSTRAINT [FK_IDVehiculos] FOREIGN KEY([IDVehiculo])
REFERENCES [dbo].[TBVehiculo] ([IDVehiculo])
GO

ALTER TABLE [dbo].[TBExtrasVehiculo] CHECK CONSTRAINT [FK_IDVehiculos]
GO


/*---------------------------------------------------------------------------------------------------------*/
CREATE TABLE [dbo].[TBFotos](
	[IDFoto] [bigint] IDENTITY(1,1) NOT NULL,
	[Imagen] [varchar](2000) NULL,
	[IDVehiculo] [bigint] NOT NULL,
 CONSTRAINT [PK_IDFoto] PRIMARY KEY CLUSTERED 
(
	[IDFoto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/*FK DEL VEHICULO PARA EL FOTOS*/
ALTER TABLE [dbo].[TBFotos]  WITH CHECK ADD  CONSTRAINT [FK_IDVehiculoFoto] FOREIGN KEY([IDVehiculo])
REFERENCES [dbo].[TBVehiculo] ([IDVehiculo])
GO

ALTER TABLE [dbo].[TBFotos] CHECK CONSTRAINT [FK_IDVehiculoFoto]
GO

/*---------------------------------------------------------------------------------------------------------*/
CREATE TABLE [dbo].[TBTipoVendedor](
	[IDTipoVendedor] [bigint] IDENTITY(1,1) NOT NULL,
	[NombreTipo] [varchar](50) NOT NULL,
 CONSTRAINT [PK_IDTipoVendedor] PRIMARY KEY CLUSTERED 
(
	[IDTipoVendedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/*---------------------------------------------------------------------------------------------------------*/
CREATE TABLE [dbo].[TBVendedor](
	[IDVendedor] [bigint] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido1] [varchar](50) NOT NULL,
	[Apellido2] [varchar](50) NOT NULL,
	[Telefono] [varchar](9) NOT NULL,
	[Correo] [varchar](100) NOT NULL,
	[IDTipoVendedor] [bigint] NULL,
	[Empresa] [varchar](50) NULL,
	[Calificación] [int] NULL,
 CONSTRAINT [PK_IDVendedor] PRIMARY KEY CLUSTERED 
(
	[IDVendedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/*FK DEL TIPO DE VENDEDOR PARA EL REGISTRO DE VENDEDORES*/
ALTER TABLE [dbo].[TBVendedor]  WITH CHECK ADD  CONSTRAINT [FK_IDTipoVendedor] FOREIGN KEY([IDTipoVendedor])
REFERENCES [dbo].[TBTipoVendedor] ([IDTipoVendedor])
GO

ALTER TABLE [dbo].[TBVendedor] CHECK CONSTRAINT [FK_IDTipoVendedor]
GO

/*---------------------------------------------------------------------------------------------------------*/
CREATE TABLE [dbo].[TBUsuario](
	[IDUsuario] [bigint] IDENTITY(1,1) NOT NULL,
	[NombreUsuario][varchar](50) NOT NULL,
	[Contrasenna] [varchar](50) NOT NULL,
	[IDVendedor] [bigint] NOT NULL,
 CONSTRAINT [PK_IDUsuario] PRIMARY KEY CLUSTERED 
(
	[IDUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/*FK DEL VENDEDOR PARA EL REGISTRO DE USUARIOS/CUENTAS DE LOGIN*/
ALTER TABLE [dbo].[TBUsuario]  WITH CHECK ADD  CONSTRAINT [FK_IDVendedor] FOREIGN KEY([IDVendedor])
REFERENCES [dbo].[TBVendedor] ([IDVendedor])
GO

ALTER TABLE [dbo].[TBUsuario] CHECK CONSTRAINT [FK_IDVendedor]
GO

/*---------------------------------------------------------------------------------------------------------*/
CREATE TABLE [dbo].[TBCondicionVehiculo](
	[IDCondicion] [bigint] IDENTITY(1,1) NOT NULL,
	[CondicionVehiculo] [varchar](50) NOT NULL,
 CONSTRAINT [PK_IDCondicion] PRIMARY KEY CLUSTERED 
(
	[IDCondicion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/*---------------------------------------------------------------------------------------------------------*/
CREATE TABLE [dbo].[TBEstatusPublicacion](
	[IDEstatus] [bigint] IDENTITY(1,1) NOT NULL,
	[Estatus] [varchar](50) NOT NULL,
 CONSTRAINT [PK_IDEstatus] PRIMARY KEY CLUSTERED 
(
	[IDEstatus] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/*---------------------------------------------------------------------------------------------------------*/
CREATE TABLE [dbo].[TBPublicaciones](
	[IDPublicacion] [bigint] IDENTITY(1,1) NOT NULL,
	[TituloPublicacion] [varchar](100) NOT NULL,
	[IDVehiculo] [bigint] NOT NULL,
	[Imagen] [varchar](2000) NOT NULL,
	[Fecha] [Datetime] NOT NULL,
	[Precio] [decimal] NOT NULL,
	[Descripcion] [varchar](255) NULL,
	[Ubicacion] [varchar](100) NOT NULL,
	[IDVendedor] [bigint] NOT NULL,
	[IDEstatus][bigint] NOT NULL,
	[IDCondicion][bigint] NOT NULL,
 CONSTRAINT [PK_IDPublicacion] PRIMARY KEY CLUSTERED 
(
	[IDPublicacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/*FK DEL VENDEDOR PARA LAS PUBLICACIONES*/
ALTER TABLE [dbo].[TBPublicaciones]  WITH CHECK ADD  CONSTRAINT [FK_IDVendedorPublicacion] FOREIGN KEY([IDVendedor])
REFERENCES [dbo].[TBVendedor] ([IDVendedor])
GO

ALTER TABLE [dbo].[TBPublicaciones] CHECK CONSTRAINT [FK_IDVendedorPublicacion]
GO

/*FK DEL VEHICULO PARA LAS PUBLICACIONES*/
ALTER TABLE [dbo].[TBPublicaciones]  WITH CHECK ADD  CONSTRAINT [FK_IDVehiculoPublicacion] FOREIGN KEY([IDVehiculo])
REFERENCES [dbo].[TBVehiculo] ([IDVehiculo])
GO

ALTER TABLE [dbo].[TBPublicaciones] CHECK CONSTRAINT [FK_IDVehiculoPublicacion]
GO

/*FK DEL ESTATUS PARA LAS PUBLICACIONES*/
ALTER TABLE [dbo].[TBPublicaciones]  WITH CHECK ADD  CONSTRAINT [FK_IDEstatus] FOREIGN KEY([IDEstatus])
REFERENCES [dbo].[TBEstatusPublicacion] ([IDEstatus])
GO

ALTER TABLE [dbo].[TBPublicaciones] CHECK CONSTRAINT [FK_IDEstatus]
GO

/*FK DE LA CONDICION DEL AUTO PARA LAS PUBLICACIONES*/
ALTER TABLE [dbo].[TBPublicaciones]  WITH CHECK ADD  CONSTRAINT [FK_IDCondicionPublicacion] FOREIGN KEY([IDCondicion])
REFERENCES [dbo].[TBCondicionVehiculo] ([IDCondicion])
GO

ALTER TABLE [dbo].[TBPublicaciones] CHECK CONSTRAINT [FK_IDCondicionPublicacion]
GO
/*-----------------------------------------------------------------------------------------*/

/*Procedimiento almacenado*/
create procedure mostrarPublicacion 
as
select a.TituloPublicacion, a.Fecha, a.Precio, a.Descripcion, a.Ubicacion,a.Imagen ,
b.Kilometraje, b.Cilindraje, b.Transmision, b.Color, b.NumeroPuertas, b.Año, b.Combustible, 
c.Nombre, c.Apellido1, c.Apellido2, c.Telefono, c.Correo 
from TBPublicaciones a, TBDetalleVehiculo b,TBVendedor c
where a.IDVehiculo = b.IDVehiculo and a.IDVendedor=c.IDVendedor;

/*Area inserts a la base de datos */

insert into TBTipoVendedor values('Vendedor casual');

insert into TBMarca values ('Toyota');
insert into TBMarca values ('Kia');
insert into TBMarca values ('Nissan');
insert into TBMarca values ('Hyundai');
insert into TBMarca values ('Mazda');
insert into TBMarca values ('Suzuki');
insert into TBMarca values ('Mitsubishi');

insert into TBCondicionVehiculo values('Usado');
insert into TBCondicionVehiculo values('Nuevo');

insert into TBEstatusPublicacion values('En venta');
insert into TBEstatusPublicacion values('Vendido');

insert into TBExtra values('Bolsas de aire');
insert into TBExtra values('Sensores y cámara de visión trasera');
insert into TBExtra values('Vidrios tintados');
insert into TBExtra values('Vidrios eléctricos');
insert into TBExtra values('Alarma');
insert into TBExtra values('Aire acondicionado');
insert into TBExtra values('Frenos ABS');
insert into TBExtra values('Radio con USB/AUX');
insert into TBExtra values('Bluetooth');
insert into TBExtra values('Volante ajustable');



