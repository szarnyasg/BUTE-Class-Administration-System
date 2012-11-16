using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BUTEClassAdministrationTypes;

namespace BUTEClassAdministrationService
{
	public partial class ClassAdministrationService
	{
		public void CreateCourse(Course[] courses)
		{
			using (ClassAdministrationEntityContext context = new ClassAdministrationEntityContext())
			{
				foreach (var course in courses)
				{
					context.CourseSet.ApplyChanges(course);
				}
				context.SaveChanges();
			}
		}

		public Course[] ReadCoursesFromSemester(int semesterId)
		{
			using (ClassAdministrationEntityContext context = new ClassAdministrationEntityContext())
			{
				return context.CourseSet.Where(course => course.Semester.Id == semesterId).ToArray();
			}
		}


		public void UpdateCourses(Course[] courses)
		{
			using (ClassAdministrationEntityContext context = new ClassAdministrationEntityContext())
			{
				foreach (var course in courses)
				{
					context.CourseSet.ApplyChanges(course);
				}
				context.SaveChanges();
			}
		}

		public void DeleteCourses(int courseIds)
		{
			throw new NotImplementedException();
		}
	}
}