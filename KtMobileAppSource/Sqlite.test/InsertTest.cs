using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqlite.test
{
    [TestFixture]
    public class InsertTest
    {
        [Test]
        public void AddItineraryTest()
        {
            var tripRefNum = "Wil5T-419600";
            var ktBL = new KT.BusinessLayer.Itinerary();
            var tripServiceData = ktBL.AddItinerary(tripRefNum);
        }

        [Test]
        public void GetItineraryTest()
        {
            var tripRefNum = "Wil5T-419600";
            var ktBL = new KT.BusinessLayer.Itinerary();
            var tripServiceData = ktBL.GetItinerary(tripRefNum);

        }

        [Test]
        public void GetItineraryDaysTest()
        {
            var itinId = 1042157; //itinerayId based on tripRefNum 
            var ktBL = new KT.BusinessLayer.Itinerary();
            var tripServiceData = ktBL.GetItineraryDays(itinId);
        }

        [Test]
        public void GetItineraryDayDescTest()
        {
            var itinDayId = 12266038; //itinerayId based on tripRefNum 
            var ktBL = new KT.BusinessLayer.Itinerary();
            var tripServiceData = ktBL.GetItineraryDayDesc(itinDayId);
        }

        [Test]
        public void GetItineraryDayHighlightsTest()
        {
            var itinId = 1042157; //itinerayId based on tripRefNum 
            var itinDayId = 12266035; //itinerayId based on tripRefNum 
            var ktBL = new KT.BusinessLayer.Itinerary();
            var tripServiceData = ktBL.GetItineraryDayHighlights(itinId,itinDayId);
        }

    }
}
