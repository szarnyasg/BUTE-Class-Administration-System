using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using STESchoolModelTypes;

namespace STESchoolModelService
{
    // <snippetSTEServiceInterface>
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        void UpdateDepartment(Department updated);
        [OperationContract]
        List<Department> GetDepartments();
    }
    // </snippetSTEServiceInterface>
}
