USE [master]
GO
/****** Object:  Database [TrainingSystem]    Script Date: 11/14/2022 9:32:16 PM ******/
CREATE DATABASE [TrainingSystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TrainingSystem', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\TrainingSystem.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TrainingSystem_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\TrainingSystem_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [TrainingSystem] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TrainingSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TrainingSystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TrainingSystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TrainingSystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TrainingSystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TrainingSystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [TrainingSystem] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [TrainingSystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TrainingSystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TrainingSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TrainingSystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TrainingSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TrainingSystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TrainingSystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TrainingSystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TrainingSystem] SET  ENABLE_BROKER 
GO
ALTER DATABASE [TrainingSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TrainingSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TrainingSystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TrainingSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TrainingSystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TrainingSystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TrainingSystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TrainingSystem] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TrainingSystem] SET  MULTI_USER 
GO
ALTER DATABASE [TrainingSystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TrainingSystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TrainingSystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TrainingSystem] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TrainingSystem] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TrainingSystem] SET QUERY_STORE = OFF
GO
USE [TrainingSystem]
GO
/****** Object:  Table [dbo].[KhoaHoc]    Script Date: 11/14/2022 9:32:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhoaHoc](
	[MaKhoaHoc] [int] NOT NULL,
	[TenKhoaHoc] [nvarchar](100) NULL,
	[MaNHD] [int] NULL,
 CONSTRAINT [PK_KhoaHoc] PRIMARY KEY CLUSTERED 
(
	[MaKhoaHoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NguoiHuongDan]    Script Date: 11/14/2022 9:32:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NguoiHuongDan](
	[MaNHD] [int] NOT NULL,
	[TenNHD] [nvarchar](50) NULL,
 CONSTRAINT [PK_NHD] PRIMARY KEY CLUSTERED 
(
	[MaNHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[KhoaHoc]  WITH CHECK ADD  CONSTRAINT [FK_KhoaHoc_NHD] FOREIGN KEY([MaNHD])
REFERENCES [dbo].[NguoiHuongDan] ([MaNHD])
GO
ALTER TABLE [dbo].[KhoaHoc] CHECK CONSTRAINT [FK_KhoaHoc_NHD]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllKhoaHoc]    Script Date: 11/14/2022 9:32:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create or alter procedure [dbo].[sp_GetAllKhoaHoc]
as
begin
	select MaKhoaHoc, TenKhoaHoc,[TenNHD] from KhoaHoc kh WITH(nolock) join [NguoiHuongDan] nhd on kh.MaNHD = nhd.MaNHD where kh.active = 1
end
GO
USE [master]
GO
ALTER DATABASE [TrainingSystem] SET  READ_WRITE 
GO

alter table KhoaHoc ADD active bit
go
create or alter procedure [dbo].[sp_DeactiveKhoaHoc] @id int
as
begin
	update khoahoc set active=0 where makhoahoc=@id
end
