using Cartridges.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cartridges.Ser.DepartmentSer
{
    public interface IDepartmentService
    {
        IEnumerable<Department> GetDepartments();
        Department GetDepartment(long id);
        void InsertDepartment(Department entity);
        void UpdateDepartment(Department entity);
        void DeleteDepartment(long id);
    }
}
