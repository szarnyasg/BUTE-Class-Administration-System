using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BUTEClassAdministrationTypes;

namespace BUTEClassAdministrationService
{
	public partial class ClassAdministrationService
	{
		public void CreateInstructor(Instructor[] instructors)
		{
			using (ClassAdministrationEntityContext context = new ClassAdministrationEntityContext())
			{
				foreach (var instructor in instructors)
				{
					context.InstructorSet.ApplyChanges(instructor);
				}
				context.SaveChanges();
			}
		}

		public Instructor[] ReadInstructors()
		{
			using (ClassAdministrationEntityContext context = new ClassAdministrationEntityContext())
			{
				return context.InstructorSet.ToArray();
			}
		}

		public void UpdateInstructors(Instructor[] instructors)
		{
			using (ClassAdministrationEntityContext context = new ClassAdministrationEntityContext())
			{
				foreach (var instructor in instructors)
				{
					context.InstructorSet.ApplyChanges(instructor);
				}
				context.SaveChanges();
			}
		}

		public void DeleteInstructors(int[] instructorIds)
		{
			using (ClassAdministrationEntityContext context = new ClassAdministrationEntityContext())
			{
				foreach (var instructorId in instructorIds)
				{
					var entity = new Instructor { Id = instructorId };
					
				}
			}
		}
	}
}