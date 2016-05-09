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
using Java.Lang;
using frProject.BL.Entities;
using frProject.Droid.Helpers;
using Android.Graphics;
using System.IO;

namespace frProject.Droid
{
    [Activity(Label = "Exercises")]
    public class Exercises : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.exercises);

            var themes = App.Current.DataService.GetThemes();
            
            GridView grid_view = FindViewById<GridView>(Resource.Id.exercises_gridview);
            
            grid_view.Adapter = new ThemeAdapter(this, themes);
                
        }
    }


    public class ThemeAdapter : BaseAdapter
    {
        readonly Context context;
        readonly List<Theme> themes;

        public ThemeAdapter(Context c, List<Theme> dbThemes)
        {
            context = c;
            themes = dbThemes;
        }

        public override int Count
        {
            get
            {
                return themes == null ? 0 : themes.Count;
            }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            if (themes == null)
                return null;

            return new JavaObjectWrapper<Theme>() { Obj = themes[position] };
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {

            ListView view;

            if (convertView == null)
            {
                // if it's not recycled, initialize some attributes
                view = new ListView(context);
                view.LayoutParameters = new AbsListView.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
                
            }
            else
            {
                view = (ListView)convertView;
            }

            Bitmap b = null;
            var imageFilePath = System.IO.Path.Combine(themes[position].Image.Path, themes[position].Image.FileName);
            if (File.Exists(imageFilePath))
            {
                b = BitmapFactory.DecodeFile(new Java.IO.File(imageFilePath).AbsolutePath);
            }

            view.Adapter = new ThemeItemAdapter(context, b, themes[position].Score);
            
            return view;
        }
    }

    public class ThemeItemAdapter : BaseAdapter
    {
        readonly Context context;
        readonly Bitmap themeBitmap;
        readonly int themeScore;

        public ThemeItemAdapter(Context c, Bitmap bitmap, int score)
        {
            context = c;
            themeBitmap = bitmap;
            themeScore = score;
        }
        
        public override int Count
        {
            get
            {
                return 2;
            }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return 0;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            if (position == 0)
            {
                ImageView imageView;

                if (convertView == null)
                {
                    // if it's not recycled, initialize some attributes
                    imageView = new ImageView(context);
                    imageView.LayoutParameters = new AbsListView.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
                    imageView.SetScaleType(ImageView.ScaleType.CenterCrop);
                    imageView.SetPadding(8, 8, 8, 8);
                }
                else
                {
                    imageView = (ImageView)convertView;
                }

                imageView.SetImageBitmap(themeBitmap);

                return imageView;

            }
            else
            {
                RatingBar ratingBar;
                if (convertView == null)
                {
                    // if it's not recycled, initialize some attributes
                    ratingBar = new RatingBar(context);
                    ratingBar.LayoutParameters = new AbsListView.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
                    
                }
                else
                {
                    ratingBar = (RatingBar)convertView;
                }

                ratingBar.Rating = themeScore;
                return ratingBar;
            }
        }
    }

}