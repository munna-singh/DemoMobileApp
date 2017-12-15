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
    public enum TripImportStatus
    {
        Error = 0,
        Add = 1,
        Update = 2
    }

    public class Itinerary : ITripService
    {

        //public const string baseUri = "http://new-api-tmt.kensingtontours.com/api";

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

        private bool InsertTripDataFromApi(int tripId)
        {
            //Webservice to fetch data related to trip this tripId
            apiUri = string.Format("{0}/{1}", "trips", tripId);
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

            //Initialize db
            var ktdb = new KT.DAL.KTdb();
            //insert trip
            var insertCount = ktdb.Insert(tripService);

            return true;
        }

        public TripImportStatus AddItinerary(string tripRefNumber)
        {
            //validate triprefnumber for '-' or emptystring
            if (string.IsNullOrWhiteSpace(tripRefNumber)) throw new ArgumentException("TripRefNumber cannot be empty");

            if (!tripRefNumber.Contains("-")) throw new ArgumentException("Provider a valid trip ref number Ex.Wil5T-000100 ");

            var tripId = tripRefNumber.Split('-')[1];

            //Check if this TripId is already in db then return from db
            var tripIdInt = Convert.ToInt32(tripId);
            var ktdb = new DAL.KTdb();
           

            var tripServiceId = ktdb.ExecuteScalar<int>("select Id from TripServices where Id = ?", tripIdInt);

            //Add
            if (tripServiceId == 0)
            {
                InsertTripDataFromApi(tripIdInt);

                //get itineraryId 
                var itinId = ktdb.ExecuteScalar<int>("select ItineraryId from TripServices where Id = ?", tripIdInt);
                GetItineraryDays(itinId);
                return TripImportStatus.Add;
            }

            //return from db if pk is already exists
            if (tripServiceId > 0)
            {
                //save itineraryId 
                var itinId = ktdb.ExecuteScalar<int>("select ItineraryId from TripServices where Id = ?", tripIdInt);

                //delete data for this trip
                ktdb.Table<ItineraryDayDesc>().Delete(x => x.ItineraryId == itinId);
                ktdb.Table<ItineraryDays>().Delete(x => x.ItineraryId == itinId);
                ktdb.Table<TripServices>().Delete(x=>x.Id== tripServiceId);

                //reload the data
                InsertTripDataFromApi(tripIdInt);
                GetItineraryDays(itinId);

                //update as status
                return TripImportStatus.Update;
            }

            return TripImportStatus.Error;
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

            InsertTripDataFromApi(tripIdInt);
            return ktdb.Get<TripServices>(x => x.Id == tripIdInt);
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
                    var itinDayDesc = GetItineraryService(itineraryId, itinServiceDto.Where(x => x.ItineraryDayId == dayObj.ItineraryDayId && x.ItineraryId == dayObj.ItineraryId).ToList());
                    var insertCount = ktdb.InsertAll(itinDayDesc);

                    //find source and destination to update in ItineraryDay table
                    List<string> srcDest = new List<string>();
                    foreach(var dayDesc in itinDayDesc)
                    {
                        if (dayDesc.SourceName != "Global Location")
                        {
                            if (!srcDest.Contains(dayDesc.SourceName))
                                srcDest.Add(dayDesc.SourceName);
                        }

                        if (dayDesc.DestName != "Global Location")
                        {
                            if (!srcDest.Contains(dayDesc.DestName))
                                srcDest.Add(dayDesc.DestName);
                        }
                    }

                    day.Summary = string.Join("|",srcDest);
                    insertCount = ktdb.Insert(day);
                    itineraryDays.Add(day);
                }
            }

            return itineraryDays.ToArray();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itineraryId"></param>
        /// <param name="serviceDto"></param>
        /// <returns></returns>
        private List<ItineraryDayDesc> GetItineraryService(int itineraryId,List<ItineraryServiceDto> serviceDto)
        {
            var dayDescList = new List<ItineraryDayDesc>();
            foreach (var dataObj in serviceDto)
            {
                var itinDayDesc = new ItineraryDayDesc()
                {
                    ItineraryDayId = dataObj.ItineraryDayId,  
                    ItineraryId = itineraryId,
                    TimeOfDayId = dataObj.TimeOfDay.TimeOfDayId,
                    CustomDisplayName = dataObj.CustomDisplayName,
                    ActivityTypeDisplayName = dataObj.ServiceDescription.ActivityTypeDisplayName,
                    DisplayOrder = dataObj.DisplayOrder,
                    Alerts = dataObj.Alerts,
                    TermsAndConditions = dataObj.ServiceDescription.TermsAndConditions,
                    SourceName = dataObj.SourceLocale.Name,
                    DestName = (dataObj.SourceLocale.Name.Equals(dataObj.DestinationLocale.Name,StringComparison.InvariantCultureIgnoreCase)?null: dataObj.DestinationLocale.Name),
                    Description = dataObj.ServiceDescription.Description
                };
                dayDescList.Add(itinDayDesc);
            }
            return dayDescList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itineraryDayId"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itineraryId"></param>
        /// <param name="itineraryDayId"></param>
        /// <returns></returns>
        public List<string> GetItineraryDayHighlights(int itineraryId, int itineraryDayId)
        {
            //validation
            if (itineraryId < 0) throw new ArgumentException("Provide a valid ItineraryId.");
            if (itineraryDayId < 0) throw new ArgumentException("Provide a valid ItineraryDayId.");

            var ktdb = new DAL.KTdb();
            var itinIdExists = ktdb.ExecuteScalar<int>("select count(1) from ItineraryDayDesc where ItineraryId = ? and ItineraryDayId = ?", itineraryId, itineraryDayId);
            var dayDescData = ktdb.Table<ItineraryDayDesc>().Where(x => x.ItineraryDayId == itineraryDayId && x.ItineraryId == itineraryId).OrderBy(y=>y.TimeOfDayId).ThenBy(z=>z.DisplayOrder);
            return dayDescData.Select(x => x.ActivityTypeDisplayName + "-" +x.CustomDisplayName).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<TripServices> GetItineraryList()
        {
           
            //fetch and return from db
            var ktdb = new KT.DAL.KTdb();
            var itinIdExists = ktdb.ExecuteScalar<int>("select count(1) from TripServices");
            if (itinIdExists > 0) return ktdb.Table<TripServices>().ToList();

            return null;
        }


    }
}
