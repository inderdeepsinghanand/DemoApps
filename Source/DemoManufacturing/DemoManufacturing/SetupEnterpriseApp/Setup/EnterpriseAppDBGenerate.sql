USE [master]
GO

/****** Object:  Database [EnterpriseApp]    Script Date: 03/24/2018 12:51:03 ******/
IF  EXISTS (SELECT name FROM sys.databases WHERE name = N'EnterpriseApp')
DROP DATABASE [EnterpriseApp]
GO

USE [master]
GO

declare @RandNo int

select @RandNo = ABS(Checksum(NewID()) % 115)

--declare @MdfFile as nvarchar(500) -- , 
--declare @LdfFile as nvarchar(500)

--SELECT @MdfFile = 'c:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\EnterpriseApp-' + CAST(@RandNo as nvarchar(3)) +  '.mdf';
--SELECT @LdfFile = 'c:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\EnterpriseApp_log-' + CAST(@RandNo as nvarchar(3)) +  '.ldf';



--SELECT @MdfFile,@LdfFile

/****** Object:  Database [EnterpriseApp]    Script Date: 03/24/2018 12:51:03 ******/
CREATE DATABASE [EnterpriseApp] ON  PRIMARY 
( NAME = N'EnterpriseApp', FILENAME = 'c:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\EnterpriseApp.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'EnterpriseApp_log', FILENAME = 'c:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\EnterpriseApp_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

--ALTER DATABASE [EnterpriseApp] SET COMPATIBILITY_LEVEL = 100
--GO

--IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
--begin
--EXEC [EnterpriseApp].[dbo].[sp_fulltext_database] @action = 'enable'
--end
--GO

ALTER DATABASE [EnterpriseApp] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [EnterpriseApp] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [EnterpriseApp] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [EnterpriseApp] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [EnterpriseApp] SET ARITHABORT OFF 
GO

ALTER DATABASE [EnterpriseApp] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [EnterpriseApp] SET AUTO_CREATE_STATISTICS ON 
GO

ALTER DATABASE [EnterpriseApp] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [EnterpriseApp] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [EnterpriseApp] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [EnterpriseApp] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [EnterpriseApp] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [EnterpriseApp] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [EnterpriseApp] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [EnterpriseApp] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [EnterpriseApp] SET  DISABLE_BROKER 
GO

ALTER DATABASE [EnterpriseApp] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [EnterpriseApp] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [EnterpriseApp] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [EnterpriseApp] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [EnterpriseApp] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [EnterpriseApp] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [EnterpriseApp] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [EnterpriseApp] SET  READ_WRITE 
GO

ALTER DATABASE [EnterpriseApp] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [EnterpriseApp] SET  MULTI_USER 
GO

ALTER DATABASE [EnterpriseApp] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [EnterpriseApp] SET DB_CHAINING OFF 
GO

USE [EnterpriseApp]


/****** Object:  Table [dbo].[tbl_Users]    Script Date: 03/14/2018 08:52:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[tbl_Users]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)

/****** Object:  Table [dbo].[tbl_Products]    Script Date: 16/03/2018 15:02:50 ******/
DROP TABLE [dbo].tbl_Users
GO



CREATE TABLE [dbo].[tbl_Users](
	[UserID] [bigint] IDENTITY(1,1) NOT NULL,
	--[Name] [nvarchar](500) NOT NULL,
	[FirstName] [nvarchar](100) NULL,
	[LastName] nvarchar(100),
	[Username] [nvarchar](100) NULL,
	[Password] [nvarchar](100) NULL,
	
	
 CONSTRAINT [PK_tbl_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[tbl_Screens]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)

/****** Object:  Table [dbo].[tbl_Products]    Script Date: 16/03/2018 15:02:50 ******/
DROP TABLE [dbo].tbl_Screens
GO

CREATE TABLE [dbo].[tbl_Screens](
	[ScreenID] [bigint] IDENTITY(1,1) NOT NULL,
	--[Name] [nvarchar](500) NOT NULL,
	[ScreenName] [nvarchar](200) NULL,
	
 CONSTRAINT [PK_tbl_Screens] PRIMARY KEY CLUSTERED 
(
	[ScreenID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]




IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[tbl_UserRights]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)

/****** Object:  Table [dbo].[tbl_UserRights]    Script Date: 16/03/2018 15:02:50 ******/
DROP TABLE [dbo].[tbl_UserRights]
GO



CREATE TABLE [dbo].[tbl_UserRights](
	[UserID] [bigint] ,
	[ScreenID] [bigint]
	
)



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
	[CreatedByUserId] [bigint] NOT NULL,
	[CreatedByName] nvarchar(250) NULL,
	[LastUpdatedByUserId] [bigint]  NULL,
	[LastUpdatedByUserName] nvarchar(250) NULL

	
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



GO



/****** Object:  Table [dbo].[tbl_CustomerOrders]    Script Date: 23/03/2018 13:36:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[tbl_OrderStatus]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)

/****** Object:  Table [dbo].[tbl_OrderStatus]    Script Date: 23/03/2018 13:36:06 ******/
DROP TABLE [dbo].[tbl_OrderStatus]
GO


/****** Object:  Table [dbo].[tbl_CustomerOrders]    Script Date: 23/03/2018 13:36:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[tbl_OrderStatus]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)

/****** Object:  Table [dbo].[tbl_CustomerOrders]    Script Date: 23/03/2018 13:36:06 ******/
DROP TABLE [dbo].[tbl_OrderStatus]
GO


CREATE TABLE [dbo].[tbl_OrderStatus](
	[StatusID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[DisplayName] [nvarchar](100) NULL,
	
 CONSTRAINT [PK_tbl_OrderStatus] PRIMARY KEY CLUSTERED 
(
	[StatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[tbl_CustomerOrders]    Script Date: 23/03/2018 13:36:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[tbl_CustomerOrders]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)

/****** Object:  Table [dbo].[tbl_CustomerOrders]    Script Date: 23/03/2018 13:36:06 ******/
DROP TABLE [dbo].[tbl_CustomerOrders]
GO



CREATE TABLE [dbo].[tbl_CustomerOrders](
	[OrderID] [bigint] IDENTITY(1,1) NOT NULL,
	[ProductID] bigint foreign key references tbl_Products([ProductID]),
	[Color] [nvarchar](50) NULL,
	[EmissionNorms] [nvarchar](100) NULL,
	[MajorVariant] [nvarchar](500) NULL,
	[Type] [nvarchar](20) NULL,
	[CustomerCode] [nvarchar](150) NOT NULL,
	[IsBarCodePrinted] [bit] NULL,
	[BarCode] [nvarchar](1000) NULL,
	[OrderStatusID] bigint foreign key references [tbl_OrderStatus]([StatusID]),
	[Reason] nvarchar(1000) NULL,
	[CreatedByUserId] [bigint] NOT NULL,
	[CreatedByName] nvarchar(250) NULL,
	[LastUpdatedByUserId] [bigint] NULL,
	[LastUpdatedByUserName] nvarchar(250) NULL

 CONSTRAINT [PK_tbl_CustomerOrders] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO



IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[tbl_CustomerOrdersMisMatch]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)

/****** Object:  Table [dbo].[[tbl_CustomerOrdersMisMatch]]    Script Date: 23/03/2018 13:36:06 ******/
DROP TABLE [dbo].[tbl_CustomerOrdersMisMatch]
GO



GO

/****** Object:  Table [dbo].[tbl_CustomerOrdersMisMatch]    Script Date: 23/03/2018 14:38:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbl_CustomerOrdersMisMatch](
	[OrderID] [bigint] IDENTITY(1,1) NOT NULL,
	[Color] [nvarchar](50) NULL,
	[EmissionNorms] [nvarchar](100) NULL,
	[MajorVariant] [nvarchar](500) NULL,
	[Type] [nvarchar](20) NULL,
	[CustomerCode] [nvarchar](150) NULL,
	
	[CreatedByUserId] [bigint] NOT NULL,
	[CreatedByName] nvarchar(250) NULL,
	[LastUpdatedByUserId] [bigint] NULL,
	[LastUpdatedByUserName] nvarchar(250) NULL
 CONSTRAINT [PK_tbl_CustomerOrdersMisMatch] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO




/***************** PROcedures **************************/


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
,@UserId [bigint] 
,@Name nvarchar(250) 

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
			   ,LastUpdatedByUserId = @UserId
			   ,LastUpdatedByUserName = @Name
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
			   ,CreatedByUserId
			   ,CreatedByName
			   )
		 VALUES
			   (@Color
			   ,@EmissionNorms
			   ,@MajorVariant
			   ,@Type
			   ,@CustomerCode
			   ,@BarCode
			   ,@UserId
			   ,@Name
			   )

	END

END
GO

GO


/****** Object:  StoredProcedure [dbo].[usp_SaveOrder]    Script Date: 03/21/2018 23:08:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_SaveOrder]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[usp_SaveOrder]
GO


/****** Object:  StoredProcedure [dbo].[usp_SaveOrder]    Script Date: 03/21/2018 23:08:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[usp_SaveOrder]
@OrderID BIGINT,
@Color nvarchar(50),
@EmissionNorms nvarchar(100)
,@MajorVariant nvarchar(500)
--,@Type nvarchar(20)
--,@CustomerCode nvarchar(150)
--,@IsBarCodePrinted BIT
,@OrderStatusID BIGINT
--,@SaveMisMatchOrder BIT
,@UserId [bigint] 
,@Name nvarchar(250) 

AS
BEGIN

dECLARE @IsMisMatch BIT
declare @BarCode nvarchar(1000),@CustomerCode nvarchar(150)
declare @Type nvarchar(20)
declare @ProductID bigint
declare @InsertNewOrder bit = 0


IF @OrderStatusID <=0
BEGIN
Select @OrderStatusID = StatusID from dbo.tbl_OrderStatus where Name = 'New' 
END

SELECT top 1 @BarCode = BarCode,@CustomerCode =[CustomerCode], @ProductID = ProductID 
	FROM dbo.tbl_Products where LTRIM(RTRIM([Color])) = LTRIM(RTRIM(@Color))
	AND LTRIM(RTRIM([EmissionNorms]))=LTRIM(RTRIM(@EmissionNorms))
	AND LTRIM(RTRIM([MajorVariant])) =LTRIM(RTRIM(@MajorVariant)) --AND LTRIM(RTRIM([Type])) = LTRIM(RTRIM(@Type)) 
	--AND LTRIM(RTRIM([CustomerCode])) = LTRIM(RTRIM(@CustomerCode))

--check for Missmatch
	IF  (@ProductID > 0)
		BEGIN
			 SET @IsMisMatch = 0
			-- DELETE from dbo.tbl_CustomerOrdersMisMatch where OrderID = @OrderID
			 
		END
		ELSE
		BEGIN
			SET @IsMisMatch = 1;
			--IF (EXISTS(SELECT * FROM tbl_CustomerOrdersMisMatch where OrderID = @OrderID))
			--BEGIN
			--UPDATE tbl_CustomerOrdersMisMatch
			--SET [Color] = @Color
			--   ,[EmissionNorms] = @EmissionNorms
			--   ,[MajorVariant] = @MajorVariant
			--  -- ,[Type] = @Type
			--	WHERE [OrderID] = @OrderID	
			INSERT INTO tbl_CustomerOrdersMisMatch
			   ([Color] 
			   ,[EmissionNorms]
			   ,[MajorVariant]
			   ,[Type]
			   ,[CustomerCode]
			   ,CreatedByUserId
			   ,CreatedByName
			   )
		 VALUES
			   (@Color
			   ,@EmissionNorms
			   ,@MajorVariant
			   ,@Type
			   ,@CustomerCode   
			   ,@UserId
			   ,@Name
			   )
			END			
	

IF(@OrderID >0)
	BEGIN 
	
	IF @IsMisMatch = 0
	BEGIN
	
		IF EXISTS(SELECT * FROM tbl_CustomerOrders where OrderID = @OrderID)
			BEGIN
			UPDATE dbo.tbl_CustomerOrders
			SET [Color] = @Color
				   ,[EmissionNorms] = @EmissionNorms
				   ,[MajorVariant] = @MajorVariant
				   ,[Type] = @Type
				   ,[CustomerCode] = @CustomerCode
				  -- ,[IsBarCodePrinted] = @IsBarCodePrinted
				   ,[BarCode] = @BarCode
				   ,[ProductID] = @ProductID,
				   [OrderStatusID] = @OrderStatusID
				   ,LastUpdatedByUserId = @UserId
				   ,LastUpdatedByUserName = @Name
			WHERE [OrderID] = @OrderID		   
			END
		ELSE
			BEGIN
				SEt @InsertNewOrder = 1
			END
	END
	ELSE
	BEGIN
	
		delete  from tbl_CustomerOrders where OrderID = @OrderID;
	
	END
	
	END
ELSE
	BEGIN
	
	IF @IsMisMatch = 0
	BEGIN
		SET @InsertNewOrder = 1
	END
	
	IF @InsertNewOrder = 1
	BEGIN
	--insert fro Front 
	INSERT INTO tbl_CustomerOrders
			   ([Color] 
			   ,[EmissionNorms]
			   ,[MajorVariant]
			   ,[Type]
			   ,[CustomerCode]
			  -- ,[IsBarCodePrinted]
			   ,[BarCode]
			   ,[OrderStatusID] 
			   ,[ProductID]
			   ,CreatedByUserId
			  ,CreatedByName )
		 VALUES
			   (@Color
			   ,@EmissionNorms
			   ,@MajorVariant
			   ,'Front'
			   ,@CustomerCode
			  -- ,@IsBarCodePrinted
			   ,@BarCode
			   ,@OrderStatusID
			   ,@ProductID
			   ,@UserId
			   ,@Name
			   )
			   
			   --insert fro Rear
			   INSERT INTO tbl_CustomerOrders
			   ([Color] 
			   ,[EmissionNorms]
			   ,[MajorVariant]
			   ,[Type]
			   ,[CustomerCode]
			  -- ,[IsBarCodePrinted]
			   ,[BarCode]
			   ,[OrderStatusID] 
			   ,[ProductID]
			    ,CreatedByUserId
			  ,CreatedByName
			   )
		 VALUES
			   (@Color
			   ,@EmissionNorms
			   ,@MajorVariant
			   ,'Rear'
			   ,@CustomerCode
			  -- ,@IsBarCodePrinted
			   ,@BarCode
			   ,@OrderStatusID
			   ,@ProductID
			   ,@UserId
			   ,@Name
			   )
			   
			   
END 
	END

END
GO

GO




/****** Object:  StoredProcedure [dbo].[usp_SaveMisMatchOrder]    Script Date: 03/21/2018 23:08:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_SaveMisMatchOrder]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[usp_SaveMisMatchOrder]
GO


/****** Object:  StoredProcedure [dbo].[usp_SaveMisMatchOrder]    Script Date: 03/21/2018 23:08:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[usp_SaveMisMatchOrder]
@OrderID BIGINT,
@Color nvarchar(50),
@EmissionNorms nvarchar(100)
,@MajorVariant nvarchar(500)
--,@Type nvarchar(20)
--,@CustomerCode nvarchar(150)
--,@IsBarCodePrinted BIT
,@OrderStatusID BIGINT
--,@SaveMisMatchOrder BIT
,@UserId [bigint] 
,@Name nvarchar(250) 

AS
BEGIN

DECLARE @IsMisMatch BIT
declare @BarCode nvarchar(1000),@CustomerCode nvarchar(150)
declare @Type nvarchar(20)
declare @ProductID bigint
declare @InsertNewOrder bit = 0


IF @OrderStatusID <=0
BEGIN
Select @OrderStatusID = StatusID from dbo.tbl_OrderStatus where Name = 'New' 
END

SELECT top 1 @BarCode = BarCode,@CustomerCode =[CustomerCode], @ProductID = ProductID 
	FROM dbo.tbl_Products where LTRIM(RTRIM([Color])) = LTRIM(RTRIM(@Color))
	AND LTRIM(RTRIM([EmissionNorms]))=LTRIM(RTRIM(@EmissionNorms))
	AND LTRIM(RTRIM([MajorVariant])) =LTRIM(RTRIM(@MajorVariant)) --AND LTRIM(RTRIM([Type])) = LTRIM(RTRIM(@Type)) 
	--AND LTRIM(RTRIM([CustomerCode])) = LTRIM(RTRIM(@CustomerCode))

--check for Missmatch
IF  (@ProductID > 0)
			 BEGIN
			 SET @IsMisMatch = 0
			 DELETE from dbo.tbl_CustomerOrdersMisMatch where OrderID = @OrderID
			 --insert fro Front 
	INSERT INTO tbl_CustomerOrders
			   ([Color] 
			   ,[EmissionNorms]
			   ,[MajorVariant]
			   ,[Type]
			   ,[CustomerCode]
			  -- ,[IsBarCodePrinted]
			   ,[BarCode]
			   ,[OrderStatusID] 
			   ,[ProductID]
			   )
		 VALUES
			   (@Color
			   ,@EmissionNorms
			   ,@MajorVariant
			   ,'Front'
			   ,@CustomerCode
			  -- ,@IsBarCodePrinted
			   ,@BarCode
			   ,@OrderStatusID
			   ,@ProductID
			   )
			   
			   --insert fro Rear
			   INSERT INTO tbl_CustomerOrders
			   ([Color] 
			   ,[EmissionNorms]
			   ,[MajorVariant]
			   ,[Type]
			   ,[CustomerCode]
			  -- ,[IsBarCodePrinted]
			   ,[BarCode]
			   ,[OrderStatusID] 
			   ,[ProductID]
			   )
		 VALUES
			   (@Color
			   ,@EmissionNorms
			   ,@MajorVariant
			   ,'Rear'
			   ,@CustomerCode
			  -- ,@IsBarCodePrinted
			   ,@BarCode
			   ,@OrderStatusID
			   ,@ProductID
			   )
			   
			 END
	ELSE
			BEGIN
			SET @IsMisMatch = 1;
			IF (EXISTS(SELECT * FROM tbl_CustomerOrdersMisMatch where OrderID = @OrderID))
			BEGIN
			UPDATE tbl_CustomerOrdersMisMatch
			SET [Color] = @Color
			   ,[EmissionNorms] = @EmissionNorms
			   ,[MajorVariant] = @MajorVariant
			  -- ,[Type] = @Type
				WHERE [OrderID] = @OrderID	
			
			END
			ELSE
			BEGIN
			INSERT INTO tbl_CustomerOrdersMisMatch
			   ([Color] 
			   ,[EmissionNorms]
			   ,[MajorVariant]
			   ,[Type]
			   ,[CustomerCode]
			  
			   )
		 VALUES
			   (@Color
			   ,@EmissionNorms
			   ,@MajorVariant
			   ,@Type
			   ,@CustomerCode
			   
			   
			   )
			END
			END


--IF(@OrderID >0)
--	BEGIN 
	
--	IF @IsMisMatch = 0
--	BEGIN
	
--		IF EXISTS(SELECT * FROM tbl_CustomerOrders where OrderID = @OrderID)
--			BEGIN
--			UPDATE dbo.tbl_CustomerOrders
--			SET [Color] = @Color
--				   ,[EmissionNorms] = @EmissionNorms
--				   ,[MajorVariant] = @MajorVariant
--				   ,[Type] = @Type
--				   ,[CustomerCode] = @CustomerCode
--				  -- ,[IsBarCodePrinted] = @IsBarCodePrinted
--				   ,[BarCode] = @BarCode
--				   ,[ProductID] = @ProductID,
--				   [OrderStatusID] = @OrderStatusID
--			WHERE [OrderID] = @OrderID		   
--		END
--		ELSE
--		BEGIN
--		SEt @InsertNewOrder = 1
--		END
--	END
--	ELSE
--	BEGIN
--	IF @SaveMisMatchOrder = 0
--	BEGIN
--	delete  from tbl_CustomerOrders where OrderID = @OrderID;
--	END
--	END
	
--	END
--ELSE
--	BEGIN
	
--	IF @IsMisMatch = 0
--	BEGIN
--		SET @InsertNewOrder = 1
--	END
	
--	IF @InsertNewOrder = 1
--	BEGIN
	
			   
--END 
	--END

END
GO

GO




/****** Object:  StoredProcedure [dbo].[usp_ChangePrintStatus]    Script Date: 03/21/2018 23:08:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_ChangePrintStatus]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[usp_ChangePrintStatus]
GO


/****** Object:  StoredProcedure [dbo].[usp_ChangePrintStatus]    Script Date: 03/21/2018 23:08:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[usp_ChangePrintStatus]
@OrderID BIGINT
,@UserId [bigint] 
,@Name nvarchar(250) 
AS
BEGIN

declare @StatusID BIGINT 

select @StatusID = StatusID from dbo.tbl_OrderStatus where Name = 'BCPrinted'

Update dbo.tbl_CustomerOrders set IsBarCodePrinted =1,OrderStatusID =@StatusID where OrderID = @OrderID


END
GO


/****** Object:  StoredProcedure [dbo].[usp_ChangePrintStatus]    Script Date: 03/21/2018 23:08:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_GetStatusCount]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[usp_GetStatusCount]
GO


/****** Object:  StoredProcedure [dbo].[usp_GetStatusCount]    Script Date: 03/21/2018 23:08:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[usp_GetStatusCount]
@Type nvarchar(20)
--,@UserId [bigint] 
--,@Name nvarchar(250) 
AS
BEGIN

declare @PrintedStatusID BIGINT,@NewStatusID BIGINT, @ApprovedStatusID BIGINT ,@RejectedStatusID BIGINT 

select @PrintedStatusID = StatusID from dbo.tbl_OrderStatus where Name = 'BCPrinted'
select @NewStatusID = StatusID from dbo.tbl_OrderStatus where Name = 'New'
select @ApprovedStatusID = StatusID from dbo.tbl_OrderStatus where Name = 'Approved'
select @RejectedStatusID = StatusID from dbo.tbl_OrderStatus where Name = 'Rejected'

declare @PrintedCount BIGINT,@NewCount BIGINT, @ApprovedCount BIGINT ,@RejectedCount BIGINT 

select @NewCount = Count(*) from tbl_CustomerOrders where [Type] = @Type AND OrderStatusID =@NewStatusID;
select @PrintedCount = Count(*) from tbl_CustomerOrders where [Type] = @Type AND OrderStatusID =@PrintedStatusID;
select @ApprovedCount = Count(*) from tbl_CustomerOrders where [Type] = @Type AND OrderStatusID =@ApprovedStatusID;
select @RejectedCount = Count(*) from tbl_CustomerOrders where [Type] = @Type AND OrderStatusID =@RejectedStatusID;

select @NewCount as New, @PrintedCount as Printed, @ApprovedCount as Approved, @RejectedCount as Rejected


END
GO

/****** Object:  StoredProcedure [dbo].[usp_ApproveRejectOrder]    Script Date: 03/21/2018 23:08:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[usp_ApproveRejectOrder]    Script Date: 03/21/2018 23:08:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_ApproveRejectOrder]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[usp_ApproveRejectOrder]
GO


create proc [dbo].[usp_ApproveRejectOrder]
@OrderID BIGINT,
@StatusID BIGINT,
@Reason NVARCHAR(1000)
,@UserId [bigint] 
,@Name nvarchar(250) 

AS
BEGIN

--declare @StatusID BIGINT 

--select @StatusID = StatusID from dbo.tbl_OrderStatus where Name = 'BC Printed'

Update dbo.tbl_CustomerOrders set OrderStatusID =@StatusID,Reason = @Reason where OrderID = @OrderID


END
GO


-------- Insert statements-----------------

INSERT INTO [dbo].[tbl_Users]
           ([FirstName]
           ,[LastName]
           ,[Username]
           ,[Password])
     VALUES
           ('Administrator'
           ,NULL
           ,'admin'
           ,'password')
           
           
       INSERT INTO [dbo].[tbl_Users]
       ([FirstName]
       ,[LastName]
       ,[Username]
       ,[Password])
 VALUES
       ('Inspector'
       ,NULL
       ,'inspector'
       ,'password')
GO


---Screen 

INSERT INTO [dbo].[tbl_Screens]
           ([ScreenName])
     VALUES
           ('MasterUpload')
GO

INSERT INTO [dbo].[tbl_Screens]
           ([ScreenName])
     VALUES
           ('OrderUpload')
GO
INSERT INTO [dbo].[tbl_Screens]
           ([ScreenName])
     VALUES
           ('Dashboard')
GO
INSERT INTO [dbo].[tbl_Screens]
           ([ScreenName])
     VALUES
           ('Inspection')
GO

--user screens right
--[tbl_UserRights]

INSERT INTO [EnterpriseApp].[dbo].[tbl_UserRights]
           ([UserID]
           ,[ScreenID])
     VALUES
           ((Select UserID from tbl_Users where Username = 'admin')
           ,(Select ScreenID from tbl_Screens where ScreenName= 'Dashboard'))
GO
INSERT INTO [EnterpriseApp].[dbo].[tbl_UserRights]
           ([UserID]
           ,[ScreenID])
     VALUES
           ((Select UserID from tbl_Users where Username = 'admin')
           ,(Select ScreenID from tbl_Screens where ScreenName= 'MasterUpload'))
GO

INSERT INTO [EnterpriseApp].[dbo].[tbl_UserRights]
           ([UserID]
           ,[ScreenID])
     VALUES
           ((Select UserID from tbl_Users where Username = 'admin')
           ,(Select ScreenID from tbl_Screens where ScreenName= 'OrderUpload'))
GO


INSERT INTO [EnterpriseApp].[dbo].[tbl_UserRights]
           ([UserID]
           ,[ScreenID])
     VALUES
           ((Select UserID from tbl_Users where Username = 'inspector')
           ,(Select ScreenID from tbl_Screens where ScreenName= 'Inspection'))
GO


--order status

INSERT INTO [dbo].[tbl_OrderStatus]
           ([Name], [DisplayName])
     VALUES
           ('New', 'New')
GO

INSERT INTO [dbo].[tbl_OrderStatus]
           ([Name], [DisplayName])
     VALUES
           ('BCPrinted', 'BC Printed')
GO           
INSERT INTO [dbo].[tbl_OrderStatus]
           ([Name], [DisplayName])
     VALUES
           ('Approved', 'Tested Ok')

GO

INSERT INTO [dbo].[tbl_OrderStatus]
           ([Name], [DisplayName])
     VALUES
           ('Rejected', 'Rejected')

GO