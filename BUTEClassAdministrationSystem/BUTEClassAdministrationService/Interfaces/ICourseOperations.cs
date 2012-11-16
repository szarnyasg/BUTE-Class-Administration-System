using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using BUTEClassAdministrationTypes;

namespace BUTEClassAdministrationService
{
	[ServiceContract]
	public interface ICourseOperations
	{
		[OperationContract]
		void CreateCourse(Course[] courses);

		[OperationContract]
		Course[] ReadCoursesFromSemester(int semesterId);

		[OperationContract]
		void UpdateCourses(Course[] courses);

		[OperationContract]
		void DeleteCourses(int courseIds);
	}
}
