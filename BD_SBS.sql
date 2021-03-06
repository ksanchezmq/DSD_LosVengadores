CREATE DATABASE BD_SBS
GO

USE [BD_SBS]
GO


/****** Object:  Table [dbo].[Deudor]    Script Date: 3/04/2016 12:17:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Deudor](
	[DNI] [int] NULL,
	[Monto] [decimal](18, 3) NULL,
	[EntidadFinanciera] [nvarchar](100) NULL
) ON [PRIMARY]

GO
INSERT [dbo].[Deudor] ([DNI], [Monto], [EntidadFinanciera]) VALUES (43657617, CAST(1200.000 AS Decimal(18, 3)), N'Banco de Crédito BCP')
INSERT [dbo].[Deudor] ([DNI], [Monto], [EntidadFinanciera]) VALUES (87654321, CAST(1500.000 AS Decimal(18, 3)), N'Banco de Crédito BCP')



/****** Object:  StoredProcedure [dbo].[uspObtenerDeudaPorDNI]    Script Date: 3/04/2016 12:17:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspObtenerDeudaPorDNI]
	@DNI int
AS
BEGIN
	SELECT COALESCE(SUM(Monto), 0)
	FROM [dbo].[Deudor]
	WHERE DNI = @DNI
END



GO