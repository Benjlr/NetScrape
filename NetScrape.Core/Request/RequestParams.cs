using System.Collections.Generic;

namespace NetScrape.Core.Request
{
    public class RequestParams : IRequestDetails
    {
        public string Scheme { get; }
        public string Host { get; }
        public string Path { get; set; }
        public Dictionary<string, string> Params { get; }

        public RequestParams(string scheme, string host, string path, Dictionary<string, string> myParams) {
            Scheme = scheme;
            Host = host;
            Path = path;
            Params = myParams;
        }
    }
}