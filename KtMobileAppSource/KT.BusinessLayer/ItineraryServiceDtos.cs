using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace KT.BusinessLayer
{
    public class Currency
    {
        public string Name { get; set; }
        public string ISOCurrencyCode { get; set; }
        public string HTMLSymbol { get; set; }
        public int ToBase { get; set; }
        public int FromBase { get; set; }
        public int BaseCurrencyId { get; set; }
        public string IsQuotable { get; set; }
        public string IsBankAccepted { get; set; }
        public int iCurrencyId { get; set; }
    }

    public class MoneyDto
    {
        public double Amount { get; set; }
        public Currency Currency { get; set; }
    }
    
    public class Vendor
    {
        public int VendorId { get; set; }
        public string VendorDisplayName { get; set; }
        public ContactDto ContactInformation { get; set; }
        public int? PaymentTermId { get; set; }
        public string VendorName { get; set; }
        public string Contact { get; set; }
        public string Note { get; set; }
        public string ApNote { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public BookingAgentDto[] BookingAgents { get; set; }
    }

    public class ContactDto
    {
        public AddressDto Address { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
    }

    public class AddressDto
    {
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
    }

    public class BookingAgentDto
    {
        public int BookingAgentId { get; set; }
        public string Name { get; set; }
        public int? VendorId { get; set; }
        public int? TripId { get; set; }
        public int? UpdateAction { get; set; }//optional 0,1,2
    }

    public class LocaleDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IsGlobal { get; set; }
    }   

    public class TimeOfDay
    {
        [JsonProperty(PropertyName = "<TimeOfDayId>k__BackingField")]
        public int TimeOfDayId { get; set; }
        [JsonProperty(PropertyName = "<Name>k__BackingField")]
        public string Name { get; set; }
    }

    public class ServiceDescriptionDto
    {
        public ServiceDescriptionAdditionalInfoDto AdditionalInfo { get; set; }
        public int? ServiceDescriptionId { get; set; }
        public int? ServiceId { get; set; }
        public int? GlobalServiceId { get; set; }
        public string Description { get; set; }
        public string Alerts { get; set; }
        public string TermsAndConditions { get; set; }
        public string QuoteServiceName { get; set; }
        public string ClientServiceName { get; set; }
        public int SourceLocaleId { get; set; }
        public int DestinationLocaleId { get; set; }
        public string ActivityTypeName { get; set; }
        public string CategoryName { get; set; }
        public int VendorId { get; set; }
        public string ProductCode { get; set; }
        public string ProviderServiceId { get; set; }
        public string IsActive { get; set; }
        public string IsDescriptionOnly { get; set; }
        public string Deleted { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastModified { get; set; }
        public string SimpleServiceName { get; set; }
        public string ActivityTypeDisplayName { get; set; }
        public string IsCustom { get; set; }
        public string IsCustomServiceDescription { get; set; }
        public int? ActivityTypeId { get; set; }
        public string Preferred { get; set; }
        public string ShowLocaleInfo { get; set; }
        public int? PreferredId { get; set; }
        public string DestinationLocaleName { get; set; }
        public string SourceLocaleName { get; set; }
    }

    public class ServiceDescriptionAdditionalInfoDto
    {
        public int? ServiceDescription2CustomServiceId { get; set; }
        public int? ServiceDescriptionId { get; set; }
        public  int? ServiceId { get; set; }
        public  string RoomsFacilities { get; set; }
        public string ClientConfirmDetails { get; set; }
        public string Deleted { get; set; }
        public string LastModified { get; set; }
        public  int? RateTypeId { get; set; }
        public int? VehicleCapacity { get; set; }
        public string VendorNotes { get; set; }
        public int[] Photos { get; set; }
    }

    public class ItineraryServiceDto
    {
        public int? ServiceTypeGroup { get; set; }
        public int? ServiceType { get; set; }
        public int ItineraryServiceId { get; set; }
        public int ItineraryId { get; set; }
        public int ItineraryDayId { get; set; }
        public int? ParentItineraryServiceId { get; set; }
        public int? DisplayOrder { get; set; }
        //public MoneyDto QuotedCost { get; set; }
        //public MoneyDto QuotedCostInItineraryCurrency { get; set; }
        public string Comments { get; set; }
        public Vendor Vendor { get; set; }
        public string IsAlertDismissed { get; set; }
        public double Markup { get; set; }
        public string QuotedGroupAllocation { get; set; }
        public string DefaultQuotedGroupAllocation { get; set; }
        public string IsCustomGroupAllocation { get; set; }
        public int? CopiedFromItineraryServiceId { get; set; }
        public string UseCustomCost { get; set; }
        public int? IsAlternateForService { get; set; }
        public string ProviderServiceId { get; set; }
        public string IsCommissionable { get; set; }
        public string IsCustomServiceName { get; set; }
        public string IsPackageService { get; set; }
        public int? DayNumber { get; set; }
        public LocaleDto SourceLocale { get; set; }
        public LocaleDto DestinationLocale { get; set; }
        public DateTime ActualServiceStartDate { get; set; }
        public TimeOfDay TimeOfDay { get; set; }
        public DateTime CheckinDate { get; set; }
        public int? Duration { get; set; }
        public string Alerts { get; set; }
        public string IsCustomService { get; set; }
        public int? GlobalServiceId { get; set; }
        public string OfferOldRate { get; set; }
        public int? KTUserId { get; set; }
        public ServiceDescriptionDto ServiceDescription { get; set; }
        public string CustomDisplayName { get; set; }
    }
}
