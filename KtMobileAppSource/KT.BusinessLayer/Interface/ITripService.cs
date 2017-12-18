using KT.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KT.BusinessLayer.Interface
{
    public interface ITripService
    {
        TripServices GetItinerary(string tripRefNumber);
        ItineraryDays[] GetItineraryDays(int itineraryId);
        ItineraryDayDescDto GetItineraryDayDesc(int itineraryDayId);
    }
}
