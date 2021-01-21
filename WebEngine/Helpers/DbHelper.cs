using System;
using System.Collections.Concurrent;

namespace WebEngine
{
    public class DbHelper : IDisposable
    {

        protected ConcurrentDictionary<string, Repository> Repositories { get; set; } = new ConcurrentDictionary<string, Repository>();

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
                this.Repositories.AddOrUpdate(query, result, (oldkey, oldvalue) => result);
            }
            else
            {
                result = new Repository(query, System.Data.CommandType.Text);
                this.Repositories.AddOrUpdate(query, result, (oldkey, oldvalue) => result);
            }

            return result;

        }

        public Repository ExecuteSP(string spName)
        {
            Repository result = null;
            if (!string.IsNullOrWhiteSpace(this.ConnectionName))
            {
                result = new Repository(this.ConnectionName, spName, System.Data.CommandType.StoredProcedure);
                this.Repositories.AddOrUpdate(spName, result, (oldkey, oldvalue) => result);
            }
            else
            {
                result = new Repository(spName, System.Data.CommandType.StoredProcedure);
                this.Repositories.AddOrUpdate(spName, result, (oldkey, oldvalue) => result);
            }

            return result;

        }


        public void Dispose()
        {
            this.Repositories.Clear();
        }
    }
}