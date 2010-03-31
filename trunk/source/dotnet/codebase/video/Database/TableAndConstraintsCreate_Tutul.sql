SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ChapterDefinitionFile]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ChapterDefinitionFile](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FileName] [nvarchar](255) NOT NULL,
	[CreationTime] [datetime] NULL,
	[ModificationTime] [datetime] NULL,
 CONSTRAINT [PK_ChapterDefinitionFile] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[User](
	[UserID] [bigint] IDENTITY(1,1) NOT NULL,
	[SerialKey] [varchar](255) NULL,
	[FirstName] [varchar](255) NOT NULL,
	[MiddleName] [varchar](255) NULL,
	[LastName] [varchar](255) NULL,
	[Password] [varchar](50) NULL,
	[Email] [varchar](255) NOT NULL,
	[IsResident] [bit] NOT NULL,
	[ResidencyYear] [int] NULL,
	[Created] [datetime] NOT NULL,
	[LastLoggedIn] [datetime] NULL,
	[Modified] [datetime] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[ActivationKey] [varchar](100) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SerialKey]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SerialKey](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Key] [varchar](250) NOT NULL,
	[Created] [datetime] NOT NULL CONSTRAINT [DF_SerialKey_Created]  DEFAULT (getdate()),
 CONSTRAINT [PK_SerialKey] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FileCategory]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[FileCategory](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [varchar](255) NULL,
 CONSTRAINT [PK_FileCategory] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VideoChapter]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[VideoChapter](
	[ChapterID] [bigint] IDENTITY(1,1) NOT NULL,
	[FileID] [bigint] NULL,
	[ChapterName] [varchar](255) NULL,
	[Duration] [bigint] NULL,
	[PlayListSize] [bigint] NULL,
	[Created] [datetime] NOT NULL,
	[Modified] [datetime] NOT NULL,
 CONSTRAINT [PK_VideoChapter] PRIMARY KEY CLUSTERED 
(
	[ChapterID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FileTracking]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[FileTracking](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[FileID] [bigint] NOT NULL,
	[IsViewed] [bit] NULL,
	[IsDownloaded] [bit] NULL,
	[UserID] [bigint] NOT NULL,
	[UserIP] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
 CONSTRAINT [PK_FileTracking] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ContentFile]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ContentFile](
	[FileID] [bigint] IDENTITY(1,1) NOT NULL,
	[FileCategoryID] [int] NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[Size] [bigint] NOT NULL,
	[XMLFileName] [varchar](255) NULL,
	[VideoLength] [bigint] NULL,
	[UploadedBy] [bigint] NOT NULL,
	[UploadedOn] [datetime] NOT NULL,
	[Modified] [datetime] NOT NULL,
 CONSTRAINT [PK_VideoFiles] PRIMARY KEY CLUSTERED 
(
	[FileID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_VideoChapter_ContentFile]') AND parent_object_id = OBJECT_ID(N'[dbo].[VideoChapter]'))
ALTER TABLE [dbo].[VideoChapter]  WITH CHECK ADD  CONSTRAINT [FK_VideoChapter_ContentFile] FOREIGN KEY([FileID])
REFERENCES [dbo].[ContentFile] ([FileID])
GO
ALTER TABLE [dbo].[VideoChapter] CHECK CONSTRAINT [FK_VideoChapter_ContentFile]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_FileTracking_ContentFile]') AND parent_object_id = OBJECT_ID(N'[dbo].[FileTracking]'))
ALTER TABLE [dbo].[FileTracking]  WITH CHECK ADD  CONSTRAINT [FK_FileTracking_ContentFile] FOREIGN KEY([FileID])
REFERENCES [dbo].[ContentFile] ([FileID])
GO
ALTER TABLE [dbo].[FileTracking] CHECK CONSTRAINT [FK_FileTracking_ContentFile]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_FileTracking_User]') AND parent_object_id = OBJECT_ID(N'[dbo].[FileTracking]'))
ALTER TABLE [dbo].[FileTracking]  WITH CHECK ADD  CONSTRAINT [FK_FileTracking_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[FileTracking] CHECK CONSTRAINT [FK_FileTracking_User]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ContentFile_FileCategory]') AND parent_object_id = OBJECT_ID(N'[dbo].[ContentFile]'))
ALTER TABLE [dbo].[ContentFile]  WITH CHECK ADD  CONSTRAINT [FK_ContentFile_FileCategory] FOREIGN KEY([FileCategoryID])
REFERENCES [dbo].[FileCategory] ([ID])
GO
ALTER TABLE [dbo].[ContentFile] CHECK CONSTRAINT [FK_ContentFile_FileCategory]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ContentFile_User]') AND parent_object_id = OBJECT_ID(N'[dbo].[ContentFile]'))
ALTER TABLE [dbo].[ContentFile]  WITH CHECK ADD  CONSTRAINT [FK_ContentFile_User] FOREIGN KEY([UploadedBy])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[ContentFile] CHECK CONSTRAINT [FK_ContentFile_User]
