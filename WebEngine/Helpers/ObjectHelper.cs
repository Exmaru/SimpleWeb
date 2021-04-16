using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace WebEngine
{
    public static class ObjectHelper
    {

        public static List<dynamic> ToDynamic(this DataTable dt)
        {
            var dynamicDt = new List<dynamic>();
            foreach (DataRow row in dt.Rows)
            {
                dynamic dyn = new ExpandoObject();
                dynamicDt.Add(dyn);
                foreach (DataColumn column in dt.Columns)
                {
                    var dic = (IDictionary<string, object>)dyn;
                    dic[column.ColumnName] = row[column];
                }
            }

            return dynamicDt;
        }


        public static string GetString(this DataRow row, string name, string defaultValue = "")
        {
            return (row != null) ? Convert.ToString(row[name]) : defaultValue;
        }

        public static int GetInt(this DataRow row, string name, int defaultValue = -1)
        {
            int result = -1;
            if (row != null)
            {
                if (int.TryParse(row.GetString(name), out result))
                {
                    return result;
                }
                else
                {
                    return defaultValue;
                }
            }
            else
            {
                return defaultValue;
            }
        }

        public static long GetLong(this DataRow row, string name, long defaultValue = -1)
        {
            long result = -1;
            if (row != null)
            {
                if (long.TryParse(row.GetString(name), out result))
                {
                    return result;
                }
                else
                {
                    return defaultValue;
                }
            }
            else
            {
                return defaultValue;
            }
        }

        public static float GetFloat(this DataRow row, string name, float defaultValue = 0)
        {
            float result = -1;
            if (row != null)
            {
                if (float.TryParse(row.GetString(name), out result))
                {
                    return result;
                }
                else
                {
                    return defaultValue;
                }
            }
            else
            {
                return defaultValue;
            }
        }

        public static bool GetBoolean(this DataRow row, string name, bool defaultValue = false)
        {
            bool result = default(bool);

            if (row != null)
            {
                if (bool.TryParse(row.GetString(name), out result))
                {
                    return result;
                }
                else
                {
                    return defaultValue;
                }
            }
            else
            {
                return defaultValue;
            }
        }

        public static DateTime GetDateTime(this DataRow row, string name)
        {
            DateTime result = default(DateTime);

            if (row != null)
            {
                if (DateTime.TryParse(row.GetString(name), out result))
                {
                    return result;
                }
                else
                {
                    return new DateTime();
                }
            }
            else
            {
                return new DateTime();
            }
        }

        public static DateTime GetDateTime(this DataRow row, string name, DateTime defaultValue)
        {
            DateTime result = default(DateTime);

            if (row != null)
            {
                if (DateTime.TryParse(row.GetString(name), out result))
                {
                    return result;
                }
                else
                {
                    return defaultValue;
                }
            }
            else
            {
                return defaultValue;
            }
        }

        public static string GetString(this DataRow row, int index, string defaultValue = "")
        {
            return (row != null) ? Convert.ToString(row[index]) : defaultValue;
        }

        public static int GetInt(this DataRow row, int index, int defaultValue = -1)
        {
            int result = -1;
            if (row != null)
            {
                if (int.TryParse(row.GetString(index), out result))
                {
                    return result;
                }
                else
                {
                    return defaultValue;
                }
            }
            else
            {
                return defaultValue;
            }
        }

        public static long GetLong(this DataRow row, int index, long defaultValue = -1)
        {
            long result = -1;
            if (row != null)
            {
                if (long.TryParse(row.GetString(index), out result))
                {
                    return result;
                }
                else
                {
                    return defaultValue;
                }
            }
            else
            {
                return defaultValue;
            }
        }

        public static float GetFloat(this DataRow row, int index, float defaultValue = 0)
        {
            float result = -1;
            if (row != null)
            {
                if (float.TryParse(row.GetString(index), out result))
                {
                    return result;
                }
                else
                {
                    return defaultValue;
                }
            }
            else
            {
                return defaultValue;
            }
        }

        public static bool GetBoolean(this DataRow row, int index, bool defaultValue = false)
        {
            bool result = default(bool);

            if (row != null)
            {
                if (bool.TryParse(row.GetString(index), out result))
                {
                    return result;
                }
                else
                {
                    return defaultValue;
                }
            }
            else
            {
                return defaultValue;
            }
        }

        public static DateTime GetDateTime(this DataRow row, int index)
        {
            DateTime result = default(DateTime);

            if (row != null)
            {
                if (DateTime.TryParse(row.GetString(index), out result))
                {
                    return result;
                }
                else
                {
                    return new DateTime();
                }
            }
            else
            {
                return new DateTime();
            }
        }

        public static DateTime GetDateTime(this DataRow row, int index, DateTime defaultValue)
        {
            DateTime result = default(DateTime);

            if (row != null)
            {
                if (DateTime.TryParse(row.GetString(index), out result))
                {
                    return result;
                }
                else
                {
                    return defaultValue;
                }
            }
            else
            {
                return defaultValue;
            }
        }

    }
}