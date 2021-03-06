USE [master]
GO
/****** Object:  Database [BillingDB]    Script Date: 2/18/2018 11:53:45 AM ******/
CREATE DATABASE [BillingDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BillingDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\BillingDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BillingDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\BillingDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BillingDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BillingDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BillingDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BillingDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BillingDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BillingDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [BillingDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BillingDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BillingDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BillingDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BillingDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BillingDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BillingDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BillingDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BillingDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BillingDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BillingDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BillingDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BillingDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BillingDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BillingDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BillingDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BillingDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BillingDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BillingDB] SET  MULTI_USER 
GO
ALTER DATABASE [BillingDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BillingDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BillingDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BillingDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BillingDB] SET DELAYED_DURABILITY = DISABLED 
GO
USE [BillingDB]
GO
/****** Object:  Table [dbo].[CompanyInfo]    Script Date: 2/18/2018 11:53:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompanyInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [nvarchar](30) NULL,
	[CompanyAddress] [nvarchar](50) NULL,
	[Mobile] [nvarchar](30) NULL,
	[Email] [nvarchar](30) NULL,
	[PAN] [nvarchar](30) NULL,
	[TIN] [nvarchar](30) NULL,
	[VAT] [int] NULL,
	[IsActive] [bit] NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedOn] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[CreatedBy] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CustomerDetails]    Script Date: 2/18/2018 11:53:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [nvarchar](30) NULL,
	[CustomerMobile] [nvarchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ItemMaster]    Script Date: 2/18/2018 11:53:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ItemName] [nvarchar](50) NULL,
	[Price] [money] NULL,
	[CreatedBy] [nvarchar](30) NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedBy] [nvarchar](30) NULL,
	[ModifiedOn] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProductSales]    Script Date: 2/18/2018 11:53:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductSales](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ItemId] [int] NULL,
	[Quantity] [int] NULL,
	[BillNo] [int] NULL,
	[BillDate] [datetime] NULL,
	[UserId] [int] NULL,
	[CustomerId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RoleMaster]    Script Date: 2/18/2018 11:53:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleMaster](
	[Id] [int] NOT NULL,
	[RoleName] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserMaster]    Script Date: 2/18/2018 11:53:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserMaster](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[DateOfBirth] [date] NULL,
	[Address] [nvarchar](100) NULL,
	[EmailId] [nvarchar](50) NULL,
	[Mobile] [nvarchar](50) NULL,
	[IsActive] [bit] NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedOn] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[RoleId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProductSales]  WITH CHECK ADD FOREIGN KEY([CustomerId])
REFERENCES [dbo].[CustomerDetails] ([Id])
GO
ALTER TABLE [dbo].[ProductSales]  WITH CHECK ADD FOREIGN KEY([ItemId])
REFERENCES [dbo].[ItemMaster] ([Id])
GO
ALTER TABLE [dbo].[ProductSales]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[UserMaster] ([UserId])
GO
ALTER TABLE [dbo].[UserMaster]  WITH CHECK ADD FOREIGN KEY([RoleId])
REFERENCES [dbo].[RoleMaster] ([Id])
GO
USE [master]
GO
ALTER DATABASE [BillingDB] SET  READ_WRITE 
GO
