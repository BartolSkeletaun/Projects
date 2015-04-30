using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using Android.Graphics;
using Android.Views;

using MBProject;
using Android.Util;

namespace MBProject {
	//TODO: implement proper lifecycle methods
	[Activity (Label = "Schedule Item Details")]			
	public class  SchedulesDetailsScreen : Activity {
		protected Schedule schedule = new Schedule();
		protected EditText scheduleTextEdit;
		protected EditText nameTextEdit;
		CheckBox doneCheckbox;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			RequestWindowFeature(WindowFeatures.ActionBar);
			ActionBar.SetDisplayHomeAsUpEnabled(true);
			ActionBar.SetHomeButtonEnabled(true);

			int scheduleID = Intent.GetIntExtra("ScheduleID", 0);
			if(scheduleID > 0) {
				schedule = MBProject.ScheduleManager.GetSchedule(scheduleID);
			}

			// set our layout to be the home screen
			SetContentView(Resource.Layout.ScheduleDetails);

			nameTextEdit = FindViewById<EditText>(Resource.Id.txtName);
			scheduleTextEdit = FindViewById<EditText>(Resource.Id.txtSchedule);
			doneCheckbox = FindViewById<CheckBox>(Resource.Id.chkDone1);

			// name
			if(nameTextEdit != null) { nameTextEdit.Text = schedule.Name; }

			// notes
			if(scheduleTextEdit != null) { scheduleTextEdit.Text = schedule.Schedules; }

			if(doneCheckbox != null) { doneCheckbox.Checked = schedule.Done; }
		}

		protected void Save()
		{
			schedule.Name = nameTextEdit.Text;
			schedule.Schedules = scheduleTextEdit.Text;
			schedule.Done = doneCheckbox.Checked;
			MBProject.ScheduleManager.SaveSchedule(schedule);

			Finish();
			this.OverridePendingTransition(Resource.Animation.slide_in_top, Resource.Animation.slide_out_bottom);

		}

		protected void CancelDelete()
		{
			if(schedule.ID != 0) {
				MBProject.ScheduleManager.DeleteSchedule(schedule.ID);
			}
			Finish();
		}

		public override bool OnCreateOptionsMenu(IMenu menu)
		{
			MenuInflater.Inflate(Resource.Menu.menu_detailsscreen, menu);

			IMenuItem menuItem = menu.FindItem(Resource.Id.menu_delete_note);
			menuItem.SetTitle(schedule.ID == 0 ? "Cancel" : "Delete");

			return true;
		}

		public override bool OnOptionsItemSelected(IMenuItem item)
		{
			switch (item.ItemId)
			{
			case Resource.Id.menu_save_note:
				Save();
				return true;

			case Resource.Id.menu_delete_note:
				CancelDelete();
				return true;

			default: 
				Finish();
				return base.OnOptionsItemSelected(item);

			}
		}

	}
}

