using System.Collections.Generic;

namespace NetScrape.Core.WebParser
{
    public interface IWebsiteParser
    {
        public List<string> Parse(string fields);
    }

}