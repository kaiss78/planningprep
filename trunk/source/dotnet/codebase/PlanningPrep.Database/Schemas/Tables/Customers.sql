IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customers]') AND type in (N'U'))
DROP TABLE [dbo].[Customers]
GO
SET ANSI_NULLS ON
GO
CREATE TABLE [dbo].[Customers](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[ContactFirstName] [varchar](30) NOT NULL,
	[ContactLastName] [varchar](20) NOT NULL,
	[ContactTitle] [varchar](80) NULL,
	[Address1] [varchar](100) NOT NULL,
	[Address2] [varchar](100) NULL,
	[Address3] [varchar](100) NULL,
	[City] [varchar](75) NOT NULL,
	[State] [varchar](50) NOT NULL,
	[PostalCode] [varchar](10) NOT NULL,
	[Country] [varchar](50) NOT NULL,
	[PhoneNumber] [varchar](30) NOT NULL,
	[FaxNumber] [varchar](30) NULL,
	[Active] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[Locked] [bit] NOT NULL,
	[CreatedBy] [varchar](60) NOT NULL,
	[CreatedByDateTime] [varchar](60) NOT NULL,
	[LastModifiedBy] [varchar](60) NOT NULL,
	[LastModifiedByDateTime] [datetime] NOT NULL,
	[DatetimeStamp] [datetime] NOT NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Customers] ADD  CONSTRAINT [DF_Customers_Country]  DEFAULT (('USA')) FOR [Country]
GO

ALTER TABLE [dbo].[Customers] ADD  CONSTRAINT [DF_Customers_Active]  DEFAULT ((1)) FOR [Active]
GO

ALTER TABLE [dbo].[Customers] ADD  CONSTRAINT [DF_Customers_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO

ALTER TABLE [dbo].[Customers] ADD  CONSTRAINT [DF_Customers_Locked]  DEFAULT ((0)) FOR [Locked]
GO 