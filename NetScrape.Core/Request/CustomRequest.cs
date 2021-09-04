using System;
using System.Collections.Specialized;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace NetScrape.Core.Request
{
    public class CustomRequest : ICustomRequest
    {
        private readonly IRequestDetails _params;

        public CustomRequest(IRequestDetails myParams) {
            _params = myParams;
        }

        public async Task<string> LoadPage() {
            using var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(BuildUrl());
            var contents = await response.Content.ReadAsStringAsync();
            return contents;
        }


        private string BuildUrl() {
            return new UriBuilder()
            {
                Scheme = _params.Scheme,
                Host = _params.Host,
                Path = _params.Path,
                Query = constructNameValueCollection()?.ToString() ?? ""
            }.ToString();
        }

        private NameValueCollection constructNameValueCollection() {
            var collection = HttpUtility.ParseQueryString("");
            foreach (var pair in _params.Params)
                collection[pair.Key] = pair.Value;
            return collection;
        }
    }

}