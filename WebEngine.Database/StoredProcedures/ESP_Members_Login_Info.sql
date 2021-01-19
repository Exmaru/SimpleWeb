CREATE PROCEDURE [dbo].[ESP_Members_Login_Info]
(
	@Token			varchar(100)
)
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED

Select Top 1
*
From Members
Where IsEnabled = 1
and MemberSeq in (
	Select 
	MemberSeq
	From MemberTokens
	where Token = @Token
	and IsEnabled = 1
	and ExpiredDate >= getdate()
)