using System;
using System.Net.Http;
using MvvmCross.Logging;
using testapp.Core.Services.LocationPrompt.Middleware;

namespace testapp.Core.Services.Base
{
    public class ServiceBase
    {
        public ServiceBase(IMvxLog log, string baseUrl)
        {
            this.log = log;
            httpClient = new HttpClient(new HttpClientDiagnosticsHandler(new HttpClientHandler(), log)) { BaseAddress = new Uri(baseUrl) };
        }

        protected HttpClient httpClient;
        protected IMvxLog log;
    }
}
