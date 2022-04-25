using Cartridges.Data;
using Cartridges.Ser.BuildingSer;
using Cartridges.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cartridges.Web.Controllers
{
    public class BuildingController : Controller
    {
        private readonly IBuildingService buildingService;
        public BuildingController(IBuildingService buildingService)
        {
            this.buildingService = buildingService;
        }

        [HttpGet]
        public IActionResult Buildings(int? sortType = 0)
        {
            if (User.IsInRole("admin") || User.IsInRole("user"))
            {
                List<Building> building = buildingService.GetBuildings().ToList();
                switch (sortType)
                {
                    case 0:
                        building = building.OrderBy(e => e.Name).ToList();
                        break;
                    case 1:
                        building = building.OrderByDescending(e => e.Name).ToList();
                        break;

                }
                List<BuildingViewModel> lbvm = new List<BuildingViewModel>();
                foreach (var b in building)
                {
                    BuildingViewModel bvm = new BuildingViewModel
                    {
                        Id = b.Id,
                        Name = b.Name,
                        OtherNames = b.OtherNames,
                        AddedDate = b.AddedDate,
                        ModifiedDate = b.ModifiedDate
                    };
                    lbvm.Add(bvm);
                }

                return View(lbvm);
            }
            return StatusCode(403);
        }

        [HttpGet]
        public IActionResult AddBuilding()
        {
            if (User.IsInRole("admin"))
            {
                BuildingViewModel model = new BuildingViewModel();
                return PartialView("_AddBuilding", model);
            }
            else
            {
                return StatusCode(403);
            }
        }

        [HttpPost]
        public IActionResult AddBuilding(BuildingViewModel model)
        {
            if (User.IsInRole("admin"))
            {
                Building buildingEntity = new Building
                {
                    Name = model.Name,
                    OtherNames = model.OtherNames == null ? "" : model.OtherNames,
                    AddedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                };
                if (ModelState.IsValid)
                {
                    buildingService.InsertBuilding(buildingEntity);
                    if (buildingEntity.Id > 0) return RedirectToAction("Buildings");
                }
                return PartialView("_AddBuilding", model);
            }
            else
            {
                return StatusCode(403);
            }
        }

        [HttpGet]
        public IActionResult EditBuilding(long? id)
        {
            if (User.IsInRole("admin"))
            {
                BuildingViewModel model = new BuildingViewModel();
                if (id.HasValue && id != 0)
                {
                    Building building = buildingService.GetBuilding((long)id);
                    model.Name = building.Name;
                    model.OtherNames = building.OtherNames;
                }
                return PartialView("_EditBuilding", model);
            }
            else
            {
                return StatusCode(403);
            }
        }

        [HttpPost]
        public IActionResult EditBuilding(BuildingViewModel model)
        {
            if (User.IsInRole("admin"))
            {
                Building buildingEntity = buildingService.GetBuilding(model.Id);
                buildingEntity.Name = model.Name;
                buildingEntity.OtherNames = model.OtherNames == null ? "" : model.OtherNames;
                buildingEntity.ModifiedDate = DateTime.Now;

                if (ModelState.IsValid)
                {
                    buildingService.UpdateBuilding(buildingEntity);
                    if (buildingEntity.Id > 0) return RedirectToAction("Buildings");
                }
                return PartialView("_EditBuilding", model);
            }
            else
            {
                return StatusCode(403);
            }
        }

        [HttpGet]
        public IActionResult DeleteBuilding(long? id)
        {
            if (User.IsInRole("admin"))
            {
                BuildingViewModel model = new BuildingViewModel();
                if (id.HasValue && id != 0)
                {
                    Building building = buildingService.GetBuilding((long)id);
                    model.Name = building.Name;
                }
                return PartialView("_DeleteBuilding", model);
            }
            else
            {
                return StatusCode(403);
            }
        }

        [HttpPost]
        public IActionResult DeleteBuilding(long id)
        {
            if (User.IsInRole("admin"))
            {
                buildingService.DeleteBuilding(id);
                return RedirectToAction("Buildings");
            }
            else
            {
                return StatusCode(403);
            }
        }
    }
}
