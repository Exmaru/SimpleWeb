CREATE TABLE [dbo].[DynamicPageDetail]
(
	[DpdSeq] [bigint] IDENTITY(1,1) NOT NULL,
	[DpmSeq] [int] NOT NULL,
	[RegistDate] [datetime2](7) NOT NULL,
	[RegistMember] [bigint] NOT NULL,
	[LastUpdate] [datetime2](7) NOT NULL,
	[UpdateMember] [bigint] NOT NULL,
	[IsEnabled] [bit] NOT NULL,
	[Extra00] [nvarchar](255) NULL,
	[Extra01] [nvarchar](255) NULL,
	[Extra02] [nvarchar](255) NULL,
	[Extra03] [nvarchar](255) NULL,
	[Extra04] [nvarchar](255) NULL,
	[Extra05] [nvarchar](255) NULL,
	[Extra06] [nvarchar](255) NULL,
	[Extra07] [nvarchar](255) NULL,
	[Extra08] [nvarchar](255) NULL,
	[Extra09] [nvarchar](255) NULL,
	[Extra10] [nvarchar](255) NULL,
	[Extra11] [nvarchar](255) NULL,
	[Extra12] [nvarchar](255) NULL,
	[Extra13] [nvarchar](255) NULL,
	[Extra14] [nvarchar](255) NULL,
	[Extra15] [nvarchar](255) NULL,
	[Extra16] [nvarchar](255) NULL,
	[Extra17] [nvarchar](255) NULL,
	[Extra18] [nvarchar](255) NULL,
	[Extra19] [nvarchar](255) NULL,
	[Extra20] [nvarchar](255) NULL,
	[Extra21] [nvarchar](255) NULL,
	[Extra22] [nvarchar](255) NULL,
	[Extra23] [nvarchar](255) NULL,
	[Extra24] [nvarchar](255) NULL,
	[Extra25] [nvarchar](255) NULL,
	[Extra26] [nvarchar](255) NULL,
	[Extra27] [nvarchar](255) NULL,
	[Extra28] [nvarchar](255) NULL,
	[Extra29] [nvarchar](255) NULL,
	[Extra30] [nvarchar](255) NULL,
	[Extra31] [nvarchar](255) NULL,
	[Extra32] [nvarchar](255) NULL,
	[Extra33] [nvarchar](255) NULL,
	[Extra34] [nvarchar](255) NULL,
	[Extra35] [nvarchar](255) NULL,
	[Extra36] [nvarchar](255) NULL,
	[Extra37] [nvarchar](255) NULL,
	[Extra38] [nvarchar](255) NULL,
	[Extra39] [nvarchar](255) NULL,
	[Extra40] [nvarchar](255) NULL,
	[Extra41] [nvarchar](255) NULL,
	[Extra42] [nvarchar](255) NULL,
	[Extra43] [nvarchar](255) NULL,
	[Extra44] [nvarchar](255) NULL,
	[Extra45] [nvarchar](255) NULL,
	[Extra46] [nvarchar](255) NULL,
	[Extra47] [nvarchar](255) NULL,
	[Extra48] [nvarchar](255) NULL,
	[Extra49] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[DpdSeq] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[DynamicPageDetail] ADD  DEFAULT (getdate()) FOR [RegistDate]
GO

ALTER TABLE [dbo].[DynamicPageDetail] ADD  DEFAULT (getdate()) FOR [LastUpdate]
GO

ALTER TABLE [dbo].[DynamicPageDetail] ADD  DEFAULT ((1)) FOR [IsEnabled]
GO


