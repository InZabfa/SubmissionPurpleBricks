using System.Threading.Tasks;
using MvvmCross.Logging;
using Refit;
using testapp.Core.Services.Base;

namespace testapp.Core.Services.Property
{
    public class PropertyDetailsService : ServiceBase, IPropertyDetailsService
    {
        private readonly IPropertyDetailsApi _apiClient;

        public PropertyDetailsService(IMvxLog log) : base(log, "https://www.purplebricks.co.uk")
        {
            _apiClient = RestService.For<IPropertyDetailsApi>(httpClient);
        }

        public async Task<PropertyDetailsResult> FetchPropertyDetails(int propertyId)
        {
            return await _apiClient.GetPropertyDetails(propertyId);
        }
    }
}
