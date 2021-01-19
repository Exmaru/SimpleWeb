CREATE PROCEDURE [dbo].[ESP_Members_PasswordChange]
(
    @MemberSeq              bigint
    ,@Password              NVARCHAR(512)
    ,@IsCrypto              bit
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
IF Not Exists(select MemberSeq from Members where MemberSeq = @MemberSeq)
    BEGIN
        SET @Err = @Err + 1
        SET @Msg = '대상을 찾을 수 없습니다.'
	END
ELSE
    BEGIN
        select @Code = MemberSeq from Members where MemberSeq = @MemberSeq

        Update Members Set
        [Password] = @Password
        ,IsCrypto = @IsCrypto
        ,LastUpdate = getdate()
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