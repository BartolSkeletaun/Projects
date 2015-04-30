using System;

using Android.OS;
using Android.Support.V4.App;
using Android.App;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace MBProject
{
[Activity(Label = "Build Stages")]
public class DetailsActivity : FragmentActivity
{
    protected override void OnCreate(Bundle bundle)
    {
        base.OnCreate(bundle);
		
        var index = Intent.Extras.GetInt("current_play_id", 0);

        var details = DetailsFragment.NewInstance(index); // Details

        var fragmentTransaction = SupportFragmentManager.BeginTransaction();
        fragmentTransaction.Add(Android.Resource.Id.Content, details);
        fragmentTransaction.Commit();
    }
}
}