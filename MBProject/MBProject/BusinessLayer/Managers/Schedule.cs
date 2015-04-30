using System;
using MBProject;



namespace MBProject
{
	/// <summary>
	/// Represents a Task.
	/// </summary>
	public class Schedule : IBusinessEntity
	{
		public Schedule ()
		{
		}

		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public string Name { get; set; }
		public string Schedules { get; set; }
		// new property
		public bool Done { get; set; }
	}
}


