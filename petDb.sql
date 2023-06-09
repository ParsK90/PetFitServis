USE [master]
GO
/****** Object:  Database [Pet]    Script Date: 7.06.2023 23:31:25 ******/
CREATE DATABASE [Pet]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Pet', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Pet.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Pet_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Pet_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Pet] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Pet].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Pet] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Pet] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Pet] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Pet] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Pet] SET ARITHABORT OFF 
GO
ALTER DATABASE [Pet] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Pet] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Pet] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Pet] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Pet] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Pet] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Pet] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Pet] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Pet] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Pet] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Pet] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Pet] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Pet] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Pet] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Pet] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Pet] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Pet] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Pet] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Pet] SET  MULTI_USER 
GO
ALTER DATABASE [Pet] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Pet] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Pet] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Pet] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Pet] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Pet] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Pet', N'ON'
GO
ALTER DATABASE [Pet] SET QUERY_STORE = ON
GO
ALTER DATABASE [Pet] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Pet]
GO
/****** Object:  Table [dbo].[PetAsi]    Script Date: 7.06.2023 23:31:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PetAsi](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Aciklama] [nvarchar](256) NULL,
	[EkAciklama] [nvarchar](256) NULL,
	[Doz] [float] NULL,
	[EklenmeTarihi] [datetime] NULL,
	[Aktif] [smallint] NULL,
 CONSTRAINT [PK_PetAsi_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PetAsiHareket]    Script Date: 7.06.2023 23:31:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PetAsiHareket](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[HayvanId] [int] NULL,
	[AsiId] [int] NULL,
	[Aciklama] [nvarchar](256) NULL,
	[EkAciklama] [nvarchar](256) NULL,
	[EklenmeTarihi] [datetime] NULL,
	[Aktif] [smallint] NULL,
 CONSTRAINT [PK_PetAsi] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PetBakim]    Script Date: 7.06.2023 23:31:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PetBakim](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[HayvanId] [int] NULL,
	[BakimTurId] [int] NULL,
	[Aciklama] [nvarchar](256) NULL,
	[EkAciklama] [nvarchar](256) NULL,
	[EklenmeTarihi] [datetime] NULL,
	[Aktif] [smallint] NULL,
 CONSTRAINT [PK_PetBakim] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PetBakimTur]    Script Date: 7.06.2023 23:31:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PetBakimTur](
	[Id] [int] NOT NULL,
	[Aciklama] [nvarchar](256) NULL,
	[EkAciklama] [nvarchar](256) NULL,
	[EklenmeTarihi] [datetime] NULL,
	[Aktif] [smallint] NULL,
 CONSTRAINT [PK_PetBakimTur] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PetHayvan]    Script Date: 7.06.2023 23:31:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PetHayvan](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SahipId] [int] NULL,
	[HayvanCinsTurId] [int] NULL,
	[Aciklama] [nvarchar](256) NULL,
	[EkAciklama] [nvarchar](256) NULL,
	[DogumTarihi] [datetime] NULL,
	[Cinsiyet] [varchar](16) NULL,
	[Chip] [varchar](72) NULL,
	[Renk] [nvarchar](64) NULL,
	[Kilo] [float] NULL,
	[EklenmeTarihi] [datetime] NULL,
	[Aktif] [smallint] NULL,
	[Resim] [image] NULL,
 CONSTRAINT [PK_PetHayvan] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PetHayvanCins]    Script Date: 7.06.2023 23:31:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PetHayvanCins](
	[Id] [int] NOT NULL,
	[Aciklama] [nvarchar](256) NULL,
	[EklenmeTarihi] [datetime] NULL,
	[Aktif] [smallint] NULL,
 CONSTRAINT [PK_PetCins] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PetHayvanCinsTur]    Script Date: 7.06.2023 23:31:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PetHayvanCinsTur](
	[Id] [int] NOT NULL,
	[HayvanCinsId] [int] NULL,
	[Aciklama] [nvarchar](256) NULL,
	[EkAciklama] [nvarchar](256) NULL,
	[EklenmeTarihi] [datetime] NULL,
	[Aktif] [smallint] NULL,
 CONSTRAINT [PK_PetHayvanCinsTur] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PetMusteri]    Script Date: 7.06.2023 23:31:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PetMusteri](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Aciklama] [nvarchar](256) NULL,
	[EkAciklama] [nvarchar](256) NULL,
	[Mail] [varchar](64) NULL,
	[Sifre] [varchar](64) NULL,
	[Telefon] [varchar](16) NULL,
	[Adres] [nvarchar](512) NULL,
	[EklenmeTarihi] [datetime] NULL,
	[Aktif] [smallint] NULL,
 CONSTRAINT [PK_PetMusteri] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[PetAsiHareket]  WITH CHECK ADD  CONSTRAINT [FK_PetAsiHareketWithAsiId] FOREIGN KEY([AsiId])
REFERENCES [dbo].[PetAsi] ([Id])
GO
ALTER TABLE [dbo].[PetAsiHareket] CHECK CONSTRAINT [FK_PetAsiHareketWithAsiId]
GO
ALTER TABLE [dbo].[PetAsiHareket]  WITH CHECK ADD  CONSTRAINT [FK_PetAsiHareketWithHayvanId] FOREIGN KEY([HayvanId])
REFERENCES [dbo].[PetHayvan] ([Id])
GO
ALTER TABLE [dbo].[PetAsiHareket] CHECK CONSTRAINT [FK_PetAsiHareketWithHayvanId]
GO
ALTER TABLE [dbo].[PetBakim]  WITH CHECK ADD  CONSTRAINT [FK_PetBakimWithBakimTurId] FOREIGN KEY([BakimTurId])
REFERENCES [dbo].[PetBakimTur] ([Id])
GO
ALTER TABLE [dbo].[PetBakim] CHECK CONSTRAINT [FK_PetBakimWithBakimTurId]
GO
ALTER TABLE [dbo].[PetBakim]  WITH CHECK ADD  CONSTRAINT [FK_PetBakimWithHayvanId] FOREIGN KEY([HayvanId])
REFERENCES [dbo].[PetHayvan] ([Id])
GO
ALTER TABLE [dbo].[PetBakim] CHECK CONSTRAINT [FK_PetBakimWithHayvanId]
GO
ALTER TABLE [dbo].[PetHayvan]  WITH CHECK ADD  CONSTRAINT [FK_PetHayvanWithHayvanCinsTurId] FOREIGN KEY([HayvanCinsTurId])
REFERENCES [dbo].[PetHayvanCinsTur] ([Id])
GO
ALTER TABLE [dbo].[PetHayvan] CHECK CONSTRAINT [FK_PetHayvanWithHayvanCinsTurId]
GO
ALTER TABLE [dbo].[PetHayvan]  WITH CHECK ADD  CONSTRAINT [FK_PetHayvanWithSahipId] FOREIGN KEY([SahipId])
REFERENCES [dbo].[PetMusteri] ([Id])
GO
ALTER TABLE [dbo].[PetHayvan] CHECK CONSTRAINT [FK_PetHayvanWithSahipId]
GO
ALTER TABLE [dbo].[PetHayvanCinsTur]  WITH CHECK ADD  CONSTRAINT [FK_PetHayvanCinsTurWithHayvanCinsId] FOREIGN KEY([HayvanCinsId])
REFERENCES [dbo].[PetHayvanCins] ([Id])
GO
ALTER TABLE [dbo].[PetHayvanCinsTur] CHECK CONSTRAINT [FK_PetHayvanCinsTurWithHayvanCinsId]
GO
USE [master]
GO
ALTER DATABASE [Pet] SET  READ_WRITE 
GO
