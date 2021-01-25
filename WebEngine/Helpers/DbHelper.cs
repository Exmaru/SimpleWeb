using System;
using System.Collections.Concurrent;
using System.Data.SqlClient;

namespace WebEngine
{
    public class DbHelper : IDisposable
    {

        protected string ConnectionName { get; set; } = string.Empty;

        protected SqlConnection SqlConn { get; set; }

        public DbHelper() : this("DBConn")
        {
        }

        public DbHelper(string connName)
        {
            this.ConnectionName = connName;
            this.SqlConn = new SqlConnection(Global.Connection(connName));
            this.SqlConn.Open();
        }



        public Repository ExecuteQuery(string query)
        {
            Repository result = null;
            if (!string.IsNullOrWhiteSpace(this.ConnectionName))
            {
                result = new Repository(this.SqlConn, query, System.Data.CommandType.Text);
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
                result = new Repository(this.SqlConn, spName, System.Data.CommandType.StoredProcedure);
            }
            else
            {
                result = new Repository(spName, System.Data.CommandType.StoredProcedure);
            }

            return result;

        }


        public void Dispose()
        {
            if (this.SqlConn != null)
            {
                if (this.SqlConn.State == System.Data.ConnectionState.Open)
                {
                    this.SqlConn.Close();
                }
                this.SqlConn.Dispose();
                this.SqlConn = null;
            }
        }
    }
}