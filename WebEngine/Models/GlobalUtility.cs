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