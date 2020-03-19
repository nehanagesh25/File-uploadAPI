using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace CovertusWebApplication.Controllers
{
    public class BaseAPIController : ApiController
    {
        public static HttpClient APIclient = new HttpClient();
        public BaseAPIController()
        {
            APIclient.BaseAddress = new Uri("http://localhost:51230/");
            APIclient.DefaultRequestHeaders.Accept.Clear();
            APIclient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
