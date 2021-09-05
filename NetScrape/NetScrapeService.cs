using NetScrape.Core;
using NetScrape.Core.Request;
using NetScrape.Core.ResultsAnalysis;
using NetScrape.Core.WebParser;
using System;
using System.Collections.Generic;

namespace NetScrape
{
    public class NetScrapeService
    {
        private readonly List<Action<string>> _subscribers;
        private ICustomRequest _request { get; set; }
        private IResultFinder _resultFinder { get; set; }
        private IWebsiteParser _websiteParser { get; set; }

        public NetScrapeService(
            ICustomRequest customRequest,
            IResultFinder finder,
            IWebsiteParser wbParser) {

            _request = customRequest;
            _resultFinder = finder;
            _websiteParser = wbParser;
            _subscribers = new List<Action<string>>();
        }

        public void SubscribeToChanges(Action<string> myAction) =>
            _subscribers.Add(myAction);


        public async void Update() {
            var resultString =
                Utils.IntListToStringConverter(
                    _resultFinder.GetResults(
                        _websiteParser.Parse(
                            await _request.LoadPage())));

            foreach (var subscriber in _subscribers)
                subscriber.Invoke(resultString);

        }
    }
}
