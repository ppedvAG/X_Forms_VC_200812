using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace X_Forms.PersonenDb.Service
{
    public interface IDatabaseService
    {
        SQLiteConnection GetConnection();
    }
}
