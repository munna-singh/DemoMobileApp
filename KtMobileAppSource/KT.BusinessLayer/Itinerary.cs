using KT.BusinessLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace KT.BusinessLayer
{
    public class Itinerary : ITripService
    {
        public ItineraryDto GetItinerary(string tripRefNumber)
        {
            var itinearary = new ItineraryDto()
            {
                Name = "Journey Through Kenya & Tanzania",
                Schedules = new ScheduleDto[]
                {
                    new ScheduleDto()
                    {
                        StartDate = "Jun 24, 2017",
                        EndDate = "Jun 26, 2017"                    
                    }
                },
                BookingAgents = new BookingAgentDto[]
                {
                    new BookingAgentDto()
                    {
                        BookingAgentId = 1,
                        Name = "Adrew Drummond",
                        TripId = 1,
                        VendorId = 1,
                        UpdateAction =0
                    }
                },                
                Highlights = "  Kenya (Nairobi, Masai Mara, Chyulu Hills, Amboseli) Tanzania(Serengeti, Ngorongoro)",
                NumberOfDays = 12,
                GroupSize = 5,
                Notes = "Thank you for booking with Kensington Tours. Below you will find a full list of the details we currently have on file for you and some important informationaboutyourtrip..Pleasereviewandverifythisdocument,as wewanttoensurethatallyourpersonalinformation is up todateandaccurate beforeyourdeparture.",
                Description = "Journey Through Kenya & Tanzania",
                Photos = new ImageDto[]
                {
                    new ImageDto()
                    {
                        Name = "FrontImage",
                        Path = "http://images.traveledge.com/assets/itinerary/banners/kt_General_Wildlife_Wilderbeest%20Migration%20Hot%20Air%20Balloon%20Background_iStock_000021993224MediumNOBALLOON.jpg",
                    }
                }                           

            };
            return itinearary;
        }
    }
}
