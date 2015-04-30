using System;
using System.Collections.Generic;
using MBProject;

namespace MBProject
{
	public static class NoteManager
	{
		static NoteManager ()
		{
		}
		
		public static Note GetNote(int id)
		{
			return MBProjectRepository.GetNote(id);
		}
		
		public static IList<Note> GetNotes ()
		{
			return new List<Note>(MBProjectRepository.GetNotes());
		}
		
		public static int SaveNote (Note item)
		{
			return MBProjectRepository.SaveNote(item);
		}
		
		public static int DeleteNote(int id)
		{
			return MBProjectRepository.DeleteNote(id);
		}
		
	}
}