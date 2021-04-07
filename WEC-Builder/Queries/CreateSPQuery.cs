using System.Collections.Generic;

namespace WEC_Builder
{
    public class CreateSPQuery
    {
        public List<string> All { get; set; } = new List<string>();

        public CreateSPQuery()
        {
            this.All.Add(ESP_Members_Regist);
            this.All.Add(ESP_Members_Update);
            this.All.Add(ESP_Members_PasswordChange);
            this.All.Add(ESP_Members_PasswordReset);
            this.All.Add(ESP_Members_Login);
            this.All.Add(ESP_Members_Login_Info);
            this.All.Add(ESP_Boards_Show_Detail);
            this.All.Add(ESP_Boards_Action);
            this.All.Add(ESP_Boards_MasterSave);
            this.All.Add(ESP_Boards_Save);
            this.All.Add(ESP_DynamicPageMaster_Save);
            this.All.Add(ESP_DynamicPageDetail_Save);
        }

        public string ESP_Members_Regist =
@"CREATE PROCEDURE [dbo].[ESP_Members_Regist]
(
    @MemberID VARCHAR(255)
    ,@Password NVARCHAR(512)
	,@ViewName NVARCHAR(50)
    ,@MemberType NVARCHAR(50)
    ,@IDType NVARCHAR(50)
    ,@MemberStatus NVARCHAR(50)
    ,@IsCrypto bit = 0
    ,@SubMemberType NVARCHAR(50) = '' 
    ,@Email VARCHAR(255) = '' 
    ,@ExtraColumn01 NVARCHAR(50) = null
    ,@ExtraColumn02 NVARCHAR(50) = null
    ,@ExtraColumn03 NVARCHAR(50) = null
    ,@ExtraColumn04 NVARCHAR(50) = null
    ,@ExtraColumn05 NVARCHAR(50) = null
    ,@ExtraColumn06 NVARCHAR(50) = null
    ,@ExtraColumn07 NVARCHAR(50) = null
    ,@ExtraColumn08 NVARCHAR(50) = null
    ,@ExtraColumn09 NVARCHAR(50) = null
    ,@ExtraColumn10 NVARCHAR(50) = null
    ,@ExtraColumn11 NVARCHAR(50) = null
    ,@ExtraColumn12 NVARCHAR(50) = null
    ,@ExtraColumn13 NVARCHAR(50) = null
    ,@ExtraColumn14 NVARCHAR(50) = null
    ,@ExtraColumn15 NVARCHAR(50) = null
    ,@ExtraColumn16 NVARCHAR(50) = null
    ,@ExtraColumn17 NVARCHAR(50) = null
    ,@ExtraColumn18 NVARCHAR(50) = null
    ,@ExtraColumn19 NVARCHAR(50) = null
    ,@ExtraColumn20 NVARCHAR(50) = null
    ,@ExtraColumn21 NVARCHAR(50) = null
    ,@ExtraColumn22 NVARCHAR(50) = null
    ,@ExtraColumn23 NVARCHAR(50) = null
    ,@ExtraColumn24 NVARCHAR(50) = null
    ,@ExtraColumn25 NVARCHAR(50) = null
    ,@ExtraColumn26 NVARCHAR(50) = null
    ,@ExtraColumn27 NVARCHAR(50) = null
    ,@ExtraColumn28 NVARCHAR(50) = null
    ,@ExtraColumn29 NVARCHAR(50) = null
    ,@ExtraColumn30 NVARCHAR(50) = null
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
IF Exists(select MemberSeq from Members where MemberID = @MemberID)
    BEGIN
        SET @Err = @Err + 1
        SET @Msg = '해당 아이디는 이미 사용중입니다.'
	END
ELSE
    BEGIN
        Insert into Members (
        MemberID,[Password],MemberType,SubMemberType,IDType,Email,RegistDate,LastUpdate,LastLogin,MemberStatus,IsCrypto,IsEnabled,ViewName
        ,ExtraColumn01,ExtraColumn02,ExtraColumn03,ExtraColumn04,ExtraColumn05
        ,ExtraColumn06,ExtraColumn07,ExtraColumn08,ExtraColumn09,ExtraColumn10
        ,ExtraColumn11,ExtraColumn12,ExtraColumn13,ExtraColumn14,ExtraColumn15
        ,ExtraColumn16,ExtraColumn17,ExtraColumn18,ExtraColumn19,ExtraColumn20
        ,ExtraColumn21,ExtraColumn22,ExtraColumn23,ExtraColumn24,ExtraColumn25
        ,ExtraColumn26,ExtraColumn27,ExtraColumn28,ExtraColumn29,ExtraColumn30
        ) values (
        @MemberID,@Password,@MemberType,@SubMemberType,@IDType,@Email,getdate(),getdate(),getdate(),@MemberStatus,@IsCrypto,1,@ViewName
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
    END";

        public string ESP_Members_Update =
@"CREATE PROCEDURE [dbo].[ESP_Members_Update]
(
    @MemberSeq bigint
	,@ViewName NVARCHAR(50)
    ,@MemberType NVARCHAR(50)
    ,@IDType NVARCHAR(50)
    ,@MemberStatus NVARCHAR(50)
    ,@SubMemberType NVARCHAR(50) = '' 
    ,@Email VARCHAR(255) = '' 
    ,@ExtraColumn01 NVARCHAR(50) = null
    ,@ExtraColumn02 NVARCHAR(50) = null
    ,@ExtraColumn03 NVARCHAR(50) = null
    ,@ExtraColumn04 NVARCHAR(50) = null
    ,@ExtraColumn05 NVARCHAR(50) = null
    ,@ExtraColumn06 NVARCHAR(50) = null
    ,@ExtraColumn07 NVARCHAR(50) = null
    ,@ExtraColumn08 NVARCHAR(50) = null
    ,@ExtraColumn09 NVARCHAR(50) = null
    ,@ExtraColumn10 NVARCHAR(50) = null
    ,@ExtraColumn11 NVARCHAR(50) = null
    ,@ExtraColumn12 NVARCHAR(50) = null
    ,@ExtraColumn13 NVARCHAR(50) = null
    ,@ExtraColumn14 NVARCHAR(50) = null
    ,@ExtraColumn15 NVARCHAR(50) = null
    ,@ExtraColumn16 NVARCHAR(50) = null
    ,@ExtraColumn17 NVARCHAR(50) = null
    ,@ExtraColumn18 NVARCHAR(50) = null
    ,@ExtraColumn19 NVARCHAR(50) = null
    ,@ExtraColumn20 NVARCHAR(50) = null
    ,@ExtraColumn21 NVARCHAR(50) = null
    ,@ExtraColumn22 NVARCHAR(50) = null
    ,@ExtraColumn23 NVARCHAR(50) = null
    ,@ExtraColumn24 NVARCHAR(50) = null
    ,@ExtraColumn25 NVARCHAR(50) = null
    ,@ExtraColumn26 NVARCHAR(50) = null
    ,@ExtraColumn27 NVARCHAR(50) = null
    ,@ExtraColumn28 NVARCHAR(50) = null
    ,@ExtraColumn29 NVARCHAR(50) = null
    ,@ExtraColumn30 NVARCHAR(50) = null
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
IF Exists(select MemberSeq from Members where MemberSeq = @MemberSeq)
    BEGIN
        select @Code = MemberSeq from Members where MemberSeq = @MemberSeq

        Update Members Set
        MemberType = @MemberType
		,ViewName = @ViewName
        ,SubMemberType = @SubMemberType
        ,IDType = @IDType
        ,Email = @Email
        ,LastUpdate = getdate()
        ,MemberStatus = @MemberStatus
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
        where MemberSeq = @Code

        SET @Err = @Err + @@Error
	END
ELSE
    BEGIN
        SET @Err = @Err + 1
        SET @Msg = '대상을 찾을 수 없습니다.'
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
    END";

        public string ESP_Members_PasswordChange =
@"CREATE PROCEDURE [dbo].[ESP_Members_PasswordChange]
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
    END";

        public string ESP_Members_PasswordReset =
@"CREATE PROCEDURE [dbo].[ESP_Members_PasswordReset]
(
    @MemberSeq              bigint
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
        [Password] = ''
        ,IsCrypto = 0
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
    END";

        public string ESP_Members_Login =
@"CREATE PROCEDURE [dbo].[ESP_Members_Login]
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
    END";

        public string ESP_Members_Login_Info =
@"CREATE PROCEDURE [dbo].[ESP_Members_Login_Info]
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
)";

        public string ESP_Boards_Show_Detail =
@"CREATE PROCEDURE [dbo].[ESP_Boards_Show_Detail]
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

Select Top 1 BoardSeq From Boards where BoardSeq = @BoardSeq";

        public string ESP_Boards_Action =
@"CREATE PROCEDURE [dbo].[ESP_Boards_Action]
(
    @BoardSeq              bigint
    ,@MemberSeq             bigint
    ,@Column                varchar(50)
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
IF NOT Exists(select MemberSeq from Members where MemberSeq = @MemberSeq)
    BEGIN
        SET @Err = @Err + 1
        SET @Msg = '대상 회원이 없습니다.'
	END
ELSE IF NOT Exists(select BoardSeq from Boards where BoardSeq = @BoardSeq)
    BEGIN
        SET @Err = @Err + 1
        SET @Msg = '대상 게시판이 없습니다.'
	END
ELSE
    BEGIN
        IF Exists(Select BoardSeq From BoardActionLog where BoardSeq = @BoardSeq and MemberSeq = @MemberSeq and [Column] = @Column)
            BEGIN
                SET @Err = @Err + 1
                
                IF @Column = 'LikeCount'
                    BEGIN
                       SET @Msg = '이미 좋아요 하셨습니다.' 
                    END
                ELSE IF @Column = 'UnLikeCount'
                    BEGIN
                       SET @Msg = '이미 싫어요 하셨습니다.' 
                    END
                ELSE IF @Column = 'RecommendCount'
                    BEGIN
                       SET @Msg = '이미 추천 하셨습니다.' 
                    END
                ELSE
                    BEGIN
                        SET @Msg = '이미 참여하였습니다.' 
                    END
            END
        ELSE
            BEGIN
                Insert into BoardActionLog (MemberSeq, BoardSeq, [Column]) values (@MemberSeq, @BoardSeq, @Code)

                SET @Err = @Err + @@Error
                SET @Code = @BoardSeq
            END
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
    END";

        public string ESP_Boards_MasterSave =
@"CREATE PROCEDURE [dbo].[ESP_Boards_MasterSave]
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
    END";

        public string ESP_Boards_Save =
@"CREATE PROCEDURE [dbo].[ESP_Boards_Save]
(
    @Title                  nvarchar(50)
    ,@Content               nvarchar(max)
    ,@BmSeq                 bigint
    ,@ParentBoardSeq        bigint              = -1
    ,@Password              nvarchar(30)        = null
    ,@Answer                nvarchar(max)       = null
    ,@BoardStatus           nvarchar(50)        = null
    ,@IsShow                bit                 = 1
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
        ELSE
            BEGIN
                select @Code = BoardSeq from Boards where BoardSeq = @BoardSeq

                UPdate Boards set
                Title = @Title
                ,Content = @Content
                ,LastUpdate = getdate()
                ,BoardStatus = @BoardStatus
                ,IsShow = @IsShow
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
                where BoardSeq = @Code

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
        Insert into Boards (Title,Content,BmSeq,MemberSeq,[Password],ParentBoardSeq,Answer,AnswerDate,BoardStatus,IsShow
        ,ExtraColumn01,ExtraColumn02,ExtraColumn03,ExtraColumn04,ExtraColumn05
        ,ExtraColumn06,ExtraColumn07,ExtraColumn08,ExtraColumn09,ExtraColumn10
        ,ExtraColumn11,ExtraColumn12,ExtraColumn13,ExtraColumn14,ExtraColumn15
        ,ExtraColumn16,ExtraColumn17,ExtraColumn18,ExtraColumn19,ExtraColumn20
        ,ExtraColumn21,ExtraColumn22,ExtraColumn23,ExtraColumn24,ExtraColumn25
        ,ExtraColumn26,ExtraColumn27,ExtraColumn28,ExtraColumn29,ExtraColumn30)
        values (@Title,@Content,@BmSeq,@MemberSeq,@Password,@ParentBoardSeq,@Answer,getdate(),@BoardStatus,@IsShow
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
    END";

        public string ESP_DynamicPageMaster_Save =
@"CREATE PROCEDURE [dbo].[ESP_DynamicPageMaster_Save]
(
	@MemberSeq					bigint
,	@DpmCode					varchar(30)
,	@Title					    nvarchar(50)
,	@ExType00					varchar(30) = ''
,	@ExType01					varchar(30) = ''
,	@ExType02					varchar(30) = ''
,	@ExType03					varchar(30) = ''
,	@ExType04					varchar(30) = ''
,	@ExType05					varchar(30) = ''
,	@ExType06					varchar(30) = ''
,	@ExType07					varchar(30) = ''
,	@ExType08					varchar(30) = ''
,	@ExType09					varchar(30) = ''
,	@ExType10					varchar(30) = ''
,	@ExType11					varchar(30) = ''
,	@ExType12					varchar(30) = ''
,	@ExType13					varchar(30) = ''
,	@ExType14					varchar(30) = ''
,	@ExType15					varchar(30) = ''
,	@ExType16					varchar(30) = ''
,	@ExType17					varchar(30) = ''
,	@ExType18					varchar(30) = ''
,	@ExType19					varchar(30) = ''
,	@ExType20					varchar(30) = ''
,	@ExType21					varchar(30) = ''
,	@ExType22					varchar(30) = ''
,	@ExType23					varchar(30) = ''
,	@ExType24					varchar(30) = ''
,	@ExType25					varchar(30) = ''
,	@ExType26					varchar(30) = ''
,	@ExType27					varchar(30) = ''
,	@ExType28					varchar(30) = ''
,	@ExType29					varchar(30) = ''
,	@ExType30					varchar(30) = ''
,	@ExType31					varchar(30) = ''
,	@ExType32					varchar(30) = ''
,	@ExType33					varchar(30) = ''
,	@ExType34					varchar(30) = ''
,	@ExType35					varchar(30) = ''
,	@ExType36					varchar(30) = ''
,	@ExType37					varchar(30) = ''
,	@ExType38					varchar(30) = ''
,	@ExType39					varchar(30) = ''
,	@ExType40					varchar(30) = ''
,	@ExType41					varchar(30) = ''
,	@ExType42					varchar(30) = ''
,	@ExType43					varchar(30) = ''
,	@ExType44					varchar(30) = ''
,	@ExType45					varchar(30) = ''
,	@ExType46					varchar(30) = ''
,	@ExType47					varchar(30) = ''
,	@ExType48					varchar(30) = ''
,	@ExType49					varchar(30) = ''
,	@Extra00					nvarchar(30) = ''
,	@Extra01					nvarchar(30) = ''
,	@Extra02					nvarchar(30) = ''
,	@Extra03					nvarchar(30) = ''
,	@Extra04					nvarchar(30) = ''
,	@Extra05					nvarchar(30) = ''
,	@Extra06					nvarchar(30) = ''
,	@Extra07					nvarchar(30) = ''
,	@Extra08					nvarchar(30) = ''
,	@Extra09					nvarchar(30) = ''
,	@Extra10					nvarchar(30) = ''
,	@Extra11					nvarchar(30) = ''
,	@Extra12					nvarchar(30) = ''
,	@Extra13					nvarchar(30) = ''
,	@Extra14					nvarchar(30) = ''
,	@Extra15					nvarchar(30) = ''
,	@Extra16					nvarchar(30) = ''
,	@Extra17					nvarchar(30) = ''
,	@Extra18					nvarchar(30) = ''
,	@Extra19					nvarchar(30) = ''
,	@Extra20					nvarchar(30) = ''
,	@Extra21					nvarchar(30) = ''
,	@Extra22					nvarchar(30) = ''
,	@Extra23					nvarchar(30) = ''
,	@Extra24					nvarchar(30) = ''
,	@Extra25					nvarchar(30) = ''
,	@Extra26					nvarchar(30) = ''
,	@Extra27					nvarchar(30) = ''
,	@Extra28					nvarchar(30) = ''
,	@Extra29					nvarchar(30) = ''
,	@Extra30					nvarchar(30) = ''
,	@Extra31					nvarchar(30) = ''
,	@Extra32					nvarchar(30) = ''
,	@Extra33					nvarchar(30) = ''
,	@Extra34					nvarchar(30) = ''
,	@Extra35					nvarchar(30) = ''
,	@Extra36					nvarchar(30) = ''
,	@Extra37					nvarchar(30) = ''
,	@Extra38					nvarchar(30) = ''
,	@Extra39					nvarchar(30) = ''
,	@Extra40					nvarchar(30) = ''
,	@Extra41					nvarchar(30) = ''
,	@Extra42					nvarchar(30) = ''
,	@Extra43					nvarchar(30) = ''
,	@Extra44					nvarchar(30) = ''
,	@Extra45					nvarchar(30) = ''
,	@Extra46					nvarchar(30) = ''
,	@Extra47					nvarchar(30) = ''
,	@Extra48					nvarchar(30) = ''
,	@Extra49					nvarchar(30) = ''
,	@ExOption00					nvarchar(100) = ''
,	@ExOption01					nvarchar(100) = ''
,	@ExOption02					nvarchar(100) = ''
,	@ExOption03					nvarchar(100) = ''
,	@ExOption04					nvarchar(100) = ''
,	@ExOption05					nvarchar(100) = ''
,	@ExOption06					nvarchar(100) = ''
,	@ExOption07					nvarchar(100) = ''
,	@ExOption08					nvarchar(100) = ''
,	@ExOption09					nvarchar(100) = ''
,	@ExOption10					nvarchar(100) = ''
,	@ExOption11					nvarchar(100) = ''
,	@ExOption12					nvarchar(100) = ''
,	@ExOption13					nvarchar(100) = ''
,	@ExOption14					nvarchar(100) = ''
,	@ExOption15					nvarchar(100) = ''
,	@ExOption16					nvarchar(100) = ''
,	@ExOption17					nvarchar(100) = ''
,	@ExOption18					nvarchar(100) = ''
,	@ExOption19					nvarchar(100) = ''
,	@ExOption20					nvarchar(100) = ''
,	@ExOption21					nvarchar(100) = ''
,	@ExOption22					nvarchar(100) = ''
,	@ExOption23					nvarchar(100) = ''
,	@ExOption24					nvarchar(100) = ''
,	@ExOption25					nvarchar(100) = ''
,	@ExOption26					nvarchar(100) = ''
,	@ExOption27					nvarchar(100) = ''
,	@ExOption28					nvarchar(100) = ''
,	@ExOption29					nvarchar(100) = ''
,	@ExOption30					nvarchar(100) = ''
,	@ExOption31					nvarchar(100) = ''
,	@ExOption32					nvarchar(100) = ''
,	@ExOption33					nvarchar(100) = ''
,	@ExOption34					nvarchar(100) = ''
,	@ExOption35					nvarchar(100) = ''
,	@ExOption36					nvarchar(100) = ''
,	@ExOption37					nvarchar(100) = ''
,	@ExOption38					nvarchar(100) = ''
,	@ExOption39					nvarchar(100) = ''
,	@ExOption40					nvarchar(100) = ''
,	@ExOption41					nvarchar(100) = ''
,	@ExOption42					nvarchar(100) = ''
,	@ExOption43					nvarchar(100) = ''
,	@ExOption44					nvarchar(100) = ''
,	@ExOption45					nvarchar(100) = ''
,	@ExOption46					nvarchar(100) = ''
,	@ExOption47					nvarchar(100) = ''
,	@ExOption48					nvarchar(100) = ''
,	@ExOption49					nvarchar(100) = ''
,	@DpmSeq					int     = -1
,	@Code					bigint				output
,	@Value					varchar(100)		output
,	@Msg					nvarchar(100)		output
)
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED

Declare @Err int
SET @Err = 0

SET @Code = 0
SET @Value = ''
SET @Msg = ''

BEGIN TRY
IF Exists(select [DpmSeq] from [DynamicPageMaster] where [DpmSeq] = @DpmSeq)
	BEGIN
update [DynamicPageMaster] set 
[DpmCode] = @DpmCode
,[Title] = @Title
,[LastUpdate] = getdate()
,[UpdateMember] = @MemberSeq
,[ExType00] = @ExType00
,[ExType01] = @ExType01
,[ExType02] = @ExType02
,[ExType03] = @ExType03
,[ExType04] = @ExType04
,[ExType05] = @ExType05
,[ExType06] = @ExType06
,[ExType07] = @ExType07
,[ExType08] = @ExType08
,[ExType09] = @ExType09
,[ExType10] = @ExType10
,[ExType11] = @ExType11
,[ExType12] = @ExType12
,[ExType13] = @ExType13
,[ExType14] = @ExType14
,[ExType15] = @ExType15
,[ExType16] = @ExType16
,[ExType17] = @ExType17
,[ExType18] = @ExType18
,[ExType19] = @ExType19
,[ExType20] = @ExType20
,[ExType21] = @ExType21
,[ExType22] = @ExType22
,[ExType23] = @ExType23
,[ExType24] = @ExType24
,[ExType25] = @ExType25
,[ExType26] = @ExType26
,[ExType27] = @ExType27
,[ExType28] = @ExType28
,[ExType29] = @ExType29
,[ExType30] = @ExType30
,[ExType31] = @ExType31
,[ExType32] = @ExType32
,[ExType33] = @ExType33
,[ExType34] = @ExType34
,[ExType35] = @ExType35
,[ExType36] = @ExType36
,[ExType37] = @ExType37
,[ExType38] = @ExType38
,[ExType39] = @ExType39
,[ExType40] = @ExType40
,[ExType41] = @ExType41
,[ExType42] = @ExType42
,[ExType43] = @ExType43
,[ExType44] = @ExType44
,[ExType45] = @ExType45
,[ExType46] = @ExType46
,[ExType47] = @ExType47
,[ExType48] = @ExType48
,[ExType49] = @ExType49
,[Extra00] = @Extra00
,[Extra01] = @Extra01
,[Extra02] = @Extra02
,[Extra03] = @Extra03
,[Extra04] = @Extra04
,[Extra05] = @Extra05
,[Extra06] = @Extra06
,[Extra07] = @Extra07
,[Extra08] = @Extra08
,[Extra09] = @Extra09
,[Extra10] = @Extra10
,[Extra11] = @Extra11
,[Extra12] = @Extra12
,[Extra13] = @Extra13
,[Extra14] = @Extra14
,[Extra15] = @Extra15
,[Extra16] = @Extra16
,[Extra17] = @Extra17
,[Extra18] = @Extra18
,[Extra19] = @Extra19
,[Extra20] = @Extra20
,[Extra21] = @Extra21
,[Extra22] = @Extra22
,[Extra23] = @Extra23
,[Extra24] = @Extra24
,[Extra25] = @Extra25
,[Extra26] = @Extra26
,[Extra27] = @Extra27
,[Extra28] = @Extra28
,[Extra29] = @Extra29
,[Extra30] = @Extra30
,[Extra31] = @Extra31
,[Extra32] = @Extra32
,[Extra33] = @Extra33
,[Extra34] = @Extra34
,[Extra35] = @Extra35
,[Extra36] = @Extra36
,[Extra37] = @Extra37
,[Extra38] = @Extra38
,[Extra39] = @Extra39
,[Extra40] = @Extra40
,[Extra41] = @Extra41
,[Extra42] = @Extra42
,[Extra43] = @Extra43
,[Extra44] = @Extra44
,[Extra45] = @Extra45
,[Extra46] = @Extra46
,[Extra47] = @Extra47
,[Extra48] = @Extra48
,[Extra49] = @Extra49
,[ExOption00] = @ExOption00
,[ExOption01] = @ExOption01
,[ExOption02] = @ExOption02
,[ExOption03] = @ExOption03
,[ExOption04] = @ExOption04
,[ExOption05] = @ExOption05
,[ExOption06] = @ExOption06
,[ExOption07] = @ExOption07
,[ExOption08] = @ExOption08
,[ExOption09] = @ExOption09
,[ExOption10] = @ExOption10
,[ExOption11] = @ExOption11
,[ExOption12] = @ExOption12
,[ExOption13] = @ExOption13
,[ExOption14] = @ExOption14
,[ExOption15] = @ExOption15
,[ExOption16] = @ExOption16
,[ExOption17] = @ExOption17
,[ExOption18] = @ExOption18
,[ExOption19] = @ExOption19
,[ExOption20] = @ExOption20
,[ExOption21] = @ExOption21
,[ExOption22] = @ExOption22
,[ExOption23] = @ExOption23
,[ExOption24] = @ExOption24
,[ExOption25] = @ExOption25
,[ExOption26] = @ExOption26
,[ExOption27] = @ExOption27
,[ExOption28] = @ExOption28
,[ExOption29] = @ExOption29
,[ExOption30] = @ExOption30
,[ExOption31] = @ExOption31
,[ExOption32] = @ExOption32
,[ExOption33] = @ExOption33
,[ExOption34] = @ExOption34
,[ExOption35] = @ExOption35
,[ExOption36] = @ExOption36
,[ExOption37] = @ExOption37
,[ExOption38] = @ExOption38
,[ExOption39] = @ExOption39
,[ExOption40] = @ExOption40
,[ExOption41] = @ExOption41
,[ExOption42] = @ExOption42
,[ExOption43] = @ExOption43
,[ExOption44] = @ExOption44
,[ExOption45] = @ExOption45
,[ExOption46] = @ExOption46
,[ExOption47] = @ExOption47
,[ExOption48] = @ExOption48
,[ExOption49] = @ExOption49
 where [DpmSeq] = @DpmSeq

SET @Err = @Err + @@Error

IF IsNull(@Err,0) = 0
    BEGIN
        SET @Code = @DpmSeq
    END
ELSE
    BEGIN
        SET @Code = -1
        SET @Msg = '수정하지 못했습니다.'
    END
	END
ELSE
	BEGIN
insert into [DynamicPageMaster] (
[DpmCode]
,[Title]
,[RegistDate]
,[RegistMember]
,[LastUpdate]
,[UpdateMember]
,[IsEnabled]
,[ExType00]
,[ExType01]
,[ExType02]
,[ExType03]
,[ExType04]
,[ExType05]
,[ExType06]
,[ExType07]
,[ExType08]
,[ExType09]
,[ExType10]
,[ExType11]
,[ExType12]
,[ExType13]
,[ExType14]
,[ExType15]
,[ExType16]
,[ExType17]
,[ExType18]
,[ExType19]
,[ExType20]
,[ExType21]
,[ExType22]
,[ExType23]
,[ExType24]
,[ExType25]
,[ExType26]
,[ExType27]
,[ExType28]
,[ExType29]
,[ExType30]
,[ExType31]
,[ExType32]
,[ExType33]
,[ExType34]
,[ExType35]
,[ExType36]
,[ExType37]
,[ExType38]
,[ExType39]
,[ExType40]
,[ExType41]
,[ExType42]
,[ExType43]
,[ExType44]
,[ExType45]
,[ExType46]
,[ExType47]
,[ExType48]
,[ExType49]
,[Extra00]
,[Extra01]
,[Extra02]
,[Extra03]
,[Extra04]
,[Extra05]
,[Extra06]
,[Extra07]
,[Extra08]
,[Extra09]
,[Extra10]
,[Extra11]
,[Extra12]
,[Extra13]
,[Extra14]
,[Extra15]
,[Extra16]
,[Extra17]
,[Extra18]
,[Extra19]
,[Extra20]
,[Extra21]
,[Extra22]
,[Extra23]
,[Extra24]
,[Extra25]
,[Extra26]
,[Extra27]
,[Extra28]
,[Extra29]
,[Extra30]
,[Extra31]
,[Extra32]
,[Extra33]
,[Extra34]
,[Extra35]
,[Extra36]
,[Extra37]
,[Extra38]
,[Extra39]
,[Extra40]
,[Extra41]
,[Extra42]
,[Extra43]
,[Extra44]
,[Extra45]
,[Extra46]
,[Extra47]
,[Extra48]
,[Extra49]
,[ExOption00]
,[ExOption01]
,[ExOption02]
,[ExOption03]
,[ExOption04]
,[ExOption05]
,[ExOption06]
,[ExOption07]
,[ExOption08]
,[ExOption09]
,[ExOption10]
,[ExOption11]
,[ExOption12]
,[ExOption13]
,[ExOption14]
,[ExOption15]
,[ExOption16]
,[ExOption17]
,[ExOption18]
,[ExOption19]
,[ExOption20]
,[ExOption21]
,[ExOption22]
,[ExOption23]
,[ExOption24]
,[ExOption25]
,[ExOption26]
,[ExOption27]
,[ExOption28]
,[ExOption29]
,[ExOption30]
,[ExOption31]
,[ExOption32]
,[ExOption33]
,[ExOption34]
,[ExOption35]
,[ExOption36]
,[ExOption37]
,[ExOption38]
,[ExOption39]
,[ExOption40]
,[ExOption41]
,[ExOption42]
,[ExOption43]
,[ExOption44]
,[ExOption45]
,[ExOption46]
,[ExOption47]
,[ExOption48]
,[ExOption49]
) values (
@DpmCode
,@Title
,getdate()
,@MemberSeq
,getdate()
,@MemberSeq
,1
,@ExType00
,@ExType01
,@ExType02
,@ExType03
,@ExType04
,@ExType05
,@ExType06
,@ExType07
,@ExType08
,@ExType09
,@ExType10
,@ExType11
,@ExType12
,@ExType13
,@ExType14
,@ExType15
,@ExType16
,@ExType17
,@ExType18
,@ExType19
,@ExType20
,@ExType21
,@ExType22
,@ExType23
,@ExType24
,@ExType25
,@ExType26
,@ExType27
,@ExType28
,@ExType29
,@ExType30
,@ExType31
,@ExType32
,@ExType33
,@ExType34
,@ExType35
,@ExType36
,@ExType37
,@ExType38
,@ExType39
,@ExType40
,@ExType41
,@ExType42
,@ExType43
,@ExType44
,@ExType45
,@ExType46
,@ExType47
,@ExType48
,@ExType49
,@Extra00
,@Extra01
,@Extra02
,@Extra03
,@Extra04
,@Extra05
,@Extra06
,@Extra07
,@Extra08
,@Extra09
,@Extra10
,@Extra11
,@Extra12
,@Extra13
,@Extra14
,@Extra15
,@Extra16
,@Extra17
,@Extra18
,@Extra19
,@Extra20
,@Extra21
,@Extra22
,@Extra23
,@Extra24
,@Extra25
,@Extra26
,@Extra27
,@Extra28
,@Extra29
,@Extra30
,@Extra31
,@Extra32
,@Extra33
,@Extra34
,@Extra35
,@Extra36
,@Extra37
,@Extra38
,@Extra39
,@Extra40
,@Extra41
,@Extra42
,@Extra43
,@Extra44
,@Extra45
,@Extra46
,@Extra47
,@Extra48
,@Extra49
,@ExOption00
,@ExOption01
,@ExOption02
,@ExOption03
,@ExOption04
,@ExOption05
,@ExOption06
,@ExOption07
,@ExOption08
,@ExOption09
,@ExOption10
,@ExOption11
,@ExOption12
,@ExOption13
,@ExOption14
,@ExOption15
,@ExOption16
,@ExOption17
,@ExOption18
,@ExOption19
,@ExOption20
,@ExOption21
,@ExOption22
,@ExOption23
,@ExOption24
,@ExOption25
,@ExOption26
,@ExOption27
,@ExOption28
,@ExOption29
,@ExOption30
,@ExOption31
,@ExOption32
,@ExOption33
,@ExOption34
,@ExOption35
,@ExOption36
,@ExOption37
,@ExOption38
,@ExOption39
,@ExOption40
,@ExOption41
,@ExOption42
,@ExOption43
,@ExOption44
,@ExOption45
,@ExOption46
,@ExOption47
,@ExOption48
,@ExOption49
)

SET @Err = @Err + @@Error

IF IsNull(@Err,0) = 0
    BEGIN
        SET @Code = @@IDENTITY
    END
ELSE
    BEGIN
        SET @Code = -1
        SET @Msg = '저장하지 못했습니다.'
    END
	END

END TRY
BEGIN CATCH
    SET @Code = -1
    SET @Err = @Err + 1
    SET @Msg = ERROR_MESSAGE()
END CATCH";

        public string ESP_DynamicPageDetail_Save =
@"CREATE PROCEDURE [dbo].[ESP_DynamicPageDetail_Save]
(
	@MemberSeq					bigint
,	@DpmSeq					int
,	@Extra00					nvarchar(255) = ''
,	@Extra01					nvarchar(255) = ''
,	@Extra02					nvarchar(255) = ''
,	@Extra03					nvarchar(255) = ''
,	@Extra04					nvarchar(255) = ''
,	@Extra05					nvarchar(255) = ''
,	@Extra06					nvarchar(255) = ''
,	@Extra07					nvarchar(255) = ''
,	@Extra08					nvarchar(255) = ''
,	@Extra09					nvarchar(255) = ''
,	@Extra10					nvarchar(255) = ''
,	@Extra11					nvarchar(255) = ''
,	@Extra12					nvarchar(255) = ''
,	@Extra13					nvarchar(255) = ''
,	@Extra14					nvarchar(255) = ''
,	@Extra15					nvarchar(255) = ''
,	@Extra16					nvarchar(255) = ''
,	@Extra17					nvarchar(255) = ''
,	@Extra18					nvarchar(255) = ''
,	@Extra19					nvarchar(255) = ''
,	@Extra20					nvarchar(255) = ''
,	@Extra21					nvarchar(255) = ''
,	@Extra22					nvarchar(255) = ''
,	@Extra23					nvarchar(255) = ''
,	@Extra24					nvarchar(255) = ''
,	@Extra25					nvarchar(255) = ''
,	@Extra26					nvarchar(255) = ''
,	@Extra27					nvarchar(255) = ''
,	@Extra28					nvarchar(255) = ''
,	@Extra29					nvarchar(255) = ''
,	@Extra30					nvarchar(255) = ''
,	@Extra31					nvarchar(255) = ''
,	@Extra32					nvarchar(255) = ''
,	@Extra33					nvarchar(255) = ''
,	@Extra34					nvarchar(255) = ''
,	@Extra35					nvarchar(255) = ''
,	@Extra36					nvarchar(255) = ''
,	@Extra37					nvarchar(255) = ''
,	@Extra38					nvarchar(255) = ''
,	@Extra39					nvarchar(255) = ''
,	@Extra40					nvarchar(255) = ''
,	@Extra41					nvarchar(255) = ''
,	@Extra42					nvarchar(255) = ''
,	@Extra43					nvarchar(255) = ''
,	@Extra44					nvarchar(255) = ''
,	@Extra45					nvarchar(255) = ''
,	@Extra46					nvarchar(255) = ''
,	@Extra47					nvarchar(255) = ''
,	@Extra48					nvarchar(255) = ''
,	@Extra49					nvarchar(255) = ''
,	@DpdSeq					bigint     = -1
,	@Code					bigint				output
,	@Value					varchar(100)		output
,	@Msg					nvarchar(100)		output
)
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED

Declare @Err int
SET @Err = 0

SET @Code = 0
SET @Value = ''
SET @Msg = ''

BEGIN TRY
IF Exists(select [DpdSeq] from [DynamicPageDetail] where [DpdSeq] = @DpdSeq)
	BEGIN
        update [DynamicPageDetail] set 
        [DpmSeq] = @DpmSeq
        ,[LastUpdate] = getdate()
        ,[UpdateMember] = @MemberSeq
        ,[Extra00] = @Extra00
        ,[Extra01] = @Extra01
        ,[Extra02] = @Extra02
        ,[Extra03] = @Extra03
        ,[Extra04] = @Extra04
        ,[Extra05] = @Extra05
        ,[Extra06] = @Extra06
        ,[Extra07] = @Extra07
        ,[Extra08] = @Extra08
        ,[Extra09] = @Extra09
        ,[Extra10] = @Extra10
        ,[Extra11] = @Extra11
        ,[Extra12] = @Extra12
        ,[Extra13] = @Extra13
        ,[Extra14] = @Extra14
        ,[Extra15] = @Extra15
        ,[Extra16] = @Extra16
        ,[Extra17] = @Extra17
        ,[Extra18] = @Extra18
        ,[Extra19] = @Extra19
        ,[Extra20] = @Extra20
        ,[Extra21] = @Extra21
        ,[Extra22] = @Extra22
        ,[Extra23] = @Extra23
        ,[Extra24] = @Extra24
        ,[Extra25] = @Extra25
        ,[Extra26] = @Extra26
        ,[Extra27] = @Extra27
        ,[Extra28] = @Extra28
        ,[Extra29] = @Extra29
        ,[Extra30] = @Extra30
        ,[Extra31] = @Extra31
        ,[Extra32] = @Extra32
        ,[Extra33] = @Extra33
        ,[Extra34] = @Extra34
        ,[Extra35] = @Extra35
        ,[Extra36] = @Extra36
        ,[Extra37] = @Extra37
        ,[Extra38] = @Extra38
        ,[Extra39] = @Extra39
        ,[Extra40] = @Extra40
        ,[Extra41] = @Extra41
        ,[Extra42] = @Extra42
        ,[Extra43] = @Extra43
        ,[Extra44] = @Extra44
        ,[Extra45] = @Extra45
        ,[Extra46] = @Extra46
        ,[Extra47] = @Extra47
        ,[Extra48] = @Extra48
        ,[Extra49] = @Extra49
         where [DpdSeq] = @DpdSeq

        SET @Err = @Err + @@Error

        IF IsNull(@Err,0) = 0
            BEGIN
                SET @Code = @DpdSeq
            END
        ELSE
            BEGIN
                SET @Code = -1
                SET @Msg = '수정하지 못했습니다.'
            END
	END
ELSE
	BEGIN
        insert into [DynamicPageDetail] (
        [DpmSeq]
        ,[RegistDate]
        ,[RegistMember]
        ,[LastUpdate]
        ,[UpdateMember]
        ,[IsEnabled]
        ,[Extra00]
        ,[Extra01]
        ,[Extra02]
        ,[Extra03]
        ,[Extra04]
        ,[Extra05]
        ,[Extra06]
        ,[Extra07]
        ,[Extra08]
        ,[Extra09]
        ,[Extra10]
        ,[Extra11]
        ,[Extra12]
        ,[Extra13]
        ,[Extra14]
        ,[Extra15]
        ,[Extra16]
        ,[Extra17]
        ,[Extra18]
        ,[Extra19]
        ,[Extra20]
        ,[Extra21]
        ,[Extra22]
        ,[Extra23]
        ,[Extra24]
        ,[Extra25]
        ,[Extra26]
        ,[Extra27]
        ,[Extra28]
        ,[Extra29]
        ,[Extra30]
        ,[Extra31]
        ,[Extra32]
        ,[Extra33]
        ,[Extra34]
        ,[Extra35]
        ,[Extra36]
        ,[Extra37]
        ,[Extra38]
        ,[Extra39]
        ,[Extra40]
        ,[Extra41]
        ,[Extra42]
        ,[Extra43]
        ,[Extra44]
        ,[Extra45]
        ,[Extra46]
        ,[Extra47]
        ,[Extra48]
        ,[Extra49]
        ) values (
        @DpmSeq
        ,getdate()
        ,@MemberSeq
        ,getdate()
        ,@MemberSeq
        ,1
        ,@Extra00
        ,@Extra01
        ,@Extra02
        ,@Extra03
        ,@Extra04
        ,@Extra05
        ,@Extra06
        ,@Extra07
        ,@Extra08
        ,@Extra09
        ,@Extra10
        ,@Extra11
        ,@Extra12
        ,@Extra13
        ,@Extra14
        ,@Extra15
        ,@Extra16
        ,@Extra17
        ,@Extra18
        ,@Extra19
        ,@Extra20
        ,@Extra21
        ,@Extra22
        ,@Extra23
        ,@Extra24
        ,@Extra25
        ,@Extra26
        ,@Extra27
        ,@Extra28
        ,@Extra29
        ,@Extra30
        ,@Extra31
        ,@Extra32
        ,@Extra33
        ,@Extra34
        ,@Extra35
        ,@Extra36
        ,@Extra37
        ,@Extra38
        ,@Extra39
        ,@Extra40
        ,@Extra41
        ,@Extra42
        ,@Extra43
        ,@Extra44
        ,@Extra45
        ,@Extra46
        ,@Extra47
        ,@Extra48
        ,@Extra49
        )

        SET @Err = @Err + @@Error

        IF IsNull(@Err,0) = 0
            BEGIN
                SET @Code = @@IDENTITY
            END
        ELSE
            BEGIN
                SET @Code = -1
                SET @Msg = '저장하지 못했습니다.'
            END
	END

END TRY
BEGIN CATCH
    SET @Code = -1
    SET @Err = @Err + 1
    SET @Msg = ERROR_MESSAGE()
END CATCH";
    }
}
