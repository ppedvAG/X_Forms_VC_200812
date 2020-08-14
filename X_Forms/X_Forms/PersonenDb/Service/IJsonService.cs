using System;
using System.Collections.Generic;
using System.Text;

namespace X_Forms.PersonenDb.Service
{
    //vgl. IDatabaseService
    //vgl. Android/Services/AndroidJsonService
    public interface IJsonService
    {
        void SaveJson(object data);

        T LoadJson<T>();
    }
}
