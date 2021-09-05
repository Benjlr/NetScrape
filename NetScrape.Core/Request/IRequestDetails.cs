using System.Collections.Generic;

namespace NetScrape.Core.Request
{
    public interface IRequestDetails
    {
        public string Scheme { get; set; }
        public string Host { get; set; }
        public string Path { get; set; }
        Dictionary<string, string> Params { get; set; }
    }

}