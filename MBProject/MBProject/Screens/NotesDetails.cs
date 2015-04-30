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
	[Activity (Label = "Site Note Details")]			
	public class  NotesDetailsScreen : Activity {
		protected Note note = new Note();
		protected EditText notesTextEdit;
		protected EditText nameTextEdit;
		CheckBox doneCheckbox;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			RequestWindowFeature(WindowFeatures.ActionBar);
			ActionBar.SetDisplayHomeAsUpEnabled(true);
			ActionBar.SetHomeButtonEnabled(true);

			int noteID = Intent.GetIntExtra("NoteID", 0);
			if(noteID > 0) {
				note = MBProject.NoteManager.GetNote(noteID);
			}

			// set our layout to be the home screen
			SetContentView(Resource.Layout.NoteDetails);

			nameTextEdit = FindViewById<EditText>(Resource.Id.txtName);
			notesTextEdit = FindViewById<EditText>(Resource.Id.txtNotes);
			doneCheckbox = FindViewById<CheckBox>(Resource.Id.chkDone);

			// name
			if(nameTextEdit != null) { nameTextEdit.Text = note.Name; }

			// notes
			if(notesTextEdit != null) { notesTextEdit.Text = note.Notes; }

			if(doneCheckbox != null) { doneCheckbox.Checked = note.Done; }
		}

		protected void Save()
		{
			note.Name = nameTextEdit.Text;
			note.Notes = notesTextEdit.Text;
			note.Done = doneCheckbox.Checked;
			MBProject.NoteManager.SaveNote(note);

			Finish();
			this.OverridePendingTransition(Resource.Animation.slide_in_top, Resource.Animation.slide_out_bottom);

		}

		protected void CancelDelete()
		{
			if(note.ID != 0) {
				MBProject.NoteManager.DeleteNote(note.ID);
			}
			Finish();
		}

		public override bool OnCreateOptionsMenu(IMenu menu)
		{
			MenuInflater.Inflate(Resource.Menu.menu_detailsscreen, menu);

			IMenuItem menuItem = menu.FindItem(Resource.Id.menu_delete_note);
			menuItem.SetTitle(note.ID == 0 ? "Cancel" : "Delete");

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

