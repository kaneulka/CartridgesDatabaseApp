using Cartridges.Data;
using Cartridges.Repo.DepartmentRepo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cartridges.Ser.DepartmentSer
{
    public class DepartmentService : IDepartmentService
    {
        private IDepartmentRepo departmentRepository;

        public DepartmentService(IDepartmentRepo departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }

        public IEnumerable<Department> GetDepartments()
        {
            return departmentRepository.GetAll();
        }

        public Department GetDepartment(long id)
        {
            return departmentRepository.Get(id);
        }

        public void InsertDepartment(Department entity)
        {
            departmentRepository.Insert(entity);
        }
        public void UpdateDepartment(Department entity)
        {
            departmentRepository.Update(entity);
        }
        public void DeleteDepartment(long id)
        {
            Department department = GetDepartment(id);
            departmentRepository.Remove(department);
            departmentRepository.SaveChanges();
        }
    }
}
