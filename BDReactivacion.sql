CREATE DATABASE BD_Reactivacion
GO
USE [BD_Reactivacion]
GO

/****** Object:  Table [dbo].[tb001_cliente]    Script Date: 19/03/2016 4:08:33 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb001_cliente](
	[n001_codafiliado] [int] NOT NULL,
	[s001_nombre] [nvarchar](150) NULL,
	[n001_dni] [int] NOT NULL,
	[s001_direccion_emp] [nvarchar](200) NULL,
	[s001_ruc] [nvarchar](11) NULL,
	[n002_estado] [smallint] NULL,
	[n003_tipo_pos] [smallint] NULL,
	[n004_num_serie] [varchar](50) NULL,
	[s002_correo] [nvarchar](60) NULL,
 CONSTRAINT [PK_tb001_cliente] PRIMARY KEY CLUSTERED 
(
	[n001_codafiliado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tb002_estado]    Script Date: 19/03/2016 4:08:33 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb002_estado](
	[n002_codigo] [smallint] NOT NULL,
	[s002_descripcion] [nvarchar](100) NULL,
 CONSTRAINT [PK_tb002_estado] PRIMARY KEY CLUSTERED 
(
	[n002_codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tb003_tipo_pos]    Script Date: 19/03/2016 4:08:33 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb003_tipo_pos](
	[n003_codigo] [smallint] NOT NULL,
	[s003_descripcion] [nvarchar](100) NULL,
 CONSTRAINT [PK_tb003_pos] PRIMARY KEY CLUSTERED 
(
	[n003_codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tb004_pos]    Script Date: 19/03/2016 4:08:33 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb004_pos](
	[n004_codigo] [varchar](50) NOT NULL,
	[s004_marca] [nvarchar](100) NULL,
	[s004_modelo] [nvarchar](100) NULL,
 CONSTRAINT [pk_n004_codigo] PRIMARY KEY CLUSTERED 
(
	[n004_codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tb005_Solicitud]    Script Date: 19/03/2016 4:08:33 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb005_Solicitud](
	[n005_codigo] [bigint] IDENTITY(1,1) NOT NULL,
	[n005_estado] [int] NOT NULL,
	[n001_codafiliado] [int] NOT NULL,
	[s005_fechaHora] [datetime] NOT NULL,
 CONSTRAINT [pk_n005_codigo] PRIMARY KEY CLUSTERED 
(
	[n005_codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[tb001_cliente] ([n001_codafiliado], [s001_nombre], [n001_dni], [s001_direccion_emp], [s001_ruc], [n002_estado], [n003_tipo_pos], [n004_num_serie], [s002_correo]) VALUES (1, N'Cesar Elias Vicuña', 45964729, N'Bayovar Norte 195 Surco', N'10459647291', 2, 1, N'1', N'cesarelias@gmail.com')
INSERT [dbo].[tb001_cliente] ([n001_codafiliado], [s001_nombre], [n001_dni], [s001_direccion_emp], [s001_ruc], [n002_estado], [n003_tipo_pos], [n004_num_serie], [s002_correo]) VALUES (2, N'Noemi Arce Toribio', 42578978, N'Av. Los Próceres', N'10425789782', 1, 2, N'2', N'noemiarce@gmail.com')
INSERT [dbo].[tb001_cliente] ([n001_codafiliado], [s001_nombre], [n001_dni], [s001_direccion_emp], [s001_ruc], [n002_estado], [n003_tipo_pos], [n004_num_serie], [s002_correo]) VALUES (3, N'Juan Perez Valdivia', 12345678, N'Los Ficus 300 La Molina', N'10123456789', 2, 2, N'1', N'juanperez@gmail.com')
INSERT [dbo].[tb001_cliente] ([n001_codafiliado], [s001_nombre], [n001_dni], [s001_direccion_emp], [s001_ruc], [n002_estado], [n003_tipo_pos], [n004_num_serie], [s002_correo]) VALUES (4, N'Pedro Navaja', 87654321, N'Av. Benavides 234 Miraflroes', N'10876543211', 2, 1, N'2', N'pedronavaja@gmail.com')
INSERT [dbo].[tb001_cliente] ([n001_codafiliado], [s001_nombre], [n001_dni], [s001_direccion_emp], [s001_ruc], [n002_estado], [n003_tipo_pos], [n004_num_serie], [s002_correo]) VALUES (5, N'Jhonny  Morales', 43657617, N'Av. Tupac Amaru Km 12  Comas', N'10436576175', 2, 1, N'1', N'jmorales0786@gmail.com')
INSERT [dbo].[tb001_cliente] ([n001_codafiliado], [s001_nombre], [n001_dni], [s001_direccion_emp], [s001_ruc], [n002_estado], [n003_tipo_pos], [n004_num_serie], [s002_correo]) VALUES (6, N'Graziella Villafuerte', 44758845, N'Av. 200 Millas', N'10447588451', 2, 2, N'1', N'graziellavillafuerte@gmail.com')
INSERT [dbo].[tb002_estado] ([n002_codigo], [s002_descripcion]) VALUES (1, N'Activo')
INSERT [dbo].[tb002_estado] ([n002_codigo], [s002_descripcion]) VALUES (2, N'Inactivo')
INSERT [dbo].[tb002_estado] ([n002_codigo], [s002_descripcion]) VALUES (3, N'En Proceso')
INSERT [dbo].[tb003_tipo_pos] ([n003_codigo], [s003_descripcion]) VALUES (1, N'Inalámbrico')
INSERT [dbo].[tb003_tipo_pos] ([n003_codigo], [s003_descripcion]) VALUES (2, N'Fijo')
INSERT [dbo].[tb004_pos] ([n004_codigo], [s004_marca], [s004_modelo]) VALUES (N'1', N'Motion', N'A')
INSERT [dbo].[tb004_pos] ([n004_codigo], [s004_marca], [s004_modelo]) VALUES (N'2', N'Motion', N'B')
SET IDENTITY_INSERT [dbo].[tb005_Solicitud] ON 

INSERT [dbo].[tb005_Solicitud] ([n005_codigo], [n005_estado], [n001_codafiliado], [s005_fechaHora]) VALUES (1, 1, 5, CAST(0x0000A5CE0046E8C5 AS DateTime))
SET IDENTITY_INSERT [dbo].[tb005_Solicitud] OFF
ALTER TABLE [dbo].[tb001_cliente]  WITH CHECK ADD FOREIGN KEY([n002_estado])
REFERENCES [dbo].[tb002_estado] ([n002_codigo])
GO
ALTER TABLE [dbo].[tb001_cliente]  WITH CHECK ADD FOREIGN KEY([n002_estado])
REFERENCES [dbo].[tb002_estado] ([n002_codigo])
GO
ALTER TABLE [dbo].[tb001_cliente]  WITH CHECK ADD FOREIGN KEY([n003_tipo_pos])
REFERENCES [dbo].[tb003_tipo_pos] ([n003_codigo])
GO
ALTER TABLE [dbo].[tb001_cliente]  WITH CHECK ADD FOREIGN KEY([n003_tipo_pos])
REFERENCES [dbo].[tb003_tipo_pos] ([n003_codigo])
GO
ALTER TABLE [dbo].[tb001_cliente]  WITH CHECK ADD FOREIGN KEY([n004_num_serie])
REFERENCES [dbo].[tb004_pos] ([n004_codigo])
GO
ALTER TABLE [dbo].[tb005_Solicitud]  WITH CHECK ADD FOREIGN KEY([n001_codafiliado])
REFERENCES [dbo].[tb001_cliente] ([n001_codafiliado])
GO


-----------------------------------------------------------------------------------
/****** Object:  StoredProcedure [dbo].[uspGenerarSolicitudCliente]    Script Date: 19/03/2016 4:08:33 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspGenerarSolicitudCliente] 
	@codigoCliente int
AS
BEGIN
	INSERT [dbo].[tb005_Solicitud](n005_estado, n001_codafiliado, s005_fechaHora)
	SELECT 1, @codigoCliente, GETUTCDATE()
	
	SELECT  SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[uspGetCliente]    Script Date: 19/03/2016 4:08:33 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspGetCliente] @codigo smallint
AS
SELECT N001_CODAFILIADO,S001_NOMBRE,N001_DNI,S001_DIRECCION_EMP,
	   S001_RUC,S002_DESCRIPCION,N003_TIPO_POS,C.s002_Correo
FROM TB001_CLIENTE C,TB002_ESTADO E
WHERE N002_ESTADO = N002_CODIGO
  AND N001_CODAFILIADO = @codigo

GO
/****** Object:  StoredProcedure [dbo].[uspValidarSiExisteSolicitudCliente]    Script Date: 19/03/2016 4:08:33 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[uspValidarSiExisteSolicitudCliente] 
	@codigoCliente int
AS
BEGIN
	SELECT CONVERT(bit, COUNT(1)) FROM [dbo].[tb005_Solicitud]
	WHERE n001_codafiliado = @codigoCliente AND n005_estado = 1
END
GO

CREATE PROCEDURE [dbo].[uspValidaCodigoCliente] @codigo smallint
AS
--DECLARE @codigo SMALLINT = 6
DECLARE @valida bit
SET  @valida = (select CONVERT(BIT,COUNT(*))
FROM TB001_CLIENTE
WHERE n001_codafiliado = @codigo)
SELECT @valida
