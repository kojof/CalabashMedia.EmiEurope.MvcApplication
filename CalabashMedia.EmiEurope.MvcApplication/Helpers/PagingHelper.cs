using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using CalabashMedia.EmiEurope.MvcApplication.Models;

namespace CalabashMedia.EmiEurope.MvcApplication.Helpers
{
    public static class PagingHelper
    {
       public static MvcHtmlString PageLinks(this HtmlHelper html, PagingInfo pagingInfo, Func<int,string> pageUrl)
       {
           StringBuilder sb = new StringBuilder();
           for (int i = 1; i <= pagingInfo.TotalPages; i++)
           {
               TagBuilder tag = new TagBuilder("a");
               tag.MergeAttribute("href", pageUrl(i));
               tag.InnerHtml = i.ToString();
               if (i == pagingInfo.CurrentPage)
               {
                   tag.AddCssClass("selected");
               }
               sb.Append(tag.ToString());
           }


           return MvcHtmlString.Create(sb.ToString());
       }
    }
}
