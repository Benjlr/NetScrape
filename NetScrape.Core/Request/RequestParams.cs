using System.Collections.Generic;

namespace NetScrape.Core.Request
{
    public class RequestParams : IRequestDetails
    {
        public string Scheme { get; set; }
        public string Host { get; set; }
        public string Path { get; set; }
        public Dictionary<string, string> Params { get; set; }

    }
}