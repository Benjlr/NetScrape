using System.Collections.Generic;

namespace NetScrape.Core.ResultsAnalysis
{
    public class ResultFinder : IResultFinder
    {
        private IDesiredResult _desiredString { get; set; }

        public ResultFinder(IDesiredResult _request) {
            _desiredString = _request;
        }

        public List<int> GetResults(List<string> allResults) {
            var returnValue = new List<int>();
            for (int i = 0; i < allResults.Count; i++)
                if (allResults[i].Contains(_desiredString.Result))
                    returnValue.Add(i + 1);
            return returnValue;
        }

    }
}