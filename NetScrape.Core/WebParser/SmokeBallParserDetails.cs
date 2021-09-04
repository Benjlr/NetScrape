namespace NetScrape.Core.WebParser
{
    public class SmokeBallParserDetails : IParserDetails
    {
        public string RegexQuery { get; set; }
        public string Qualifier { get; set; }

        public SmokeBallParserDetails(string regexExpression, string qualifier) {
            RegexQuery = regexExpression;
            Qualifier = qualifier;
        }
    }

}