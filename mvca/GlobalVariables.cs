using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace mvca
{
    public static class GlobalVariables
    {
        public static HttpClient webapiclient = new HttpClient();

        static GlobalVariables()
        {
            webapiclient.BaseAddress = new Uri("http://localhost:55262/api/");
            webapiclient.DefaultRequestHeaders.Clear();
            webapiclient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}