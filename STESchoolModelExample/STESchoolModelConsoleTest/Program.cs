using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using STESchoolModelTypes;
using STESchoolModelConsoleTest.ServiceReference1;

namespace STESchoolModelConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // <snippetSTESchoolModelTestMain>

            // Note, the service's GetDepartments method returns System.Collections.Generic.List.
            // By default, when WCF generates a proxy the return collection types are converted to IEnumerable.
            // The WCF service has to be configured to specify the List return type. 
            // To specify the List collection type, open the Configure Service Reference dialog and 
            // select the System.Collections.Generic.List type from the Collection type list. 

            Console.WriteLine("See the existing departments and courses.");
            DisplayDepartmentsAndCourses();
            Console.WriteLine();
            Console.WriteLine();

            // Use some IDs to create
            // new Department and Course. 
            // The newly created objects will
            // be then deleted.

            int departmentID = 100;

            int courseID = 50;

            AddNewDepartmentAndCourses(departmentID, courseID);
            Console.WriteLine("See existing and added.");
            DisplayDepartmentsAndCourses();
            Console.WriteLine();
            UpdateDepartmentAndCourses(departmentID, courseID);
            Console.WriteLine("See existing and updated.");
            DisplayDepartmentsAndCourses();
            Console.WriteLine();
            DeleteDepartmentAndCourses(departmentID);
            Console.WriteLine("See existing and deleted.");
            DisplayDepartmentsAndCourses();
            // </snippetSTESchoolModelTestMain>
        }
        // <snippetSTESchoolModelTestAll>

        static void DisplayDepartmentsAndCourses()
        {
            using (var service = new Service1Client())
            {
                // Get all the departments.
                List<Department> departments = service.GetDepartments();
                foreach (var d in departments)
                {
                    Console.WriteLine("ID: {0}, Name: {1}", d.DepartmentID, d.Name);
                    // Get all the courses for each department. 
                    // The reason we are able to access
                    // the related courses is because the service eagrly loaded the related objects 
                    // (using the System.Data.Objects.ObjectQuery(T).Include method).
                    foreach (var c in d.Courses.OfType<OnlineCourse>())
                    {
                        Console.WriteLine("  OnLineCourse ID: {0}, Title: {1}", c.CourseID, c.Title);
                    }
                    foreach (var c in d.Courses.OfType<OnsiteCourse>())
                    {
                        Console.WriteLine("  OnSiteCourse ID: {0}, Title: {1}", c.CourseID, c.Title);
                    }
                }
            }
        }


        static void AddNewDepartmentAndCourses(int departmentID, int courseID)
        {
            using (var service = new Service1Client())
            {
                Department newDepartment = new Department()
                {
                    DepartmentID = departmentID,
                    Budget = 13000.000m,
                    Name = "New Department",
                    StartDate = DateTime.Now
                };

                OnlineCourse newCourse = new OnlineCourse()
                { 
                    CourseID = courseID,
                    DepartmentID = departmentID,
                    URL = "http://www.fineartschool.net/Trigonometry",
                    Title = "New Onsite Course",
                    Credits = 4
                };

                // Add the course to the department.
                newDepartment.Courses.Add(newCourse);

                // The newly create objects are marked as added, the service will insert these into the store. 
                service.UpdateDepartment(newDepartment);

                // Let’s make few more changes to the saved object. 
                // Since the previous changes have now been persisted, call AcceptChanges to
                // reset the ChangeTracker on the objects and mark the state as ObjectState.Unchanged.
                // Note, AcceptChanges sets the tracking on, so you do not need to call StartTracking
                // explicitly.
                newDepartment.AcceptChanges();
                newCourse.AcceptChanges();

                // Because the change tracking is enabled
                // the following change will set newCourse.ChangeTracker.State to ObjectState.Modified.
                newCourse.Credits = 6;
                service.UpdateDepartment(newDepartment);

            }
        }

        static void UpdateDepartmentAndCourses(int departmentID, int courseID)
        {
            using (var service = new Service1Client())
            {
                // Get all the departments.
                List<Department> departments = service.GetDepartments();
                // Use LINQ to Objects to query the departments collection 
                // for the specific department object.
                Department department = departments.Single(d => d.DepartmentID == departmentID);
                department.Budget = department.Budget - 1000.00m;

                // Get the specified course that belongs to the department.
                // The reason we are able to access the related course
                // is because the service eagrly loaded the related objects 
                // (using the System.Data.Objects.ObjectQuery(T).Include method).
                Course existingCourse = department.Courses.Single(c => c.CourseID == courseID);
                existingCourse.Credits = 3;

                service.UpdateDepartment(department);
            }
        }

        static void DeleteDepartmentAndCourses(int departmentID)
        {
            using (var service = new Service1Client())
            {
                List<Department> departments = service.GetDepartments();

                Department department = departments.Single(d => d.DepartmentID == departmentID);

                // When MarkAsDeleted is called, the entity is removed from the collection,
                // if we modify the collection over which foreach is looping an exception will be thrown.
                // That is why we need to make a copy of the courses collection by 
                // calling department.Courses.ToList();
                List<Course> courses = department.Courses.ToList();
                foreach (var c in courses)
                {

                    // Marks each comment for the post as Deleted.
                    // If another entity have a foreign key relationship with this Course object
                    // an exception will be thrown during save operation. 
                    c.MarkAsDeleted();
                }

                department.MarkAsDeleted();
                service.UpdateDepartment(department);
            }
        }
        // </snippetSTESchoolModelTestAll>
    }
}
