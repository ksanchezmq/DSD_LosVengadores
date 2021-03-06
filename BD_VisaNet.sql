CREATE DATABASE BD_VisaNet
GO

USE [BD_VisaNet]
GO


/****** Object:  Table [dbo].[Cliente]    Script Date: 3/04/2016 12:17:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cliente](
	[CodAfiliado] [int] NOT NULL,
	[Nombre] [nvarchar](150) NULL,
	[DNI] [int] NOT NULL,
	[Direccion] [nvarchar](200) NULL,
	[RUC] [nvarchar](11) NULL,
	[Estado] [smallint] NULL,
	[CodTipoPos] [smallint] NULL,
	[NumSerie] [varchar](50) NULL,
	[Correo] [nvarchar](60) NULL,
 CONSTRAINT [PK_tb001_cliente] PRIMARY KEY CLUSTERED 
(
	[CodAfiliado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EstadoSolicitud]    Script Date: 3/04/2016 12:17:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EstadoSolicitud](
	[Codigo] [smallint] NOT NULL,
	[Descripcion] [nvarchar](100) NULL,
 CONSTRAINT [PK_tb002_estado] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Pos]    Script Date: 3/04/2016 12:17:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Pos](
	[Codigo] [varchar](50) NOT NULL,
	[Marca] [nvarchar](100) NULL,
	[Modelo] [nvarchar](100) NULL,
 CONSTRAINT [pk_n004_codigo] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Solicitud]    Script Date: 3/04/2016 12:17:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Solicitud](
	[Codigo] [bigint] IDENTITY(1,1) NOT NULL,
	[CodEstado] [int] NOT NULL,
	[CodAfiliado] [int] NOT NULL,
	[FechaHora] [datetime] NOT NULL,
	[Observacion] [nvarchar](200) NULL,
 CONSTRAINT [pk_n005_codigo] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TipoPos]    Script Date: 3/04/2016 12:17:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoPos](
	[Codigo] [smallint] NOT NULL,
	[Descripcion] [nvarchar](100) NULL,
 CONSTRAINT [PK_tb003_pos] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[Cliente] ([CodAfiliado], [Nombre], [DNI], [Direccion], [RUC], [Estado], [CodTipoPos], [NumSerie], [Correo]) VALUES (1, N'Cesar Elias Vicuña', 45964729, N'Bayovar Norte 195 Surco', N'10459647291', 2, 1, N'1', N'cesarelias@gmail.com')
INSERT [dbo].[Cliente] ([CodAfiliado], [Nombre], [DNI], [Direccion], [RUC], [Estado], [CodTipoPos], [NumSerie], [Correo]) VALUES (2, N'Noemi Arce Toribio', 42578978, N'Av. Los Próceres', N'10425789782', 1, 2, N'2', N'noemiarce@gmail.com')
INSERT [dbo].[Cliente] ([CodAfiliado], [Nombre], [DNI], [Direccion], [RUC], [Estado], [CodTipoPos], [NumSerie], [Correo]) VALUES (3, N'Juan Perez Valdivia', 12345678, N'Los Ficus 300 La Molina', N'10123456789', 2, 2, N'1', N'juanperez@gmail.com')
INSERT [dbo].[Cliente] ([CodAfiliado], [Nombre], [DNI], [Direccion], [RUC], [Estado], [CodTipoPos], [NumSerie], [Correo]) VALUES (4, N'Pedro Navaja', 87654321, N'Av. Benavides 234 Miraflroes', N'10876543211', 2, 1, N'2', N'pedronavaja@gmail.com')
INSERT [dbo].[Cliente] ([CodAfiliado], [Nombre], [DNI], [Direccion], [RUC], [Estado], [CodTipoPos], [NumSerie], [Correo]) VALUES (5, N'Jhonny  Morales', 43657617, N'Av. Tupac Amaru Km 12  Comas', N'10436576175', 2, 1, N'1', N'jmorales0786@gmail.com')
INSERT [dbo].[Cliente] ([CodAfiliado], [Nombre], [DNI], [Direccion], [RUC], [Estado], [CodTipoPos], [NumSerie], [Correo]) VALUES (6, N'Graziella Villafuerte', 44758845, N'Av. 200 Millas', N'10447588451', 2, 2, N'1', N'graziellavillafuerte@gmail.com')
INSERT [dbo].[EstadoSolicitud] ([Codigo], [Descripcion]) VALUES (1, N'Registrado')
INSERT [dbo].[EstadoSolicitud] ([Codigo], [Descripcion]) VALUES (2, N'En Proceso')
INSERT [dbo].[EstadoSolicitud] ([Codigo], [Descripcion]) VALUES (3, N'Rechazado')
INSERT [dbo].[EstadoSolicitud] ([Codigo], [Descripcion]) VALUES (4, N'Instalado')
INSERT [dbo].[Pos] ([Codigo], [Marca], [Modelo]) VALUES (N'1', N'Motion', N'A')
INSERT [dbo].[Pos] ([Codigo], [Marca], [Modelo]) VALUES (N'2', N'Motion', N'B')
SET IDENTITY_INSERT [dbo].[Solicitud] ON 

INSERT [dbo].[Solicitud] ([Codigo], [CodEstado], [CodAfiliado], [FechaHora], [Observacion]) VALUES (1, 3, 5, CAST(0x0000A5CE0046E8C5 AS DateTime), N'Cliente tiene deuda registrada en SBS')
INSERT [dbo].[Solicitud] ([Codigo], [CodEstado], [CodAfiliado], [FechaHora], [Observacion]) VALUES (2, 2, 3, CAST(0x0000A5CE00B2BBFF AS DateTime), N'Solicitud en proceso.')
INSERT [dbo].[Solicitud] ([Codigo], [CodEstado], [CodAfiliado], [FechaHora], [Observacion]) VALUES (3, 1, 1, CAST(0x0000A5CE0109AB91 AS DateTime), NULL)
INSERT [dbo].[Solicitud] ([Codigo], [CodEstado], [CodAfiliado], [FechaHora], [Observacion]) VALUES (4, 1, 4, CAST(0x0000A5DD0045ABB1 AS DateTime), NULL)
INSERT [dbo].[Solicitud] ([Codigo], [CodEstado], [CodAfiliado], [FechaHora], [Observacion]) VALUES (7, 1, 6, CAST(0x0000A5DD010802DD AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Solicitud] OFF
INSERT [dbo].[TipoPos] ([Codigo], [Descripcion]) VALUES (1, N'Inalámbrico')
INSERT [dbo].[TipoPos] ([Codigo], [Descripcion]) VALUES (2, N'Fijo')
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD FOREIGN KEY([CodTipoPos])
REFERENCES [dbo].[TipoPos] ([Codigo])
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD FOREIGN KEY([CodTipoPos])
REFERENCES [dbo].[TipoPos] ([Codigo])
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD FOREIGN KEY([Estado])
REFERENCES [dbo].[EstadoSolicitud] ([Codigo])
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD FOREIGN KEY([Estado])
REFERENCES [dbo].[EstadoSolicitud] ([Codigo])
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD FOREIGN KEY([NumSerie])
REFERENCES [dbo].[Pos] ([Codigo])
GO
ALTER TABLE [dbo].[Solicitud]  WITH CHECK ADD FOREIGN KEY([CodAfiliado])
REFERENCES [dbo].[Cliente] ([CodAfiliado])
GO


----------------------------------------------------------------------------------------------------------

/****** Object:  StoredProcedure [dbo].[uspActualizarSolicitud]    Script Date: 3/04/2016 12:17:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspActualizarSolicitud]
	@codigoSolicitud bigint,
	@codigoEstado int,
	@observacion nvarchar(200) 
AS
BEGIN
	UPDATE [dbo].[Solicitud]
	SET CodEstado = @codigoEstado,
		Observacion = @Observacion
	WHERE Codigo = @codigoSolicitud
END
GO
/****** Object:  StoredProcedure [dbo].[uspGenerarSolicitudCliente]    Script Date: 3/04/2016 12:17:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspGenerarSolicitudCliente] 
	@codigoCliente int
AS
BEGIN
	INSERT [dbo].[Solicitud](CodEstado, CodAfiliado, FechaHora)
	SELECT 1, @codigoCliente, GETUTCDATE()
	
	SELECT  SCOPE_IDENTITY()
END



GO
/****** Object:  StoredProcedure [dbo].[uspObtenerCliente]    Script Date: 3/04/2016 12:17:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspObtenerCliente] @codigo smallint
AS
SELECT	CODAFILIADO,
		NOMBRE,
		DNI,
		DIRECCION,
		RUC,
		ESTADO, 
		ESTADODESCRIPCION = CASE WHEN ESTADO = 1 THEN 'Activo' ELSE 'Inactivo' END,
		CODTIPOPOS,
		CORREO
FROM CLIENTE C
WHERE CODAFILIADO = @codigo




GO
/****** Object:  StoredProcedure [dbo].[uspObtenerSolicitudes]    Script Date: 3/04/2016 12:17:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspObtenerSolicitudes]
	@codigoSolicitud INT =  null
AS
BEGIN
	
	SET @codigoSolicitud = COALESCE(@codigoSolicitud, 0)
	
	SELECT	CODIGOSOLICITUD = S.CODIGO,
			ESTADODESCRIPTION = es.DESCRIPCION,
			FECHAHORA = CONVERT(nvarchar(10), S.FECHAHORA, 111),
			S.CODAFILIADO,
			NOMBRECLIENTE = c.NOMBRE,
			c.DNI,
			c.RUC
	FROM [dbo].[Solicitud] s
	INNER JOIN [dbo].[EstadoSolicitud] es ON s.CodEstado = es.Codigo
	INNER JOIN [dbo].[Cliente] c ON c.CodAfiliado = s.CodAfiliado
	WHERE @codigoSolicitud = 0 OR @codigoSolicitud = s.Codigo

END



GO
/****** Object:  StoredProcedure [dbo].[uspValidarCodigoCliente]    Script Date: 3/04/2016 12:17:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspValidarCodigoCliente] @codigo smallint
AS
--DECLARE @codigo SMALLINT = 6
DECLARE @valida bit
SET  @valida = (select CONVERT(BIT,COUNT(*))
FROM CLIENTE
WHERE codafiliado = @codigo)
SELECT @valida




GO
/****** Object:  StoredProcedure [dbo].[uspValidarSiExisteSolicitudCliente]    Script Date: 3/04/2016 12:17:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspValidarSiExisteSolicitudCliente] 
	@codigoCliente int
AS
BEGIN
	SELECT CONVERT(bit, COUNT(1)) FROM [dbo].[Solicitud]
	WHERE codafiliado = @codigoCliente AND codestado = 1
END




GO