using NetScrape.Core.Request;
using NetScrape.Core.ResultsAnalysis;
using NetScrape.Core.WebParser;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace NetScrape.Core.Tests
{
    public class WebPageTests
    {


        [Fact]
        public async Task ShouldLoadWebPage() {
            var result = new CustomRequest(new RequestParams("https", "www.google.com", "search", new Dictionary<string, string>()));
            Assert.True(!string.IsNullOrWhiteSpace(await result.LoadPage()));
        }

        [Fact]
        public void ShouldGetValidSearchResults() {
            var validList = new GoogleResultsParser(new SmokeBallParserDetails(TestHelper.Regex, TestHelper.Qualifier)).Parse(TestHelper.DummyHtml());
            Assert.Equal(7, validList.Count);
        }

        [Fact]
        public void ShouldConvertArrayToString() {
            var myIntArr = new List<int> {0, 1, 2, 3, 4};
            Assert.Equal("0, 1, 2, 3, 4", Utils.IntListToStringConverter(myIntArr));
        }

        [Fact]
        public void ShouldReturnZeroIfEmpty()
        {
            var myIntArr = new List<int> {  };
            Assert.Equal("0", Utils.IntListToStringConverter(myIntArr));
        }

        [Fact]
        public void ShouldFindStringInResults() {
            var validList = new GoogleResultsParser(new SmokeBallParserDetails(TestHelper.Regex, TestHelper.Qualifier)).Parse(TestHelper.DummyHtml());
            Assert.Equal(new List<int>(){2,6}, new ResultFinder(new DesiredResult("smokeball")).GetResults(validList));
        }

        [Fact]
        public async Task ShouldGetValidSearchResultsFromGoogle()
        {
            var result = new CustomRequest(new RequestParams("https", "www.google.com", "search", new Dictionary<string, string>() { { "num", "100" }, { "q", "conveyancing+software" } }));
            var validList = new GoogleResultsParser(new SmokeBallParserDetails(TestHelper.Regex, TestHelper.Qualifier)).Parse(await result.LoadPage());

            Assert.Equal(100, validList.Count);
        }

    }
}
