using System.Collections.Generic;

namespace WEC_Builder
{
    public class AlterTableQuery
    {
        public List<string> All { get; set; } = new List<string>();
        public AlterTableQuery()
        {
            this.All.AddRange(Categories);
            this.All.AddRange(Members);
            this.All.AddRange(ExtraMasters);
            this.All.AddRange(MemberTokens);
            this.All.AddRange(BoardActionLog);
            this.All.AddRange(BoardMasters);
            this.All.AddRange(Boards);
            this.All.AddRange(DynamicPageMaster);
            this.All.AddRange(DynamicPageDetail);
        }

        public string[] Categories = { "ALTER TABLE [dbo].[Categories] ADD DEFAULT 1 FOR[IsEnabled];" };

        public static string[] Members = {
            "ALTER TABLE [dbo].[Members] ADD DEFAULT getdate() FOR[RegistDate];",
            "ALTER TABLE [dbo].[Members] ADD DEFAULT getdate() FOR[LastUpdate];",
            "ALTER TABLE [dbo].[Members] ADD DEFAULT getdate() FOR[LastLogin];",
            "ALTER TABLE [dbo].[Members] ADD DEFAULT 0 FOR[IsCrypto];",
            "ALTER TABLE [dbo].[Members] ADD DEFAULT 1 FOR[IsEnabled];"
        };

        public string[] ExtraMasters = { "ALTER TABLE [dbo].[ExtraMasters] ADD DEFAULT 1 FOR[IsEnabled];" };

        public string[] MemberTokens = { "ALTER TABLE [dbo].[MemberTokens] ADD DEFAULT 1 FOR[IsEnabled];" };

        public string[] BoardActionLog = { "ALTER TABLE [dbo].[BoardActionLog] ADD DEFAULT getdate() FOR[RegistDate];" };

        public string[] BoardMasters = {
            "ALTER TABLE [dbo].[BoardMasters] ADD DEFAULT 0 FOR[IsPrivate];",
            "ALTER TABLE [dbo].[BoardMasters] ADD DEFAULT 0 FOR[IsSecret];",
            "ALTER TABLE [dbo].[BoardMasters] ADD DEFAULT 0 FOR[IsOnlyAdmin];",
            "ALTER TABLE [dbo].[BoardMasters] ADD DEFAULT 0 FOR[IsComment];",
            "ALTER TABLE [dbo].[BoardMasters] ADD DEFAULT 0 FOR[IsReply];",
            "ALTER TABLE [dbo].[BoardMasters] ADD DEFAULT 0 FOR[IsShow];",
            "ALTER TABLE [dbo].[BoardMasters] ADD DEFAULT 0 FOR[IsFileUpload];",
            "ALTER TABLE [dbo].[BoardMasters] ADD DEFAULT 0 FOR[IsAnswer];",
            "ALTER TABLE [dbo].[BoardMasters] ADD DEFAULT 1 FOR[IsRequiredLogin];",
            "ALTER TABLE [dbo].[BoardMasters] ADD DEFAULT 1 FOR[IsEnabled];"
        };

        public string[] Boards = {
            "ALTER TABLE [dbo].[Boards] ADD DEFAULT getdate() FOR[AnswerDate];",
            "ALTER TABLE[dbo].[Boards] ADD DEFAULT 0 FOR[ReadCount];",
            "ALTER TABLE[dbo].[Boards] ADD DEFAULT 0 FOR[Depth];",
            "ALTER TABLE[dbo].[Boards] ADD DEFAULT -1 FOR[ParentBoardSeq];",
            "ALTER TABLE[dbo].[Boards] ADD DEFAULT getdate() FOR[RegistDate];",
            "ALTER TABLE[dbo].[Boards] ADD DEFAULT getdate() FOR[LastUpdate];",
            "ALTER TABLE[dbo].[Boards] ADD DEFAULT 0 FOR[RecommendCount];",
            "ALTER TABLE[dbo].[Boards] ADD DEFAULT 0 FOR[LikeCount];",
            "ALTER TABLE[dbo].[Boards] ADD DEFAULT 0 FOR[UnLikeCount];",
            "ALTER TABLE[dbo].[Boards] ADD DEFAULT 0 FOR[ShareCount];",
            "ALTER TABLE[dbo].[Boards] ADD DEFAULT 1 FOR[IsEnabled];"
        };

        public string[] DynamicPageMaster =
        {
            "ALTER TABLE [dbo].[DynamicPageMaster] ADD DEFAULT (getdate()) FOR [RegistDate];",
            "ALTER TABLE [dbo].[DynamicPageMaster] ADD DEFAULT (getdate()) FOR [LastUpdate];",
            "ALTER TABLE [dbo].[DynamicPageMaster] ADD DEFAULT ((1)) FOR [IsEnabled];"
        };

        public string[] DynamicPageDetail =
        {
            "ALTER TABLE [dbo].[DynamicPageDetail] ADD DEFAULT (getdate()) FOR [RegistDate];",
            "ALTER TABLE [dbo].[DynamicPageDetail] ADD DEFAULT (getdate()) FOR [LastUpdate];",
            "ALTER TABLE [dbo].[DynamicPageDetail] ADD DEFAULT ((1)) FOR [IsEnabled];"
        };
    }
}
