using System.Threading.Tasks;
using Refit;

namespace testapp.Core.Services.Property
{
    public interface IPropertyDetailsApi
    {
        [Get("/api/propertylisting/{id}")]
        Task<PropertyDetailsResult> GetPropertyDetails([AliasAs("id")]int propertyId);
    }
}
