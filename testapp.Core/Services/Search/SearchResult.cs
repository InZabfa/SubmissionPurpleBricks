using System.Collections.Generic;
using Newtonsoft.Json;

namespace testapp.Core.Services.Search
{
    public class SearchResult
    {
        public SearchResultMetaData MetaData { get; set; }
        public IList<SearchPropertyResult> Properties { get; set; }
    }

    public class SearchResultMetaData
    {
        public int PageCount { get; set; }
        public int TotalItemCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public bool HasPreviousPage { get; set; }
        public bool HasNextPage { get; set; }
        public bool IsFirstPage { get; set; }
        public bool IsLastPage { get; set; }
        public int FirstItemOnPage { get; set; }
        public int LastItemOnPage { get; set; }
    }

    public class SearchPropertyResult
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string ShortAddress { get; set; }
        public decimal MarketPrice { get; set; }
        public PropertySearchImage Image { get; set; }
        public string Description { get; set; }
        public string Postcode { get; set; }
        public string PriceQualifier { get; set; }
        public string RentFrequency { get; set; }
        public bool HasExtras { get; set; }
        public Features PropertyFeatures { get; set; }

        [JsonIgnore]
        public string FormattedMarketPrice => (PriceQualifier != "POA") ?
            $"£{MarketPrice:n0}{(string.IsNullOrEmpty(RentFrequency) ? "" : " " + RentFrequency)}" : "POA";

        [JsonIgnore]
        public string LargeImage => string.IsNullOrWhiteSpace(Image?.MediumImage) ? string.Empty : Image.MediumImage.Replace(@"/medium/", @"/large/");
    }

    public class PropertySearchImage
    {
        public string MediumImage { get; set; }
        public string Thumbnail { get; set; }
        public string Title { get; set; }
    }

    public class Features
    {
        public int? Bathrooms { get; set; }
        public int? Bedrooms { get; set; }
        public int? CarSpaces { get; set; }
        public int? Receptions { get; set; }
    }
}
