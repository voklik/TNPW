USE [master]


CREATE DATABASE [Eshop]
 

USE [Eshop]
GO

CREATE TABLE [dbo].[Adresy](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[aktivovano] [bit] NOT NULL,
	[mesto] [varchar](max) NOT NULL,
	[zeme] [varchar](max) NOT NULL,
	[psc] [varchar](max) NOT NULL,
	[uliceCP] [varchar](max) NOT NULL,
 CONSTRAINT [PK_Adresy] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DopravaMoznosti]    Script Date: 29.03.2019 10:26:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DopravaMoznosti](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[aktivovano] [bit] NOT NULL,
	[nazev] [varchar](max) NOT NULL,
	[popis] [varchar](max) NOT NULL,
	[cena] [decimal](9, 4) NOT NULL,
 CONSTRAINT [PK_DopravaMoznosti] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hry]    Script Date: 29.03.2019 10:26:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hry](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nazev] [varchar](max) NOT NULL,
	[cena] [decimal](9, 4) NOT NULL,
	[popis] [text] NOT NULL,
	[sleva] [decimal](5, 4) NOT NULL,
	[platforma] [int] NOT NULL,
	[vydavatel] [int] NOT NULL,
	[ikona] [varchar](50) NULL,
	[skladem] [int] NULL,
	[datumVydani] [varchar](50) NOT NULL,
	[aktivovano] [bit] NOT NULL,
	[dph] [decimal](5, 4) NOT NULL,
 CONSTRAINT [PK_Hry] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KombinaceMoznosti]    Script Date: 29.03.2019 10:26:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KombinaceMoznosti](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[aktivovano] [bit] NOT NULL,
	[platebniMoznost] [int] NOT NULL,
	[dopravniMoznost] [int] NOT NULL,
	[cenaDoprava] [decimal](9, 4) NOT NULL,
	[cenaPlatba] [decimal](9, 4) NOT NULL,
	[cenaObjednavka] [decimal](9, 4) NOT NULL,
 CONSTRAINT [PK_KombinaceMoznosti] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Objednavky]    Script Date: 29.03.2019 10:26:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Objednavky](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[aktivovano] [bit] NOT NULL,
	[cislo] [varchar](50) NULL,
	[uzivatel] [int] NOT NULL,
	[stav] [int] NOT NULL,
	[datumObjednani] [datetime] NOT NULL,
	[platba] [int] NOT NULL,
	[doprava] [int] NOT NULL,
	[adresa] [int] NOT NULL,
	[cenaDopravy] [decimal](9, 4) NOT NULL,
	[cenaPlatby] [decimal](9, 4) NOT NULL,
	[cenaCelkem] [decimal](9, 4) NOT NULL,
	[jmeno] [varchar](max) NULL,
	[prijmeni] [varchar](max) NULL,
	[email] [varchar](max) NULL,
	[telefon] [varchar](max) NULL,
 CONSTRAINT [PK_Objednavky] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Obrazky]    Script Date: 29.03.2019 10:26:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Obrazky](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[hra_id] [int] NOT NULL,
	[ikona] [varchar](50) NOT NULL,
	[popis] [varchar](max) NULL,
	[aktivovano] [bit] NOT NULL,
 CONSTRAINT [PK_Obrazky] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PlatebniMoznosti]    Script Date: 29.03.2019 10:26:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlatebniMoznosti](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[aktivovano] [bit] NOT NULL,
	[nazev] [varchar](max) NOT NULL,
	[popis] [varchar](max) NOT NULL,
	[cena] [decimal](9, 4) NOT NULL,
 CONSTRAINT [PK_PlatebniMoznosti] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Platformy]    Script Date: 29.03.2019 10:26:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Platformy](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nazev] [varchar](50) NOT NULL,
	[aktivovano] [bit] NOT NULL,
	[pocet] [int] NOT NULL,
 CONSTRAINT [PK_Platformy] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PolozkyKosiku]    Script Date: 29.03.2019 10:26:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PolozkyKosiku](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[aktivovano] [bit] NOT NULL,
	[uzivatel] [int] NOT NULL,
	[hra] [int] NOT NULL,
	[mnozstvi] [int] NOT NULL,
 CONSTRAINT [PK_PolozkyKosiku] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PolozkyObjednavka]    Script Date: 29.03.2019 10:26:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PolozkyObjednavka](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[aktivovano] [bit] NOT NULL,
	[tehdejsiCena] [decimal](9, 4) NOT NULL,
	[hra] [int] NOT NULL,
	[mnozstvi] [int] NOT NULL,
	[objednavkaID] [int] NOT NULL,
	[stav] [int] NULL,
 CONSTRAINT [PK_Polozkyobjednavka] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 29.03.2019 10:26:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[identifikator] [varchar](50) NOT NULL,
	[popis] [varchar](50) NULL,
	[aktivovano] [bit] NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stavy]    Script Date: 29.03.2019 10:26:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stavy](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[aktivovano] [bit] NOT NULL,
	[nazev] [varchar](max) NOT NULL,
 CONSTRAINT [PK_Stavy] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ucty]    Script Date: 29.03.2019 10:26:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ucty](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[jmeno] [varchar](50) NOT NULL,
	[prijmeni] [varchar](50) NOT NULL,
	[prezdivka] [varchar](50) NOT NULL,
	[login] [varchar](50) NOT NULL,
	[heslo] [varchar](50) NOT NULL,
	[aktivovano] [bit] NOT NULL,
	[role] [int] NOT NULL,
	[adresa] [int] NULL,
	[email] [varchar](50) NULL,
	[telefon] [varchar](50) NULL,
 CONSTRAINT [PK_Ucty] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vydavatele]    Script Date: 29.03.2019 10:26:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vydavatele](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nazev] [varchar](50) NOT NULL,
	[aktivovano] [bit] NOT NULL,
	[pocet] [int] NOT NULL,
 CONSTRAINT [PK_Vydavatele] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Adresy] ON 
