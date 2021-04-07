using System.Collections.Generic;

namespace WEC_Builder
{
    public class CreateIndexQuery
    {
        public List<string> All { get; set; } = new List<string>();

        public CreateIndexQuery()
        {
            this.All.Add("CREATE UNIQUE NONCLUSTERED INDEX [IX_Members_ID] ON [dbo].[Members]([MemberID] DESC);");
            this.All.Add("CREATE UNIQUE NONCLUSTERED INDEX [IX_ExtraMasters_TableName] ON [dbo].[ExtraMasters]([TableName] ASC);");
            this.All.Add("CREATE UNIQUE NONCLUSTERED INDEX [IX_MemberTokens_Token] ON [dbo].[MemberTokens]([Token] ASC);");
            this.All.Add("CREATE UNIQUE CLUSTERED INDEX [IX_BoardActionLog_Identity] ON [dbo].[BoardActionLog]([BoardSeq] DESC, [Column] DESC, [MemberSeq] DESC);");
        }
    }
}
