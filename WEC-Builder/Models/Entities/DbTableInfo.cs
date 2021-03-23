using System;
using System.Data;

namespace WEC_Builder
{
    public class DbTableInfo
    {
        public string TableID { get; set; } = string.Empty;
        public string TableName { get; set; } = string.Empty;

        public string ColumnName { get; set; } = string.Empty;
        public int column_id { get; set; } = 0;
        public string ColumnType { get; set; } = string.Empty;
        public int ColumnMaxLength { get; set; } = -1;

        public int max_length { get; set; } = -1;

        public bool is_nullable { get; set; } = false;
        public bool is_identity { get; set; } = false;

        public string Description { get; set; } = string.Empty;

        public string Name
        {
            get
            {
                if (String.IsNullOrWhiteSpace(Description))
                {
                    return this.ColumnName;
                }
                else
                {
                    return this.Description;
                }
            }
        }

        public SqlDbType DbType
        {
            get
            {
                switch (this.ColumnType)
                {
                    case "tinyint":
                        return SqlDbType.TinyInt;
                    case "smallint":
                        return SqlDbType.SmallInt;
                    case "int":
                        return SqlDbType.Int;
                    case "real":
                        return SqlDbType.Real;
                    case "money":
                        return SqlDbType.Money;
                    case "smallmoney":
                        return SqlDbType.SmallMoney;
                    case "decimal":
                    case "numeric":
                        return SqlDbType.Decimal;
                    case "bigint":
                        return SqlDbType.BigInt;
                    case "uniqueidentifier":
                        return SqlDbType.UniqueIdentifier;
                    case "float":
                        return SqlDbType.Float;
                    case "timestamp":
                        return SqlDbType.Timestamp;
                    case "date":
                        return SqlDbType.Date;
                    case "time":
                        return SqlDbType.Time;
                    case "datetimeoffset":
                        return SqlDbType.DateTimeOffset;
                    case "smalldatetime":
                        return SqlDbType.SmallDateTime;
                    case "datetime":
                        return SqlDbType.DateTime;
                    case "datetime2":
                        return SqlDbType.DateTime2;
                    case "text":
                        return SqlDbType.Text;
                    case "ntext":
                        return SqlDbType.NText;
                    case "nvarchar":
                        return SqlDbType.NVarChar;
                    case "nchar":
                        return SqlDbType.NChar;
                    case "char":
                        return SqlDbType.Char;
                    case "bit":
                        return SqlDbType.Bit;
                    case "sql_variant":
                        return SqlDbType.Variant;
                    case "hierarchyid":
                    case "geometry":
                    case "geography":
                    case "varbinary":
                        return SqlDbType.VarBinary;
                    case "binary":
                        return SqlDbType.Binary;
                    case "xml":
                        return SqlDbType.Xml;
                    case "image":
                        return SqlDbType.Image;
                    case "sysname":
                    case "varchar":
                    default:
                        return SqlDbType.VarChar;
                }
            }
        }

        public string ObjectType
        {
            get
            {
                switch (this.ColumnType)
                {
                    case "tinyint":
                    case "smallint":
                    case "int":
                    case "real":
                    case "money":
                    case "decimal":
                    case "numeric":
                    case "smallmoney":
                    case "uniqueidentifier":
                        return "int";
                    case "bigint":
                        return "long";
                    case "float":
                        return "double";
                    case "timestamp":
                    case "date":
                    case "time":
                    case "datetime2":
                    case "datetimeoffset":
                    case "smalldatetime":
                    case "datetime":
                        return "DateTime";
                    case "text":
                    case "ntext":
                    case "nvarchar":
                    case "nchar":
                    case "varchar":
                    case "char":
                        return "string";
                    case "bit":
                        return "bool";
                    case "sql_variant":
                    case "hierarchyid":
                    case "geometry":
                    case "geography":
                    case "varbinary":
                    case "binary":
                    case "xml":
                    case "sysname":
                    case "image":
                    default:
                        return "object";
                }
            }
        }

        public DbTableInfo() : base()
        {
        }
    }
}
