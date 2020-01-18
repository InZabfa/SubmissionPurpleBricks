using System.Collections.Generic;
using System.Threading.Tasks;
using MvvmCross.Logging;
using Refit;
using testapp.Core.Services.Base;

namespace testapp.Core.Services.LocationPrompt
{
    public class LocationPromptService : ServiceBase, ILocationPromptService
    {
        private readonly ILocationPromptApi _apiClient;

        public LocationPromptService(IMvxLog log): base(log, "https://www.purplebricks.co.uk")
        {
            _apiClient = RestService.For<ILocationPromptApi>(httpClient);
        }


        public async Task<List<LocationPromptResult>> GetLocationDetails(string location)
        {
            return await _apiClient.GetLocationDetails(location).ConfigureAwait(false);
        }
    }
}
