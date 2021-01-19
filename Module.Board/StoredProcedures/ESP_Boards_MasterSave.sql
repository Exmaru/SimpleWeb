CREATE PROCEDURE [dbo].[ESP_Boards_MasterSave]
(
    @Title                  nvarchar(50)
    ,@SubTitle              nvarchar(100)       = null
    ,@Description           nvarchar(1000)      = null
    ,@BmCode                varchar(50)         = null
    ,@IsPrivate             bit                 = 0
    ,@IsSecret              bit                 = 0
    ,@IsOnlyAdmin           bit                 = 0
    ,@IsComment             bit                 = 0
    ,@IsReply               bit                 = 0
    ,@IsShow                bit                 = 0
    ,@IsFileUpload          bit                 = 0
    ,@IsRequiredLogin       bit                 = 0
    ,@IsAnswer              bit                 = 0
    ,@BmSeq                 bigint              = -1
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
IF @BmSeq > 0 and Exists(select BmSeq from BoardMasters where BmSeq = @BmSeq)
    BEGIN
        select @Code = BmSeq from BoardMasters where BmSeq = @BmSeq

        UPdate BoardMasters set
            Title = @Title
        ,   SubTitle = @SubTitle
        ,   [Description] = @Description
        ,   BmCode = @BmCode
        ,   IsPrivate = @IsPrivate
        ,   IsSecret = @IsSecret
        ,   IsOnlyAdmin = @IsOnlyAdmin
        ,   IsComment = @IsComment
        ,   IsReply = @IsReply
        ,   IsShow = @IsShow
        ,   IsFileUpload = @IsFileUpload
        ,   IsRequiredLogin = @IsRequiredLogin
        ,   IsAnswer = @IsAnswer
        where BmSeq = @Code

        SET @Err = @Err + @@Error
	END
ELSE
    BEGIN
        Insert into BoardMasters (Title,SubTitle,[Description],BmCode,IsPrivate,IsSecret,IsOnlyAdmin,IsComment,IsReply,IsShow,IsFileUpload,IsRequiredLogin,IsAnswer)
        values (@Title,@SubTitle,@Description,@BmCode,@IsPrivate,@IsSecret,@IsOnlyAdmin,@IsComment,@IsReply,@IsShow,@IsFileUpload,@IsRequiredLogin,@IsAnswer)

        SET @Code = @@IDENTITY
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