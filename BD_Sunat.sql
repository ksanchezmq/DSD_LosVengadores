CREATE DATABASE [BD_Sunat]
GO

USE [BD_Sunat]
GO

/****** Object:  Table [dbo].[Contribuyente]    Script Date: 3/04/2016 12:18:22 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contribuyente](
	[RUC] [nvarchar](11) NULL,
	[Estado] [bit] NULL
) ON [PRIMARY]

GO
INSERT [dbo].[Contribuyente] ([RUC], [Estado]) VALUES (N'10436576175', 1)
INSERT [dbo].[Contribuyente] ([RUC], [Estado]) VALUES (N'10123456789', 1)
INSERT [dbo].[Contribuyente] ([RUC], [Estado]) VALUES (N'10876543211', 1)
INSERT [dbo].[Contribuyente] ([RUC], [Estado]) VALUES (N'10447588451', 1)
INSERT [dbo].[Contribuyente] ([RUC], [Estado]) VALUES (N'10425789782', 0)
INSERT [dbo].[Contribuyente] ([RUC], [Estado]) VALUES (N'10459647291', 0)


/****** Object:  StoredProcedure [dbo].[uspValidarRUCContribuyente]    Script Date: 3/04/2016 12:18:22 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspValidarRUCContribuyente]
	@RUC nvarchar(11)
AS
BEGIN
	SELECT convert(bit, count(1)) FROM [dbo].[Contribuyente] 
	where RUC = @RUC and Estado = 1
END



GO