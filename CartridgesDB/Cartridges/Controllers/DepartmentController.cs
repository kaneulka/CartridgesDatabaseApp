using Cartridges.Data;
using Cartridges.Ser.DepartmentSer;
using Cartridges.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cartridges.Web.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            this.departmentService = departmentService;
        }

        [HttpGet]
        public IActionResult Departments(int? sortType = 0)
        {
            if (User.IsInRole("admin") || User.IsInRole("user"))
            {
                List<Department> department = departmentService.GetDepartments().ToList();
                switch (sortType)
                {
                    case 0:
                        department = department.OrderBy(e => e.Name).ToList();
                        break;
                    case 1:
                        department = department.OrderByDescending(e => e.Name).ToList();
                        break;

                }
                List<DepartmentViewModel> lbvm = new List<DepartmentViewModel>();
                foreach (var b in department)
                {
                    DepartmentViewModel bvm = new DepartmentViewModel
                    {
                        Id = b.Id,
                        Name = b.Name,
                        AddedDate = b.AddedDate,
                        ModifiedDate = b.ModifiedDate,
                        OtherNames = b.OtherNames
                    };
                    lbvm.Add(bvm);
                }

                return View(lbvm);
            }
                return StatusCode(403);

        }

        [HttpGet]
        public IActionResult AddDepartment()
        {
            if (User.IsInRole("admin"))
            {
                DepartmentViewModel model = new DepartmentViewModel();
                return PartialView("_AddDepartment", model);
            }
            else
            {
                return StatusCode(403);
            }
        }

        [HttpPost]
        public IActionResult AddDepartment(DepartmentViewModel model)
        {
            if (User.IsInRole("admin"))
            {
                Department departmentEntity = new Department
                {
                    Name = model.Name,
                    OtherNames = model.OtherNames == null ? "" : model.OtherNames,
                    AddedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                };
                if (ModelState.IsValid)
                {
                    departmentService.InsertDepartment(departmentEntity);
                    if (departmentEntity.Id > 0) return RedirectToAction("Departments");
                }
                return PartialView("_AddDepartment", model);
            }
            else
            {
                return StatusCode(403);
            }
        }

        [HttpGet]
        public IActionResult EditDepartment(long? id)
        {
            if (User.IsInRole("admin"))
            {
                DepartmentViewModel model = new DepartmentViewModel();
                if (id.HasValue && id != 0)
                {
                    Department department = departmentService.GetDepartment((long)id);
                    model.Name = department.Name;
                    model.OtherNames = department.OtherNames;
                }

                return PartialView("_EditDepartment", model);
            }
            else
            {
                return StatusCode(403);
            }
        }

        [HttpPost]
        public IActionResult EditDepartment(DepartmentViewModel model)
        {
            if (User.IsInRole("admin"))
            {
                Department departmentEntity = departmentService.GetDepartment(model.Id);
                departmentEntity.Name = model.Name;
                departmentEntity.OtherNames = model.OtherNames == null ? "" : model.OtherNames;
                departmentEntity.ModifiedDate = DateTime.Now;

                if (ModelState.IsValid)
                {
                    departmentService.UpdateDepartment(departmentEntity);
                    if (departmentEntity.Id > 0) return RedirectToAction("Departments");
                }
                return PartialView("_EditDepartment", model);
            }
            else
            {
                return StatusCode(403);
            }
        }

        [HttpGet]
        public IActionResult DeleteDepartment(long? id)
        {
            if (User.IsInRole("admin"))
            {
                DepartmentViewModel model = new DepartmentViewModel();
                if (id.HasValue && id != 0)
                {
                    Department department = departmentService.GetDepartment((long)id);
                    model.Name = department.Name;
                }
                return PartialView("_DeleteDepartment", model);
            }
            else
            {
                return StatusCode(403);
            }
        }

        [HttpPost]
        public IActionResult DeleteDepartment(long id)
        {
            if (User.IsInRole("admin"))
            {
                departmentService.DeleteDepartment(id);
                return RedirectToAction("Departments");
            }
            else
            {
                return StatusCode(403);
            }
        }
    }
}
