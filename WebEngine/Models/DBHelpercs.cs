using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebEngine
{
    public class DBHelpercs : IDisposable
    {
        private static readonly Lazy<DBHelpercs> lazy = new Lazy<DBHelpercs>(() => new DBHelpercs());
        public static DBHelpercs Query { get { return lazy.Value; } }

        private bool disposedValue = false;

        protected Repository DB { get; set; }

        public DBHelpercs()
        {
            this.DB = new Repository();
            this.DB.Open(SimpleConfig.Global.GetConnection("DBConn"));
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (this.DB != null)
                    {
                        this.DB.Close();
                        this.DB.Dispose();
                    }
                    this.DB = null;
                }
            }
        }

        ~DBHelpercs()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}