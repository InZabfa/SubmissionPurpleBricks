using System.Collections.Generic;
using System.Threading.Tasks;

namespace testapp.Core.Services.LocationPrompt
{
    public interface ILocationPromptService
    {
        Task<List<LocationPromptResult>> GetLocationDetails(string location);
    }
}
