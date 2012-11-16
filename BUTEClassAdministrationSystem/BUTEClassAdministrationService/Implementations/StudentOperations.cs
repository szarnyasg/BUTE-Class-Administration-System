using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BUTEClassAdministrationTypes;

namespace BUTEClassAdministrationService
{
	public partial class ClassAdministrationService
	{
		public void CreateStudents(Student[] students)
		{
			using (ClassAdministrationEntityContext context = new ClassAdministrationEntityContext())
			{
				foreach (var student in students)
				{
					// skip duplicates
					if (context.StudentSet.Where(Student => Student.Neptun == student.Neptun).Any())
					{
						continue;
					};

					context.StudentSet.ApplyChanges(student);
					context.SaveChanges();
				}
				context.SaveChanges();
			}
		}

		public Student[] ReadStudentsFromSemester(int semesterId)
		{
			using (ClassAdministrationEntityContext context = new ClassAdministrationEntityContext())
			{
				return context.StudentSet.Where(student => student.Semester.Id == semesterId).ToArray();
			}
		}

		public Student[] ReadStudentsFromSemesterAndCourse(int semesterId, int courseId)
		{
			using (ClassAdministrationEntityContext context = new ClassAdministrationEntityContext())
			{
				return context.StudentSet.Where(student => student.Semester.Id == semesterId && student.Course.Id == courseId).ToArray();
			}
		}


		public void UpdateStudents(Student[] students)
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

		public void DeleteStudent(Student[] students)
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


		public void DeleteStudent(int[] studentIds)
		{
			throw new NotImplementedException();
		}

	}
}