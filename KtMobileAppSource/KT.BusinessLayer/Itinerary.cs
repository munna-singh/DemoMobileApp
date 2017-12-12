using KT.BusinessLayer.Interface;
using KT.BusinessLayer.Service;
using KT.DAL.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
namespace KT.BusinessLayer
{
    public class Itinerary : ITripService
    {

        public const string baseUri = "http://new-api-tmt.kensingtontours.com/api";

        public string apiUri;

        public Itinerary()
        {
            //KT db instance
            var ktdb = new KT.DAL.KTdb();

            //below CreateTable creates table if not exists - any model changes - it alters the table to new model structure
            ktdb.CreateTable<TripServices>();
            ktdb.CreateTable<ItineraryDays>();
            ktdb.CreateTable<ItineraryDayDesc>();
        }

        public TripServices GetItinerary(string tripRefNumber)
        {
            //validate triprefnumber for '-' or emptystring
            if (string.IsNullOrWhiteSpace(tripRefNumber)) throw new ArgumentException("TripRefNumber cannot be empty");

            if (!tripRefNumber.Contains("-")) throw new ArgumentException("Provider a valid trip ref number Ex.Wil5T-000100 ");

            var tripId = tripRefNumber.Split('-')[1];

            //Initialize db
            var ktdb = new KT.DAL.KTdb();

            //Check if this TripId is already in db then return from db
            var tripIdInt = Convert.ToInt32(tripId);           
            var tripServiceId = ktdb.ExecuteScalar<int>("select Id from TripServices where Id = ?", tripIdInt);

            //return from db if pk is already exists
            if (tripServiceId > 0) return ktdb.Get<TripServices>(x => x.Id == tripIdInt);

            //Call webservice to fetch data related to trip this tripId
            apiUri = string.Format("{0}/{1}/{2}", baseUri, "trips", tripId);

            var tripObject = new KTApi<TripDto>().Get(apiUri);

            //Insert to db object 
            var tripService = new TripServices()
            {
                Id = tripObject.TripId,
                Name = tripObject.TripName,
                ItineraryId = Convert.ToInt32(tripObject.SystemOfRecordId.Replace("KT:IT-", "")),
                RefNum = tripObject.TripReference,
                StartDate = tripObject.TripStartDate,
                NoOfDays = tripObject.NumberOfDays,
                NoOfPeople = tripObject.NumberOfPeople,
                GroupName = tripObject.GroupName,
                ImageSrc = "",
                IsArchived = 0
            };

            //insert to db

            var insertCount = ktdb.Insert(tripService);
            return tripService;
        }

        public ItineraryDays[] GetItineraryDays(int itineraryId)
        {
            var itineraryDays = new List<ItineraryDays>();

            //validation
            if (itineraryId <= 0) throw new ArgumentException("Provide a valid ItineraryId.");

            //If this id already exists in db return from db
            var ktdb = new KT.DAL.KTdb();
            var itinIdExists = ktdb.ExecuteScalar<int>("select count(ItineraryId) from ItineraryDays where ItineraryId = ?", itineraryId);
            if (itinIdExists>0) return ktdb.Table<ItineraryDays>().Where(x=>x.ItineraryId== itineraryId).ToArray();

            //hit api to fetch itineraryDays
            apiUri = string.Format("{0}/{1}/{2}", "itineraries", itineraryId, "days");
            var itineraryDayList = new KTApi<List<ItineraryDays>>().Get(apiUri);

            if (itineraryDayList != null && itineraryDayList.Count > 0)
            {
                //hit api to fetch ItineraryService Data 
                apiUri = string.Format("itineraries/itineraryId/itineraryservices?itineraryid={0}&request.itineraryId={0}&request.includeServiceDescriptions=true", itineraryId);
                var itinServiceDto = new KTApi<List<ItineraryServiceDto>>().Get(apiUri);
                //insert each object to db      
                foreach (var dayObj in itineraryDayList)
                {
                    if (dayObj.Day == null) continue;

                    var day = new ItineraryDays()
                    {
                        ItineraryDayId = dayObj.ItineraryDayId,
                        Day = dayObj.Day,
                        Deleted = dayObj.Deleted,
                        ItineraryId = dayObj.ItineraryId,
                        Notes = dayObj.Notes,
                        ItineraryDayDate = dayObj.ItineraryDayDate,
                        IsCustomDescription = dayObj.IsCustomDescription,
                        PictureId = dayObj.PictureId,                       
                    };

                    //Save ItineraryDayDesc
                    var itinDayDesc = GetItineraryService(itinServiceDto.FirstOrDefault(x => x.ItineraryDayId == dayObj.ItineraryDayId && x.ItineraryId == dayObj.ItineraryId));
                    var insertCount = ktdb.Insert(itinDayDesc);

                    day.Summary = (itinDayDesc.SourceName == itinDayDesc.DestName ? itinDayDesc.SourceName : itinDayDesc.SourceName+ "|" + itinDayDesc.DestName);               //Save ItineraryDays
                    insertCount = ktdb.Insert(day);
                    itineraryDays.Add(day);
                }
            }

            return itineraryDays.ToArray();
        }

        private ItineraryDayDesc GetItineraryService(ItineraryServiceDto serviceDto)
        {
            var itinDayDesc = new ItineraryDayDesc()
            {
                ItineraryDayId = serviceDto.ItineraryDayId,
                TimeOfDayId = serviceDto.TimeOfDay.TimeId,
                CustomDisplayName = serviceDto.CustomDisplayName,
                ActivityTypeDisplayName = serviceDto.ServiceDescription.ActivityTypeDisplayName,
                DisplayOrder = serviceDto.DisplayOrder,
                Alerts = serviceDto.Alerts,
                TermsAndConditions = serviceDto.ServiceDescription.TermsAndConditions,
                SourceName = serviceDto.SourceLocale.Name,
                DestName = serviceDto.DestinationLocale.Name,
                Description = serviceDto.ServiceDescription.Description
            };

            return itinDayDesc;
        }

        public ItineraryDayDesc GetItineraryDayDesc(int itineraryDayId)
        {
            //validation
            if (itineraryDayId <0 ) throw new ArgumentException("Provide a valid ItineraryDayId.");
            //fetch and return from db
            var ktdb = new KT.DAL.KTdb();
            var itinIdExists = ktdb.ExecuteScalar<int>("select count(1) from ItineraryDayDesc where ItineraryDayId = ?", itineraryDayId);
            if (itinIdExists > 0) return ktdb.Get<ItineraryDayDesc>(x => x.ItineraryDayId == itineraryDayId);

            return null;
        }


    }
}
