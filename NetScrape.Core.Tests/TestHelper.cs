namespace NetScrape.Core.Tests
{
    public class TestHelper
    {
        public static readonly string Qualifier = "<div class=\"kCrYT\"><a href=\"/url?q=";
        public static string DummyHtml() {
            return
                Qualifier +
                "http://www.othersoftware.com" +
                Qualifier +
                "www.smokeball.com" +
                Qualifier +
                "https://www.othersoftware.com" +
                Qualifier +
                "www.othersoftware.com" +
                Qualifier +
                "http://www.othersoftware.com" +
                Qualifier +
                "https://www.smokeball.com" +
                Qualifier +
                "https://www.othersoftware.com";
        }
    }
}
