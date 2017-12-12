using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace KT.DAL
{
    public class KTdb : SQLiteConnection
    {
        public KTdb(bool storeDataTimeAsTicks=true) : base(@"C:\travelEdge\KT.db", storeDataTimeAsTicks)
        {
            Trace = true;
        }

    }
}
