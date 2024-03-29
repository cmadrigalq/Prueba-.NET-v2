USE [SistemaFacturacionDB]
GO
/****** Object:  Table [dbo].[TArticulo]    Script Date: 3/16/2024 12:38:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TArticulo](
	[Codigo] [varchar](20) NOT NULL,
	[NombreArticulo] [varchar](20) NULL,
	[PrecioArticulo] [decimal](18, 0) NULL,
	[AplicarIVA] [bit] NULL,
	[PrecioConIVA] [decimal](18, 0) NULL,
 CONSTRAINT [pk_codigo] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TDetalle]    Script Date: 3/16/2024 12:38:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TDetalle](
	[CodigoDetalle] [int] NOT NULL,
	[ConsecutivoFactura] [int] NOT NULL,
	[CodigoArticulo] [varchar](20) NOT NULL,
	[Cantidad] [int] NULL,
	[PrecioFinal] [decimal](18, 0) NULL,
 CONSTRAINT [pk_detalle] PRIMARY KEY CLUSTERED 
(
	[CodigoDetalle] ASC,
	[ConsecutivoFactura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TFactura]    Script Date: 3/16/2024 12:38:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TFactura](
	[UsuarioFactura] [int] NULL,
	[ConsecutivoFactura] [int] NOT NULL,
	[FechaFactura] [date] NULL,
	[DetallesFactura] [varchar](50) NULL,
 CONSTRAINT [pk_consecutivo] PRIMARY KEY CLUSTERED 
(
	[ConsecutivoFactura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TUsuario]    Script Date: 3/16/2024 12:38:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TUsuario](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[NombreUsuario] [varchar](20) NULL,
	[Contraseña] [varchar](100) NULL,
 CONSTRAINT [pk_usuario] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TDetalle]  WITH CHECK ADD  CONSTRAINT [fk_articulo] FOREIGN KEY([CodigoArticulo])
REFERENCES [dbo].[TArticulo] ([Codigo])
GO
ALTER TABLE [dbo].[TDetalle] CHECK CONSTRAINT [fk_articulo]
GO
ALTER TABLE [dbo].[TDetalle]  WITH CHECK ADD  CONSTRAINT [fk_consecutivo] FOREIGN KEY([ConsecutivoFactura])
REFERENCES [dbo].[TFactura] ([ConsecutivoFactura])
GO
ALTER TABLE [dbo].[TDetalle] CHECK CONSTRAINT [fk_consecutivo]
GO
ALTER TABLE [dbo].[TFactura]  WITH CHECK ADD  CONSTRAINT [fk_usuario] FOREIGN KEY([UsuarioFactura])
REFERENCES [dbo].[TUsuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[TFactura] CHECK CONSTRAINT [fk_usuario]
GO
/****** Object:  StoredProcedure [dbo].[sp_CrearDetalle]    Script Date: 3/16/2024 12:38:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_CrearDetalle](
@CodigoDetalle int,
@ConsecutivoFactura int,
@CodigoArticulo varchar(20),
@Cantidad int NULL,
@PrecioFinal decimal(18, 0)
)
as
begin
	insert into TDetalle(CodigoDetalle, ConsecutivoFactura , CodigoArticulo, Cantidad, PrecioFinal) 
	values(@CodigoDetalle, @ConsecutivoFactura, @CodigoArticulo, @Cantidad, @PrecioFinal)
end
GO
/****** Object:  StoredProcedure [dbo].[sp_CrearFactura]    Script Date: 3/16/2024 12:38:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_CrearFactura](
@UsuarioFactura int, 
@ConsecutivoFactura int, 
@FechaFactura date, 
@DetallesFactura varchar(50)
)
as
begin
	insert into TFactura(UsuarioFactura, ConsecutivoFactura, FechaFactura, DetallesFactura) values(@UsuarioFactura, @ConsecutivoFactura, @FechaFactura, @DetallesFactura)
end
GO
/****** Object:  StoredProcedure [dbo].[sp_EditarArticulo]    Script Date: 3/16/2024 12:38:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_EditarArticulo](
@Codigo varchar(20),
@NombreArticulo varchar(20),
@PrecioArticulo decimal,
@AplicarIVA bit,
@PrecioConIVA decimal
)
as
begin
	update TArticulo set Codigo = @Codigo, NombreArticulo = @NombreArticulo, PrecioArticulo = @PrecioArticulo, AplicarIVA = @AplicarIVA, PrecioConIVA = @PrecioConIVA 
	where Codigo = @Codigo
end
GO
/****** Object:  StoredProcedure [dbo].[sp_EditarFactura]    Script Date: 3/16/2024 12:38:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_EditarFactura](
@UsuarioFactura int, 
@ConsecutivoFactura int, 
@FechaFactura date, 
@DetallesFactura varchar(50)
)
as
begin
	update TFactura set UsuarioFactura = @UsuarioFactura, ConsecutivoFactura = @ConsecutivoFactura, FechaFactura = @FechaFactura, DetallesFactura = @DetallesFactura 
	where ConsecutivoFactura = @ConsecutivoFactura
end
GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarArticulo]    Script Date: 3/16/2024 12:38:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_EliminarArticulo](
@Codigo varchar(20)
)
as
begin
	delete from TArticulo where Codigo = @Codigo
end
GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarFactura]    Script Date: 3/16/2024 12:38:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_EliminarFactura](
@ConsecutivoFactura int 
)
as
begin
	delete from TFactura where ConsecutivoFactura = @ConsecutivoFactura
end
GO
/****** Object:  StoredProcedure [dbo].[sp_ListarArticulos]    Script Date: 3/16/2024 12:38:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_ListarArticulos]
as
begin
	select * from TArticulo
end
GO
/****** Object:  StoredProcedure [dbo].[sp_ListarFacturas]    Script Date: 3/16/2024 12:38:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_ListarFacturas]
as
begin
	select * from TFactura
end
GO
/****** Object:  StoredProcedure [dbo].[sp_ObtenerArticulo]    Script Date: 3/16/2024 12:38:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_ObtenerArticulo](
@CodigoArticulo varchar(20)
)
as
begin
	select * from TArticulo where Codigo = @CodigoArticulo
end
GO
/****** Object:  StoredProcedure [dbo].[sp_ObtenerDetalle]    Script Date: 3/16/2024 12:38:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_ObtenerDetalle](
@CodigoDetalle varchar(20)
)
as
begin
	select * from TDetalle where CodigoDetalle = @CodigoDetalle
end
GO
/****** Object:  StoredProcedure [dbo].[sp_ObtenerDetallesFactura]    Script Date: 3/16/2024 12:38:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_ObtenerDetallesFactura](
@ConsecutivoFactura int
)
as
begin
	select TDetalle.CodigoDetalle, TDetalle.ConsecutivoFactura, TDetalle.CodigoArticulo, TDetalle.Cantidad, TDetalle.PrecioFinal, TFactura.UsuarioFactura, TFactura.ConsecutivoFactura, TFactura.FechaFactura, TFactura.DetallesFactura
	from TDetalle INNER JOIN TFactura ON TDetalle.ConsecutivoFactura = TFactura.ConsecutivoFactura where TDetalle.ConsecutivoFactura=@ConsecutivoFactura
end
GO
/****** Object:  StoredProcedure [dbo].[sp_ObtenerFactura]    Script Date: 3/16/2024 12:38:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_ObtenerFactura](
@ConsecutivoFactura int
)
as
begin
	select * from TFactura where ConsecutivoFactura = @ConsecutivoFactura
end
GO
/****** Object:  StoredProcedure [dbo].[sp_RegistrarUsuario]    Script Date: 3/16/2024 12:38:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_RegistrarUsuario](
@NombreUsuario varchar(20),
@Contraseña varchar(100),
@Registrado bit output,
@Mensaje varchar(100) output
)
as
begin
if(not exists(select * from TUsuario where NombreUsuario = @NombreUsuario))
	begin
		insert into TUsuario(NombreUsuario, Contraseña) values (@NombreUsuario, @Contraseña)
		set @Registrado = 1
		set @Mensaje = 'Usuario registrado con exito.'
	end
	else
	begin
		set @Registrado = 0
		set @Mensaje = 'Usuario ya existe, ingrese otro nombre de usuario.'
	end
end
GO
/****** Object:  StoredProcedure [dbo].[sp_ValidarUsuario]    Script Date: 3/16/2024 12:38:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_ValidarUsuario](
@NombreUsuario varchar(20),
@Contraseña varchar(100)
)
as
begin
if(exists(select * from TUsuario where NombreUsuario = @NombreUsuario and Contraseña = @Contraseña))
		  select NombreUsuario from TUsuario where NombreUsuario = @NombreUsuario and Contraseña = @Contraseña
	else
	select '0'
end

declare @registrado bit, @mensaje varchar(100)
exec sp_RegistrarUsuario 'logical', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', @registrado output, @mensaje output

select @registrado
select @mensaje

GO
