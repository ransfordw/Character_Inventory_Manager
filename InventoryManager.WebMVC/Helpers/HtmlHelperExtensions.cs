using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace InventoryManager.WebMVC.Helpers
{
    public static class HtmlHelperExtensions
    {
        public static string CurrentViewName(this HtmlHelper html)
        {
            return Path.GetFileNameWithoutExtension(((RazorView)html.ViewContext.View).ViewPath);
        }

        public static string ControllerName(this HtmlHelper html)
        {
            return Path.GetFileNameWithoutExtension(html.ViewContext.Controller.GetType().Name);
        }

        //Extension of Enum.GetDisplayName that returns DislplayName Annotations from Data.
         
        //public static string GetDisplayName(this Enum enumType)
        //{
        //    return enumType.GetType().GetMember(enumType.ToString()).First().GetCustomAttribute<DisplayAttribute>().GetName();
        //}

    }
}