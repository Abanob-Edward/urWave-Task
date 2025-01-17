USE [URWaveTaks]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 1/9/2025 2:51:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 1/9/2025 2:51:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](500) NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[IsDeleted] [bit] NULL,
	[CreatedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250106114336_Init', N'9.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250106115810_Add-CreatedDate', N'9.0.0')
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [IsDeleted], [CreatedDate]) VALUES (1, N'Hp Laptop', N'HP laptop with 16 G RAM and 512 SSD .', CAST(32000.00 AS Decimal(18, 2)), 0, CAST(N'2025-01-06T14:03:36.9184505' AS DateTime2))
INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [IsDeleted], [CreatedDate]) VALUES (2, N'Iphone', N'A premium smartphone with advanced features.', CAST(999.99 AS Decimal(18, 2)), 0, CAST(N'2025-01-06T14:32:34.4246774' AS DateTime2))
INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [IsDeleted], [CreatedDate]) VALUES (3, N'TV', N'A high-definition television for entertainment.', CAST(599.00 AS Decimal(18, 2)), 1, CAST(N'2025-01-06T14:33:09.8489279' AS DateTime2))
INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [IsDeleted], [CreatedDate]) VALUES (4, N'Smart Watch', N'A wearable device for fitness tracking and notifications.', CAST(299.95 AS Decimal(18, 2)), 0, CAST(N'2025-01-06T14:33:24.1107514' AS DateTime2))
INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [IsDeleted], [CreatedDate]) VALUES (1002, N'Smartwatch', N'Description 1', CAST(255245.00 AS Decimal(18, 2)), 0, CAST(N'2025-01-08T21:58:56.1360143' AS DateTime2))
INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [IsDeleted], [CreatedDate]) VALUES (1003, N'Smartwatch1', N'aaaaaaaaaaaaa', CAST(5225.00 AS Decimal(18, 2)), 0, CAST(N'2025-01-08T22:02:16.2332242' AS DateTime2))
INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [IsDeleted], [CreatedDate]) VALUES (1004, N'Tablate', N'asdasdsa', CAST(54564.00 AS Decimal(18, 2)), 1, CAST(N'2025-01-08T22:15:17.9861566' AS DateTime2))
INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [IsDeleted], [CreatedDate]) VALUES (1005, N'Ae', N'edit', CAST(54564.00 AS Decimal(18, 2)), 0, CAST(N'2025-01-08T22:15:26.4538313' AS DateTime2))
INSERT [dbo].[Product] ([Id], [Name], [Description], [Price], [IsDeleted], [CreatedDate]) VALUES (1006, N'Smartwatch12', N'asda', CAST(213.00 AS Decimal(18, 2)), 1, CAST(N'2025-01-08T23:11:41.7085835' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
