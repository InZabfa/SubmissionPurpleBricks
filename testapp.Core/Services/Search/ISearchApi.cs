using System.Threading.Tasks;
using Refit;

namespace testapp.Core.Services.Search
{
    public interface ISearchApi
    {
        [Get("/api/search?searchRadius=2&sortBy=2")]
        Task<SearchResult> SearchProperties(string location, double latitude, double longitude, int pageNumber, int pageSize, bool toLet);
    }
}
