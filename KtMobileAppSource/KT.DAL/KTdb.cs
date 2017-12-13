using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace KT.DAL
{
    public class KTdb : SQLiteConnection
    {
        public KTdb(bool storeDataTimeAsTicks=true) : base(@"KT.db", storeDataTimeAsTicks)
        {
            Trace = true;
        }

    }
}
