using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace FamousCities
{
    [Activity(Label = "FamousCities", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private Button mButton;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView (Resource.Layout.Main);
            //ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
            mButton = FindViewById<Button>(Resource.Id.button1);

            mButton.Click += MButton_Click;
        }

        private void MButton_Click(object sender, System.EventArgs e)
        {
            var itemActivity = new Intent(this, typeof(ItemActivity));
            itemActivity.PutExtra("MyExtras", "data from main activity");
            StartActivity(itemActivity);
        }
    }
}

