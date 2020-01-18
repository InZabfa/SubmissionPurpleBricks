using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using MvvmCross.Logging;

namespace testapp.Core.Services.LocationPrompt.Middleware
{
    [DebuggerStepThrough]
    public class HttpClientDiagnosticsHandler : DelegatingHandler
    {
        private readonly IMvxLog _log;

        public HttpClientDiagnosticsHandler(HttpMessageHandler innerHandler, IMvxLog log) : base(innerHandler)
        {
            _log = log;
        }

        public HttpClientDiagnosticsHandler(IMvxLog log)
        {
            _log = log;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var totalElapsedTime = Stopwatch.StartNew();

            _log.Debug(string.Format("Request: {0}", request));
            if (request.Content != null)
            {
                var content = await request.Content.ReadAsStringAsync().ConfigureAwait(false);
                _log.Debug(string.Format("Request Content: {0}", content));
            }

            var responseElapsedTime = Stopwatch.StartNew();
            var response = await base.SendAsync(request, cancellationToken);

            _log.Debug(string.Format("Response: {0}", response));
            if (response.Content != null)
            {
                var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                _log.Debug(string.Format("Response Content: {0}", content));
            }

            responseElapsedTime.Stop();
            _log.Debug(string.Format("Response elapsed time: {0} ms", responseElapsedTime.ElapsedMilliseconds));

            totalElapsedTime.Stop();
            _log.Debug(string.Format("Total elapsed time: {0} ms", totalElapsedTime.ElapsedMilliseconds));

            return response;
        }
    }
}