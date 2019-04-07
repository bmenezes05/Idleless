using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace WebHackathon.Helper
{
    public class MyHttp
    {
        HttpClient _HttpClient;
        public MyHttp(string uri)
        {
            _HttpClient = new HttpClient();
            _HttpClient.BaseAddress = new Uri(uri);
            _HttpClient.DefaultRequestHeaders.Accept.Clear();
            _HttpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }



        public async Task<string> Get(string path)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(path);

            //will throw an exception if not successful
            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
            return content;
        }

   

      
    }
}