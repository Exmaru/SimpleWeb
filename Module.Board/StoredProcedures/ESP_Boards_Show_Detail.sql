CREATE PROCEDURE [dbo].[ESP_Boards_Show_Detail]
(
	@BoardSeq			bigint
)
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED

IF Exists(Select BoardSeq From Boards where BoardSeq = @BoardSeq)
	BEGIN
		Update Boards set
		ReadCount = ReadCount + 1
		where BoardSeq = @BoardSeq
	END

Select Top 1 BoardSeq From Boards where BoardSeq = @BoardSeq
