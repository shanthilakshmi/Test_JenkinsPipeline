using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1
{
    // every method must be static
    public static class CustomHelper
    {
        public static IHtmlString Img(string src, string alt)
        {
            return new MvcHtmlString(string.Format("<img src='{0}' alt='{1}'></img>", src, alt));
        }
        public static IHtmlString bold(this HtmlHelper helper, string str)
        {
            return new MvcHtmlString(string.Format("<b>{0}</b>", str));
        }
        public static IHtmlString LinkTag(this HtmlHelper helper, string href, string name)
        {
            TagBuilder t = new TagBuilder("a");
            t.MergeAttribute("href", href);
            t.InnerHtml = name;
            return new MvcHtmlString(t.ToString());
        }
    }
}