namespace NetScrape.Core.ResultsAnalysis
{
    public struct DesiredResult : IDesiredResult
    {
        public string Result { get; }

        public DesiredResult(string result) {
            Result = result;
        }
    }
}