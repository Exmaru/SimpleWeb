using System;
using System.Collections.Generic;
using System.Text;
using System.Web.WebPages.Html;

namespace WebEngine
{
    public class WhereString : IDisposable
    {
        protected List<string> whereList { get; set; }


        public WhereString()
        {
            this.whereList = new List<string>();
        }

        public void Append(string where)
        {
            if (!string.IsNullOrWhiteSpace(where))
            {
                this.whereList.Add(where.Trim());
            }
        }

        public string Result
        {
            get
            {
                if (whereList != null && whereList.Count > 0)
                {
                    int num = 0;
                    StringBuilder builder = new StringBuilder(200);
                    builder.Append(" where ");
                    foreach(string where in this.whereList)
                    {
                        if (num > 0) builder.Append(" and ");
                        builder.Append($"{where}");
                        num++;
                    }
                    return builder.ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        public void Dispose()
        {

        }
    }
}