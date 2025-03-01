using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Runtime.ConstrainedExecution;

namespace IKBlok
{
    public class Yetki : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if (filterContext.HttpContext.Session.GetInt32("roleid") == 2)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
                return;
            }
            else if (filterContext.HttpContext.Session.GetInt32("roleid") == 1)
            {
                return;
            }
            else if (filterContext.HttpContext.Session.GetInt32("roleid") == 0)
            {
                var routeValues = new RouteValueDictionary
                {
                    { "controller", "Gonderis" },
                    { "action", "Index" }
                };
                var routeValues2 = new RouteValueDictionary
                {
                    { "controller", "Home" },
                    { "action", "Index" }
                };
                var redirectToRoutes = new List<RouteValueDictionary> { routeValues, routeValues2};
                filterContext.Result = new RedirectToRouteResult(redirectToRoutes[0]);
                 for (int i = 0; i < redirectToRoutes.Count; i++)
                 {
                     filterContext.Result = new RedirectToRouteResult(redirectToRoutes[i]);
                 }
                return;
            }
            else if (filterContext.HttpContext.Session.GetInt32("roleid") == null)
            {
                var routeValues = new RouteValueDictionary
                {
                    { "controller", "Home" },
                    { "action", "Index" }
                };
                var redirectToRoutes = new List<RouteValueDictionary> { routeValues};
                filterContext.Result = new RedirectToRouteResult(redirectToRoutes[0]);
                for (int i = 0; i < redirectToRoutes.Count; i++)
                {
                    filterContext.Result = new RedirectToRouteResult(redirectToRoutes[i]);
                }
                return;
            }
        }
    }
}