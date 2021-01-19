CREATE PROCEDURE [dbo].[ESP_Boards_Save]
(
    @Title                  nvarchar(50)
    ,@Content               nvarchar(max)
    ,@BmSeq                 bigint
    ,@ParentBoardSeq        bigint              = -1
    ,@Password              nvarchar(30)        = null
    ,@Answer                nvarchar(max)       = null
    ,@BoardStatus           nvarchar(50)        = null
    ,@ExtraColumn01         NVARCHAR(50)        = null
    ,@ExtraColumn02         NVARCHAR(50)        = null
    ,@ExtraColumn03         NVARCHAR(50)        = null
    ,@ExtraColumn04         NVARCHAR(50)        = null
    ,@ExtraColumn05         NVARCHAR(50)        = null
    ,@ExtraColumn06         NVARCHAR(50)        = null
    ,@ExtraColumn07         NVARCHAR(50)        = null
    ,@ExtraColumn08         NVARCHAR(50)        = null
    ,@ExtraColumn09         NVARCHAR(50)        = null
    ,@ExtraColumn10         NVARCHAR(50)        = null
    ,@ExtraColumn11         NVARCHAR(50)        = null
    ,@ExtraColumn12         NVARCHAR(50)        = null
    ,@ExtraColumn13         NVARCHAR(50)        = null
    ,@ExtraColumn14         NVARCHAR(50)        = null
    ,@ExtraColumn15         NVARCHAR(50)        = null
    ,@ExtraColumn16         NVARCHAR(50)        = null
    ,@ExtraColumn17         NVARCHAR(50)        = null
    ,@ExtraColumn18         NVARCHAR(50)        = null
    ,@ExtraColumn19         NVARCHAR(50)        = null
    ,@ExtraColumn20         NVARCHAR(50)        = null
    ,@ExtraColumn21         NVARCHAR(50)        = null
    ,@ExtraColumn22         NVARCHAR(50)        = null
    ,@ExtraColumn23         NVARCHAR(50)        = null
    ,@ExtraColumn24         NVARCHAR(50)        = null
    ,@ExtraColumn25         NVARCHAR(50)        = null
    ,@ExtraColumn26         NVARCHAR(50)        = null
    ,@ExtraColumn27         NVARCHAR(50)        = null
    ,@ExtraColumn28         NVARCHAR(50)        = null
    ,@ExtraColumn29         NVARCHAR(50)        = null
    ,@ExtraColumn30         NVARCHAR(50)        = null
    ,@BoardSeq              bigint              = -1
    ,@MemberSeq             bigint              = -1
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
IF @BoardSeq > 0 and Exists(select BoardSeq from Boards where BoardSeq = @BoardSeq)
    BEGIN
        IF @MemberSeq > 0 and NOT Exists(select BoardSeq From Boards where BoardSeq = @BoardSeq and MemberSeq = @MemberSeq)
            BEGIN
                SET @Err = @Err + 1
                SET @Msg = '본인이 작성한 글이 아니면 수정할 수 없습니다.'
            END
        ELSE IF NOT Exists(select BoardSeq From Boards where BoardSeq = @BoardSeq and [Password] = @Password)
            BEGIN
                SET @Err = @Err + 1
                SET @Msg = '비밀번호가 일치하지 않습니다.'
            END
        ELSE
            BEGIN
                select @Code = BoardSeq from Boards where BoardSeq = @BoardSeq

                UPdate Boards set
                Title = @Title
                ,Content = @Content
                ,LastUpdate = getdate()
                ,BoardStatus = @BoardStatus
                ,ExtraColumn01 = @ExtraColumn01
                ,ExtraColumn02 = @ExtraColumn02
                ,ExtraColumn03 = @ExtraColumn03
                ,ExtraColumn04 = @ExtraColumn04
                ,ExtraColumn05 = @ExtraColumn05
                ,ExtraColumn06 = @ExtraColumn06
                ,ExtraColumn07 = @ExtraColumn07
                ,ExtraColumn08 = @ExtraColumn08
                ,ExtraColumn09 = @ExtraColumn09
                ,ExtraColumn10 = @ExtraColumn10
                ,ExtraColumn11 = @ExtraColumn11
                ,ExtraColumn12 = @ExtraColumn12
                ,ExtraColumn13 = @ExtraColumn13
                ,ExtraColumn14 = @ExtraColumn14
                ,ExtraColumn15 = @ExtraColumn15
                ,ExtraColumn16 = @ExtraColumn16
                ,ExtraColumn17 = @ExtraColumn17
                ,ExtraColumn18 = @ExtraColumn18
                ,ExtraColumn19 = @ExtraColumn19
                ,ExtraColumn20 = @ExtraColumn20
                ,ExtraColumn21 = @ExtraColumn21
                ,ExtraColumn22 = @ExtraColumn22
                ,ExtraColumn23 = @ExtraColumn23
                ,ExtraColumn24 = @ExtraColumn24
                ,ExtraColumn25 = @ExtraColumn25
                ,ExtraColumn26 = @ExtraColumn26
                ,ExtraColumn27 = @ExtraColumn27
                ,ExtraColumn28 = @ExtraColumn28
                ,ExtraColumn29 = @ExtraColumn29
                ,ExtraColumn30 = @ExtraColumn30
                where BmSeq = @Code

                SET @Err = @Err + @@Error
                
                IF LTrim(RTrim(IsNull(@Answer,''))) <> ''
                    BEGIN
                        Update Boards set
                        Answer = @Answer
                        ,AnswerDate = getdate()
                        where BmSeq = @Code

                        SET @Err = @Err + @@Error
                    END
            END


	END
ELSE
    BEGIN
        Insert into Boards (Title,Content,BmSeq,MemberSeq,[Password],ParentBoardSeq,Answer,AnswerDate,BoardStatus
        ,ExtraColumn01,ExtraColumn02,ExtraColumn03,ExtraColumn04,ExtraColumn05
        ,ExtraColumn06,ExtraColumn07,ExtraColumn08,ExtraColumn09,ExtraColumn10
        ,ExtraColumn11,ExtraColumn12,ExtraColumn13,ExtraColumn14,ExtraColumn15
        ,ExtraColumn16,ExtraColumn17,ExtraColumn18,ExtraColumn19,ExtraColumn20
        ,ExtraColumn21,ExtraColumn22,ExtraColumn23,ExtraColumn24,ExtraColumn25
        ,ExtraColumn26,ExtraColumn27,ExtraColumn28,ExtraColumn29,ExtraColumn30)
        values (@Title,@Content,@BmSeq,@MemberSeq,@Password,@ParentBoardSeq,@Answer,getdate(),@BoardStatus
        ,@ExtraColumn01,@ExtraColumn02,@ExtraColumn03,@ExtraColumn04,@ExtraColumn05
        ,@ExtraColumn06,@ExtraColumn07,@ExtraColumn08,@ExtraColumn09,@ExtraColumn10
        ,@ExtraColumn11,@ExtraColumn12,@ExtraColumn13,@ExtraColumn14,@ExtraColumn15
        ,@ExtraColumn16,@ExtraColumn17,@ExtraColumn18,@ExtraColumn19,@ExtraColumn20
        ,@ExtraColumn21,@ExtraColumn22,@ExtraColumn23,@ExtraColumn24,@ExtraColumn25
        ,@ExtraColumn26,@ExtraColumn27,@ExtraColumn28,@ExtraColumn29,@ExtraColumn30
        )


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