USE [TheWorldOfComputerTechnology]
GO
/****** Object:  Table [dbo].[CharacteristicsOfTheEquipment]    Script Date: 19.02.2023 18:55:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CharacteristicsOfTheEquipment](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Technic] [int] NOT NULL,
	[Characteristics] [int] NOT NULL,
	[Meaning] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_CharacteristicsOfTheEquipment] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clients]    Script Date: 19.02.2023 18:55:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clients](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Surname] [nvarchar](150) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[Patronymic] [nvarchar](150) NOT NULL,
	[DateOfBirth] [datetime] NOT NULL,
	[PlaceOfBirth] [nvarchar](150) NOT NULL,
	[SeriesPassport] [nvarchar](4) NOT NULL,
	[Number_passport] [nvarchar](6) NOT NULL,
	[DateOfIssue] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
	[PlaceOfIssue] [nvarchar](255) NOT NULL,
	[Gender] [int] NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClientStatus]    Script Date: 19.02.2023 18:55:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClientStatus](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NULL,
 CONSTRAINT [PK_ClientStatus] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 19.02.2023 18:55:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](150) NOT NULL,
	[Password] [nvarchar](150) NOT NULL,
	[Surname] [nvarchar](150) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[Patronymic] [nvarchar](150) NOT NULL,
	[DateOfBirth] [date] NOT NULL,
	[Role] [int] NOT NULL,
	[Gender] [int] NOT NULL,
	[Photo] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Gender]    Script Date: 19.02.2023 18:55:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gender](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](12) NOT NULL,
 CONSTRAINT [PK_Gender] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ListOfErrors]    Script Date: 19.02.2023 18:55:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ListOfErrors](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RepairWork] [int] NOT NULL,
	[DateStart] [datetime] NOT NULL,
	[Reason] [nvarchar](150) NOT NULL,
	[DateEnd] [datetime] NOT NULL,
	[Description] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_ListOfErrors] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderingSpareParts]    Script Date: 19.02.2023 18:55:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderingSpareParts](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[Orders] [int] NOT NULL,
	[Parent] [int] NULL,
 CONSTRAINT [PK_OrderingSpareParts] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 19.02.2023 18:55:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Date] [date] NOT NULL,
	[Client] [int] NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderStatus]    Script Date: 19.02.2023 18:55:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderStatus](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NULL,
 CONSTRAINT [PK_OrderStatus] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RepairTechnic]    Script Date: 19.02.2023 18:55:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RepairTechnic](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Technic] [int] NOT NULL,
	[DeliveryDate] [datetime] NOT NULL,
	[Date] [datetime] NOT NULL,
	[Orders] [int] NOT NULL,
 CONSTRAINT [PK_RepairTechnic] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RepairWork]    Script Date: 19.02.2023 18:55:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RepairWork](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NOT NULL,
	[RepairTechnic] [int] NOT NULL,
	[Description] [nvarchar](150) NOT NULL,
	[Employees] [int] NOT NULL,
 CONSTRAINT [PK_RepairWork] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 19.02.2023 18:55:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Technic]    Script Date: 19.02.2023 18:55:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Technic](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Marking] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[Type] [int] NULL,
 CONSTRAINT [PK_Technic] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Type]    Script Date: 19.02.2023 18:55:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Type](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_Type] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Clients] ON 

INSERT [dbo].[Clients] ([ID], [Surname], [Name], [Patronymic], [DateOfBirth], [PlaceOfBirth], [SeriesPassport], [Number_passport], [DateOfIssue], [EndDate], [PlaceOfIssue], [Gender], [Status]) VALUES (1, N'Фассалов', N'Юрий', N'Альфретлвич', CAST(N'2012-12-12T00:00:00.000' AS DateTime), N'2001-12-12', N'1212', N'121212', CAST(N'2012-12-12' AS Date), CAST(N'2012-12-12' AS Date), N'12', 1, 1)
INSERT [dbo].[Clients] ([ID], [Surname], [Name], [Patronymic], [DateOfBirth], [PlaceOfBirth], [SeriesPassport], [Number_passport], [DateOfIssue], [EndDate], [PlaceOfIssue], [Gender], [Status]) VALUES (2, N'Воробьев', N'Илья', N'Сернеевич', CAST(N'2023-02-16T00:00:00.000' AS DateTime), N'qwqwdq', N'1231', N'121231', CAST(N'2023-02-16' AS Date), CAST(N'2023-02-16' AS Date), N'adsasdasd', 1, 2)
SET IDENTITY_INSERT [dbo].[Clients] OFF
GO
SET IDENTITY_INSERT [dbo].[ClientStatus] ON 

INSERT [dbo].[ClientStatus] ([ID], [Name]) VALUES (1, N'Обычный')
INSERT [dbo].[ClientStatus] ([ID], [Name]) VALUES (2, N'Постоянный')
SET IDENTITY_INSERT [dbo].[ClientStatus] OFF
GO
SET IDENTITY_INSERT [dbo].[Employees] ON 

INSERT [dbo].[Employees] ([ID], [Login], [Password], [Surname], [Name], [Patronymic], [DateOfBirth], [Role], [Gender], [Photo]) VALUES (47, N'loginDEttt', N'qwerty', N'Семенов', N'Владимир', N'Филатовичq', CAST(N'2023-02-18' AS Date), 2, 1, N'')
INSERT [dbo].[Employees] ([ID], [Login], [Password], [Surname], [Name], [Patronymic], [DateOfBirth], [Role], [Gender], [Photo]) VALUES (48, N'loginDExrn', N'qwerty', N'Абрамова', N'Оксана', N'Ростиславовна', CAST(N'2023-02-16' AS Date), 3, 1, N'photo.jpg')
INSERT [dbo].[Employees] ([ID], [Login], [Password], [Surname], [Name], [Patronymic], [DateOfBirth], [Role], [Gender], [Photo]) VALUES (49, N'loginDEwxdДиректор', N'qwerty', N'Косьвинцев', N'Алексей', N'Антоновичq', CAST(N'2023-02-18' AS Date), 1, 1, N'')
INSERT [dbo].[Employees] ([ID], [Login], [Password], [Surname], [Name], [Patronymic], [DateOfBirth], [Role], [Gender], [Photo]) VALUES (50, N'loginDEmwq', N'qwerty', N'Синичкин', N'Бронислав', N'Тихонович', CAST(N'2000-02-18' AS Date), 2, 1, N'photo.jpg')
INSERT [dbo].[Employees] ([ID], [Login], [Password], [Surname], [Name], [Patronymic], [DateOfBirth], [Role], [Gender], [Photo]) VALUES (51, N'loginDEykk', N'qwerty', N'Голева', N'Нина', N'Мстиславовна', CAST(N'2023-02-16' AS Date), 1, 1, N'')
INSERT [dbo].[Employees] ([ID], [Login], [Password], [Surname], [Name], [Patronymic], [DateOfBirth], [Role], [Gender], [Photo]) VALUES (52, N'loginDEell', N'qwerty', N'Терентьев', N'Игорь', N'Александрович', CAST(N'2000-02-20' AS Date), 3, 1, N'photo.jpg')
INSERT [dbo].[Employees] ([ID], [Login], [Password], [Surname], [Name], [Patronymic], [DateOfBirth], [Role], [Gender], [Photo]) VALUES (53, N'loginDEzqn', N'qwerty', N'Петрова', N'Иванна', N'Андреевна', CAST(N'2000-02-21' AS Date), 2, 2, N'photo.jpg')
INSERT [dbo].[Employees] ([ID], [Login], [Password], [Surname], [Name], [Patronymic], [DateOfBirth], [Role], [Gender], [Photo]) VALUES (54, N'loginDEiyy', N'qwerty', N'Федосеев', N'Иван', N'Валентинович', CAST(N'2000-02-22' AS Date), 2, 1, N'photo.jpg')
INSERT [dbo].[Employees] ([ID], [Login], [Password], [Surname], [Name], [Patronymic], [DateOfBirth], [Role], [Gender], [Photo]) VALUES (55, N'loginDEaul', N'qwerty', N'Путин', N'Станислав', N'Протасьевич', CAST(N'2000-02-23' AS Date), 2, 1, N'photo.jpg')
INSERT [dbo].[Employees] ([ID], [Login], [Password], [Surname], [Name], [Patronymic], [DateOfBirth], [Role], [Gender], [Photo]) VALUES (56, N'loginDEyzp', N'qwerty', N'Долинина', N'Ольга', N'Аркадьевна', CAST(N'2000-02-24' AS Date), 2, 2, N'photo.jpg')
INSERT [dbo].[Employees] ([ID], [Login], [Password], [Surname], [Name], [Patronymic], [DateOfBirth], [Role], [Gender], [Photo]) VALUES (57, N'loginDErwb', N'qwerty', N'Сокольчик', N'Владислав', N'Антонинович', CAST(N'2023-02-16' AS Date), 3, 1, N'')
INSERT [dbo].[Employees] ([ID], [Login], [Password], [Surname], [Name], [Patronymic], [DateOfBirth], [Role], [Gender], [Photo]) VALUES (58, N'loginDEpri', N'qwerty', N'Шубин', N'Тихон', N'Лаврентьевич', CAST(N'2000-02-26' AS Date), 2, 1, N'photo.jpg')
INSERT [dbo].[Employees] ([ID], [Login], [Password], [Surname], [Name], [Patronymic], [DateOfBirth], [Role], [Gender], [Photo]) VALUES (59, N'loginDEzpr', N'qwerty', N'Ермолаев', N'Эдуард', N'Протасьевич', CAST(N'2023-02-16' AS Date), 2, 1, N'')
INSERT [dbo].[Employees] ([ID], [Login], [Password], [Surname], [Name], [Patronymic], [DateOfBirth], [Role], [Gender], [Photo]) VALUES (60, N'loginDEhfv', N'qwerty', N'Мечников', N'Борис', N'Лукьевич', CAST(N'2000-02-28' AS Date), 2, 1, N'photo.jpg')
INSERT [dbo].[Employees] ([ID], [Login], [Password], [Surname], [Name], [Patronymic], [DateOfBirth], [Role], [Gender], [Photo]) VALUES (61, N'Yrmen45', N'Yrmen45', N'Фассалов', N'Юрий', N'Альфретович', CAST(N'2003-10-17' AS Date), 4, 1, N'photo.jpg')
INSERT [dbo].[Employees] ([ID], [Login], [Password], [Surname], [Name], [Patronymic], [DateOfBirth], [Role], [Gender], [Photo]) VALUES (62, N'User2', N'User2', N'User2', N'User2', N'User2', CAST(N'2023-02-19' AS Date), 3, 2, N'')
INSERT [dbo].[Employees] ([ID], [Login], [Password], [Surname], [Name], [Patronymic], [DateOfBirth], [Role], [Gender], [Photo]) VALUES (63, N'User1', N'qwerty', N'User', N'User', N'User', CAST(N'2023-02-16' AS Date), 3, 2, N'')
INSERT [dbo].[Employees] ([ID], [Login], [Password], [Surname], [Name], [Patronymic], [DateOfBirth], [Role], [Gender], [Photo]) VALUES (64, N'User3', N'User3', N'User3', N'User3', N'qwe', CAST(N'2023-02-19' AS Date), 3, 2, N'')
INSERT [dbo].[Employees] ([ID], [Login], [Password], [Surname], [Name], [Patronymic], [DateOfBirth], [Role], [Gender], [Photo]) VALUES (65, N'ewqwqweqwe', N'qwe', N'qweqwe', N'qwe', N'qew', CAST(N'2023-02-16' AS Date), 3, 1, N'photo.jpg')
INSERT [dbo].[Employees] ([ID], [Login], [Password], [Surname], [Name], [Patronymic], [DateOfBirth], [Role], [Gender], [Photo]) VALUES (66, N'sa', N'asd', N'saasd', N'asd', N'asd', CAST(N'2023-02-16' AS Date), 1, 1, N'')
SET IDENTITY_INSERT [dbo].[Employees] OFF
GO
SET IDENTITY_INSERT [dbo].[Gender] ON 

INSERT [dbo].[Gender] ([ID], [Name]) VALUES (1, N'М')
INSERT [dbo].[Gender] ([ID], [Name]) VALUES (2, N'Ж')
SET IDENTITY_INSERT [dbo].[Gender] OFF
GO
SET IDENTITY_INSERT [dbo].[ListOfErrors] ON 

INSERT [dbo].[ListOfErrors] ([ID], [RepairWork], [DateStart], [Reason], [DateEnd], [Description]) VALUES (2, 2, CAST(N'2003-12-12T00:00:00.000' AS DateTime), N'ну', CAST(N'2003-12-12T00:00:00.000' AS DateTime), N'1')
INSERT [dbo].[ListOfErrors] ([ID], [RepairWork], [DateStart], [Reason], [DateEnd], [Description]) VALUES (17, 7, CAST(N'2023-02-18T11:24:00.000' AS DateTime), N'121', CAST(N'2023-02-18T11:24:00.000' AS DateTime), N'12')
INSERT [dbo].[ListOfErrors] ([ID], [RepairWork], [DateStart], [Reason], [DateEnd], [Description]) VALUES (18, 7, CAST(N'2023-02-18T11:24:00.000' AS DateTime), N'121', CAST(N'2023-02-18T11:24:00.000' AS DateTime), N'12')
INSERT [dbo].[ListOfErrors] ([ID], [RepairWork], [DateStart], [Reason], [DateEnd], [Description]) VALUES (19, 8, CAST(N'2023-02-18T11:24:00.000' AS DateTime), N'121', CAST(N'2023-02-18T11:24:00.000' AS DateTime), N'12')
INSERT [dbo].[ListOfErrors] ([ID], [RepairWork], [DateStart], [Reason], [DateEnd], [Description]) VALUES (20, 8, CAST(N'2023-02-18T11:24:00.000' AS DateTime), N'121', CAST(N'2023-02-18T11:24:00.000' AS DateTime), N'12')
INSERT [dbo].[ListOfErrors] ([ID], [RepairWork], [DateStart], [Reason], [DateEnd], [Description]) VALUES (21, 9, CAST(N'2023-02-18T11:24:00.000' AS DateTime), N'121', CAST(N'2023-02-18T11:24:00.000' AS DateTime), N'12')
INSERT [dbo].[ListOfErrors] ([ID], [RepairWork], [DateStart], [Reason], [DateEnd], [Description]) VALUES (22, 9, CAST(N'2023-02-18T11:24:00.000' AS DateTime), N'121', CAST(N'2023-02-18T11:24:00.000' AS DateTime), N'12')
INSERT [dbo].[ListOfErrors] ([ID], [RepairWork], [DateStart], [Reason], [DateEnd], [Description]) VALUES (23, 10, CAST(N'2023-02-18T11:24:00.000' AS DateTime), N'121', CAST(N'2023-02-18T11:24:00.000' AS DateTime), N'12')
INSERT [dbo].[ListOfErrors] ([ID], [RepairWork], [DateStart], [Reason], [DateEnd], [Description]) VALUES (24, 10, CAST(N'2023-02-18T11:24:00.000' AS DateTime), N'121', CAST(N'2023-02-18T11:24:00.000' AS DateTime), N'12')
INSERT [dbo].[ListOfErrors] ([ID], [RepairWork], [DateStart], [Reason], [DateEnd], [Description]) VALUES (25, 11, CAST(N'2023-02-18T11:33:00.000' AS DateTime), N'wqe', CAST(N'2023-02-18T11:33:00.000' AS DateTime), N'wew')
INSERT [dbo].[ListOfErrors] ([ID], [RepairWork], [DateStart], [Reason], [DateEnd], [Description]) VALUES (26, 12, CAST(N'2023-02-18T11:34:00.000' AS DateTime), N'dsf', CAST(N'2023-02-18T11:34:00.000' AS DateTime), N'sdf')
INSERT [dbo].[ListOfErrors] ([ID], [RepairWork], [DateStart], [Reason], [DateEnd], [Description]) VALUES (27, 12, CAST(N'2023-02-18T11:34:00.000' AS DateTime), N'dsf', CAST(N'2023-02-18T11:34:00.000' AS DateTime), N'sdf')
INSERT [dbo].[ListOfErrors] ([ID], [RepairWork], [DateStart], [Reason], [DateEnd], [Description]) VALUES (28, 12, CAST(N'2023-02-18T11:34:00.000' AS DateTime), N'dsf', CAST(N'2023-02-18T11:34:00.000' AS DateTime), N'sdf')
INSERT [dbo].[ListOfErrors] ([ID], [RepairWork], [DateStart], [Reason], [DateEnd], [Description]) VALUES (29, 7, CAST(N'2023-02-18T13:26:00.000' AS DateTime), N'cxz', CAST(N'2023-02-18T13:26:00.000' AS DateTime), N'xzc')
INSERT [dbo].[ListOfErrors] ([ID], [RepairWork], [DateStart], [Reason], [DateEnd], [Description]) VALUES (30, 7, CAST(N'2023-02-18T13:26:00.000' AS DateTime), N'cxz', CAST(N'2023-02-18T13:26:00.000' AS DateTime), N'xzc')
INSERT [dbo].[ListOfErrors] ([ID], [RepairWork], [DateStart], [Reason], [DateEnd], [Description]) VALUES (31, 7, CAST(N'2023-02-18T13:26:00.000' AS DateTime), N'cxz', CAST(N'2023-02-18T13:26:00.000' AS DateTime), N'xzc')
INSERT [dbo].[ListOfErrors] ([ID], [RepairWork], [DateStart], [Reason], [DateEnd], [Description]) VALUES (32, 13, CAST(N'2023-02-18T13:34:00.000' AS DateTime), N'sdf', CAST(N'2023-02-18T13:34:00.000' AS DateTime), N'sdf')
INSERT [dbo].[ListOfErrors] ([ID], [RepairWork], [DateStart], [Reason], [DateEnd], [Description]) VALUES (33, 13, CAST(N'2023-02-18T13:34:00.000' AS DateTime), N'sdf', CAST(N'2023-02-18T13:34:00.000' AS DateTime), N'sdf')
INSERT [dbo].[ListOfErrors] ([ID], [RepairWork], [DateStart], [Reason], [DateEnd], [Description]) VALUES (34, 14, CAST(N'2023-02-18T13:40:00.000' AS DateTime), N'xvc', CAST(N'2023-02-18T13:40:00.000' AS DateTime), N'xcv')
INSERT [dbo].[ListOfErrors] ([ID], [RepairWork], [DateStart], [Reason], [DateEnd], [Description]) VALUES (35, 14, CAST(N'2023-02-18T13:40:00.000' AS DateTime), N'xvc', CAST(N'2023-02-18T13:40:00.000' AS DateTime), N'xcv')
INSERT [dbo].[ListOfErrors] ([ID], [RepairWork], [DateStart], [Reason], [DateEnd], [Description]) VALUES (36, 14, CAST(N'2023-02-18T13:40:00.000' AS DateTime), N'xvc', CAST(N'2023-02-18T13:40:00.000' AS DateTime), N'xcv')
INSERT [dbo].[ListOfErrors] ([ID], [RepairWork], [DateStart], [Reason], [DateEnd], [Description]) VALUES (37, 14, CAST(N'2023-02-18T13:40:00.000' AS DateTime), N'xvc', CAST(N'2023-02-18T13:40:00.000' AS DateTime), N'xcv')
SET IDENTITY_INSERT [dbo].[ListOfErrors] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([ID], [Name], [Date], [Client], [Status]) VALUES (1, N'Заказ: 2023-02-16 23:36:28 ', CAST(N'2023-02-18' AS Date), 1, 1)
INSERT [dbo].[Orders] ([ID], [Name], [Date], [Client], [Status]) VALUES (2, N'Заказ: 2023-02-16 23:36:28 ', CAST(N'2023-02-18' AS Date), 2, 1)
INSERT [dbo].[Orders] ([ID], [Name], [Date], [Client], [Status]) VALUES (3, N'Заказ: 2023-02-16 23:36:35 ', CAST(N'2023-02-18' AS Date), 1, 1)
INSERT [dbo].[Orders] ([ID], [Name], [Date], [Client], [Status]) VALUES (4, N'MyOrder', CAST(N'2023-02-18' AS Date), 2, 1)
INSERT [dbo].[Orders] ([ID], [Name], [Date], [Client], [Status]) VALUES (5, N'MyOrder 2', CAST(N'2023-02-18' AS Date), 1, 1)
INSERT [dbo].[Orders] ([ID], [Name], [Date], [Client], [Status]) VALUES (6, N'MyOrder 3', CAST(N'2023-02-18' AS Date), 1, 1)
INSERT [dbo].[Orders] ([ID], [Name], [Date], [Client], [Status]) VALUES (7, N'MyOrder 4', CAST(N'2023-02-18' AS Date), 2, 1)
INSERT [dbo].[Orders] ([ID], [Name], [Date], [Client], [Status]) VALUES (8, N'MyOrder 5', CAST(N'2023-02-18' AS Date), 2, 2)
INSERT [dbo].[Orders] ([ID], [Name], [Date], [Client], [Status]) VALUES (9, N'MyOrder 6', CAST(N'2023-02-18' AS Date), 1, 1)
INSERT [dbo].[Orders] ([ID], [Name], [Date], [Client], [Status]) VALUES (10, N'MyOrder 7', CAST(N'2023-02-18' AS Date), 2, 1)
INSERT [dbo].[Orders] ([ID], [Name], [Date], [Client], [Status]) VALUES (11, N'MyOrder 8', CAST(N'2023-02-18' AS Date), 1, 1)
INSERT [dbo].[Orders] ([ID], [Name], [Date], [Client], [Status]) VALUES (12, N'MyOrder 9', CAST(N'2023-02-18' AS Date), 2, 1)
INSERT [dbo].[Orders] ([ID], [Name], [Date], [Client], [Status]) VALUES (13, N'MyOrder 10', CAST(N'2023-02-18' AS Date), 2, 1)
INSERT [dbo].[Orders] ([ID], [Name], [Date], [Client], [Status]) VALUES (14, N'MyOrder 11', CAST(N'2023-02-18' AS Date), 1, 1)
INSERT [dbo].[Orders] ([ID], [Name], [Date], [Client], [Status]) VALUES (15, N'MyOrder 12', CAST(N'2023-02-18' AS Date), 1, 1)
INSERT [dbo].[Orders] ([ID], [Name], [Date], [Client], [Status]) VALUES (16, N'MyOrder 13', CAST(N'2023-02-18' AS Date), 2, 1)
INSERT [dbo].[Orders] ([ID], [Name], [Date], [Client], [Status]) VALUES (17, N'MyOrder 14', CAST(N'2023-02-18' AS Date), 1, 1)
INSERT [dbo].[Orders] ([ID], [Name], [Date], [Client], [Status]) VALUES (18, N'MyOrder 15', CAST(N'2023-02-18' AS Date), 2, 1)
INSERT [dbo].[Orders] ([ID], [Name], [Date], [Client], [Status]) VALUES (19, N'MyOrder 16', CAST(N'2023-02-18' AS Date), 2, 1)
INSERT [dbo].[Orders] ([ID], [Name], [Date], [Client], [Status]) VALUES (20, N'MyOrder 18', CAST(N'2023-02-18' AS Date), 1, 1)
INSERT [dbo].[Orders] ([ID], [Name], [Date], [Client], [Status]) VALUES (21, N'MyOrder 19', CAST(N'2023-02-18' AS Date), 1, 1)
INSERT [dbo].[Orders] ([ID], [Name], [Date], [Client], [Status]) VALUES (22, N'MyOrder 20', CAST(N'2023-02-18' AS Date), 1, 1)
INSERT [dbo].[Orders] ([ID], [Name], [Date], [Client], [Status]) VALUES (23, N'MyOrder 21', CAST(N'2023-02-18' AS Date), 1, 1)
INSERT [dbo].[Orders] ([ID], [Name], [Date], [Client], [Status]) VALUES (24, N'MyOrder 22', CAST(N'2023-02-18' AS Date), 2, 1)
INSERT [dbo].[Orders] ([ID], [Name], [Date], [Client], [Status]) VALUES (25, N'MyOrder 23', CAST(N'2023-02-19' AS Date), 1, 1)
INSERT [dbo].[Orders] ([ID], [Name], [Date], [Client], [Status]) VALUES (26, N'MyOrder 24', CAST(N'2023-02-19' AS Date), 1, 1)
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderStatus] ON 

INSERT [dbo].[OrderStatus] ([ID], [Name]) VALUES (1, N'Новый')
INSERT [dbo].[OrderStatus] ([ID], [Name]) VALUES (2, N'Оплачен')
SET IDENTITY_INSERT [dbo].[OrderStatus] OFF
GO
SET IDENTITY_INSERT [dbo].[RepairTechnic] ON 

INSERT [dbo].[RepairTechnic] ([ID], [Technic], [DeliveryDate], [Date], [Orders]) VALUES (1, 2, CAST(N'2023-12-12T00:00:00.000' AS DateTime), CAST(N'2023-12-12T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[RepairTechnic] ([ID], [Technic], [DeliveryDate], [Date], [Orders]) VALUES (70, 2, CAST(N'2023-02-18T11:44:00.000' AS DateTime), CAST(N'2023-02-18T11:44:00.000' AS DateTime), 15)
INSERT [dbo].[RepairTechnic] ([ID], [Technic], [DeliveryDate], [Date], [Orders]) VALUES (71, 5, CAST(N'2023-02-18T13:24:00.000' AS DateTime), CAST(N'2023-02-18T13:24:00.000' AS DateTime), 24)
INSERT [dbo].[RepairTechnic] ([ID], [Technic], [DeliveryDate], [Date], [Orders]) VALUES (72, 5, CAST(N'2023-02-18T13:24:00.000' AS DateTime), CAST(N'2023-02-18T13:24:00.000' AS DateTime), 24)
SET IDENTITY_INSERT [dbo].[RepairTechnic] OFF
GO
SET IDENTITY_INSERT [dbo].[RepairWork] ON 

INSERT [dbo].[RepairWork] ([ID], [Date], [RepairTechnic], [Description], [Employees]) VALUES (2, CAST(N'2023-02-18T11:09:00.000' AS DateTime), 1, N'1212', 47)
INSERT [dbo].[RepairWork] ([ID], [Date], [RepairTechnic], [Description], [Employees]) VALUES (7, CAST(N'2023-02-18T13:26:00.000' AS DateTime), 1, N'ssadsad', 47)
INSERT [dbo].[RepairWork] ([ID], [Date], [RepairTechnic], [Description], [Employees]) VALUES (8, CAST(N'2023-02-18T11:34:00.000' AS DateTime), 1, N'21', 47)
INSERT [dbo].[RepairWork] ([ID], [Date], [RepairTechnic], [Description], [Employees]) VALUES (9, CAST(N'2023-02-18T11:33:00.000' AS DateTime), 1, N'aaa1', 47)
INSERT [dbo].[RepairWork] ([ID], [Date], [RepairTechnic], [Description], [Employees]) VALUES (10, CAST(N'2023-02-18T11:24:00.000' AS DateTime), 1, N'21', 47)
INSERT [dbo].[RepairWork] ([ID], [Date], [RepairTechnic], [Description], [Employees]) VALUES (11, CAST(N'2023-02-18T11:33:00.000' AS DateTime), 1, N'wqqwewq', 47)
INSERT [dbo].[RepairWork] ([ID], [Date], [RepairTechnic], [Description], [Employees]) VALUES (12, CAST(N'2023-02-18T11:34:00.000' AS DateTime), 1, N'ds', 47)
INSERT [dbo].[RepairWork] ([ID], [Date], [RepairTechnic], [Description], [Employees]) VALUES (13, CAST(N'2023-02-18T13:34:00.000' AS DateTime), 70, N'ds', 47)
INSERT [dbo].[RepairWork] ([ID], [Date], [RepairTechnic], [Description], [Employees]) VALUES (14, CAST(N'2023-02-18T13:40:00.000' AS DateTime), 70, N'xcv', 47)
SET IDENTITY_INSERT [dbo].[RepairWork] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([ID], [Name]) VALUES (1, N'Директор')
INSERT [dbo].[Roles] ([ID], [Name]) VALUES (2, N'Сборщик')
INSERT [dbo].[Roles] ([ID], [Name]) VALUES (3, N'Менеджер')
INSERT [dbo].[Roles] ([ID], [Name]) VALUES (4, N'Администратор')
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Technic] ON 

INSERT [dbo].[Technic] ([ID], [Marking], [Name], [Type]) VALUES (2, N'Stark Industries', N'Mark 0', 2)
INSERT [dbo].[Technic] ([ID], [Marking], [Name], [Type]) VALUES (3, N'Stark Industries', N'Mark 1', 2)
INSERT [dbo].[Technic] ([ID], [Marking], [Name], [Type]) VALUES (4, N'Stark Industries', N'Mark 2', 2)
INSERT [dbo].[Technic] ([ID], [Marking], [Name], [Type]) VALUES (5, N'Stark Industries', N'Mark 3', 2)
INSERT [dbo].[Technic] ([ID], [Marking], [Name], [Type]) VALUES (6, N'Stark Industries', N'Mark 4', 2)
INSERT [dbo].[Technic] ([ID], [Marking], [Name], [Type]) VALUES (7, N'Stark Industries', N'Mark 5 ', 2)
SET IDENTITY_INSERT [dbo].[Technic] OFF
GO
SET IDENTITY_INSERT [dbo].[Type] ON 

INSERT [dbo].[Type] ([ID], [Name]) VALUES (1, N'Ноутбук')
INSERT [dbo].[Type] ([ID], [Name]) VALUES (2, N'Кибер Протез')
INSERT [dbo].[Type] ([ID], [Name]) VALUES (3, N'ПК')
SET IDENTITY_INSERT [dbo].[Type] OFF
GO
ALTER TABLE [dbo].[Clients] ADD  CONSTRAINT [DF_Clients_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Orders] ADD  CONSTRAINT [DF_Orders_OrderName]  DEFAULT (N'Заказ: '+CONVERT([char](20),getdate(),(120))) FOR [Name]
GO
ALTER TABLE [dbo].[Orders] ADD  CONSTRAINT [DF_Orders_OrderDate]  DEFAULT (getdate()) FOR [Date]
GO
ALTER TABLE [dbo].[Orders] ADD  CONSTRAINT [DF_Orders_OrderStatus]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[CharacteristicsOfTheEquipment]  WITH CHECK ADD  CONSTRAINT [FK_CharacteristicsOfTheEquipment_Technic] FOREIGN KEY([Technic])
REFERENCES [dbo].[Technic] ([ID])
GO
ALTER TABLE [dbo].[CharacteristicsOfTheEquipment] CHECK CONSTRAINT [FK_CharacteristicsOfTheEquipment_Technic]
GO
ALTER TABLE [dbo].[Clients]  WITH CHECK ADD  CONSTRAINT [FK_Clients_ClientStatus] FOREIGN KEY([Status])
REFERENCES [dbo].[ClientStatus] ([ID])
GO
ALTER TABLE [dbo].[Clients] CHECK CONSTRAINT [FK_Clients_ClientStatus]
GO
ALTER TABLE [dbo].[Clients]  WITH CHECK ADD  CONSTRAINT [FK_Clients_Gender] FOREIGN KEY([Gender])
REFERENCES [dbo].[Gender] ([ID])
GO
ALTER TABLE [dbo].[Clients] CHECK CONSTRAINT [FK_Clients_Gender]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Gender] FOREIGN KEY([Gender])
REFERENCES [dbo].[Gender] ([ID])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Gender]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Roles] FOREIGN KEY([Role])
REFERENCES [dbo].[Roles] ([ID])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Roles]
GO
ALTER TABLE [dbo].[ListOfErrors]  WITH CHECK ADD  CONSTRAINT [FK_ListOfErrors_RepairWork] FOREIGN KEY([RepairWork])
REFERENCES [dbo].[RepairWork] ([ID])
GO
ALTER TABLE [dbo].[ListOfErrors] CHECK CONSTRAINT [FK_ListOfErrors_RepairWork]
GO
ALTER TABLE [dbo].[OrderingSpareParts]  WITH CHECK ADD  CONSTRAINT [FK_OrderingSpareParts_Orders] FOREIGN KEY([Orders])
REFERENCES [dbo].[Orders] ([ID])
GO
ALTER TABLE [dbo].[OrderingSpareParts] CHECK CONSTRAINT [FK_OrderingSpareParts_Orders]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Clients] FOREIGN KEY([Client])
REFERENCES [dbo].[Clients] ([ID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Clients]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_OrderStatus] FOREIGN KEY([Status])
REFERENCES [dbo].[OrderStatus] ([ID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_OrderStatus]
GO
ALTER TABLE [dbo].[RepairTechnic]  WITH CHECK ADD  CONSTRAINT [FK_RepairTechnic_Orders1] FOREIGN KEY([Orders])
REFERENCES [dbo].[Orders] ([ID])
GO
ALTER TABLE [dbo].[RepairTechnic] CHECK CONSTRAINT [FK_RepairTechnic_Orders1]
GO
ALTER TABLE [dbo].[RepairTechnic]  WITH CHECK ADD  CONSTRAINT [FK_RepairTechnic_Technic] FOREIGN KEY([Technic])
REFERENCES [dbo].[Technic] ([ID])
GO
ALTER TABLE [dbo].[RepairTechnic] CHECK CONSTRAINT [FK_RepairTechnic_Technic]
GO
ALTER TABLE [dbo].[RepairWork]  WITH CHECK ADD  CONSTRAINT [FK_RepairWork_Employees] FOREIGN KEY([Employees])
REFERENCES [dbo].[Employees] ([ID])
GO
ALTER TABLE [dbo].[RepairWork] CHECK CONSTRAINT [FK_RepairWork_Employees]
GO
ALTER TABLE [dbo].[RepairWork]  WITH CHECK ADD  CONSTRAINT [FK_RepairWork_RepairTechnic] FOREIGN KEY([RepairTechnic])
REFERENCES [dbo].[RepairTechnic] ([ID])
GO
ALTER TABLE [dbo].[RepairWork] CHECK CONSTRAINT [FK_RepairWork_RepairTechnic]
GO
ALTER TABLE [dbo].[Technic]  WITH CHECK ADD  CONSTRAINT [FK_Technic_Type] FOREIGN KEY([Type])
REFERENCES [dbo].[Type] ([ID])
GO
ALTER TABLE [dbo].[Technic] CHECK CONSTRAINT [FK_Technic_Type]
GO
