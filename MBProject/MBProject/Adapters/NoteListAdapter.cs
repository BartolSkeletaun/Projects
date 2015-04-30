using System;
using System.Collections.Generic;
using Android.Widget;
using MBProject;
using Android.App;
using Android;
using Android.Views;

namespace MBProject {
	public class NoteListAdapter : BaseAdapter<Note> {
		protected Activity context = null;
		protected IList<Note> notes = new List<Note>();
		
		public NoteListAdapter (Activity context, IList<Note> notes) : base ()
		{
			this.context = context;
			this.notes = notes;
		}
		
		public override Note this[int position]
		{
			get { return notes[position]; }
		}
		
		public override long GetItemId (int position)
		{
			return position;
		}
		
		public override int Count
		{
			get { return notes.Count; }
		}
		
		public override Android.Views.View GetView (int position, Android.Views.View convertView, Android.Views.ViewGroup parent)
		{
			// Get our object for position
			var item = notes[position];			
            View view;

            //Try to reuse convertView if it's not  null, otherwise inflate it from our item layout
            // gives us some performance gains by not always inflating a new view
            if (convertView == null)
            {
                view = context.LayoutInflater.Inflate(Resource.Layout.NoteListItem, null);
            }
            else
            {
                view = convertView;
            }

            var nameLabel = view.FindViewById<TextView>(Resource.Id.lblName);
            nameLabel.Text = item.Name;
            var notesLabel = view.FindViewById<TextView>(Resource.Id.lblDescription);
            notesLabel.Text = item.Notes;

            // TODO: set the check.
            var checkMark = view.FindViewById<ImageView>(Resource.Id.checkMark);
            checkMark.Visibility = item.Done ? ViewStates.Visible : ViewStates.Gone;

			//Finally return the view
			return view;
		}
	}
}