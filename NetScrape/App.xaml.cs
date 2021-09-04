﻿using Microsoft.Extensions.Hosting;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using NetScrape.Core.Request;
using NetScrape.Core.ResultsAnalysis;

namespace NetScrape
{

    public partial class App : Application
    {

        private readonly IHost _host;

        public App() {
            _host = Host.CreateDefaultBuilder()
                .ConfigureServices(ServiceConfiguration)
                .Build();

        }

        private void ServiceConfiguration(IServiceCollection services) {
            //services
            //    .AddTransient<ICustomRequest,CustomRequest>()
            //    .AddSingleton<IRequestDetails,RequestParams>()
            //    .AddTransient<IResultFinder,ResultFinder>()
            //    .AddTransient<>()
        }


        protected override async void OnStartup(StartupEventArgs e) {
            await _host.StartAsync();
            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e) {
            using (_host) {
                await _host.StopAsync();
                base.OnExit(e);
            }
        }
    }
}
