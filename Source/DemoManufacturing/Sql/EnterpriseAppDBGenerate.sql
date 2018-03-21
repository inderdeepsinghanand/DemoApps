
USE [EnterpriseApp]
GO
/****** Object:  Table [dbo].[tbl_Products]    Script Date: 03/14/2018 08:52:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[tbl_Products]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)

/****** Object:  Table [dbo].[tbl_Products]    Script Date: 16/03/2018 15:02:50 ******/
DROP TABLE [dbo].[tbl_Products]
GO



CREATE TABLE [dbo].[tbl_Products](
	[ProductID] [bigint] IDENTITY(1,1) NOT NULL,
	--[Name] [nvarchar](500) NOT NULL,
	[Color] [nvarchar](50) NULL,
	[EmissionNorms] nvarchar(100),
	[MajorVariant] [nvarchar](500) NULL,
	[Type] [nvarchar](20) NULL,
	[CustomerCode] [nvarchar](150) NOT NULL,
	[BarCode] [nvarchar](1000) NULL,
	
 CONSTRAINT [PK_tbl_Products] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[tbl_ProductType]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)

/****** Object:  Table [dbo].[tbl_Products]    Script Date: 16/03/2018 15:02:50 ******/
DROP TABLE [dbo].[tbl_ProductType]
GO



CREATE TABLE [dbo].[tbl_ProductType](
	[ProductTypeID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](500) NOT NULL,

CONSTRAINT [PK_tbl_ProductType] PRIMARY KEY CLUSTERED 
(
	[ProductTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO




/****** Object:  StoredProcedure [dbo].[usp_SaveProduct]    Script Date: 03/21/2018 23:08:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_SaveProduct]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[usp_SaveProduct]
GO


/****** Object:  StoredProcedure [dbo].[usp_SaveProduct]    Script Date: 03/21/2018 23:08:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[usp_SaveProduct]
@ProductID BIGINT,
@Color nvarchar(50),
@EmissionNorms nvarchar(100)
,@MajorVariant nvarchar(500)
,@Type nvarchar(20)
,@CustomerCode nvarchar(150)
,@BarCode nvarchar(1000)

AS
BEGIN

IF(@ProductID >0)
	BEGIN 
		UPDATE [tbl_Products]
		SET [Color] = @Color
			   ,[EmissionNorms] = @EmissionNorms
			   ,[MajorVariant] = @MajorVariant
			   ,[Type] = @Type
			   ,[CustomerCode] = @CustomerCode
			   ,[BarCode] = @BarCode
		WHERE [ProductID] = @ProductID		   
	END
ELSE
	BEGIN

	INSERT INTO [tbl_Products]
			   ([Color] 
			   ,[EmissionNorms]
			   ,[MajorVariant]
			   ,[Type]
			   ,[CustomerCode]
			   ,[BarCode]
			   )
		 VALUES
			   (@Color
			   ,@EmissionNorms
			   ,@MajorVariant
			   ,@Type
			   ,@CustomerCode
			   ,@BarCode
			   
			   )

	END

END
GO

GO