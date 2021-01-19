CREATE TABLE [dbo].[BoardActionLog]
(
	[BoardSeq] BIGINT NOT NULL, 
    [MemberSeq] BIGINT NOT NULL, 
    [Column] VARCHAR(50) NOT NULL, 
    [RegistDate] DATETIME2 NOT NULL DEFAULT getdate()
)

GO

CREATE UNIQUE CLUSTERED INDEX [IX_BoardActionLog_Identity] ON [dbo].[BoardActionLog] ([BoardSeq] DESC, [Column] DESC, [MemberSeq] DESC)
