using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;

namespace Koffiescanner
{
    class RequestPage
    {
        public async Task<String> GetHTML(string url)
        {
            try
            {
                HttpClientHandler handler = new HttpClientHandler();
                HttpClient client = new HttpClient(handler);
                string responseBody = await client.GetStringAsync(url);

                return responseBody;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}