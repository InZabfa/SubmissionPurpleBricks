using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;

namespace testapp.Core.Services.LocationPrompt
{
    public interface ILocationPromptApi
    {
        [Get("/api/locationPrompt?pageSize=1")]
        Task<List<LocationPromptResult>> GetLocationDetails([AliasAs("id")] string location);
    }
}
