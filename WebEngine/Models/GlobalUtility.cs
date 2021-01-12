using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace WebEngine
{
    public class GlobalUtility
    {
        private JavaScriptSerializer jsonHandler = new JavaScriptSerializer();

        public GlobalUtility()
        {
        }

        public string Serialize(object obj)
        {
            return jsonHandler.Serialize(obj);
        }

    }
}