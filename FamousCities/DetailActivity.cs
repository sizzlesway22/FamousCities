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

namespace FamousCities
{
    [Activity(Label = "DetailActivity")]
    public class DetailActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.details);

            string name = Intent.GetStringExtra("MyName") ?? "Data not available";
            string country = Intent.GetStringExtra("MyCountry") ?? "Data not available";
            string description = Intent.GetStringExtra("MyDescription") ?? "Data not available";
            int image = Intent.GetIntExtra("MyImage", Resource.Drawable.Guinness);

            FindViewById<TextView>(Resource.Id.myName).Text = name;
            FindViewById<TextView>(Resource.Id.myCountry).Text = country;
            FindViewById<TextView>(Resource.Id.myDescription).Text = description;
            FindViewById<ImageView>(Resource.Id.myImage).SetImageResource(image);
        }
    }
}