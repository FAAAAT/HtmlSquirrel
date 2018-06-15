using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;

namespace HtmlSquirrel
{
    public class Requester : IRequester
    {
        private HttpClient client;

        public Requester(HttpClient client)
        {
            this.client = client;
        }

        public string GetContent(string uriStr)
        {
            var uri = new Uri(uriStr);
            return GetContent(uri);
        }

        public string GetContent(Uri uri)
        {
           return client.GetStringAsync(uri).GetAwaiter().GetResult();
        }

        public async Task<string> GetContentAsync(Uri uri)
        {
            return await client.GetStringAsync(uri);
        }

        


    }
}
