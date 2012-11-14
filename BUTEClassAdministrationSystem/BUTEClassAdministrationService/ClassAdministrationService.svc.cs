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

		public void CreateStudents(Student[] students)
		{
			using (ClassAdministrationEntityContext context = new ClassAdministrationEntityContext())
			{
				foreach (var student in students)
				{
					// skip duplicates
					if (context.StudentSet.ToList().Where(Student => Student.Neptun == student.Neptun).Any())
					{
						continue;
					};
					
					context.StudentSet.ApplyChanges(student);
					context.SaveChanges();
				}
				context.SaveChanges();
			}
		}

		public Student[] ReadStudentsFromSemester(Semester semester)
		{
			using (ClassAdministrationEntityContext context = new ClassAdministrationEntityContext())
			{
				return context.StudentSet.ToList().Where(Student => Student.Semester.Equals(semester)).ToArray();
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

		#endregion




		#region Course operations

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

		public Course[] ReadCoursesFromSemester(Semester semester)
		{
			using (ClassAdministrationEntityContext context = new ClassAdministrationEntityContext())
			{
                List<Course> courses = new List<Course>();

                foreach (var course in context.CourseSet.ToList())
                {
                    if (course.Semester != null)
                    {
                        courses.Add(course);
                    }
                }

                return courses.ToArray();
                //return context.CourseSet.ToArray().Where(Course => Course.Semester.Equals(semester)).ToArray();
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

		public void DeleteCourses(Course[] courses)
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

		public void CreateGroup(Group[] groups)
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

		public Group[] ReadGroupsFromSemester(Semester semester)
		{
			using (ClassAdministrationEntityContext context = new ClassAdministrationEntityContext())
			{
				return context.GroupSet.ToList().Where(Group => Group.Semester.Equals(semester)).ToArray();
			}
		}

		public void UpdateGroups(Group[] groups)
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

		public void DeleteGroups(Group[] groups)
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

		public void DeleteInstructors(Instructor[] instructors)
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
