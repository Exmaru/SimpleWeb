CREATE PROCEDURE [dbo].[ESP_Members_Regist]
(
    @MemberID VARCHAR(255)
    ,@Password NVARCHAR(512)
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
        MemberID,[Password],MemberType,SubMemberType,IDType,Email,RegistDate,LastUpdate,LastLogin,MemberStatus,IsCrypto,IsEnabled
        ,ExtraColumn01,ExtraColumn02,ExtraColumn03,ExtraColumn04,ExtraColumn05
        ,ExtraColumn06,ExtraColumn07,ExtraColumn08,ExtraColumn09,ExtraColumn10
        ,ExtraColumn11,ExtraColumn12,ExtraColumn13,ExtraColumn14,ExtraColumn15
        ,ExtraColumn16,ExtraColumn17,ExtraColumn18,ExtraColumn19,ExtraColumn20
        ,ExtraColumn21,ExtraColumn22,ExtraColumn23,ExtraColumn24,ExtraColumn25
        ,ExtraColumn26,ExtraColumn27,ExtraColumn28,ExtraColumn29,ExtraColumn30
        ) values (
        @MemberID,@Password,@MemberType,@SubMemberType,@IDType,@Email,getdate(),getdate(),getdate(),@MemberStatus,@IsCrypto,1
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