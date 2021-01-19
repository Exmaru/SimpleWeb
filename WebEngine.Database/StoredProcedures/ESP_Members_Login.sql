CREATE PROCEDURE [dbo].[ESP_Members_Login]
(
    @MemberID              varchar(255)
    ,@Code					bigint				output
    ,@Value					varchar(100)		output
    ,@Msg					nvarchar(100)	    output
)
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED

Declare @Err int
SET @Err = 0

SET @Code = 0
SET @Value = ''
SET @Msg = ''

BEGIN TRAN

BEGIN TRY
IF Not Exists(select MemberSeq from Members where MemberID = @MemberID)
    BEGIN
        SET @Err = @Err + 1
        SET @Msg = '대상을 찾을 수 없습니다.'
	END
ELSE
    BEGIN
        select @Code = MemberSeq from Members where MemberID = @MemberID

        IF Exists(Select MtSeq From MemberTokens where MemberSeq = @Code and ExpiredDate >= getdate() and IsEnabled=1)
            BEGIN
                Select @Value = Token From MemberTokens where MemberSeq = @Code and ExpiredDate >= getdate() and IsEnabled=1
            END
        ELSE
            BEGIN
                SET @Value = newid()

                Insert into MemberTokens (MemberSeq, Token, RegistDate, ExpiredDate, IsEnabled)
                values (@Code, @Value, getdate(), DateAdd(month,1,getdate()),1)

                SET @Err = @Err + @@Error
            END


        Update Members Set
        LastLogin = getdate()
        where MemberSeq = @Code

        SET @Err = @Err + @@Error
    END


END TRY
BEGIN CATCH
    SET @Err = @Err + 1
    SET @Msg = ERROR_MESSAGE()
END CATCH

IF @Err > 0
    BEGIN
        ROLLBACK TRAN
        SET @Code = -1
        IF @Msg = ''
            SET @Msg = '데이터베이스 처리가 실패하였습니다.'
    END
ELSE
    BEGIN
        COMMIT TRAN
    END