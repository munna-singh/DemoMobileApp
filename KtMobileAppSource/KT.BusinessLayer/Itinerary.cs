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

        public ItineraryDto[] GetItineries()
        {
            var itineraryList = new List<ItineraryDto>();

            //Sample 1 itinerary
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
                NumberOfDays = 3,
                GroupSize = 5,
                Description = "Journey Through Kenya & Tanzania",
                Photos = new ImageDto[]
                 {
                    new ImageDto()
                    {
                        Name = "FrontImage",
                        Path = "http://1-day-tours-in-kenya.com/images/lions_nairobi_national_park.jpg",
                    }
                 }

            };

            itineraryList.Add(itinearary);

            //Sample 2 itinerary
            itinearary = new ItineraryDto()
            {
                Name = "Tour through Paris, France",
                Schedules = new ScheduleDto[]
                 {
                    new ScheduleDto()
                    {
                        StartDate = "Jun 27, 2017",
                        EndDate = "Jun 30, 2017"
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
                NumberOfDays = 4,
                GroupSize = 5,
                Description = "Tour Paris",
                Photos = new ImageDto[]
                 {
                    new ImageDto()
                    {
                        Name = "FrontImage",
                        Path = "https://cache-graphicslib.viator.com/graphicslib/thumbs360x240/7845/SITours/eiffel-tower-summit-priority-access-with-host-in-paris-408219.jpg",
                    }
                 }

            };

            itineraryList.Add(itinearary);

            return itineraryList.ToArray();

        }

        public ItineraryDayDto[] GetItineraryDays(int itinearyId)
        {
            var itineraryDays = new List<ItineraryDayDto>() {

                new ItineraryDayDto() {
                    Day =1,
                    ItineraryDayDate = "Jul 24, 2017",
                    Notes= "248262/3",
                    CustomServiceDesc = "Emergency Evacuation Insurance\r\nTransfer - Private - Airport - Vehicle/Driver\r\nDinner (not included)\r\nHemingways Nairobi (B) (Deluxe Room)\r\n",
                    LocationName = "NAIROBI"
                },
                new ItineraryDayDto() {
                    Day =2,
                    ItineraryDayDate = "Jul 25, 2017",
                    Notes= "AK 5995EB 14:00 14:40\r\nWB2689",
                    CustomServiceDesc = "Tour - Private - Transportation - 4X4 - Kenya\r\nVisit Giraffe Center & David Sheldrick Elephant Orphanage - Entrance Paid Locally\r\nAir - Nairobi - Masai Mara [Direct (45min)] - SL\r\nPark Fee - Included" +
                            "Transfer - Airstrip Pick Up & Game Drive - 4X4 - Kenya\r\nDinner (included)\r\nAngama Mara (BLD) (Tented Suite (Package))",
                    LocationName = "NAIROBI\r\nMASAI MARA"
                },
                new ItineraryDayDto() {
                    Day= 3,
                    ItineraryDayDate = "Jul 26, 2017",
                    Notes= "WB2689",
                    CustomServiceDesc = "Tour - Private - Morning Game Drive - 4X4 - Kenya\r\nLunch (included)" +
                        "Tour - Private - Afternoon Game Drive - Big 5\r\nPark Fee - Included \r\nDinner (included)Angama Mara (BLD) (Tented Suite (Package))",
                    LocationName = "NAIROBI\r\nMASAI MARA"
                }
            };

            return itineraryDays.ToArray();

        }
    }
}
