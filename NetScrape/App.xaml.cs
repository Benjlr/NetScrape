using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetScrape.Core.Request;
using NetScrape.Core.ResultsAnalysis;
using System.Windows;
using NetScrape.Core.WebParser;

namespace NetScrape
{

    public partial class App : Application
    {

        public static IHost MyHost;

        public App() {
            MyHost = Host.CreateDefaultBuilder()
                .ConfigureServices(ServiceConfiguration)
                .Build();
        }

        private void ServiceConfiguration(IServiceCollection services) =>
            services
                .AddSingleton<MainWindow>()
                .AddSingleton<IRequestDetails, RequestParams>()
                .AddSingleton<IDesiredResult, DesiredResult>()
                .AddSingleton<IParserDetails, SmokeBallParserDetails>()
                .AddTransient<IWebsiteParser, GoogleResultsParser>()
                .AddTransient<IResultFinder, ResultFinder>()
                .AddTransient<ICustomRequest, CustomRequest>()
                .AddSingleton<NetScrapeService>();



        protected override async void OnStartup(StartupEventArgs e) {
            await MyHost.StartAsync();
            MyHost.Services.GetRequiredService<MainWindow>().Show();
            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e) {
            using (MyHost) {
                await MyHost.StopAsync();
                base.OnExit(e);
            }
        }
    }
}
