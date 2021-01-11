using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebEngine
{
    public class Repository : BaseRepository
    {
        public Repository() : base()
        {
            this.Open(SimpleConfig.Global.GetConnection("DBConn"));
        }
    }
}