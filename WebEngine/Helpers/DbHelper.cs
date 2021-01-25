using System;
using System.Collections.Concurrent;

namespace WebEngine
{
    public class DbHelper : IDisposable
    {

        protected string ConnectionName { get; set; } = string.Empty;

        public DbHelper() : this("DBConn")
        {
        }

        public DbHelper(string connName)
        {
            this.ConnectionName = connName;
        }



        public Repository ExecuteQuery(string query)
        {
            Repository result = null;
            if (!string.IsNullOrWhiteSpace(this.ConnectionName))
            {
                result = new Repository(this.ConnectionName, query, System.Data.CommandType.Text);
            }
            else
            {
                result = new Repository(query, System.Data.CommandType.Text);
            }

            return result;

        }

        public Repository ExecuteSP(string spName)
        {
            Repository result = null;
            if (!string.IsNullOrWhiteSpace(this.ConnectionName))
            {
                result = new Repository(this.ConnectionName, spName, System.Data.CommandType.StoredProcedure);
            }
            else
            {
                result = new Repository(spName, System.Data.CommandType.StoredProcedure);
            }

            return result;

        }


        public void Dispose()
        {
        }
    }
}