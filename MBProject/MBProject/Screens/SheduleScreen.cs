

using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using MBProject;
using Android.Views;

namespace MBProject {
	[Activity (Label = "MySchedule")]			
	public class ScheduleScreen : Activity {
		protected MBProject.ScheduleListAdapter schedulesList;
		protected IList<Schedule> schedule;
		protected ListView scheduleListView = null;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Enable the ActionBar
			RequestWindowFeature(WindowFeatures.ActionBar);

			// set our layout to be the home screen
			SetContentView(Resource.Layout.ScheduleScreen);

			//Find our controls
			scheduleListView = FindViewById<ListView> (Resource.Id.lstSchedule);

			// wire up task click handler
			if(scheduleListView != null) {
				scheduleListView.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) => {
					var scheduleDetails = new Intent (this, typeof (SchedulesDetailsScreen));
					scheduleDetails.PutExtra ("ScheduleID", schedule[e.Position].ID);
					StartActivity (scheduleDetails);
					this.OverridePendingTransition(Resource.Animation.slide_in_top, Resource.Animation.slide_out_bottom);

				};
			}
		}

		protected override void OnResume ()
		{
			base.OnResume ();

			schedule = MBProject.ScheduleManager.GetSchedules();

			// create our adapter
			schedulesList = new MBProject.ScheduleListAdapter(this, schedule);

			//Hook up our adapter to our ListView
			scheduleListView.Adapter = schedulesList;
		}

		public override bool OnCreateOptionsMenu(IMenu menu)
		{
			// Create the actions in the ActionBar.
			MenuInflater.Inflate(Resource.Menu.menu_notesscreen, menu);
			return true;
		}
		public override bool OnOptionsItemSelected(IMenuItem item)
		{
			switch (item.ItemId)

			{
			case Resource.Id.menu_add_note:
				// The user has tapped the add task button
				StartActivity(typeof(SchedulesDetailsScreen));
				return true;

			default:
				return base.OnOptionsItemSelected(item);
			}

		}
	}
}