
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

namespace MBProject
{


	public class ScheduleListViewAdapter : BaseAdapter<string>

	{
		private List<string> sItems;
		private Context sContext;

		public ScheduleListViewAdapter(Context context, List<string> items){
			sItems = items;
			sContext = context;


		}

		public override int Count {
			
			get {return sItems.Count;}
		}

		public override long GetItemId(int position){

			return position;
		}

		public override string this[int position] 
		{
			get { return sItems [position];}
		}

		public override View GetView(int position, View convertView, ViewGroup parent){


			View row = convertView;

			if (row == null) {
				
				row = LayoutInflater.From (sContext).Inflate(Resource.Layout.Frag2Layout, null, false);

			}

//			TextView txtName = row.FindViewById<TextView> (Resource.Id.textView1);
//			txtName.Text = sItems [position];

			return row;
		}
}

}



























//List<string> ScheduleItems;
//Fragment lContext;
//
//public ScheduleListViewAdapter(Fragment context, List<string> items){
//
//	ScheduleItems = items;
//	lContext = context;
//
//}
//
//public override int Count{
//
//	get{ return ScheduleItems.Count;}
//
//}
//
//public override long GetItemId(int Position){
//
//	return Position;
//}
//
//
////indexer - returns string 
//
//public override string this[int Position]
//{
//
//
//	get {return ScheduleItems[Position];}
//
//}
//
////get the view
//
//public override View GetView (int Position, View convertView, ViewGroup parent)
//{
//	View row = convertView;
//
//	if (row = null) {
//
//		row = LayoutInflater.From (lContext).Inflate (Resource.Layout.ScheduleSample, null, false);
//
//	}
//
//	TextView titletxt = row.FindViewById<TextView>(Resource.Id.sample_row);
//	titletxt.Text = ScheduleItems[Position];
//
//	return row;
//}