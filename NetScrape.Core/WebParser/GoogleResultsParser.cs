using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace NetScrape.Core.WebParser
{
    public class GoogleResultsParser : IWebsiteParser
    {
        private readonly IParserDetails _details;

        public GoogleResultsParser(IParserDetails details) {
            _details = details;
        }

        public List<string> Parse(string fields) {
            if (string.IsNullOrWhiteSpace(fields))
                return new List<string>();

            var returnValue = new List<string>();
            foreach (var t in new Regex(_details.RegexQuery).Matches(fields).ToList())
                if (fields
                    .Substring(t.Index - _details.Qualifier.Length, _details.Qualifier.Length + 1)
                    .Contains(_details.Qualifier))
                    returnValue.Add(t.Value);

            return returnValue;
        }
    }

}