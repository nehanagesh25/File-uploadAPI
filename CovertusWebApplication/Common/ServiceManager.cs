using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Net.Http;
using System.Text;

namespace CovertusWebApplication.Common
{
    public class ServiceManager
    {
        public static HttpClient APIclient;
        public string getServResponse(string url)
        {
            //  string response = null;
            if (APIclient == null)
            {
                APIclient = new HttpClient();
                APIclient.BaseAddress = new Uri(ConfigurationManager.AppSettings["CovertServiceURL"]);
            }

            // string queryString = "login/authenticate/" + username + "/" + password;
            HttpResponseMessage servResponse = APIclient.GetAsync(url).Result;

            return servResponse.Content.ReadAsStringAsync().Result;

        }

        public HttpResponseMessage getByParam_ServResponse(string url)
        {
            if (APIclient == null)
            {
                APIclient = new HttpClient();
                APIclient.BaseAddress = new Uri(ConfigurationManager.AppSettings["CovertServiceURL"]);
            }

            // string queryString = "login/authenticate/" + username + "/" + password;
            HttpResponseMessage response = APIclient.GetAsync(url).Result;

            return response;
        }

        public HttpResponseMessage postRequest(string url, object body)
        {
            if (APIclient == null)
            {
                APIclient = new HttpClient();
                APIclient.BaseAddress = new Uri(ConfigurationManager.AppSettings["CovertServiceURL"]);
            }
            HttpContent contentPost = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");

            // string queryString = "login/authenticate/" + username + "/" + password;
            var response = APIclient.PostAsync(url, contentPost);

            return response.Result;

        }
        public string post_Request(string url, object body)
        {
            if (APIclient == null)
            {
                APIclient = new HttpClient();
                APIclient.BaseAddress = new Uri(ConfigurationManager.AppSettings["CovertServiceURL"]);
            }
            HttpContent contentPost = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");

            // string queryString = "login/authenticate/" + username + "/" + password;
            var response = APIclient.PostAsync(url, contentPost);

            return response.Result.Content.ReadAsStringAsync().Result;

        }

        public HttpResponseMessage DeleteRequest(string url)
        {
            if (APIclient == null)
            {
                APIclient = new HttpClient();
                APIclient.BaseAddress = new Uri(ConfigurationManager.AppSettings["CovertServiceURL"]);
            }
            //  HttpContent contentPost = new StringContent(JsonConvert.SerializeObject(id), Encoding.UTF8, "application/json");

            // string queryString = "login/authenticate/" + username + "/" + password;
            var response = APIclient.DeleteAsync(url);

            return response.Result;

        }
        public HttpResponseMessage UpdateRequest(string url, object body)
        {
            if (APIclient == null)
            {
                APIclient = new HttpClient();
                APIclient.BaseAddress = new Uri(ConfigurationManager.AppSettings["CovertServiceURL"]);
            }
            HttpContent contentUpdate = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");

            // string queryString = "login/authenticate/" + username + "/" + password;
            var response = APIclient.PutAsync(url, contentUpdate);

            return response.Result;
        }
        
    } 
    
}
