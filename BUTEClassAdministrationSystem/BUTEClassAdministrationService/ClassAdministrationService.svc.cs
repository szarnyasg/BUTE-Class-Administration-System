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
		#region Semester operations

		public IEnumerable<Semester> ReadSemesters()
		{
			using (ClassAdministrationEntityContext context = new ClassAdministrationEntityContext())
			{
				return context.SemesterSet.ToList();
			}
		}

		#endregion




		#region Student operations

		public void CreateStudents(IEnumerable<Student> students)
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

		public IEnumerable<Student> ReadStudentsFromSemester(Semester semester)
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




		#region Course operations

		public void CreateCourse(IEnumerable<Course> courses)
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

		public IEnumerable<Course> ReadCoursesFromSemester(Semester semester)
		{
			using (ClassAdministrationEntityContext context = new ClassAdministrationEntityContext())
			{
				return context.CourseSet.Where(Course => Course.Semester.Equals(semester)).ToList();
			}
		}

		public void UpdateCourses(IEnumerable<Course> courses)
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

		public void DeleteCourses(IEnumerable<Course> courses)
		{
			using (ClassAdministrationEntityContext context = new ClassAdministrationEntityContext())
			{
				foreach (var course in courses)
				{
					course.ChangeTracker.State = BUTEClassAdministrationTypes.ObjectState.Deleted;
					context.CourseSet.ApplyChanges(course);
				}

				context.SaveChanges();
			}
		}

		#endregion




		#region Group operations

		public void CreateGroup(IEnumerable<Group> groups)
		{
			using (ClassAdministrationEntityContext context = new ClassAdministrationEntityContext())
			{
				foreach (var group in groups)
				{
					context.GroupSet.ApplyChanges(group);
				}
				context.SaveChanges();
			}
		}

		public IEnumerable<Group> ReadGroupsFromSemester(Semester semester)
		{
			using (ClassAdministrationEntityContext context = new ClassAdministrationEntityContext())
			{
				return context.GroupSet.Where(Group => Group.Semester.Equals(semester)).ToList();
			}
		}

		public void UpdateGroups(IEnumerable<Group> groups)
		{
			using (ClassAdministrationEntityContext context = new ClassAdministrationEntityContext())
			{
				foreach (var group in groups)
				{
					context.GroupSet.ApplyChanges(group);
				}
				context.SaveChanges();
			}
		}

		public void DeleteGroups(IEnumerable<Group> groups)
		{
			using (ClassAdministrationEntityContext context = new ClassAdministrationEntityContext())
			{
				foreach (var group in groups)
				{
					group.ChangeTracker.State = BUTEClassAdministrationTypes.ObjectState.Deleted;
					context.GroupSet.ApplyChanges(group);
				}

				context.SaveChanges();
			}
		}

		#endregion




		#region Instructor operations

		public void CreateInstructor(IEnumerable<Instructor> instructors)
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

		public IEnumerable<Instructor> ReadInstructors()
		{
			using (ClassAdministrationEntityContext context = new ClassAdministrationEntityContext())
			{
				return context.InstructorSet.ToList();
			}
		}

		public void UpdateInstructors(IEnumerable<Instructor> instructors)
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

		public void DeleteInstructors(IEnumerable<Instructor> instructors)
		{
			using (ClassAdministrationEntityContext context = new ClassAdministrationEntityContext())
			{
				foreach (var instructor in instructors)
				{
					instructor.ChangeTracker.State = BUTEClassAdministrationTypes.ObjectState.Deleted;
					context.InstructorSet.ApplyChanges(instructor);
				}

				context.SaveChanges();
			}
		}

		#endregion




		#region Room operations

		public IEnumerable<Room> ReadRooms()
		{
			using (ClassAdministrationEntityContext context = new ClassAdministrationEntityContext())
			{
				return context.RoomSet.ToList();
			}
		}

		#endregion
	}
}
