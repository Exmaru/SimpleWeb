using System.Collections.Generic;

namespace WEC_Builder
{
    public class CreateViewQuery
    {
        public List<string> All { get; set; } = new List<string>();

        public CreateViewQuery()
        {
            this.All.Add(V_Boards);
        }

        public string V_Boards =
@"CREATE VIEW [dbo].[V_Boards]
AS
Select
A.*,B.MemberID,B.Email,B.ViewName
,B.ExtraColumn01 as MemberColumn01
,B.ExtraColumn02 as MemberColumn02
,B.ExtraColumn03 as MemberColumn03
,B.ExtraColumn04 as MemberColumn04
,B.ExtraColumn05 as MemberColumn05
,B.ExtraColumn06 as MemberColumn06
,B.ExtraColumn07 as MemberColumn07
,B.ExtraColumn08 as MemberColumn08
,B.ExtraColumn09 as MemberColumn09
,B.ExtraColumn10 as MemberColumn10
,B.ExtraColumn11 as MemberColumn11
,B.ExtraColumn12 as MemberColumn12
,B.ExtraColumn13 as MemberColumn13
,B.ExtraColumn14 as MemberColumn14
,B.ExtraColumn15 as MemberColumn15
,B.ExtraColumn16 as MemberColumn16
,B.ExtraColumn17 as MemberColumn17
,B.ExtraColumn18 as MemberColumn18
,B.ExtraColumn19 as MemberColumn19
,B.ExtraColumn20 as MemberColumn20
,B.ExtraColumn21 as MemberColumn21
,B.ExtraColumn22 as MemberColumn22
,B.ExtraColumn23 as MemberColumn23
,B.ExtraColumn24 as MemberColumn24
,B.ExtraColumn25 as MemberColumn25
,B.ExtraColumn26 as MemberColumn26
,B.ExtraColumn27 as MemberColumn27
,B.ExtraColumn28 as MemberColumn28
,B.ExtraColumn29 as MemberColumn29
,B.ExtraColumn30 as MemberColumn30
From [Boards] as A
left outer join [Members] as B on A.MemberSeq = B.MemberSeq";
    }
}
