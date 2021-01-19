CREATE PROCEDURE [dbo].[ESP_DynamicPageMaster_Save]
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
END CATCH