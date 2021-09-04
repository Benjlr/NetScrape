using System.Collections.Generic;

namespace NetScrape.Core.ResultsAnalysis
{
    public class ResultFinder : IResultFinder
    {
        private readonly IDesiredResult _desired;

        public ResultFinder(IDesiredResult desired) {
            _desired = desired;
        }

        public List<int> GetResults(List<string> allResults) {
            var returnValue = new List<int>();
            for (int i = 0; i < allResults.Count; i++)
                if (allResults[i].Contains(_desired.Result))
                    returnValue.Add(i + 1);
            return returnValue;
        }

    }
}