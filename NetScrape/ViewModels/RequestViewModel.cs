using Microsoft.Extensions.DependencyInjection;
using NetScrape.Core.Request;
using NetScrape.Core.ResultsAnalysis;
using System.Collections.Generic;
using System.Windows.Input;

namespace NetScrape.ViewModels
{
    public class RequestViewModel : ViewModelBase
    {
        private IRequestDetails _request;
        private IDesiredResult _stringToFind;
        private NetScrapeService _clientService;
        private RelayCommand _sendRequest;
        public ICommand SendRequest => _sendRequest;

        public string Host { get; set; }
        public string Scheme { get; set; }
        public string SearchParams { get; set; }
        public string Desired { get; set; }
        public int NumberofResults { get; set; }


        public RequestViewModel() {
            InitialiseData();
            InitialiseCommands();
        }

        private void InitialiseData() {
            _request = App.MyHost.Services.GetRequiredService<IRequestDetails>();
            _stringToFind = App.MyHost.Services.GetRequiredService<IDesiredResult>();
            _clientService = App.MyHost.Services.GetRequiredService<NetScrapeService>();

            Host = "www.google.com";
            Scheme = "https";
            SearchParams = "conveyancing software";
            Desired = "smokeball";
            NumberofResults = 100;
        }

        private void InitialiseCommands() {
            _sendRequest = new RelayCommand(
                command => sendRequest(),
                canExecute => !string.IsNullOrWhiteSpace(Host) && !string.IsNullOrWhiteSpace(Scheme) && NumberofResults > 0);
        }

        private void sendRequest() {
            _request.Scheme = this.Scheme;
            _request.Host = this.Host;
            _request.Path = "search";
            _request.Params = new Dictionary<string, string>()
            {
                {"num", NumberofResults.ToString()},
                {"q", SearchParams.Replace(" ", "")}
            };

            _stringToFind.Result = Desired;
            _clientService.Update();
        }
    }
}
