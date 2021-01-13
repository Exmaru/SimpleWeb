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
                return new DbRow(this.Table.Rows[0]);
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

        public virtual string GetString(string name)
        {
            return Convert.ToString(this.Get[name]);
        }

        public virtual int GetInt(string name)
        {
            int result = -1;
            if (int.TryParse(this.GetString(name), out result))
            {
                return result;
            }
            else
            {
                return -1;
            }
        }

        public virtual long GetLong(string name)
        {
            long result = -1;
            if (long.TryParse(this.GetString(name), out result))
            {
                return result;
            }
            else
            {
                return -1;
            }
        }

        public virtual float GetFloat(string name)
        {
            float result = -1;
            if (float.TryParse(this.GetString(name), out result))
            {
                return result;
            }
            else
            {
                return -1;
            }
        }

        public virtual bool GetBoolean(string name)
        {
            bool result = default(bool);
            if (bool.TryParse(this.GetString(name), out result))
            {
                return result;
            }
            else
            {
                return false;
            }
        }

        public virtual DateTime GetDateTime(string name)
        {
            DateTime result = default(DateTime);
            if (DateTime.TryParse(this.GetString(name), out result))
            {
                return result;
            }
            else
            {
                return new DateTime();
            }
        }
    }

    public static class ExtendDbReulst
    {

    }
}