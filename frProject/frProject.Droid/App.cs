using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.IO;
using frProject.BL;

namespace frProject.Droid
{
    [Application]
    public class App: Application
    {
        public static App Current { get; private set; }
        public DataManager DataService { get; private set; }

        public App(IntPtr handle, global::Android.Runtime.JniHandleOwnership transfer)
			: base(handle, transfer) {
            Current = this;
        }

        public override void OnCreate()
        {
            base.OnCreate();

            var sqliteFilename = "db.db3";
            string libraryPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(libraryPath, sqliteFilename);

            DataService = new DataManager(path);
        }

    }
}