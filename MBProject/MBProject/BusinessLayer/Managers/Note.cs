using System;
using MBProject;



namespace MBProject
{
	/// <summary>
	/// Represents a Task.
	/// </summary>
	public class Note : IBusinessEntity
	{
		public Note ()
		{
		}

		[PrimaryKey, AutoIncrement]
        public int ID { get; set; }
		public string Name { get; set; }
		public string Notes { get; set; }
		// new property
		public bool Done { get; set; }
	}
}

