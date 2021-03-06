USE [master]
GO
/****** Object:  Database [FriadenrichAgustin]    Script Date: 26/11/2021 11:37:18 ******/
CREATE DATABASE [FriadenrichAgustin]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FriadenrichAgustin', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\FriadenrichAgustin.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'FriadenrichAgustin_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\FriadenrichAgustin_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [FriadenrichAgustin] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FriadenrichAgustin].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FriadenrichAgustin] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FriadenrichAgustin] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FriadenrichAgustin] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FriadenrichAgustin] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FriadenrichAgustin] SET ARITHABORT OFF 
GO
ALTER DATABASE [FriadenrichAgustin] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [FriadenrichAgustin] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FriadenrichAgustin] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FriadenrichAgustin] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FriadenrichAgustin] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FriadenrichAgustin] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FriadenrichAgustin] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FriadenrichAgustin] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FriadenrichAgustin] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FriadenrichAgustin] SET  DISABLE_BROKER 
GO
ALTER DATABASE [FriadenrichAgustin] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FriadenrichAgustin] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FriadenrichAgustin] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FriadenrichAgustin] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FriadenrichAgustin] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FriadenrichAgustin] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FriadenrichAgustin] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FriadenrichAgustin] SET RECOVERY FULL 
GO
ALTER DATABASE [FriadenrichAgustin] SET  MULTI_USER 
GO
ALTER DATABASE [FriadenrichAgustin] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FriadenrichAgustin] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FriadenrichAgustin] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FriadenrichAgustin] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [FriadenrichAgustin] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [FriadenrichAgustin] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'FriadenrichAgustin', N'ON'
GO
ALTER DATABASE [FriadenrichAgustin] SET QUERY_STORE = OFF
GO
USE [FriadenrichAgustin]
GO
/****** Object:  Table [dbo].[fabricas]    Script Date: 26/11/2021 11:37:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[fabricas](
	[tipo] [int] NOT NULL,
	[provincia] [int] NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[cantidad] [int] NOT NULL,
	[gasesEmitidos] [int] NOT NULL,
	[proveedor] [varchar](100) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[vehiculos]    Script Date: 26/11/2021 11:37:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[vehiculos](
	[tipo] [int] NOT NULL,
	[provincia] [int] NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[cantidad] [int] NOT NULL,
	[gasesEmitidos] [int] NOT NULL,
	[proveedor] [varchar](100) NOT NULL
) ON [PRIMARY]
GO
INSERT [dbo].[fabricas] ([tipo], [provincia], [nombre], [cantidad], [gasesEmitidos], [proveedor]) VALUES (650000, 7, N'BICICLETAS FUTURA S.R.L.', 1, 540000, N'Analisis General')
INSERT [dbo].[fabricas] ([tipo], [provincia], [nombre], [cantidad], [gasesEmitidos], [proveedor]) VALUES (500000, 11, N'DIONE QUÍMICA S.A.', 1, 500000, N'Analisis General')
INSERT [dbo].[fabricas] ([tipo], [provincia], [nombre], [cantidad], [gasesEmitidos], [proveedor]) VALUES (200000, 20, N'MUNDO TEXTIL S.A.', 3, 330000, N'Analisis General')
INSERT [dbo].[fabricas] ([tipo], [provincia], [nombre], [cantidad], [gasesEmitidos], [proveedor]) VALUES (500000, 0, N'QUÍMICA MORENO', 2, 520000, N'Analisis General')
INSERT [dbo].[fabricas] ([tipo], [provincia], [nombre], [cantidad], [gasesEmitidos], [proveedor]) VALUES (200000, 15, N'TEXTIL IBERO AMERICANA S.A.', 6, 260000, N'Analisis General')
GO
INSERT [dbo].[vehiculos] ([tipo], [provincia], [nombre], [cantidad], [gasesEmitidos], [proveedor]) VALUES (20, 13, N'Hyundai Ioniq', 1500, 35, N'Analisis General')
INSERT [dbo].[vehiculos] ([tipo], [provincia], [nombre], [cantidad], [gasesEmitidos], [proveedor]) VALUES (85, 22, N'Mercedes Benz - Camion', 900, 150, N'Analisis General')
INSERT [dbo].[vehiculos] ([tipo], [provincia], [nombre], [cantidad], [gasesEmitidos], [proveedor]) VALUES (60, 8, N'Ford T', 1300, 65, N'Analisis General')
INSERT [dbo].[vehiculos] ([tipo], [provincia], [nombre], [cantidad], [gasesEmitidos], [proveedor]) VALUES (60, 11, N'Toyota Etios', 550, 70, N'Analisis General')
INSERT [dbo].[vehiculos] ([tipo], [provincia], [nombre], [cantidad], [gasesEmitidos], [proveedor]) VALUES (40, 7, N'VolskWagen Gol', 2200, 42, N'Analisis General')
INSERT [dbo].[vehiculos] ([tipo], [provincia], [nombre], [cantidad], [gasesEmitidos], [proveedor]) VALUES (20, 2, N'Ford Mondeo Hybrid', 150, 10, N'Analisis General')
GO
USE [master]
GO
ALTER DATABASE [FriadenrichAgustin] SET  READ_WRITE 
GO
