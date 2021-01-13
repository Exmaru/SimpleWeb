using System;
using System.Collections.Concurrent;

namespace WebEngine
{
    public class DbHelper : IDisposable
    {

        protected ConcurrentDictionary<string, Repository> Repositories { get; set; } = new ConcurrentDictionary<string, Repository>();
        


        public Repository ExecuteQuery(string query)
        {
            var target = new Repository(query);
            this.Repositories.AddOrUpdate(query, target, (oldkey, oldvalue) => target);
            return target;
        }


        public void Dispose()
        {
            this.Repositories.Clear();
        }
    }
}