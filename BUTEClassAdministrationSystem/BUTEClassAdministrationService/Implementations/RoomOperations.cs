using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BUTEClassAdministrationTypes;

namespace BUTEClassAdministrationService
{
	public partial class ClassAdministrationService 
	{	
		public Room[] ReadRooms()
		{
			using (ClassAdministrationEntityContext context = new ClassAdministrationEntityContext())
			{
				return context.RoomSet.ToArray();
			}
		}

		public Room[] ReadRoomsFromCourse(int courseId)
		{
			using (ClassAdministrationEntityContext context = new ClassAdministrationEntityContext())
			{
				return context.RoomSet.Where(room => room.Course.Any(course => course.Id == courseId)).ToArray();
			}
		}
	}
}