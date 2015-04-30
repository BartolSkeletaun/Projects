using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using MBProject;
using Android.Views;

namespace MBProject {
	[Activity (Label = "Site Notes")]			
	public class NotesScreen : Activity {
		protected MBProject.NoteListAdapter notesList;
		protected IList<Note> notes;
		protected ListView notesListView = null;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Enable the ActionBar
			RequestWindowFeature(WindowFeatures.ActionBar);

			// set our layout to be the home screen
			SetContentView(Resource.Layout.NotesScreen);

			//Find our controls
			notesListView = FindViewById<ListView> (Resource.Id.lstNotes);

			// wire up task click handler
			if(notesListView != null) {
				notesListView.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) => {
					var noteDetails = new Intent (this, typeof (NotesDetailsScreen));
					noteDetails.PutExtra ("NoteID", notes[e.Position].ID);
					StartActivity (noteDetails);
					this.OverridePendingTransition(Resource.Animation.slide_in_top, Resource.Animation.slide_out_bottom);
			

				};
			}
		}

		protected override void OnResume ()
		{
			base.OnResume ();

			notes = MBProject.NoteManager.GetNotes();

			// create our adapter
			notesList = new MBProject.NoteListAdapter(this, notes);

			//Hook up our adapter to our ListView
			notesListView.Adapter = notesList;
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
				StartActivity(typeof(NotesDetailsScreen));
				return true;

			default:
				return base.OnOptionsItemSelected(item);
			}

		}
	}
}