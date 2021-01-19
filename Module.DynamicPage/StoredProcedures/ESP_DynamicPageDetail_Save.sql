CREATE PROCEDURE [dbo].[ESP_DynamicPageDetail_Save]
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
END CATCH