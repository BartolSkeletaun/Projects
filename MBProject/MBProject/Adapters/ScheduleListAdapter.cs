using System;
using System.Collections.Generic;
using Android.Widget;
using MBProject;
using Android.App;
using Android;
using Android.Views;

namespace MBProject {
	public class ScheduleListAdapter : BaseAdapter<Schedule> {
		protected Activity context = null;
		protected IList<Schedule> schedules = new List<Schedule>();

		public ScheduleListAdapter (Activity context, IList<Schedule> schedules) : base ()
		{
			this.context = context;
			this.schedules = schedules;
		}

		public override Schedule this[int position]
		{
			get { return schedules[position]; }
		}

		public override long GetItemId (int position)
		{
			return position;
		}

		public override int Count
		{
			get { return schedules.Count; }
		}

		public override Android.Views.View GetView (int position, Android.Views.View convertView, Android.Views.ViewGroup parent)
		{
			// Get our object for position
			var item = schedules[position];			
			View view;

			//Try to reuse convertView if it's not  null, otherwise inflate it from our item layout
			// gives us some performance gains by not always inflating a new view
			if (convertView == null)
			{
				view = context.LayoutInflater.Inflate(Resource.Layout.ScheduleListItem, null);
			}
			else
			{
				view = convertView;
			}

			var nameLabel = view.FindViewById<TextView>(Resource.Id.lblName1);
			nameLabel.Text = item.Name;
			var schedulesLabel = view.FindViewById<TextView>(Resource.Id.lblScheduleItemDetails);
			schedulesLabel.Text = item.Schedules;

			// TODO: set the check.
			var checkMark = view.FindViewById<ImageView>(Resource.Id.checkMark1);
			checkMark.Visibility = item.Done ? ViewStates.Visible : ViewStates.Gone;

			//Finally return the view
			return view;
		}
	}
}