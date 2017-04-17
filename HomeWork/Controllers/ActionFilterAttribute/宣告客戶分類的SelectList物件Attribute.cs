using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace HomeWork.Controllers.ActionFilterAttribute
{
    public class 宣告客戶分類的SelectList物件Attribute : System.Web.Mvc.ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var items = new List<SelectListItem>();
            items.Add(new SelectListItem() { Text = "客戶", Value = "客戶" });
            items.Add(new SelectListItem() { Text = "廠商", Value = "廠商" });
            filterContext.Controller.ViewBag.客戶分類 = new SelectList(items, "Value","Text");

            base.OnActionExecuting(filterContext);
        }
    }
}