GO
INSERT [dbo].[Adresy] ([id], [aktivovano], [mesto], [zeme], [psc], [uliceCP]) VALUES (2, 0, N'Týniště nad Orlicí', N'SSSR', N'51721', N'Voklik 810')
GO
INSERT [dbo].[Adresy] ([id], [aktivovano], [mesto], [zeme], [psc], [uliceCP]) VALUES (3, 0, N'Týniště nad Orlicí', N'CZ', N'51721', N'Voklik 810')
GO
INSERT [dbo].[Adresy] ([id], [aktivovano], [mesto], [zeme], [psc], [uliceCP]) VALUES (4, 0, N'Týniště nad Orlicí', N'CZ', N'51721', N'Voklik 8101')
GO
INSERT [dbo].[Adresy] ([id], [aktivovano], [mesto], [zeme], [psc], [uliceCP]) VALUES (6, 1, N'Tyn', N'cz', N'514', N'30')
GO
INSERT [dbo].[Adresy] ([id], [aktivovano], [mesto], [zeme], [psc], [uliceCP]) VALUES (7, 1, N'smrtihlavov', N'SK', N'53267', N'DOK')
GO
INSERT [dbo].[Adresy] ([id], [aktivovano], [mesto], [zeme], [psc], [uliceCP]) VALUES (8, 0, N'Rokycany', N'SSSR', N'51735', N'Rokan 45')
GO
INSERT [dbo].[Adresy] ([id], [aktivovano], [mesto], [zeme], [psc], [uliceCP]) VALUES (11, 1, N'Peklo', N'SSSR', N'666', N'Peklo 3')
GO
INSERT [dbo].[Adresy] ([id], [aktivovano], [mesto], [zeme], [psc], [uliceCP]) VALUES (12, 1, N'Týniště nad Orlicí', N'SSSR', N'51721', N'Voklik 810')
GO
INSERT [dbo].[Adresy] ([id], [aktivovano], [mesto], [zeme], [psc], [uliceCP]) VALUES (13, 1, N'Týniště nad Orlicí', N'SSSR', N'51721', N'Voklik 810')
GO
INSERT [dbo].[Adresy] ([id], [aktivovano], [mesto], [zeme], [psc], [uliceCP]) VALUES (14, 1, N'Peklo', N'SSSR', N'666', N'Peklo 3')
GO
INSERT [dbo].[Adresy] ([id], [aktivovano], [mesto], [zeme], [psc], [uliceCP]) VALUES (15, 1, N'Peklo', N'SSSR', N'666', N'Peklo 3')
GO
INSERT [dbo].[Adresy] ([id], [aktivovano], [mesto], [zeme], [psc], [uliceCP]) VALUES (16, 1, N'Týniště nad Orlicí', N'SSSR', N'51721', N'Voklik 810')
GO
INSERT [dbo].[Adresy] ([id], [aktivovano], [mesto], [zeme], [psc], [uliceCP]) VALUES (17, 1, N'Týniště nad Orlicí', N'SSSR', N'51721', N'Voklik 810')
GO
INSERT [dbo].[Adresy] ([id], [aktivovano], [mesto], [zeme], [psc], [uliceCP]) VALUES (18, 1, N'Týniště nad Orlicí', N'CZ', N'51721', N'Voklik 8101')
GO
SET IDENTITY_INSERT [dbo].[Adresy] OFF
GO
SET IDENTITY_INSERT [dbo].[DopravaMoznosti] ON 
GO
INSERT [dbo].[DopravaMoznosti] ([id], [aktivovano], [nazev], [popis], [cena]) VALUES (4, 1, N'PPL', N'PPL doručí balíček', CAST(0.5000 AS Decimal(9, 4)))
GO
INSERT [dbo].[DopravaMoznosti] ([id], [aktivovano], [nazev], [popis], [cena]) VALUES (5, 1, N'česká pošta - domu', N'česká pošta doručí', CAST(60.0000 AS Decimal(9, 4)))
GO
INSERT [dbo].[DopravaMoznosti] ([id], [aktivovano], [nazev], [popis], [cena]) VALUES (6, 0, N'česká pošta - pošta', N'česká pošta si to nechá na poště', CAST(40.0000 AS Decimal(9, 4)))
GO
INSERT [dbo].[DopravaMoznosti] ([id], [aktivovano], [nazev], [popis], [cena]) VALUES (7, 1, N'SSSR pošta', N'pošta z pravé domoviny', CAST(30.5000 AS Decimal(9, 4)))
GO
INSERT [dbo].[DopravaMoznosti] ([id], [aktivovano], [nazev], [popis], [cena]) VALUES (8, 0, N'USA federace pošt', N'USA USA USA', CAST(30.5400 AS Decimal(9, 4)))
GO
SET IDENTITY_INSERT [dbo].[DopravaMoznosti] OFF
GO
SET IDENTITY_INSERT [dbo].[Hry] ON 
GO
INSERT [dbo].[Hry] ([id], [nazev], [cena], [popis], [sleva], [platforma], [vydavatel], [ikona], [skladem], [datumVydani], [aktivovano], [dph]) VALUES (1, N'NHL 19', CAST(600.0000 AS Decimal(9, 4)), N'Boj mezi orky a lidmi.', CAST(0.0000 AS Decimal(5, 4)), 5, 2, N'c27b4391-f0fb-45a1-bbfb-224c02939e47.jpg', 0, N'2016', 1, CAST(0.2100 AS Decimal(5, 4)))
GO
INSERT [dbo].[Hry] ([id], [nazev], [cena], [popis], [sleva], [platforma], [vydavatel], [ikona], [skladem], [datumVydani], [aktivovano], [dph]) VALUES (3, N'GTA 4', CAST(1000.0000 AS Decimal(9, 4)), N'Hra plna vražd', CAST(0.2500 AS Decimal(5, 4)), 5, 4, N'f5381039-2fec-4137-95d7-de762da7fb9e.jpg', 100, N'30/04/2016', 1, CAST(0.2000 AS Decimal(5, 4)))
GO
INSERT [dbo].[Hry] ([id], [nazev], [cena], [popis], [sleva], [platforma], [vydavatel], [ikona], [skladem], [datumVydani], [aktivovano], [dph]) VALUES (5, N'Spyro', CAST(1000.0000 AS Decimal(9, 4)), N'Statečný Psyduck se vydává na cesty po světě ', CAST(0.0000 AS Decimal(5, 4)), 5, 3, N'e1b7e17f-a05b-4e4a-a16f-6564ee643354.jpg', 1000, N'30/04/2017', 1, CAST(0.2000 AS Decimal(5, 4)))
GO
INSERT [dbo].[Hry] ([id], [nazev], [cena], [popis], [sleva], [platforma], [vydavatel], [ikona], [skladem], [datumVydani], [aktivovano], [dph]) VALUES (7, N'Crash bandigoot', CAST(1000.0000 AS Decimal(9, 4)), N'Statečný Psyduck se vydává na cesty po světě ', CAST(0.2500 AS Decimal(5, 4)), 5, 1, N'5e037e8b-6222-4ab6-b4ed-c98a2b1a5d23.jpg', 35, N'30/04/2016', 1, CAST(0.2000 AS Decimal(5, 4)))
GO
INSERT [dbo].[Hry] ([id], [nazev], [cena], [popis], [sleva], [platforma], [vydavatel], [ikona], [skladem], [datumVydani], [aktivovano], [dph]) VALUES (8, N'Farming simulator 19', CAST(200.0000 AS Decimal(9, 4)), N'a', CAST(0.2500 AS Decimal(5, 4)), 5, 1, N'a59545be-a23d-418c-9c5b-c2660efa2270.jpg', 100, N'30/04/2017', 0, CAST(0.2000 AS Decimal(5, 4)))
GO
INSERT [dbo].[Hry] ([id], [nazev], [cena], [popis], [sleva], [platforma], [vydavatel], [ikona], [skladem], [datumVydani], [aktivovano], [dph]) VALUES (9, N'Division', CAST(5000.0000 AS Decimal(9, 4)), N'vražda', CAST(0.0000 AS Decimal(5, 4)), 5, 1, N'871d861a-f8c3-42fb-8fc4-41225579af87.jpg', 300, N'20/06/2010', 1, CAST(0.2100 AS Decimal(5, 4)))
GO
INSERT [dbo].[Hry] ([id], [nazev], [cena], [popis], [sleva], [platforma], [vydavatel], [ikona], [skladem], [datumVydani], [aktivovano], [dph]) VALUES (10, N'Assassins creed odysea', CAST(999.9900 AS Decimal(9, 4)), N'vražda', CAST(0.1000 AS Decimal(5, 4)), 5, 1, N'f5b54764-e6aa-4326-b6ee-3b69d8bf8e56.jpg', 800, N'20/06/2010', 1, CAST(0.2100 AS Decimal(5, 4)))
GO
INSERT [dbo].[Hry] ([id], [nazev], [cena], [popis], [sleva], [platforma], [vydavatel], [ikona], [skladem], [datumVydani], [aktivovano], [dph]) VALUES (11, N'Metro exodus', CAST(199.0000 AS Decimal(9, 4)), N'smrt', CAST(0.0000 AS Decimal(5, 4)), 5, 5, N'c5bc25f4-9de4-45cd-8443-5b31b74d40cc.jpg', 100, N'20/06/2010', 1, CAST(0.2100 AS Decimal(5, 4)))
GO
INSERT [dbo].[Hry] ([id], [nazev], [cena], [popis], [sleva], [platforma], [vydavatel], [ikona], [skladem], [datumVydani], [aktivovano], [dph]) VALUES (12, N'Call of duty', CAST(1999.0000 AS Decimal(9, 4)), N'vražda', CAST(0.2000 AS Decimal(5, 4)), 5, 2, N'9f41e9f0-956f-46e0-b8e2-d5d2f3e98001.jpg', 20, N'20/06/2010', 1, CAST(0.2100 AS Decimal(5, 4)))
GO
INSERT [dbo].[Hry] ([id], [nazev], [cena], [popis], [sleva], [platforma], [vydavatel], [ikona], [skladem], [datumVydani], [aktivovano], [dph]) VALUES (13, N'Red dead redemtion 2', CAST(2000.0000 AS Decimal(9, 4)), N'vražda', CAST(0.1000 AS Decimal(5, 4)), 5, 1, N'c990e978-b140-4e69-a2e3-a4553b150ca6.jpg', 100, N'20/06/2010', 1, CAST(0.2100 AS Decimal(5, 4)))
GO
INSERT [dbo].[Hry] ([id], [nazev], [cena], [popis], [sleva], [platforma], [vydavatel], [ikona], [skladem], [datumVydani], [aktivovano], [dph]) VALUES (14, N'destiny 2', CAST(5000.0000 AS Decimal(9, 4)), N'Hra ', CAST(0.1000 AS Decimal(5, 4)), 1, 2, N'e0a07673-02f1-46bf-a0cd-695fe1e07d54.jpg', 100, N'20/06/2010', 1, CAST(0.2100 AS Decimal(5, 4)))
GO
INSERT [dbo].[Hry] ([id], [nazev], [cena], [popis], [sleva], [platforma], [vydavatel], [ikona], [skladem], [datumVydani], [aktivovano], [dph]) VALUES (15, N'Metro exodus', CAST(900.0000 AS Decimal(9, 4)), N'Hra ', CAST(0.0000 AS Decimal(5, 4)), 1, 3, N'5d1ca9d4-fb04-4de7-b0f4-78622e0fabd4.jpg', 100, N'20/06/2010', 1, CAST(0.2100 AS Decimal(5, 4)))
GO
INSERT [dbo].[Hry] ([id], [nazev], [cena], [popis], [sleva], [platforma], [vydavatel], [ikona], [skladem], [datumVydani], [aktivovano], [dph]) VALUES (16, N'Anthem', CAST(5000.0000 AS Decimal(9, 4)), N'Hra ', CAST(0.0000 AS Decimal(5, 4)), 1, 4, N'47d3694a-9868-445e-b76f-7939ed572289.jpg', 100, N'20/06/2010', 1, CAST(0.2100 AS Decimal(5, 4)))
GO
INSERT [dbo].[Hry] ([id], [nazev], [cena], [popis], [sleva], [platforma], [vydavatel], [ikona], [skladem], [datumVydani], [aktivovano], [dph]) VALUES (17, N'World of warcraft', CAST(50000.0000 AS Decimal(9, 4)), N'Hra ', CAST(0.0000 AS Decimal(5, 4)), 1, 2, N'bba2a5bc-e61e-4606-8925-59c891cd89cd.jpg', 100, N'20/06/2010', 1, CAST(0.2100 AS Decimal(5, 4)))
GO
INSERT [dbo].[Hry] ([id], [nazev], [cena], [popis], [sleva], [platforma], [vydavatel], [ikona], [skladem], [datumVydani], [aktivovano], [dph]) VALUES (18, N'Battlefield V', CAST(0.0000 AS Decimal(9, 4)), N'Hra ', CAST(0.0000 AS Decimal(5, 4)), 1, 1, N'1d89f441-28d6-453e-8c90-3a0b63f65973.jpg', 100, N'20/06/2010', 0, CAST(0.2100 AS Decimal(5, 4)))
GO
INSERT [dbo].[Hry] ([id], [nazev], [cena], [popis], [sleva], [platforma], [vydavatel], [ikona], [skladem], [datumVydani], [aktivovano], [dph]) VALUES (19, N'Fallout 76', CAST(0.0000 AS Decimal(9, 4)), N'Hra ', CAST(0.0000 AS Decimal(5, 4)), 1, 3, N'ec8f8dd0-ab5e-44d4-b355-87aded90abe1.jpg', 100, N'20/06/2010', 1, CAST(0.2100 AS Decimal(5, 4)))
GO
INSERT [dbo].[Hry] ([id], [nazev], [cena], [popis], [sleva], [platforma], [vydavatel], [ikona], [skladem], [datumVydani], [aktivovano], [dph]) VALUES (20, N'Resident evil VII', CAST(900.0000 AS Decimal(9, 4)), N'Hra ', CAST(0.0000 AS Decimal(5, 4)), 1, 5, N'5041c25e-9929-4819-b9fd-d8cd14e2ff8e.jpg', 100, N'20/06/2010', 1, CAST(0.2100 AS Decimal(5, 4)))
GO
INSERT [dbo].[Hry] ([id], [nazev], [cena], [popis], [sleva], [platforma], [vydavatel], [ikona], [skladem], [datumVydani], [aktivovano], [dph]) VALUES (21, N'OverWatch', CAST(900.0000 AS Decimal(9, 4)), N'Hra ', CAST(0.2000 AS Decimal(5, 4)), 1, 2, N'27496c45-0b50-48eb-9b12-4a820e92265d.jpg', 800, N'20/06/2010', 1, CAST(0.2100 AS Decimal(5, 4)))
GO
INSERT [dbo].[Hry] ([id], [nazev], [cena], [popis], [sleva], [platforma], [vydavatel], [ikona], [skladem], [datumVydani], [aktivovano], [dph]) VALUES (22, N'Farming simulator 19', CAST(900.0000 AS Decimal(9, 4)), N'Hra ', CAST(0.0000 AS Decimal(5, 4)), 1, 4, N'4ace0dbd-b61f-447a-9073-48ee65f54930.jpg', 300, N'20/06/2010', 1, CAST(0.2100 AS Decimal(5, 4)))
GO
INSERT [dbo].[Hry] ([id], [nazev], [cena], [popis], [sleva], [platforma], [vydavatel], [ikona], [skladem], [datumVydani], [aktivovano], [dph]) VALUES (23, N'Metro exodus', CAST(900.0000 AS Decimal(9, 4)), N'Hra ', CAST(0.1000 AS Decimal(5, 4)), 1, 1, N'3d04e3ee-b010-47e4-a10c-ee75efaf2247.jpg', 300, N'20/06/2010', 1, CAST(0.2100 AS Decimal(5, 4)))
GO
INSERT [dbo].[Hry] ([id], [nazev], [cena], [popis], [sleva], [platforma], [vydavatel], [ikona], [skladem], [datumVydani], [aktivovano], [dph]) VALUES (24, N'lego harry potter', CAST(199.0000 AS Decimal(9, 4)), N'Hra ', CAST(0.1000 AS Decimal(5, 4)), 2, 3, N'4c11125c-e208-4f67-acfd-8537f46bb18f.jpg', 800, N'20/06/2010', 1, CAST(0.2100 AS Decimal(5, 4)))
GO
INSERT [dbo].[Hry] ([id], [nazev], [cena], [popis], [sleva], [platforma], [vydavatel], [ikona], [skladem], [datumVydani], [aktivovano], [dph]) VALUES (25, N'Red dead redemtion', CAST(359.0000 AS Decimal(9, 4)), N'Hra ', CAST(0.0000 AS Decimal(5, 4)), 2, 1, N'32eb7d70-c18c-427a-90ac-d78d9aa81e71.jpg', 300, N'20/06/2010', 1, CAST(0.2100 AS Decimal(5, 4)))
GO
INSERT [dbo].[Hry] ([id], [nazev], [cena], [popis], [sleva], [platforma], [vydavatel], [ikona], [skladem], [datumVydani], [aktivovano], [dph]) VALUES (26, N'GTA 4', CAST(500.0000 AS Decimal(9, 4)), N'Hra ', CAST(0.0000 AS Decimal(5, 4)), 2, 1, N'2e0a9c0e-1967-439e-8a7e-baede71e8210.jpg', 100, N'20/06/2010', 0, CAST(0.2100 AS Decimal(5, 4)))
GO
INSERT [dbo].[Hry] ([id], [nazev], [cena], [popis], [sleva], [platforma], [vydavatel], [ikona], [skladem], [datumVydani], [aktivovano], [dph]) VALUES (27, N'minecraft', CAST(199.0000 AS Decimal(9, 4)), N'Hra ', CAST(0.1000 AS Decimal(5, 4)), 2, 5, N'e4204079-148e-45b5-b5f2-cfcbfd7fc475.jpg', 300, N'20/06/2010', 1, CAST(0.2100 AS Decimal(5, 4)))
GO
INSERT [dbo].[Hry] ([id], [nazev], [cena], [popis], [sleva], [platforma], [vydavatel], [ikona], [skladem], [datumVydani], [aktivovano], [dph]) VALUES (28, N'lego marvel', CAST(900.0000 AS Decimal(9, 4)), N'Hra ', CAST(0.0000 AS Decimal(5, 4)), 2, 5, N'aae0bde1-916a-40b4-bb69-3862d0d7b475.jpg', 100, N'20/06/2010', 0, CAST(0.2100 AS Decimal(5, 4)))
GO
INSERT [dbo].[Hry] ([id], [nazev], [cena], [popis], [sleva], [platforma], [vydavatel], [ikona], [skladem], [datumVydani], [aktivovano], [dph]) VALUES (29, N'need for speed', CAST(199.0000 AS Decimal(9, 4)), N'Hra ', CAST(0.0000 AS Decimal(5, 4)), 2, 4, N'80d08097-b5f1-49cd-ae71-327293db3ff6.jpg', 100, N'20/06/2010', 0, CAST(0.2100 AS Decimal(5, 4)))
GO
INSERT [dbo].[Hry] ([id], [nazev], [cena], [popis], [sleva], [platforma], [vydavatel], [ikona], [skladem], [datumVydani], [aktivovano], [dph]) VALUES (30, N'lego dyno', CAST(900.0000 AS Decimal(9, 4)), N'Hra ', CAST(0.1000 AS Decimal(5, 4)), 2, 4, N'03072c92-e092-45b4-9a50-ecff2c89ea44.jpg', 300, N'20/06/2010', 0, CAST(0.2100 AS Decimal(5, 4)))
GO
INSERT [dbo].[Hry] ([id], [nazev], [cena], [popis], [sleva], [platforma], [vydavatel], [ikona], [skladem], [datumVydani], [aktivovano], [dph]) VALUES (31, N'lego avengers', CAST(199.0000 AS Decimal(9, 4)), N'Hra ', CAST(0.1000 AS Decimal(5, 4)), 2, 5, N'2206d4da-276a-45db-bdae-40a17ab279aa.jpg', 800, N'20/06/2010', 1, CAST(0.2100 AS Decimal(5, 4)))
GO
INSERT [dbo].[Hry] ([id], [nazev], [cena], [popis], [sleva], [platforma], [vydavatel], [ikona], [skladem], [datumVydani], [aktivovano], [dph]) VALUES (32, N'Just Dance', CAST(199.0000 AS Decimal(9, 4)), N'Hra ', CAST(0.1000 AS Decimal(5, 4)), 2, 1, N'4522f917-3765-4397-824f-f1433674d740.jpg', 800, N'20/06/2010', 0, CAST(0.2100 AS Decimal(5, 4)))
GO
INSERT [dbo].[Hry] ([id], [nazev], [cena], [popis], [sleva], [platforma], [vydavatel], [ikona], [skladem], [datumVydani], [aktivovano], [dph]) VALUES (33, N'Fifa 19', CAST(5000.0000 AS Decimal(9, 4)), N'Hra ', CAST(0.1000 AS Decimal(5, 4)), 2, 1, N'd143b726-f8f7-4843-b2d4-bc5cb7bec70b.jpg', 300, N'20/06/2010', 1, CAST(0.2100 AS Decimal(5, 4)))
GO
INSERT [dbo].[Hry] ([id], [nazev], [cena], [popis], [sleva], [platforma], [vydavatel], [ikona], [skladem], [datumVydani], [aktivovano], [dph]) VALUES (34, N'GTA 4', CAST(199.0000 AS Decimal(9, 4)), N'Hra ', CAST(0.1000 AS Decimal(5, 4)), 4, 1, N'2c5e645f-2051-4876-a5b5-65bf0155cb61.jpg', 300, N'20/06/2010', 0, CAST(0.2100 AS Decimal(5, 4)))
GO
INSERT [dbo].[Hry] ([id], [nazev], [cena], [popis], [sleva], [platforma], [vydavatel], [ikona], [skladem], [datumVydani], [aktivovano], [dph]) VALUES (35, N'detroit', CAST(199.0000 AS Decimal(9, 4)), N'Hra ', CAST(0.1000 AS Decimal(5, 4)), 4, 3, N'08b822ec-1678-47d9-b517-8d0869505f07.jpg', 100, N'20/06/2010', 1, CAST(0.2100 AS Decimal(5, 4)))
GO
INSERT [dbo].[Hry] ([id], [nazev], [cena], [popis], [sleva], [platforma], [vydavatel], [ikona], [skladem], [datumVydani], [aktivovano], [dph]) VALUES (36, N'god of war', CAST(5000.0000 AS Decimal(9, 4)), N'Hra ', CAST(0.1000 AS Decimal(5, 4)), 4, 4, N'2c6c6e04-cdfe-4fcc-b404-341706a0070f.jpg', 300, N'20/06/2010', 1, CAST(0.2100 AS Decimal(5, 4)))
GO
INSERT [dbo].[Hry] ([id], [nazev], [cena], [popis], [sleva], [platforma], [vydavatel], [ikona], [skladem], [datumVydani], [aktivovano], [dph]) VALUES (37, N'Red dead redemtion 2', CAST(900.0000 AS Decimal(9, 4)), N'Hra ', CAST(0.2000 AS Decimal(5, 4)), 4, 5, N'734bc89d-7276-45f9-91ec-91a67e4b4794.jpg', 20, N'20/06/2010', 1, CAST(0.2100 AS Decimal(5, 4)))
GO
INSERT [dbo].[Hry] ([id], [nazev], [cena], [popis], [sleva], [platforma], [vydavatel], [ikona], [skladem], [datumVydani], [aktivovano], [dph]) VALUES (38, N'Crash bandigoot', CAST(199.0000 AS Decimal(9, 4)), N'Hra ', CAST(0.1000 AS Decimal(5, 4)), 4, 3, N'2bee46dd-540e-4f69-877e-c5d65dd6c5c8.jpg', 100, N'20/06/2010', 1, CAST(0.2100 AS Decimal(5, 4)))
GO
INSERT [dbo].[Hry] ([id], [nazev], [cena], [popis], [sleva], [platforma], [vydavatel], [ikona], [skladem], [datumVydani], [aktivovano], [dph]) VALUES (39, N'spiderman', CAST(900.0000 AS Decimal(9, 4)), N'Hra ', CAST(0.2000 AS Decimal(5, 4)), 4, 1, N'2b00af81-9563-4a23-a736-de7f288bb152.jpg', 300, N'20/06/2010', 1, CAST(0.2100 AS Decimal(5, 4)))
GO
INSERT [dbo].[Hry] ([id], [nazev], [cena], [popis], [sleva], [platforma], [vydavatel], [ikona], [skladem], [datumVydani], [aktivovano], [dph]) VALUES (40, N'Fifa 19', CAST(1999.0000 AS Decimal(9, 4)), N'Hra ', CAST(0.1000 AS Decimal(5, 4)), 4, 4, N'6617265b-8c18-464f-96df-c64f41156d57.jpg', 300, N'20/06/2010', 1, CAST(0.2100 AS Decimal(5, 4)))
GO
INSERT [dbo].[Hry] ([id], [nazev], [cena], [popis], [sleva], [platforma], [vydavatel], [ikona], [skladem], [datumVydani], [aktivovano], [dph]) VALUES (41, N'sekiro', CAST(900.0000 AS Decimal(9, 4)), N'Hra ', CAST(0.1000 AS Decimal(5, 4)), 4, 4, N'173d0513-27bf-4ee7-ac8e-7174d78b3358.jpg', 300, N'20/06/2010', 1, CAST(0.2100 AS Decimal(5, 4)))
GO
INSERT [dbo].[Hry] ([id], [nazev], [cena], [popis], [sleva], [platforma], [vydavatel], [ikona], [skladem], [datumVydani], [aktivovano], [dph]) VALUES (42, N'the last of AS', CAST(900.0000 AS Decimal(9, 4)), N'Hra ', CAST(0.1000 AS Decimal(5, 4)), 4, 4, N'36762c84-3a7f-4eb4-a64e-03d249733799.jpg', 100, N'20/06/2010', 0, CAST(0.2100 AS Decimal(5, 4)))
GO
INSERT [dbo].[Hry] ([id], [nazev], [cena], [popis], [sleva], [platforma], [vydavatel], [ikona], [skladem], [datumVydani], [aktivovano], [dph]) VALUES (43, N'uncharted 4', CAST(900.0000 AS Decimal(9, 4)), N'USA USA USA', CAST(0.1000 AS Decimal(5, 4)), 4, 1, N'f239a93d-b2f1-4115-9632-a56f24ac4b88.jpg', 100, N'20/06/2010', 1, CAST(0.2100 AS Decimal(5, 4)))
GO
SET IDENTITY_INSERT [dbo].[Hry] OFF
GO
SET IDENTITY_INSERT [dbo].[KombinaceMoznosti] ON 
GO
INSERT [dbo].[KombinaceMoznosti] ([id], [aktivovano], [platebniMoznost], [dopravniMoznost], [cenaDoprava], [cenaPlatba], [cenaObjednavka]) VALUES (4, 1, 1, 4, CAST(0.0000 AS Decimal(9, 4)), CAST(0.0000 AS Decimal(9, 4)), CAST(2000.0000 AS Decimal(9, 4)))
GO
INSERT [dbo].[KombinaceMoznosti] ([id], [aktivovano], [platebniMoznost], [dopravniMoznost], [cenaDoprava], [cenaPlatba], [cenaObjednavka]) VALUES (10, 1, 2, 7, CAST(0.0000 AS Decimal(9, 4)), CAST(0.0000 AS Decimal(9, 4)), CAST(5000.0000 AS Decimal(9, 4)))
GO
SET IDENTITY_INSERT [dbo].[KombinaceMoznosti] OFF
GO
SET IDENTITY_INSERT [dbo].[Objednavky] ON 
GO
INSERT [dbo].[Objednavky] ([id], [aktivovano], [cislo], [uzivatel], [stav], [datumObjednani], [platba], [doprava], [adresa], [cenaDopravy], [cenaPlatby], [cenaCelkem], [jmeno], [prijmeni], [email], [telefon]) VALUES (1, 1, N'21/03/2019/1', 1, 1, CAST(N'2019-03-22T00:00:00.000' AS DateTime), 1, 4, 2, CAST(0.0000 AS Decimal(9, 4)), CAST(0.0000 AS Decimal(9, 4)), CAST(10580.0000 AS Decimal(9, 4)), NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Objednavky] ([id], [aktivovano], [cislo], [uzivatel], [stav], [datumObjednani], [platba], [doprava], [adresa], [cenaDopravy], [cenaPlatby], [cenaCelkem], [jmeno], [prijmeni], [email], [telefon]) VALUES (3, 1, N'20/03/2019/2', 1, 5, CAST(N'2019-03-22T00:00:00.000' AS DateTime), 1, 4, 2, CAST(60.0000 AS Decimal(9, 4)), CAST(60.0000 AS Decimal(9, 4)), CAST(5000.0000 AS Decimal(9, 4)), NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Objednavky] ([id], [aktivovano], [cislo], [uzivatel], [stav], [datumObjednani], [platba], [doprava], [adresa], [cenaDopravy], [cenaPlatby], [cenaCelkem], [jmeno], [prijmeni], [email], [telefon]) VALUES (14, 1, N'22 Mar 2019/14', 1, 1, CAST(N'2019-03-22T00:00:00.000' AS DateTime), 1, 4, 2, CAST(0.0000 AS Decimal(9, 4)), CAST(0.0000 AS Decimal(9, 4)), CAST(7674.0640 AS Decimal(9, 4)), NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Objednavky] ([id], [aktivovano], [cislo], [uzivatel], [stav], [datumObjednani], [platba], [doprava], [adresa], [cenaDopravy], [cenaPlatby], [cenaCelkem], [jmeno], [prijmeni], [email], [telefon]) VALUES (16, 1, N'28 Mar 2019/16', 0, 1, CAST(N'2019-03-28T18:12:33.000' AS DateTime), 1, 4, 11, CAST(0.0000 AS Decimal(9, 4)), CAST(0.0000 AS Decimal(9, 4)), CAST(2900.3482 AS Decimal(9, 4)), N'Josef', N'Hert', N'hert@seznam.cz', N'626 262')
GO
INSERT [dbo].[Objednavky] ([id], [aktivovano], [cislo], [uzivatel], [stav], [datumObjednani], [platba], [doprava], [adresa], [cenaDopravy], [cenaPlatby], [cenaCelkem], [jmeno], [prijmeni], [email], [telefon]) VALUES (17, 1, N'28 Mar 2019/17', 0, 1, CAST(N'2019-03-28T18:31:38.000' AS DateTime), 1, 4, 12, CAST(0.0000 AS Decimal(9, 4)), CAST(0.0000 AS Decimal(9, 4)), CAST(2540.9891 AS Decimal(9, 4)), N'Josef', N'Godot', N'godot@seznam.cz', N'+420 xxx xxx xxx')
GO
INSERT [dbo].[Objednavky] ([id], [aktivovano], [cislo], [uzivatel], [stav], [datumObjednani], [platba], [doprava], [adresa], [cenaDopravy], [cenaPlatby], [cenaCelkem], [jmeno], [prijmeni], [email], [telefon]) VALUES (18, 1, N'28 Mar 2019/18', 1, 1, CAST(N'2019-03-28T18:35:15.000' AS DateTime), 1, 4, 13, CAST(0.0000 AS Decimal(9, 4)), CAST(0.0000 AS Decimal(9, 4)), CAST(2540.9891 AS Decimal(9, 4)), N'Josef', N'Godot', N'godot@seznam.cz', N'+420 xxx xxx xxx')
GO
INSERT [dbo].[Objednavky] ([id], [aktivovano], [cislo], [uzivatel], [stav], [datumObjednani], [platba], [doprava], [adresa], [cenaDopravy], [cenaPlatby], [cenaCelkem], [jmeno], [prijmeni], [email], [telefon]) VALUES (19, 1, N'28 Mar 2019/19', 0, 1, CAST(N'2019-03-28T20:29:03.000' AS DateTime), 1, 4, 14, CAST(0.0000 AS Decimal(9, 4)), CAST(0.0000 AS Decimal(9, 4)), CAST(2177.9782 AS Decimal(9, 4)), N'Josef', N'Hert', N'hert@seznam.cz', N'626 262')
GO
INSERT [dbo].[Objednavky] ([id], [aktivovano], [cislo], [uzivatel], [stav], [datumObjednani], [platba], [doprava], [adresa], [cenaDopravy], [cenaPlatby], [cenaCelkem], [jmeno], [prijmeni], [email], [telefon]) VALUES (20, 1, N'28 Mar 2019/20', 0, 1, CAST(N'2019-03-28T20:30:27.000' AS DateTime), 1, 4, 15, CAST(0.0000 AS Decimal(9, 4)), CAST(0.0000 AS Decimal(9, 4)), CAST(900.0000 AS Decimal(9, 4)), N'Josef', N'Hert', N'hert@seznam.cz', N'626 262')
GO
INSERT [dbo].[Objednavky] ([id], [aktivovano], [cislo], [uzivatel], [stav], [datumObjednani], [platba], [doprava], [adresa], [cenaDopravy], [cenaPlatby], [cenaCelkem], [jmeno], [prijmeni], [email], [telefon]) VALUES (21, 1, N'28 Mar 2019/21', 1, 1, CAST(N'2019-03-28T20:33:57.000' AS DateTime), 1, 4, 16, CAST(0.0000 AS Decimal(9, 4)), CAST(0.0000 AS Decimal(9, 4)), CAST(1200.0000 AS Decimal(9, 4)), N'Josef', N'Godot', N'godot@seznam.cz', N'+420 xxx xxx xxx')
GO
INSERT [dbo].[Objednavky] ([id], [aktivovano], [cislo], [uzivatel], [stav], [datumObjednani], [platba], [doprava], [adresa], [cenaDopravy], [cenaPlatby], [cenaCelkem], [jmeno], [prijmeni], [email], [telefon]) VALUES (22, 1, N'28 Mar 2019/22', 1, 1, CAST(N'2019-03-28T20:57:11.000' AS DateTime), 1, 4, 17, CAST(0.0000 AS Decimal(9, 4)), CAST(0.0000 AS Decimal(9, 4)), CAST(1935.0320 AS Decimal(9, 4)), N'Josef', N'Godot', N'godot@seznam.cz', N'+420 xxx xxx xxx')
GO
INSERT [dbo].[Objednavky] ([id], [aktivovano], [cislo], [uzivatel], [stav], [datumObjednani], [platba], [doprava], [adresa], [cenaDopravy], [cenaPlatby], [cenaCelkem], [jmeno], [prijmeni], [email], [telefon]) VALUES (23, 1, N'28 Mar 2019/23', 6, 1, CAST(N'2019-03-28T21:02:29.000' AS DateTime), 1, 4, 18, CAST(0.0000 AS Decimal(9, 4)), CAST(0.0000 AS Decimal(9, 4)), CAST(1935.0320 AS Decimal(9, 4)), N'Jan', N'Žižka', N'oko@seznam.cz', N'+420 xxx xxx xxx')
GO
SET IDENTITY_INSERT [dbo].[Objednavky] OFF
GO
SET IDENTITY_INSERT [dbo].[Obrazky] ON 
GO
INSERT [dbo].[Obrazky] ([id], [hra_id], [ikona], [popis], [aktivovano]) VALUES (8, 1, N'4460d5f7-22e6-4243-95df-0e821dee9765.jpg', N'warcraft', 1)
GO
INSERT [dbo].[Obrazky] ([id], [hra_id], [ikona], [popis], [aktivovano]) VALUES (24, 16, N'd296fdb7-4ad7-4f22-a9ba-cb503fd98a4d.jpg', NULL, 1)
GO
INSERT [dbo].[Obrazky] ([id], [hra_id], [ikona], [popis], [aktivovano]) VALUES (25, 16, N'87fcae31-713d-4050-8cfd-c6f6861f2baf.jpg', N'Hra ', 1)
GO
INSERT [dbo].[Obrazky] ([id], [hra_id], [ikona], [popis], [aktivovano]) VALUES (26, 16, N'31dde021-f2b5-422f-9cf0-2e2de69cfa67.jpg', N'Hra ', 1)
GO
INSERT [dbo].[Obrazky] ([id], [hra_id], [ikona], [popis], [aktivovano]) VALUES (27, 10, N'af20822a-1e40-4e72-a118-cdb05c9f1fbe.jpg', NULL, 1)
GO
INSERT [dbo].[Obrazky] ([id], [hra_id], [ikona], [popis], [aktivovano]) VALUES (28, 18, N'8acae858-32ab-4d69-b0c3-b17589a4f09a.jpg', NULL, 1)
GO
INSERT [dbo].[Obrazky] ([id], [hra_id], [ikona], [popis], [aktivovano]) VALUES (29, 12, N'54ad12c5-ef8f-44f6-80b0-69df92bafd26.jpg', NULL, 1)
GO
INSERT [dbo].[Obrazky] ([id], [hra_id], [ikona], [popis], [aktivovano]) VALUES (30, 7, N'4522d40c-48cb-4b1e-87da-7cc685b3d1de.jpg', NULL, 1)
GO
INSERT [dbo].[Obrazky] ([id], [hra_id], [ikona], [popis], [aktivovano]) VALUES (31, 7, N'a0a4183d-392a-454b-82d0-5e724db785dc.jpg', NULL, 1)
GO
INSERT [dbo].[Obrazky] ([id], [hra_id], [ikona], [popis], [aktivovano]) VALUES (32, 38, N'4607eaaf-545b-4935-a2a8-791ca7928f96.jpg', N'Hra ', 1)
GO
INSERT [dbo].[Obrazky] ([id], [hra_id], [ikona], [popis], [aktivovano]) VALUES (33, 14, N'ef2cc7e3-479c-44df-91d4-68cc0fd97d8d.jpg', N'Hra ', 1)
GO
SET IDENTITY_INSERT [dbo].[Obrazky] OFF
GO
SET IDENTITY_INSERT [dbo].[PlatebniMoznosti] ON 
GO
INSERT [dbo].[PlatebniMoznosti] ([id], [aktivovano], [nazev], [popis], [cena]) VALUES (1, 1, N'Dobírka', N'Dobírka', CAST(40.0000 AS Decimal(9, 4)))
GO
INSERT [dbo].[PlatebniMoznosti] ([id], [aktivovano], [nazev], [popis], [cena]) VALUES (2, 1, N'Platba předem', N'platba předem', CAST(0.6000 AS Decimal(9, 4)))
GO
SET IDENTITY_INSERT [dbo].[PlatebniMoznosti] OFF
GO
SET IDENTITY_INSERT [dbo].[Platformy] ON 
GO
INSERT [dbo].[Platformy] ([id], [nazev], [aktivovano], [pocet]) VALUES (1, N'PC', 1, 10)
GO
INSERT [dbo].[Platformy] ([id], [nazev], [aktivovano], [pocet]) VALUES (2, N'Xbox 360', 1, 10)
GO
INSERT [dbo].[Platformy] ([id], [nazev], [aktivovano], [pocet]) VALUES (3, N'PS3', 0, 0)
GO
INSERT [dbo].[Platformy] ([id], [nazev], [aktivovano], [pocet]) VALUES (4, N'PS4', 1, 10)
GO
INSERT [dbo].[Platformy] ([id], [nazev], [aktivovano], [pocet]) VALUES (5, N'Xbox One', 1, 10)
GO
INSERT [dbo].[Platformy] ([id], [nazev], [aktivovano], [pocet]) VALUES (6, N'Nintendo Switch', 0, 0)
GO
SET IDENTITY_INSERT [dbo].[Platformy] OFF
GO
SET IDENTITY_INSERT [dbo].[PolozkyObjednavka] ON 
GO
INSERT [dbo].[PolozkyObjednavka] ([id], [aktivovano], [tehdejsiCena], [hra], [mnozstvi], [objednavkaID], [stav]) VALUES (1, 1, CAST(1600.0000 AS Decimal(9, 4)), 11, 3, 1, 9)
GO
INSERT [dbo].[PolozkyObjednavka] ([id], [aktivovano], [tehdejsiCena], [hra], [mnozstvi], [objednavkaID], [stav]) VALUES (4, 1, CAST(500.0000 AS Decimal(9, 4)), 1, 1, 3, 8)
GO
INSERT [dbo].[PolozkyObjednavka] ([id], [aktivovano], [tehdejsiCena], [hra], [mnozstvi], [objednavkaID], [stav]) VALUES (5, 1, CAST(5000.0000 AS Decimal(9, 4)), 11, 1, 1, 9)
GO
INSERT [dbo].[PolozkyObjednavka] ([id], [aktivovano], [tehdejsiCena], [hra], [mnozstvi], [objednavkaID], [stav]) VALUES (7, 1, CAST(726.0000 AS Decimal(9, 4)), 1, 1, 1, 8)
GO
INSERT [dbo].[PolozkyObjednavka] ([id], [aktivovano], [tehdejsiCena], [hra], [mnozstvi], [objednavkaID], [stav]) VALUES (8, 1, CAST(900.0000 AS Decimal(9, 4)), 7, 1, 1, 8)
GO
INSERT [dbo].[PolozkyObjednavka] ([id], [aktivovano], [tehdejsiCena], [hra], [mnozstvi], [objednavkaID], [stav]) VALUES (9, 1, CAST(1935.0320 AS Decimal(9, 4)), 12, 1, 14, 9)
GO
INSERT [dbo].[PolozkyObjednavka] ([id], [aktivovano], [tehdejsiCena], [hra], [mnozstvi], [objednavkaID], [stav]) VALUES (10, 1, CAST(1935.0320 AS Decimal(9, 4)), 12, 1, 14, 8)
GO
INSERT [dbo].[PolozkyObjednavka] ([id], [aktivovano], [tehdejsiCena], [hra], [mnozstvi], [objednavkaID], [stav]) VALUES (11, 1, CAST(1935.0320 AS Decimal(9, 4)), 12, 1, 14, 8)
GO
INSERT [dbo].[PolozkyObjednavka] ([id], [aktivovano], [tehdejsiCena], [hra], [mnozstvi], [objednavkaID], [stav]) VALUES (13, 1, CAST(900.0000 AS Decimal(9, 4)), 7, 1, 14, 8)
GO
INSERT [dbo].[PolozkyObjednavka] ([id], [aktivovano], [tehdejsiCena], [hra], [mnozstvi], [objednavkaID], [stav]) VALUES (14, 1, CAST(726.0000 AS Decimal(9, 4)), 1, 1, 14, 8)
GO
INSERT [dbo].[PolozkyObjednavka] ([id], [aktivovano], [tehdejsiCena], [hra], [mnozstvi], [objednavkaID], [stav]) VALUES (15, 1, CAST(726.0000 AS Decimal(9, 4)), 1, 1, 14, 8)
GO
INSERT [dbo].[PolozkyObjednavka] ([id], [aktivovano], [tehdejsiCena], [hra], [mnozstvi], [objednavkaID], [stav]) VALUES (16, 1, CAST(726.0000 AS Decimal(9, 4)), 1, 1, 14, 8)
GO
INSERT [dbo].[PolozkyObjednavka] ([id], [aktivovano], [tehdejsiCena], [hra], [mnozstvi], [objednavkaID], [stav]) VALUES (17, 1, CAST(726.0000 AS Decimal(9, 4)), 1, 1, 14, 8)
GO
INSERT [dbo].[PolozkyObjednavka] ([id], [aktivovano], [tehdejsiCena], [hra], [mnozstvi], [objednavkaID], [stav]) VALUES (18, 1, CAST(726.0000 AS Decimal(9, 4)), 1, 1, 1, 8)
GO
INSERT [dbo].[PolozkyObjednavka] ([id], [aktivovano], [tehdejsiCena], [hra], [mnozstvi], [objednavkaID], [stav]) VALUES (19, 1, CAST(726.0000 AS Decimal(9, 4)), 1, 1, 1, 8)
GO
INSERT [dbo].[PolozkyObjednavka] ([id], [aktivovano], [tehdejsiCena], [hra], [mnozstvi], [objednavkaID], [stav]) VALUES (20, 1, CAST(6050.0000 AS Decimal(9, 4)), 9, 1, 1, 8)
GO
INSERT [dbo].[PolozkyObjednavka] ([id], [aktivovano], [tehdejsiCena], [hra], [mnozstvi], [objednavkaID], [stav]) VALUES (21, 1, CAST(726.0000 AS Decimal(9, 4)), 1, 1, 1, 8)
GO
INSERT [dbo].[PolozkyObjednavka] ([id], [aktivovano], [tehdejsiCena], [hra], [mnozstvi], [objednavkaID], [stav]) VALUES (22, 1, CAST(726.0000 AS Decimal(9, 4)), 1, 1, 1, 8)
GO
INSERT [dbo].[PolozkyObjednavka] ([id], [aktivovano], [tehdejsiCena], [hra], [mnozstvi], [objednavkaID], [stav]) VALUES (24, 1, CAST(1088.9891 AS Decimal(9, 4)), 10, 2, 16, 8)
GO
INSERT [dbo].[PolozkyObjednavka] ([id], [aktivovano], [tehdejsiCena], [hra], [mnozstvi], [objednavkaID], [stav]) VALUES (25, 1, CAST(240.7900 AS Decimal(9, 4)), 11, 3, 16, 8)
GO
INSERT [dbo].[PolozkyObjednavka] ([id], [aktivovano], [tehdejsiCena], [hra], [mnozstvi], [objednavkaID], [stav]) VALUES (26, 1, CAST(726.0000 AS Decimal(9, 4)), 1, 2, 17, 8)
GO
INSERT [dbo].[PolozkyObjednavka] ([id], [aktivovano], [tehdejsiCena], [hra], [mnozstvi], [objednavkaID], [stav]) VALUES (27, 1, CAST(1088.9891 AS Decimal(9, 4)), 10, 1, 17, 8)
GO
INSERT [dbo].[PolozkyObjednavka] ([id], [aktivovano], [tehdejsiCena], [hra], [mnozstvi], [objednavkaID], [stav]) VALUES (28, 1, CAST(726.0000 AS Decimal(9, 4)), 1, 2, 18, 8)
GO
INSERT [dbo].[PolozkyObjednavka] ([id], [aktivovano], [tehdejsiCena], [hra], [mnozstvi], [objednavkaID], [stav]) VALUES (29, 1, CAST(1088.9891 AS Decimal(9, 4)), 10, 1, 18, 8)
GO
INSERT [dbo].[PolozkyObjednavka] ([id], [aktivovano], [tehdejsiCena], [hra], [mnozstvi], [objednavkaID], [stav]) VALUES (30, 1, CAST(1088.9891 AS Decimal(9, 4)), 10, 2, 19, 8)
GO
INSERT [dbo].[PolozkyObjednavka] ([id], [aktivovano], [tehdejsiCena], [hra], [mnozstvi], [objednavkaID], [stav]) VALUES (31, 1, CAST(900.0000 AS Decimal(9, 4)), 7, 1, 20, 8)
GO
INSERT [dbo].[PolozkyObjednavka] ([id], [aktivovano], [tehdejsiCena], [hra], [mnozstvi], [objednavkaID], [stav]) VALUES (32, 1, CAST(1200.0000 AS Decimal(9, 4)), 5, 1, 21, 8)
GO
INSERT [dbo].[PolozkyObjednavka] ([id], [aktivovano], [tehdejsiCena], [hra], [mnozstvi], [objednavkaID], [stav]) VALUES (33, 1, CAST(1935.0320 AS Decimal(9, 4)), 12, 1, 22, 8)
GO
INSERT [dbo].[PolozkyObjednavka] ([id], [aktivovano], [tehdejsiCena], [hra], [mnozstvi], [objednavkaID], [stav]) VALUES (34, 1, CAST(1935.0320 AS Decimal(9, 4)), 12, 1, 23, 8)
GO
SET IDENTITY_INSERT [dbo].[PolozkyObjednavka] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 
GO
INSERT [dbo].[Role] ([id], [identifikator], [popis], [aktivovano]) VALUES (1, N'zakaznik', N'Zákazník', 0)
GO
INSERT [dbo].[Role] ([id], [identifikator], [popis], [aktivovano]) VALUES (2, N'pracovnik', N'Pracovník', 0)
GO
INSERT [dbo].[Role] ([id], [identifikator], [popis], [aktivovano]) VALUES (3, N'admin', N'Admin', 0)
GO
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[Stavy] ON 
GO
INSERT [dbo].[Stavy] ([id], [aktivovano], [nazev]) VALUES (1, 1, N'Přijato do systému')
GO
INSERT [dbo].[Stavy] ([id], [aktivovano], [nazev]) VALUES (3, 1, N'Odesláno a čeká se na platbu')
GO
INSERT [dbo].[Stavy] ([id], [aktivovano], [nazev]) VALUES (5, 1, N'Odesláno a zaplaceno')
GO
INSERT [dbo].[Stavy] ([id], [aktivovano], [nazev]) VALUES (7, 1, N'Stornováno')
GO
INSERT [dbo].[Stavy] ([id], [aktivovano], [nazev]) VALUES (8, 1, N'V pořádku Polozky')
GO
INSERT [dbo].[Stavy] ([id], [aktivovano], [nazev]) VALUES (9, 1, N'Storno Polozky')
GO
INSERT [dbo].[Stavy] ([id], [aktivovano], [nazev]) VALUES (12, 1, N'Reklamováná Položka')
GO
SET IDENTITY_INSERT [dbo].[Stavy] OFF
GO
SET IDENTITY_INSERT [dbo].[Ucty] ON 
GO
INSERT [dbo].[Ucty] ([Id], [jmeno], [prijmeni], [prezdivka], [login], [heslo], [aktivovano], [role], [adresa], [email], [telefon]) VALUES (1, N'Josef', N'Godot', N'Nedostižný', N'godot1', N'95-5D-B0-B8-1E-F1-98-9B-4A-4D-FE-AE-80-61-A9-A6', 1, 2, 2, N'godot@seznam.cz', N'+420 xxx xxx xxx')
GO
INSERT [dbo].[Ucty] ([Id], [jmeno], [prijmeni], [prezdivka], [login], [heslo], [aktivovano], [role], [adresa], [email], [telefon]) VALUES (2, N'Jan', N'Hus', N'palivo', N'hus', N'95-5D-B0-B8-1E-F1-98-9B-4A-4D-FE-AE-80-61-A9-A6', 1, 2, 3, N'hus@seznam.cz', N'+420 xxx xxx xxx')
GO
INSERT [dbo].[Ucty] ([Id], [jmeno], [prijmeni], [prezdivka], [login], [heslo], [aktivovano], [role], [adresa], [email], [telefon]) VALUES (6, N'Jan', N'Žižka', N'Ostrozraký', N'oko1', N'95-5D-B0-B8-1E-F1-98-9B-4A-4D-FE-AE-80-61-A9-A6', 1, 3, 4, N'oko@seznam.cz', N'+420 xxx xxx xxx')
GO
INSERT [dbo].[Ucty] ([Id], [jmeno], [prijmeni], [prezdivka], [login], [heslo], [aktivovano], [role], [adresa], [email], [telefon]) VALUES (1002, N'Krom', N'Dobyvatel', N'Zabiják', N'krom', N'95-5D-B0-B8-1E-F1-98-9B-4A-4D-FE-AE-80-61-A9-A6', 0, 1, 6, N'krom@seznam.cz', N'+420 xxx xxx xxx')
GO
INSERT [dbo].[Ucty] ([Id], [jmeno], [prijmeni], [prezdivka], [login], [heslo], [aktivovano], [role], [adresa], [email], [telefon]) VALUES (1003, N'Sandokan', N'San', N'dokan', N'san', N'95-5D-B0-B8-1E-F1-98-9B-4A-4D-FE-AE-80-61-A9-A6', 1, 1, 7, N'san@seznam.cz', N'+420 xxx xxx xxx')
GO
INSERT [dbo].[Ucty] ([Id], [jmeno], [prijmeni], [prezdivka], [login], [heslo], [aktivovano], [role], [adresa], [email], [telefon]) VALUES (1007, N'Tonda', N'Panenka', N'panenka', N'panenka', N'95-5D-B0-B8-1E-F1-98-9B-4A-4D-FE-AE-80-61-A9-A6', 1, 1, 8, N'panenka@seznam.cz', N'+420 xxx xxx xxx')
GO
SET IDENTITY_INSERT [dbo].[Ucty] OFF
GO
SET IDENTITY_INSERT [dbo].[Vydavatele] ON 
GO
INSERT [dbo].[Vydavatele] ([id], [nazev], [aktivovano], [pocet]) VALUES (1, N'Ubisoft', 1, 14)
GO
INSERT [dbo].[Vydavatele] ([id], [nazev], [aktivovano], [pocet]) VALUES (2, N'Blizzard', 1, 5)
GO
INSERT [dbo].[Vydavatele] ([id], [nazev], [aktivovano], [pocet]) VALUES (3, N'Bethseda', 1, 6)
GO
INSERT [dbo].[Vydavatele] ([id], [nazev], [aktivovano], [pocet]) VALUES (4, N'Red Projekt', 1, 9)
GO
INSERT [dbo].[Vydavatele] ([id], [nazev], [aktivovano], [pocet]) VALUES (5, N'Piraňa software', 1, 6)
GO
SET IDENTITY_INSERT [dbo].[Vydavatele] OFF
GO
ALTER TABLE [dbo].[Hry] ADD  CONSTRAINT [DF_Hry_aktivovano]  DEFAULT ((0)) FOR [aktivovano]
GO
ALTER TABLE [dbo].[Hry] ADD  CONSTRAINT [DF__Hry__Dph__74AE54BC]  DEFAULT ((0.21)) FOR [dph]
GO
ALTER TABLE [dbo].[Obrazky] ADD  CONSTRAINT [DF_Obrazky_aktivovano]  DEFAULT ((0)) FOR [aktivovano]
GO
ALTER TABLE [dbo].[Platformy] ADD  CONSTRAINT [DF_Platformy_aktivovano]  DEFAULT ((0)) FOR [aktivovano]
GO
ALTER TABLE [dbo].[Role] ADD  CONSTRAINT [DF_Role_aktivovano]  DEFAULT ((0)) FOR [aktivovano]
GO
ALTER TABLE [dbo].[Ucty] ADD  CONSTRAINT [DF_Ucty_aktivovano]  DEFAULT ((0)) FOR [aktivovano]
GO
ALTER TABLE [dbo].[Vydavatele] ADD  CONSTRAINT [DF_Vydavatele_aktivovano]  DEFAULT ((0)) FOR [aktivovano]
GO
ALTER TABLE [dbo].[KombinaceMoznosti]  WITH CHECK ADD  CONSTRAINT [FK_KombinaceMoznosti_DopravaMoznosti] FOREIGN KEY([dopravniMoznost])
REFERENCES [dbo].[DopravaMoznosti] ([id])
GO
ALTER TABLE [dbo].[KombinaceMoznosti] CHECK CONSTRAINT [FK_KombinaceMoznosti_DopravaMoznosti]
GO
ALTER TABLE [dbo].[KombinaceMoznosti]  WITH CHECK ADD  CONSTRAINT [FK_KombinaceMoznosti_PlatebniMoznosti] FOREIGN KEY([platebniMoznost])
REFERENCES [dbo].[PlatebniMoznosti] ([id])
GO
ALTER TABLE [dbo].[KombinaceMoznosti] CHECK CONSTRAINT [FK_KombinaceMoznosti_PlatebniMoznosti]
GO
ALTER TABLE [dbo].[Obrazky]  WITH CHECK ADD  CONSTRAINT [Game] FOREIGN KEY([hra_id])
REFERENCES [dbo].[Hry] ([id])
GO
ALTER TABLE [dbo].[Obrazky] CHECK CONSTRAINT [Game]
GO
ALTER TABLE [dbo].[PolozkyKosiku]  WITH CHECK ADD  CONSTRAINT [Hra] FOREIGN KEY([hra])
REFERENCES [dbo].[Hry] ([id])
GO
ALTER TABLE [dbo].[PolozkyKosiku] CHECK CONSTRAINT [Hra]
GO
ALTER TABLE [dbo].[PolozkyObjednavka]  WITH CHECK ADD  CONSTRAINT [FK_Polozkyobjednavka_Hry] FOREIGN KEY([hra])
REFERENCES [dbo].[Hry] ([id])
GO
ALTER TABLE [dbo].[PolozkyObjednavka] CHECK CONSTRAINT [FK_Polozkyobjednavka_Hry]
GO
ALTER TABLE [dbo].[Ucty]  WITH CHECK ADD  CONSTRAINT [adresa] FOREIGN KEY([adresa])
REFERENCES [dbo].[Adresy] ([id])
GO
ALTER TABLE [dbo].[Ucty] CHECK CONSTRAINT [adresa]
GO
USE [master]
GO
ALTER DATABASE [Eshop] SET  READ_WRITE 
GO
