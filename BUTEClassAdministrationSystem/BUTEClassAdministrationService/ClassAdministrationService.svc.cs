using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

using BUTEClassAdministrationTypes;

namespace BUTEClassAdministrationService
{
	public class ClassAdministrationService : IClassAdministrationService
	{
		#region Student operations

		public void CreateStudents(IEnumerable<Student> students)
		{
			using (ClassAdministrationEntityContext context = new ClassAdministrationEntityContext())
			{
				foreach (var student in students)
				{
					context.StudentSet.AddObject(student);
				}
			}
		}
		
		public IEnumerable<Student> ReadStudentsFromSemester(string semester)
		{
			using (ClassAdministrationEntityContext context = new ClassAdministrationEntityContext())
			{
				return context.StudentSet.Where(Student => Student.Semester.Equals(semester)).ToList();
			}
		}

		public void UpdateStudents(IEnumerable<Student> students)
		{
			using (ClassAdministrationEntityContext context = new ClassAdministrationEntityContext())
			{
				foreach (var student in students)
				{
					context.StudentSet.ApplyChanges(student);
				}
				context.SaveChanges();
			}
		}

		public void DeleteStudent(IEnumerable<Student> students)
		{
			using (ClassAdministrationEntityContext context = new ClassAdministrationEntityContext())
			{
				foreach (var student in students)
				{
					student.ChangeTracker.State = BUTEClassAdministrationTypes.ObjectState.Deleted;
					context.StudentSet.ApplyChanges(student);
				}
				
				context.SaveChanges();
			}
		}

		#endregion
	}
}
