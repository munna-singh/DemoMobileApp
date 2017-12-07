using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace KT.DAL.Models
{    
    public class Itinerary
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string TripRefNumber { get; set; }
        public string TripLocation { get; set; }
        public string TripDate { get; set; }
    }
}
