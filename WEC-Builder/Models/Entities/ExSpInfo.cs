using System;
using System.Data;
using OctopusV3.Data;

namespace WEC_Builder
{
    public class ExSpInfo : SPInfo
    {
        public ExSpInfo() : base()
        {

        }

        public string ColumnName
        {
            get
            {
                return this.name.Replace("@", "".Trim());
            }
        }

        public string ObjectType
        {
            get
            {
                switch (this.SqlType)
                {
                    case SqlDbType.TinyInt:
                    case SqlDbType.SmallInt:
                    case SqlDbType.Int:
                    case SqlDbType.Real:
                    case SqlDbType.Money:
                    case SqlDbType.Decimal:
                    case SqlDbType.SmallMoney:
                    case SqlDbType.UniqueIdentifier:
                        return "int";
                    case SqlDbType.BigInt:
                        return "long";
                    case SqlDbType.Float:
                        return "double";
                    case SqlDbType.Timestamp:
                    case SqlDbType.Date:
                    case SqlDbType.Time:
                    case SqlDbType.DateTime2:
                    case SqlDbType.DateTimeOffset:
                    case SqlDbType.SmallDateTime:
                    case SqlDbType.DateTime:
                        return "DateTime";
                    case SqlDbType.Text:
                    case SqlDbType.NText:
                    case SqlDbType.NVarChar:
                    case SqlDbType.NChar:
                    case SqlDbType.VarChar:
                    case SqlDbType.Char:
                        return "string";
                    case SqlDbType.Bit:
                        return "bool";
                    case SqlDbType.Variant:
                    case SqlDbType.VarBinary:
                    case SqlDbType.Binary:
                    case SqlDbType.Xml:
                    case SqlDbType.Image:
                    default:
                        return "object";
                }
            }
        }

        public string RequestMethod
        {
            get
            {
                switch (this.SqlType)
                {
                    case SqlDbType.TinyInt:
                    case SqlDbType.SmallInt:
                    case SqlDbType.Int:
                    case SqlDbType.Real:
                    case SqlDbType.Money:
                    case SqlDbType.Decimal:
                    case SqlDbType.SmallMoney:
                    case SqlDbType.UniqueIdentifier:
                        return "GetInt";
                    case SqlDbType.BigInt:
                        return "GetLong";
                    case SqlDbType.Float:
                        return "GetFloat ";
                    case SqlDbType.Timestamp:
                    case SqlDbType.Date:
                    case SqlDbType.Time:
                    case SqlDbType.DateTime2:
                    case SqlDbType.DateTimeOffset:
                    case SqlDbType.SmallDateTime:
                    case SqlDbType.DateTime:
                        return "GetDateTime";
                    case SqlDbType.Text:
                    case SqlDbType.NText:
                    case SqlDbType.NVarChar:
                    case SqlDbType.NChar:
                    case SqlDbType.VarChar:
                    case SqlDbType.Char:
                        return "GetString";
                    case SqlDbType.Bit:
                        return "GetBoolean";
                    case SqlDbType.Variant:
                    case SqlDbType.VarBinary:
                    case SqlDbType.Binary:
                    case SqlDbType.Xml:
                    case SqlDbType.Image:
                    default:
                        return "GetObject";
                }
            }
        }
    }
}
