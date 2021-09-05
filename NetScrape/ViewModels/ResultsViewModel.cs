using Microsoft.Extensions.DependencyInjection;

namespace NetScrape.ViewModels
{
    public class ResultsViewModel : ViewModelBase
    {
        public string ResultsArray { get; set; }

        public ResultsViewModel() {
            InitialiseData();
            InitialiseCommands();
        }

        private void InitialiseData() =>
            App.MyHost.Services.GetRequiredService<NetScrapeService>().SubscribeToChanges(Update);

        private void InitialiseCommands() {
        }

        private void Update(string newResult) {
            ResultsArray = newResult;
            NotifyPropertyChanged($"ResultsArray");
        }
    }
}
