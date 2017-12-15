using SQLite;
using System;
using System.Collections.Generic;

namespace KT.BusinessLayer
{

    public class ItineraryDayDescDto
    {
        public int Id { get; set; }
        public int ItineraryDayId { get; set; }
        public int ItineraryId { get; set; }
        public string TripStartDate { get; set; }
        public int DayNumber { get; set; }
        public string LocationName { get; set; }
        public List<SummaryDto> Summary { get; set; }
    }

    public class SummaryDto
    {
        public string Name { get; set; }
        public string Description { get; set; }       
      
    }

    public class ItineraryDayDto
    {
        public int ItineraryDayId { get; set; }
        public string Day { get; set; }
        public int ItineraryId { get; set; }
        public string Notes { get; set; }
        public string Deleted { get; set; }
        public string ItineraryDayDate { get; set; }
        public string IsCustomDescription { get; set; }
        public string PictureId { get; set; }
        public string Summary { get; set; } // source|destination combination  
        public List<string> Highlights { get; set; }
    }   

    public class ItineraryDto
    {
        public int ItineraryId { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }
        public int PaymentTermId { get; set; }
        public string PaymentTermName { get; set; }
        public string Description { get; set; }
        public bool IsGroupTemplate { get; set; }
        public int GroupSize { get; set; }
        public GroupAllocationDto[] DefaultRoomAllocation { get; set; }
        public BookingAgentDto[] BookingAgents { get; set; }
        public int NumberOfDays { get; set; }
        public string Notes { get; set; }
        public string Highlights { get; set; }
        public int SalesCOAAllocationId { get; set; }
        public int UseSalesCOAAllocationForRevenue { get; set; }
        public int TemplateTypeId { get; set; }
        public int PriceOptionType { get; set; } //(integer, optional) = ['1', '2', '3']
        public string PriceDisplayText { get; set; }
        public int Min2People { get; set; }
        public int Max4People { get; set; }
        public ImageDto[] Photos { get; set; }
        public ScheduleDto[] Schedules { get; set; }
    }

    public class GroupAllocationDto
    {
        public string RoomType { get; set; }
        public string GroupName { get; set; }
        public int NumberOfVehicles { get; set; }
        public TravelersDto[] Travelers { get; set; }
}

   

    public class ImageDto
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public PhotoType TypeOfPhoto { get; set; }
    }

    public class ScheduleDto
    {
        public int ScheduleId { get; set; }
        public int TypeOfSchedule { get; set; } //(integer, optional) = ['1', '2', '3', '4']
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int Recurrence { get; set; }
        public ScheduleDateTypeValuesDto[] DateTypeValues { get; set; }
    }

    public class TravelersDto
    {
        public int TravelerId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int Gender { get; set; } // (integer, optional) = ['0', '1', '2'],
        public string FlightArrivalDetails { get; set; }
        public string FlightDepartureDetails { get; set; }
        public string PassportNumber { get; set; }
        public string PassportIssueDate { get; set; }
        public string PassportExpiryDate { get; set; }
        public string PassportCountry { get; set; }
        public string DateOfBirth { get; set; }
        public string DietaryRequirements { get; set; }
        public string MobilityDetails { get; set; }
        public string HealthDetails { get; set; }
        public string CellPhoneWhileTraveling { get; set; }
        public int Age { get; set; }
    }

    public class PhotoType
    {
        public int PhotoTypeId { get; }
        public string Name { get; }
        public int Width { get; }
        public int Height { get; }
        public int DisplayOrder { get;}
    }

    public class ScheduleDateTypeValuesDto
    {
        public int DateTypes { get; set; }
        public int[] DateValues { get; set; }
    }
    
    public class TripDto
    {
        public int TripId { get; set; }
        public int CompanyId { get; set; }
        public string TripReference { get; set; }
        public string TripName { get; set; }
        public int MasterTripId { get; set; }
        public string TourAgentId { get; set; }
        public string BookedDate { get; set; }
        public string TripStartDate { get; set; }
        public string Cancelled { get; set; }
        public string DateCancelled { get; set; }
        public int MainContactClientId { get; set; }
        public string SystemOfRecordId { get; set; }
        public int NumberOfDays { get; set; }
        public int NumberOfPeople { get; set; }
        public int CompanyBrandId { get; set; }
        public int SalesCoaAllocationId { get; set; }
        public string IsArchived { get; set; }
        public string GroupName { get; set; }
        public string DateCreated { get; set; }
        public string LastModified { get; set; }
        public string TripLockId { get; set; }
        public string ApprovalRequestId { get; set; }
        public int TRAMSResCardNum { get; set; }

    }


}
