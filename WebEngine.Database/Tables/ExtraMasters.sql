CREATE TABLE [dbo].[ExtraMasters]
(
	[EmSeq] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [TableName] VARCHAR(255) NOT NULL, 
    [ExtraColumn01] NVARCHAR(50) NULL, 
    [ExtraColumn02] NVARCHAR(50) NULL, 
    [ExtraColumn03] NVARCHAR(50) NULL, 
    [ExtraColumn04] NVARCHAR(50) NULL, 
    [ExtraColumn05] NVARCHAR(50) NULL, 
    [ExtraColumn06] NVARCHAR(50) NULL, 
    [ExtraColumn07] NVARCHAR(50) NULL, 
    [ExtraColumn08] NVARCHAR(50) NULL, 
    [ExtraColumn09] NVARCHAR(50) NULL, 
    [ExtraColumn10] NVARCHAR(50) NULL, 
    [ExtraColumn11] NVARCHAR(50) NULL, 
    [ExtraColumn12] NVARCHAR(50) NULL, 
    [ExtraColumn13] NVARCHAR(50) NULL, 
    [ExtraColumn14] NVARCHAR(50) NULL, 
    [ExtraColumn15] NVARCHAR(50) NULL, 
    [ExtraColumn16] NVARCHAR(50) NULL, 
    [ExtraColumn17] NVARCHAR(50) NULL, 
    [ExtraColumn18] NVARCHAR(50) NULL, 
    [ExtraColumn19] NVARCHAR(50) NULL, 
    [ExtraColumn20] NVARCHAR(50) NULL, 
    [ExtraColumn21] NVARCHAR(50) NULL, 
    [ExtraColumn22] NVARCHAR(50) NULL, 
    [ExtraColumn23] NVARCHAR(50) NULL, 
    [ExtraColumn24] NVARCHAR(50) NULL, 
    [ExtraColumn25] NVARCHAR(50) NULL, 
    [ExtraColumn26] NVARCHAR(50) NULL, 
    [ExtraColumn27] NVARCHAR(50) NULL, 
    [ExtraColumn28] NVARCHAR(50) NULL, 
    [ExtraColumn29] NVARCHAR(50) NULL, 
    [ExtraColumn30] NVARCHAR(50) NULL, 
    [IsEnabled] bit DEFAULT 1 NOT NULL
)

GO

CREATE UNIQUE INDEX [IX_ExtraMasters_TableName] ON [dbo].[ExtraMasters] ([TableName])
