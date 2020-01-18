using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace testapp.Core.Services.Property
{
    public class PropertyDetailsResult
    {
        public int Id { get; set; }
        public string ListingId { get; set; }
        public string Address { get; set; }
        public string Postcode { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal MarketPrice { get; set; }
        public string PriceQualifier { get; set; }
        public bool ToLet { get; set; }
        public bool IsLive { get; set; }
        public string PrimaryImageUrl { get; set; }
        public string PrimaryImageThumbnail { get; set; }
        public IList<SearchPropertyDetailImage> Images { get; set; }
        public IList<string> StarPoints { get; set; }
        public string FloorplanUrl { get; set; }
        public RentFrequencies? RentFrequency { get; set; }
        public bool UnderOffer { get; set; }
        public TenancyData Tenancy { get; set; }
        public DateTime? ClosingDate { get; set; }
        public bool IsWithdrawn { get; set; }
        public bool Sold { get; set; }
        public PropertyFeatures Features { get; set; }
        public PropertyExpert PropertyExpertData { get; set; }

        [JsonIgnore]
        public string FormattedTitle
        {
            get
            {
                if (string.IsNullOrEmpty(Title))
                {
                    return string.Empty;
                }

                return Title.First().ToString().ToUpper() + Title.Substring(1);
            }
        }

        [JsonIgnore]
        public string FormattedMarketPrice => (PriceQualifier != "POA") ?
            $"£{MarketPrice:n0}{(RentFrequency.HasValue && RentFrequency.Value == RentFrequencies.Monthly ? " pcm" : RentFrequency.HasValue && RentFrequency.Value == RentFrequencies.Weekly ? " pcw" : "" )}" : "POA";


        [JsonIgnore]
        public IList<string> StarPointsList => StarPoints == null ? new List<string>() : FormatKeyFeatures();

        private List<string> FormatKeyFeatures()
        {
            var keyfeatures = new List<string>();

            foreach (var keyFeature in StarPoints)
            {
                var firstLetter = keyFeature.Substring(0, 1);
                var remainingLetters = keyFeature.Substring(1, keyFeature.Length - 1);

                keyfeatures.Add(firstLetter.ToUpper() + remainingLetters);
            }

            return keyfeatures;
        }
    }

    public enum RentFrequencies
    {
        Yearly = 1,
        Quarterly = 4,
        Monthly = 12,
        Weekly = 52,
        Daily = 365
    }

    public class SearchPropertyDetailImage
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string ThumbnailUrl { get; set; }
        public string Title { get; set; }
    }

    public class PropertyFeatures
    {
        public int? Bathrooms { get; set; }
        public int? Bedrooms { get; set; }
        public int? CarSpaces { get; set; }
        public decimal? LandArea { get; set; }
        public string LandAreaUnit { get; set; }
        public decimal? PropertyArea { get; set; }
        public int? Receptions { get; set; }

        //G29 removes unncessary trailing zeros
        public string FormattedLandArea => LandArea.HasValue ? $"{LandArea.Value:G29}" : string.Empty;
        public string FormattedPropertyArea => PropertyArea.HasValue ? $"{PropertyArea.Value:G29}" : string.Empty;
    }

    public class PropertyExpert
    {
        public string Email { get; set; }
        public string Forename { get; set; }
        public string PhoneNumber { get; set; }
        public string PictureUrl { get; set; }
        public string Region { get; set; }
        public string Surname { get; set; }
    }

    public class TenancyData
    {
        public DateTime? AvailableFrom { get; set; }
        public long? Deposit { get; set; }
        public string Furnished { get; set; }
        public bool? PetsPermitted { get; set; }
        public bool? SmokersPermitted { get; set; }
        public string TaxBand { get; set; }
        public string LettingTerms { get; set; }
        public bool? StudentLet { get; set; }
        public bool? Shared { get; set; }
    }
}