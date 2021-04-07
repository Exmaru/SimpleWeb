using System.Collections.Generic;

namespace WEC_Builder
{
    public class InitQuery
    {
		public List<string> All { get; set; } = new List<string>();

		public InitQuery()
        {
			this.All.Add(BaseSetting);
			this.All.Add(BoardMasterSetting);
		}

		public string BaseSetting =
	@"
Declare @Err int
SET @Err = 0

BEGIN TRAN
BEGIN TRY
	IF NOT Exists(Select EmSeq From ExtraMasters where TableName = 'Members')
		BEGIN
			Insert into ExtraMasters (TableName,IsEnabled,ExtraColumn01,ExtraColumn02,ExtraColumn03,ExtraColumn04,ExtraColumn05,ExtraColumn06) 
			values ('Members',1,'별명','성별','생년월일','주소지','상세주소','가입경로')

			SET @Err = @Err + @@Error
		END

	IF NOT Exists(Select CategorySeq From Categories where Key1 = 'SiteConfig' and Key2 = 'Members' and Key3 = 'MemberType')
		BEGIN
			Insert into Categories (Key1,Key2,Key3,Value1) Values ('SiteConfig','Members','MemberType','개인')
			SET @Err = @Err + @@Error
		END

	IF NOT Exists(Select CategorySeq From Categories where Key1 = 'SiteConfig' and Key2 = 'Members' and Key3 = 'IDType')
		BEGIN
			Insert into Categories (Key1,Key2,Key3,Value1) Values ('SiteConfig','Members','IDType','Email')
			SET @Err = @Err + @@Error
		END

	IF NOT Exists(Select CategorySeq From Categories where Key1 = 'SiteCategory' and Key2 = 'Members' and Key3 = 'MemberType')
		BEGIN
			Insert into Categories (Key1,Key2,Key3,Value1) Values ('SiteCategory','Members','MemberType','개인')
			SET @Err = @Err + @@Error

			Insert into Categories (Key1,Key2,Key3,Value1) Values ('SiteCategory','Members','MemberType','기업')
			SET @Err = @Err + @@Error
		END

	IF NOT Exists(Select CategorySeq From Categories where Key1 = 'SiteCategory' and Key2 = 'Members' and Key3 = 'IDType')
		BEGIN
			Insert into Categories (Key1,Key2,Key3,Value1) Values ('SiteCategory','Members','IDType','ID')
			SET @Err = @Err + @@Error

			Insert into Categories (Key1,Key2,Key3,Value1) Values ('SiteCategory','Members','IDType','Email')
			SET @Err = @Err + @@Error
		END

	IF NOT Exists(Select CategorySeq From Categories where Key1 = 'SiteCategory' and Key2 = 'Members' and Key3 = 'SubMemberType')
		BEGIN
			Insert into Categories (Key1,Key2,Key3,Value1,Value2) Values ('SiteCategory','Members','SubMemberType','개인','내국인')
			SET @Err = @Err + @@Error

			Insert into Categories (Key1,Key2,Key3,Value1,Value2) Values ('SiteCategory','Members','SubMemberType','개인','외국인')
			SET @Err = @Err + @@Error

			Insert into Categories (Key1,Key2,Key3,Value1,Value2) Values ('SiteCategory','Members','SubMemberType','개인','기타')
			SET @Err = @Err + @@Error

			Insert into Categories (Key1,Key2,Key3,Value1,Value2) Values ('SiteCategory','Members','SubMemberType','기업','법인사업자')
			SET @Err = @Err + @@Error

			Insert into Categories (Key1,Key2,Key3,Value1,Value2) Values ('SiteCategory','Members','SubMemberType','기업','개인사업자')
			SET @Err = @Err + @@Error

			Insert into Categories (Key1,Key2,Key3,Value1,Value2) Values ('SiteCategory','Members','SubMemberType','기업','기타')
			SET @Err = @Err + @@Error
		END

	
	IF NOT Exists(Select CategorySeq From Categories where Key1 = 'SiteCategory' and Key2 = 'Members' and Key3 = 'MemberStatus')
		BEGIN
			Insert into Categories (Key1,Key2,Key3,Value1) Values ('SiteCategory','Members','MemberStatus','정상')
			SET @Err = @Err + @@Error

			Insert into Categories (Key1,Key2,Key3,Value1) Values ('SiteCategory','Members','MemberStatus','중지')
			SET @Err = @Err + @@Error

			Insert into Categories (Key1,Key2,Key3,Value1) Values ('SiteCategory','Members','MemberStatus','인증전')
			SET @Err = @Err + @@Error

			Insert into Categories (Key1,Key2,Key3,Value1) Values ('SiteCategory','Members','MemberStatus','탈퇴')
			SET @Err = @Err + @@Error
		END
END TRY
BEGIN CATCH
	Print ERROR_MESSAGE()
	SET @Err = @Err + 1
END CATCH

IF @Err > 0
	BEGIN
		ROLLBACK TRAN
		Print ('Complete')
	END
ELSE
	BEGIN
		COMMIT TRAN
		Print ('Error')
	END
";

		public string BoardMasterSetting =
@"if not exists(Select BmSeq From BoardMasters where BmCode = 'Notice')
	begin
insert into BoardMasters (Title,SubTitle,[Description],BmCode,IsPrivate,IsSecret,IsOnlyAdmin,IsComment,IsReply,IsShow,IsFileUpload,IsAnswer,IsRequiredLogin,IsEnabled) 
values ('공지사항','','','Notice',0,0,1,0,0,1,0,0,1,1)
	end";

	}
}
