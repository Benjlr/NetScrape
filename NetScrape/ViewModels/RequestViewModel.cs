using System.Windows.Input;

namespace NetScrape.ViewModels
{
    public class RequestViewModel : ViewModelBase
    {
        private RelayCommand _sendRequest;
        public ICommand SendRequest => _sendRequest;

        public string Host { get; set; }
        public string Scheme { get; set; }
        public string SearchParams { get; set; }
        public int NumberofResults { get; set; }


        public RequestViewModel() {
            InitialiseData();
            InitialiseCommands();
        }

        private void InitialiseData() {
            Host = "www.google.com";
            Scheme = "https";
            SearchParams = "conveyancing software";
            NumberofResults = 100;
        }

        private void InitialiseCommands() {
            _sendRequest = new RelayCommand(
                command => sendRequest(),
                canExecute => !string.IsNullOrWhiteSpace(Host) && !string.IsNullOrWhiteSpace(Scheme) && NumberofResults > 0);
        }


        private void sendRequest() {

        }



    }
}
