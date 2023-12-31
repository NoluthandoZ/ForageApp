USE [Forage]
GO
/****** Object:  Table [dbo].[Freelancer]    Script Date: 2023/06/15 23:00:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Freelancer](
	[Freelancer_id] [uniqueidentifier] NOT NULL,
	[Location] [varchar](50) NOT NULL,
	[JobTitle] [varchar](50) NOT NULL,
	[Description] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Freelancer] PRIMARY KEY CLUSTERED 
(
	[Freelancer_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 2023/06/15 23:00:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[user_id] [uniqueidentifier] NOT NULL,
	[firstname] [varchar](50) NOT NULL,
	[lastname] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[gender] [varchar](6) NOT NULL,
	[email] [varchar](50) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vacancies]    Script Date: 2023/06/15 23:00:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vacancies](
	[Vacany_id] [uniqueidentifier] NOT NULL,
	[ClosingDate] [date] NOT NULL,
	[Description] [varchar](200) NOT NULL,
	[CompanyName] [varchar](50) NOT NULL,
	[Requirements] [varchar](50) NULL,
	[Vacany_type] [varchar](50) NULL,
 CONSTRAINT [PK_Vacancies] PRIMARY KEY CLUSTERED 
(
	[Vacany_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Freelancer] ADD  CONSTRAINT [DF_Freelancer_Freelancer_id]  DEFAULT (newid()) FOR [Freelancer_id]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_user_id]  DEFAULT (newid()) FOR [user_id]
GO
ALTER TABLE [dbo].[Vacancies] ADD  CONSTRAINT [DF_Vacancies_Vacany_id]  DEFAULT (newid()) FOR [Vacany_id]
GO
