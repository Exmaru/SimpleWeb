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
                result = new Repository(this.ConnectionName, query);
                this.Repositories.AddOrUpdate(query, result, (oldkey, oldvalue) => result);
            }
            else
            {
                result = new Repository(query);
                this.Repositories.AddOrUpdate(query, result, (oldkey, oldvalue) => result);
            }

            return result;

        }


        public void Dispose()
        {
            this.Repositories.Clear();
        }
    }
}