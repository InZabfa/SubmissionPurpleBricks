using System.Threading.Tasks;
using testapp.Core.Services.LocationPrompt;

namespace testapp.Core.Services.Search
{
    public interface ISearchService
    {
        public Task<SearchResult> FindProperties(LocationPromptResult locationPrompt, bool toLet = false, int pageNumber = 1, int pageSize = 10); 
    }
}
