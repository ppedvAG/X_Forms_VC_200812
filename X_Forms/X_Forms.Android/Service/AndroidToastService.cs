﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using X_Forms.PersonenDb.Service;

//vgl. AndroidDatabaseService.cs
[assembly: Xamarin.Forms.Dependency(typeof(X_Forms.Droid.Service.ToastService_Android))]
namespace X_Forms.Droid.Service
{
 
        public class ToastService_Android : IToastService
        {
            public void ShowLong(string msg)
            {
                Toast.MakeText(Application.Context, msg, ToastLength.Long).Show();
            }

            public void ShowShort(string msg)
            {
                Toast.MakeText(Application.Context, msg, ToastLength.Short).Show();
            }
        }
    }