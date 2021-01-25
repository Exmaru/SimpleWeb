using OctopusV3.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.WebPages.Html;

namespace WebEngine
{
    public class PagingParameter
    {
        public string OtherParamaters { get; set; } = string.Empty;

        public int CurPage { get; set; } = 1;

        public int PageSize { get; set; } = 10;  //한 페이지에 몇개의 게시물을 보여줄 것인가

        public string LinkURL { get; set; } = string.Empty;

        public int TotalCount { get; set; } = 0;  //전체 레코드의 갯수

        public int TotalPerPage { get; set; } = 0;  //페이징 내에 표시되는 

        public int PerPageSize { get; set; } = 10;

        public int Seq { get; set; } = 0;

        protected int lastPage { get; set; } = 1;

        public int LastPage
        {
            get
            {
                return this.lastPage;
            }
        }

        public int FirstPage
        {
            get
            {
                if (this.CurPage > 10)
                {
                    return 1;
                }
                else
                {
                    return 1;
                }
            }
        }

        public int PreviousPage
        {
            get
            {
                if (TotalCount > 0)
                {
                    int tmp = this.GetPaging()[0];
                    if (tmp > this.PageSize)
                    {
                        tmp = (Convert.ToInt32(tmp / this.PerPageSize) * this.PerPageSize) + 1;
                        tmp = tmp - this.PerPageSize;
                    }
                    else
                    {
                        tmp = 1;
                    }
                    return tmp;
                }
                else
                {
                    return 1;
                }
            }
        }

        public int NextPage
        {
            get
            {
                if (TotalCount > 0)
                {
                    int tmp = this.GetPaging()[this.GetPaging().Count - 1];
                    if (tmp < this.LastPage)
                    {
                        tmp = (Convert.ToInt32(tmp / this.PerPageSize) * this.PerPageSize) + 1;
                        if (tmp > this.LastPage)
                        {
                            tmp = this.LastPage;
                        }
                    }
                    else
                    {
                        tmp = this.LastPage;
                    }
                    return tmp;
                }
                else
                {
                    return this.LastPage;
                }
            }
        }

        public PagingParameter()
        {
        }

        public PagingParameter(int curPage)
        {
            this.CurPage = curPage;
        }

        public PagingParameter(int curPage, string _otherParameters)
        {
            this.CurPage = curPage;
            this.OtherParamaters = _otherParameters;
        }

        public PagingParameter(string _otherParameters)
        {
            this.OtherParamaters = _otherParameters;
        }

        public PagingParameter(int pageSize, int curPage)
        {
            this.PageSize = pageSize;
            this.CurPage = curPage;
        }

        public PagingParameter(int pageSize, int curPage, string _otherParameters)
        {
            this.PageSize = pageSize;
            this.CurPage = curPage;
            this.OtherParamaters = _otherParameters;
        }

        public virtual string GetLinkURL(int curpage)
        {
            return $"{LinkURL}?CurPage={curpage}&{OtherParamaters}";
        }

        public virtual int Ceiling(int a, int b)
        {
            int result = 0;
            if (a > 0 && b > 0)
            {
                int gab = a % b;
                result = a / b;
                if (gab > 0)
                {
                    result++;
                }
            }
            return result;
        }

        public virtual void SetTotalCount(int totalCnt)
        {
            this.TotalCount = totalCnt;
            if (this.TotalCount > 0)
            {
                if (this.TotalCount > 10)
                {
                    this.TotalPerPage = Ceiling(Ceiling(this.TotalCount, this.PageSize), this.PerPageSize);
                }
                else
                {
                    this.TotalPerPage = 1;
                }

                if (this.CurPage > 1)
                {
                    this.Seq = this.TotalCount - (this.PageSize * (this.CurPage - 1));
                }
                else
                {
                    this.Seq = this.TotalCount;
                }
            }
        }

        public virtual int SequenceDesc
        {
            get
            {
                return this.Seq--;
            }
        }

        public virtual int SequenceAsc
        {
            get
            {
                return this.Seq++;
            }
        }

        public virtual List<int> GetPaging()
        {
            List<int> result = new List<int>();

            if (this.TotalCount > PageSize)
            {
                int st = 1;
                int ed = this.PerPageSize;

                this.lastPage = this.TotalCount / PageSize;
                int tmp = this.TotalCount % PageSize;
                if (tmp > 0)
                {
                    this.lastPage++;
                }

                if (CurPage > PerPageSize)
                {
                    st = Convert.ToInt32(CurPage / this.PerPageSize) * this.PerPageSize + 1;
                    ed = st + (this.PerPageSize - 1);
                }

                for (int i = st; i <= ed; i++)
                {
                    if (i > this.lastPage) break;
                    result.Add(i);
                }
            }

            if (result.Count == 0)
            {
                result.Add(1);
            }

            return result;
        }
    }

    public static class ExtendPagingParameter
    {
        public static HtmlString Paging(this HtmlHelper html, string path, PagingParameter paramData)
        {
            string result = string.Empty;
            if (!string.IsNullOrWhiteSpace(path))
            {
                FileInfo fi = new FileInfo(HttpContext.Current.Server.MapPath(path));
                if (fi.Exists)
                {
                    string tags = File.ReadAllText(fi.FullName, Encoding.UTF8);
                    if (!string.IsNullOrWhiteSpace(tags))
                    {
                        result = tags.CreatePagingTag(paramData);
                    }
                }
                else
                {
                    result = $"Not found file : {path}";
                }
            }
            else
            {
                result = "Not found path";
            }


            return new HtmlString(result);
        }

        public static string CreatePagingTag(this string tags, PagingParameter paramData)
        {
            StringBuilder builder = new StringBuilder(300);

            if (!string.IsNullOrWhiteSpace(tags))
            {
                builder.Append(tags);
                string pos = tags.ToLower();
                if (pos.IndexOf("<loop>") > -1)
                {
                    string loop = tags.Substring(pos.IndexOf("<loop>"), (pos.LastIndexOf("</loop>") + 7) - pos.IndexOf("<loop>")).Trim();
                    builder.Replace(loop, "{loop}");
                    loop = loop.Replace("<loop>", "").Replace("</loop>", "").Trim();
                    StringBuilder inPage = new StringBuilder(200);
                    foreach (int p in paramData.GetPaging())
                    {
                        inPage.AppendLine(loop.Replace("{LinkURL}", paramData.GetLinkURL(p)).Replace("{PageNo}", $"{p}"));
                        if (p == paramData.CurPage)
                        {
                            inPage.Replace("{active}", "active");
                        }
                        else
                        {
                            inPage.Replace("{active}", "");
                        }
                    }
                    builder.Replace("{loop}", inPage.ToString());
                }
                builder.Replace("{PreviousPage}", paramData.GetLinkURL(paramData.PreviousPage));
                builder.Replace("{NextPage}", paramData.GetLinkURL(paramData.NextPage));
            }

            builder.Replace(Environment.NewLine, "");
            builder.Replace("\r\n", "");

            return builder.ToString();
        }
    }
}