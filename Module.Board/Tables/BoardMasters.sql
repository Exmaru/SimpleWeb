CREATE TABLE [dbo].[BoardMasters]
(
	[BmSeq] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [Title] NVARCHAR(50) NOT NULL, 
    [SubTitle] NVARCHAR(100) NULL,
    [Description] NVARCHAR(1000) NULL, 
    [BmCode] VARCHAR(50) NULL,
    [IsPrivate] BIT NOT NULL DEFAULT 0, 
    [IsSecret] BIT NOT NULL DEFAULT 0, 
    [IsOnlyAdmin] BIT NOT NULL DEFAULT 0, 
    [IsComment] BIT NOT NULL DEFAULT 0, 
    [IsReply] BIT NOT NULL DEFAULT 0, 
    [IsShow] BIT NOT NULL DEFAULT 0, 
    [IsFileUpload] BIT NOT NULL DEFAULT 0, 
    [IsAnswer] BIT NOT NULL DEFAULT 0, 
    [IsRequiredLogin] BIT NOT NULL DEFAULT 1, 
    [IsEnabled] BIT NOT NULL DEFAULT 1, 
)
