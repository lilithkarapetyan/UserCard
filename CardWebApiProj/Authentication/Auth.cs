using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace CardWebApiProj.Authentication
{
    public class Auth : AuthorizationFilterAttribute
    {

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization != null)
            {
                try
                {
                    string authToken = actionContext.Request.Headers.Authorization.Parameter;
                    string authText = Encoding.UTF8.GetString(Convert.FromBase64String(authToken));
                    string[] arr = authText.Split(':');

                    string login = arr[0];
                    string password = arr[1];

                    string correctLogin = ConfigurationManager.AppSettings["Login"] ?? "";
                    string correctPassword = ConfigurationManager.AppSettings["Password"] ?? "";
                    if (login != correctLogin || password != correctPassword)
                    {
                        actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                    }
                }
                catch (Exception e)
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
            }
            else
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }

            base.OnAuthorization(actionContext);
        }
    }
}