using System.Collections.Generic;

namespace NetScrape.Core.ResultsAnalysis
{
    public interface IResultFinder
    {
        public List<int> GetResults(List<string> allResults);
    }

}