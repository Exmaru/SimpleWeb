using System;
using System.Collections.Generic;
using System.Data;

namespace WebEngine
{
    public class DbResult
    {
        protected DataTable Table { get; set; }

        public List<DbRow> List { get; set; } = new List<DbRow>();
        
        public DbResult()
        {

        }

        public bool IsCheck
        {
            get
            {
                if (this.List != null || this.List.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public DataTable Data
        {
            get
            {
                return this.Table;
            }
            set
            {
                this.Table = value;
                if (this.Table != null)
                {
                    foreach(DataRow item in this.Table.Rows)
                    {
                        this.List.Add(new DbRow(item));
                    }
                }
            }
        }

        public DataRowCollection Rows
        {
            get
            {
                return this.Table.Rows;
            }
        }

        public DbRow First
        {
            get
            {
                try
                {
                    if (this.Table != null && this.Table.Rows != null && this.Table.Rows.Count > 0)
                    {
                        return new DbRow(this.Table.Rows[0]);
                    }
                    else
                    {
                        return null;
                    }
                }
                catch
                {
                    return null;
                }
            }
        }

        public DbRow Find(int index)
        {
            return new DbRow(this.Table.Rows[index]);
        }

        public DbRow Find(string name, long seq)
        {
            DbRow result = null;
            foreach(DataRow row in this.Table.Rows)
            {
                if (Convert.ToInt64(row[name]) == seq)
                {
                    result = new DbRow(row);
                    break;
                }
            }
            return result;
        }

    }

    public class DbRow
    {
        protected DataRow row { get; set; }

        public DbRow()
        {
        }

        public bool IsCheck
        {
            get
            {
                if (this.row != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public DbRow(DataRow _row)
        {
            this.row = _row;
        }

        public DataRow Get
        {
            get
            {
                return this.row;
            }
        }

        public DataRow Set
        {
            set
            {
                this.row = value;
            }
        }

        public virtual string GetString(string name, string defaultValue = "")
        {
            return (IsCheck) ? Convert.ToString(this.Get[name]) : defaultValue;
        }

        public virtual int GetInt(string name, int defaultValue = -1)
        {
            int result = -1;
            if (IsCheck)
            {
                if (int.TryParse(this.GetString(name), out result))
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

        public virtual long GetLong(string name, long defaultValue = -1)
        {
            long result = -1;
            if (IsCheck)
            {
                if (long.TryParse(this.GetString(name), out result))
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

        public virtual float GetFloat(string name, float defaultValue = 0)
        {
            float result = -1;
            if (IsCheck)
            {
                if (float.TryParse(this.GetString(name), out result))
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

        public virtual bool GetBoolean(string name, bool defaultValue = false)
        {
            bool result = default(bool);

            if (IsCheck)
            {
                if (bool.TryParse(this.GetString(name), out result))
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

        public virtual DateTime GetDateTime(string name)
        {
            DateTime result = default(DateTime);

            if (IsCheck)
            {
                if (DateTime.TryParse(this.GetString(name), out result))
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

        public virtual DateTime GetDateTime(string name, DateTime defaultValue)
        {
            DateTime result = default(DateTime);

            if (IsCheck)
            {
                if (DateTime.TryParse(this.GetString(name), out result))
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

    public static class ExtendDbReulst
    {

    }
}