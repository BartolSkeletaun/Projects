using System;
using System.Collections.Generic;
using System.IO;
using MBProject;

namespace MBProject {
	public class MBProjectRepository {
		MBProjectDatabase db = null;
		protected static string dbLocation;		
		protected static MBProjectRepository me;		
		
		static MBProjectRepository ()
		{
			me = new MBProjectRepository();
		}
		
		protected MBProjectRepository()
		{
			// set the db location
			dbLocation = DatabaseFilePath;
			
			// instantiate the database	
			db = new MBProjectDatabase(dbLocation);
		}
		
		public static string DatabaseFilePath {
			get { 
				var sqliteFilename = "MBProjectDB.db3";

#if NETFX_CORE
                var path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, sqliteFilename);
#else

#if SILVERLIGHT
				// Windows Phone expects a local path, not absolute
	            var path = sqliteFilename;
#else

#if __ANDROID__
				// Just use whatever directory SpecialFolder.Personal returns
	            string libraryPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); ;
#else
				// we need to put in /Library/ on iOS5.1 to meet Apple's iCloud terms
				// (they don't want non-user-generated data in Documents)
				string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal); // Documents folder
				string libraryPath = Path.Combine (documentsPath, "../Library/"); // Library folder
#endif
				var path = Path.Combine (libraryPath, sqliteFilename);
#endif		

#endif
				return path;	
			}
		}

		public static Note GetNote(int id)
		{
            return me.db.GetItem<Note>(id);
		}
		
		public static IEnumerable<Note> GetNotes ()
		{
			return me.db.GetItems<Note>();
		}
		
		public static int SaveNote (Note item)
		{
			return me.db.SaveItem<Note>(item);
		}

		public static int DeleteNote(int id)
		{
			return me.db.DeleteItem<Note>(id);
		}

		public static Schedule GetSchedule(int id)
		{
			return me.db.GetItem<Schedule>(id);
		}

		public static IEnumerable<Schedule> GetSchedules ()
		{
			return me.db.GetItems<Schedule>();
		}

		public static int SaveSchedule (Schedule item)
		{
			return me.db.SaveItem<Schedule>(item);
		}

		public static int DeleteSchedule(int id)
		{
			return me.db.DeleteItem<Schedule>(id);
		}
	}
}

