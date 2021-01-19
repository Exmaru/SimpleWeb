CREATE TABLE [dbo].[MemberTokens]
(
	[MtSeq] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [MemberSeq] BIGINT NOT NULL, 
    [Token] VARCHAR(100) NOT NULL, 
    [RegistDate] DATETIME2 NOT NULL, 
    [ExpiredDate] DATETIME2 NOT NULL, 
    [IsEnabled] BIT NOT NULL DEFAULT 1
)

GO

CREATE UNIQUE INDEX [IX_MemberTokens_Token] ON [dbo].[MemberTokens] ([Token])
