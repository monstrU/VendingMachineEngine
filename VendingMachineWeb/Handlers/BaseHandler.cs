using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace VendingMachineWeb.Handlers
{
    public abstract class BaseHandler : IHttpHandler
    {
        public abstract void ProcessRequest(HttpContext context);

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        protected void WriteResult(HttpResponse response, object result)
        {
            response.ContentType = "application/json";
            response.Expires = -1;
            response.ExpiresAbsolute = DateTime.Now.AddDays(-2);
            response.Cache.SetExpires(DateTime.Now.AddDays(-2));

            response.Write(JsonConvert.SerializeObject(result));
               
            response.Flush();
        }
    }
}