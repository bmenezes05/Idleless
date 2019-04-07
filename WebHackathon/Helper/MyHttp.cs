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
        string _PathBase = string.Empty;
        public MyHttp(string pathBase)
        {
            _PathBase = pathBase;
        }

        public async Task<string> Get(string uri)
        {
            var result = await _PathBase
               .AppendPathSegment(uri)
               .GetAsync().ReceiveString();

            var resultfinal = "{\"data\":" + result + "}";
            return resultfinal;
        }

        public async Task<string> Post(string uri, object obj)
        {
            var result = await _PathBase
               .AppendPathSegment(uri)
               .PostJsonAsync(obj).ReceiveString();

            return result;
        }
    }
}