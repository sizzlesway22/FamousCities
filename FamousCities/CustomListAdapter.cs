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
    class CustomListAdapter : BaseAdapter<City>
    {
        private Activity activity;
        private List<City> list;

        public CustomListAdapter(Activity activity, List<City> _list)
        {
            this.activity = activity;
            this.list = _list;
        }

        public override City this[int position]
        {
            get
            {
                return list[position];
            }
        }

        public override int Count
        {
            get
            {
                return list.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;
            if (view == null)
                view = activity.LayoutInflater.Inflate(Resource.Layout.CityItemRow, null);

            view.Tag = position;
            City item = this[position];
            view.FindViewById<TextView>(Resource.Id.Name).Text = item.name;
            view.FindViewById<TextView>(Resource.Id.Country).Text = item.country;
            view.FindViewById<TextView>(Resource.Id.Description).Text = item.description;
            var imageView = view.FindViewById<ImageView>(Resource.Id.Thumbnail);
            switch (item.country)
            {
                case "United States":
                    imageView.SetImageResource(Resource.Drawable.USA);
                    break;
                case "Russia":
                    imageView.SetImageResource(Resource.Drawable.Russia);
                    break;
                case "China":
                    imageView.SetImageResource(Resource.Drawable.China);
                    break;
                case "United Kingdom":
                    imageView.SetImageResource(Resource.Drawable.UK);
                    break;
            }
            //view.Click += View_Click;
            return view;
        }

        private void View_Click(object sender, EventArgs e)
        {
            View view = sender as View;
            int index = -1;
            int.TryParse(view.Tag.ToString(), out index);
            var itemActivity = new Intent(activity, typeof(DetailActivity));
            itemActivity.PutExtra("MyName", this[index].name);
            itemActivity.PutExtra("MyCountry", this[index].country);
            itemActivity.PutExtra("MyDescription", this[index].description);
            itemActivity.PutExtra("MyImage", this[index].imageSrc);
            activity.StartActivity(itemActivity);

        }
    }
}