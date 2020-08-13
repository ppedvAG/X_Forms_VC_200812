using System;
using System.Collections.Generic;
using System.Text;

namespace X_Forms.PersonenDb.Service
{
    public interface IJsonService
    {
        void SaveJson(object data);

        T LoadJson<T>();
    }
}
