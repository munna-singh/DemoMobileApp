using System;
using System.Collections.Generic;
using System.Text;

namespace KT.BusinessLayer.Interface
{
    public interface ITripService
    {
        ItineraryDto GetItinerary(string tripRefNumber);

        ItineraryDto[] GetItineries();

        ItineraryDayDto[] GetItineraryDays(int itinearyId);

    }
}
