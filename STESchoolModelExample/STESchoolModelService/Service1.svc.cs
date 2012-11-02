using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using STESchoolModelTypes;

namespace STESchoolModelService
{
    // <snippetSTEServiceClass>
    public class Service1 : IService1
    {

        /// <summary>
        /// Updates department and its related courses. 
        /// </summary>
        public void UpdateDepartment(Department updated)
        {
            using (SchoolEntities context =
                new SchoolEntities())
            {
                try
                {
                    // Perform validation on the updated order before applying the changes.

                    // The ApplyChanges method examines the change tracking information 
                    // contained in the graph of self-tracking entities to infer the set of operations
                    // that need to be performed to reflect the changes in the database. 
                    context.Departments.ApplyChanges(updated);
                    context.SaveChanges();

                }
                catch (UpdateException ex)
                {
                    // To avoid propagating exception messages that contain sensitive data to the client tier, 
                    // calls to ApplyChanges and SaveChanges should be wrapped in exception handling code.
                    throw new InvalidOperationException("Failed to update the department. Try your request again.");
                }
            }
        }

        /// <summary>
        /// Gets all the departments and related courses. 
        /// </summary>
        public List<Department> GetDepartments()
        {
            using (SchoolEntities context = new SchoolEntities())
            {
                // Use System.Data.Objects.ObjectQuery(T).Include to eagrly load the related courses.
                return context.Departments.Include("Courses").OrderBy(d => d.Name).ToList();
            }
        }

    }
    // </snippetSTEServiceClass>
}
