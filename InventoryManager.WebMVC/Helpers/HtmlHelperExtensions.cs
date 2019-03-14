using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManager.WebMVC.Helpers
{
    public static class HtmlHelperExtensions
    {
        public static string CurrentViewName( this HtmlHelper html)
        {
            return Path.GetFileNameWithoutExtension(((RazorView)html.ViewContext.View).ViewPath);
        }

        public static string ControllerName(this HtmlHelper html)
        {
            return Path.GetFileNameWithoutExtension(html.ViewContext.Controller.GetType().Name);
        }
    }
}