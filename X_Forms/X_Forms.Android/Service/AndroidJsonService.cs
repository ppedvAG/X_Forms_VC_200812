using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using X_Forms.PersonenDb.Service;
using Newtonsoft.Json;
using Xamarin.Forms;

[assembly: Dependency(typeof(X_Forms.Droid.Service.AndroidJsonService))]
namespace X_Forms.Droid.Service
{
    public class AndroidJsonService : IJsonService
    {
        private static string path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "jsonText.txt");

        public T LoadJson<T>()
        {
            if (!File.Exists(path))
                File.Create(path).Dispose();

            string jsonString = File.ReadAllText(path);

            return JsonConvert.DeserializeObject<T>(jsonString);
        }

        public void SaveJson(object data)
        {
            string jsonString = JsonConvert.SerializeObject(data);

            File.WriteAllText(path, jsonString);
        }
    }
}