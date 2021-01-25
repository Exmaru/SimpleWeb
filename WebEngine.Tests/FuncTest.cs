using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace WebEngine.Tests
{
    [TestClass]
    public class FuncTest
    {
        [TestMethod]
        public void Paging_Test_Case1()
        {
            string pagingHtml = "<ul class=\"pagination\"><li class=\"prev\"><a class=\"btn btn-classic px-0 px-md-3 py-1\" href=\"{PreviousPage}\">이전</a></li><loop><li><a class=\"btn btn-classic px-2 px-md-3 py-1\" href=\"{LinkURL}\">{PageNo}</a></li></loop><li class=\"next\"><a class=\"btn btn-classic px-0 px-md-3 py-1 ml-1\" href=\"{NextPage}\">다음</a></li></ul>";
            PagingParameter paramData = new PagingParameter();
            string CompareResult = "<ul class=\"pagination\"><li class=\"prev\"><a class=\"btn btn-classic px-0 px-md-3 py-1\" href=\"?CurPage=1&\">이전</a></li><li><a class=\"btn btn-classic px-2 px-md-3 py-1\" href=\"?CurPage=1&\">1</a></li><li class=\"next\"><a class=\"btn btn-classic px-0 px-md-3 py-1 ml-1\" href=\"?CurPage=1&\">다음</a></li></ul>";
            string result = pagingHtml.CreatePagingTag(paramData);

            Assert.AreEqual(result, CompareResult);
        }
    }
}
