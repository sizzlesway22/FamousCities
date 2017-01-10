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
    [Activity(Label = "ItemActivity")]
    public class ItemActivity : Activity
    {
        private ListView mList;
        private List<City> cities = new List<City>();
        private string text;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.items);
            int picLondon = Resource.Drawable.picLondon;
            int picNewYork = Resource.Drawable.picNewYork;
            int picBeijing = Resource.Drawable.picBeijing;
            int picMoscow = Resource.Drawable.picMoscow;

            text = Intent.GetStringExtra("MyExtras") ?? "Data not available";
            cities.Add(new City("London", "United Kingdom", "I've been here", picLondon));
            cities.Add(new City("New York", "United States", "Never been here", picNewYork));
            cities.Add(new City("Beijing", "China", "I'd like to go here", picBeijing));
            cities.Add(new City("Moscow", "Russia", "This would be interesting", picMoscow));

            mList = FindViewById<ListView>(Resource.Id.myList);
            mList.Adapter = new CustomListAdapter(this, cities);
            mList.ItemClick += MList_ItemClick;
        }

        private void MList_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var index = e.Position;
            var customListAdapter = mList.Adapter as CustomListAdapter;
            var itemActivity = new Intent(this, typeof(DetailActivity));
            itemActivity.PutExtra("MyName", customListAdapter[index].name);
            itemActivity.PutExtra("MyCountry", customListAdapter[index].country);
            itemActivity.PutExtra("MyDescription", customListAdapter[index].description);
            itemActivity.PutExtra("MyImage", customListAdapter[index].imageSrc);
            StartActivity(itemActivity);
        }
    }
}