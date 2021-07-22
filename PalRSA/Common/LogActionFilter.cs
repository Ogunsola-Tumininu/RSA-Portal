using JetBrains.Annotations;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Recapture.Common
{
    public class LogActionFilter : IActionFilter // TODO: do we need to log IResultFilter, IExceptionFilter ?
    {
        private readonly ILogger _logger;

        public LogActionFilter([NotNull] ILogger logger)
        {
            if (logger == null) throw new ArgumentNullException("logger");
            _logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var httpContext = filterContext.HttpContext;
            var routeData = filterContext.RouteData;
            var isChildAction = filterContext.IsChildAction;
            const string message = "Before action";

            LogAction(httpContext, routeData, isChildAction, message);
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var httpContext = filterContext.HttpContext;
            var routeData = filterContext.RouteData;
            var isChildAction = filterContext.IsChildAction;
            var message = "After action";
            if (filterContext.Exception != null)
            {
                message += string.Format(" Exception: {0}", filterContext.Exception);
            }

            LogAction(httpContext, routeData, isChildAction, message);
        }

        private void LogAction(HttpContextBase httpContext, RouteData routeData, bool isChildAction, string message)
        {
            var url = httpContext.Request.RawUrl;
            var controllerName = routeData.Values["controller"];
            var actionName = routeData.Values["action"];
            var user = httpContext.User.Identity.Name;
            var isAjax = httpContext.Request.IsAjaxRequest();
            var sessionId = httpContext.Session == null
                ? null
                : httpContext.Session.SessionID;

            _logger.Debug("Session: {0} User: {1} Url: {2} Ajax: {3} Child: {4} Ctrl: {5} Action: {6} Msg: {7}",
                sessionId, user, url, isAjax, isChildAction, controllerName, actionName, message);
        }
    }
}