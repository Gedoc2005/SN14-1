using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using SlumpadeKontakter.Controllers;

namespace SlumpadeKontakter
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();
            Response.Clear();

            HttpException httpException = exception as HttpException;

            if (httpException != null)
            {
                string action = string.Empty;

                switch (httpException.GetHttpCode())
                {
                    case 404:
                        action = "NotFound";
                        break;
                    case 500:
                        action = "Error";
                        break;
                }

                Server.ClearError();
                var routeData = new RouteData();
                routeData.Values["controller"] = "Error";
                routeData.Values["action"] = action;

                if (exception.Message.Contains("controller"))
                {
                    routeData.Values["message"] = "Du har matat in en felaktig URL";
                }
                else
                {
                    routeData.Values["message"] = exception.Message;
                }

                IController x = new ErrorController();
                x.Execute(new RequestContext(new HttpContextWrapper(Context), routeData));
            }
        }
    }
}
