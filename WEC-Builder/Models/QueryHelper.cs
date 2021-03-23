using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEC_Builder
{
    public class QueryHelper
    {
        public const string TableViewSelect =
                    @"select 'TABLE' as ObjectType, [object_id],[name] from sys.tables where [name] <> '__RefactorLog'
                            union select 'VIEW',[object_id],[name] from sys.views
                            order by [name] asc";

        public const string SPSelect = "select [name] from sys.procedures order by [name] asc";

        public static string TableInfo(string tableName)
        {
            return
$@"select
	A.TableID
,	A.TableName
,	B.[name] as ColumnName
,	B.column_id
,	C.[name] as ColumnType
,	C.max_length as ColumnMaxLength
,	(case when C.[name] = 'nvarchar' or C.[name] = 'nchar' then (B.max_length/2) else B.max_length end) as max_length
,	B.is_nullable
,	B.is_identity
,	D.[value] as [Description]
from (select [object_id] as TableID,[name] as TableName from sys.tables union select [object_id] as TableID,[name] as TableName from sys.views) as A
inner join sys.all_columns as B on A.TableID = B.[object_id]
inner join sys.types as C on B.[system_type_id] = C.[system_type_id] and B.user_type_id = C.user_type_id
left outer join sys.extended_properties as D on D.major_id = B.[object_id] and D.minor_id = B.column_id and D.[name] = 'MS_Description'
where A.TableName = '{tableName}'";
        }
    }
}
