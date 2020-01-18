using System.Threading.Tasks;

namespace testapp.Core.Services.Property
{
    public interface IPropertyDetailsService
    {
        public Task<PropertyDetailsResult> FetchPropertyDetails(int propertyId);
    }
}
