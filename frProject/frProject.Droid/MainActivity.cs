using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace frProject.Droid
{
	[Activity (Label = "frProject.Droid", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.main_menu);
              
			Button button_exersises = FindViewById<Button> (Resource.Id.button_exercises);
            Button button_rules = FindViewById<Button>(Resource.Id.button_rules);
            Button button_dictionary = FindViewById<Button>(Resource.Id.button_dictionary);

            button_exersises.Click += delegate
            {
                StartActivity(typeof(Exercises));
            };
        }
    }
}


