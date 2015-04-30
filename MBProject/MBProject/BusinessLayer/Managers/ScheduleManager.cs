using System;
using System.Collections.Generic;
using MBProject;

namespace MBProject
{
	public static class ScheduleManager
	{
		static ScheduleManager ()
		{
		}

		public static Schedule GetSchedule(int id)
		{
			return MBProjectRepository.GetSchedule(id);
		}

		public static IList<Schedule> GetSchedules ()
		{
			return new List<Schedule>(MBProjectRepository.GetSchedules());
		}

		public static int SaveSchedule (Schedule item)
		{
			return MBProjectRepository.SaveSchedule(item);
		}

		public static int DeleteSchedule(int id)
		{
			return MBProjectRepository.DeleteSchedule(id);
		}

	}
}