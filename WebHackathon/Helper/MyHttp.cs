using Flurl;
using Flurl.Http;
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
       
        public MyHttp()
        {
   
        }

        public async Task<string> Get(string pathBase, string uri)
        {
            var result = await pathBase
               .AppendPathSegment(uri)
               .GetAsync().ReceiveString();

            var resultfinal = "{\"data\":" + result + "}";
            return resultfinal;
        }

   

      
    }
}