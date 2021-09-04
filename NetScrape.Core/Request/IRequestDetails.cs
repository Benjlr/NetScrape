using System.Collections.Generic;

namespace NetScrape.Core.Request
{
    public interface IRequestDetails
    {
        public string Scheme { get; }
        public string Host { get; }
        public string Path { get; }
        Dictionary<string, string> Params { get; }
    }

}