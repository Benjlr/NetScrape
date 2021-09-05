namespace NetScrape.Core.WebParser
{
    public class SmokeBallParserDetails : IParserDetails
    {
        public string RegexQuery { get; set; }
        public string Qualifier { get; set; }

        public SmokeBallParserDetails() {
            RegexQuery = @"(http|ftp|https)?(://)?([\w_-]+(?:(?:\.[\w_-]+)+))([\w.,@?^=%&:/~+#-]*[\w@?^=%&/~+#-])?";
            Qualifier = "<div class=\"kCrYT\"><a href=\"/url?q=";
        }
    }
}