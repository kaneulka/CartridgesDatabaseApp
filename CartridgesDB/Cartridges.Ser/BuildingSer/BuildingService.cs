using Cartridges.Data;
using Cartridges.Repo.BuildingRepo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cartridges.Ser.BuildingSer
{
    public class BuildingService : IBuildingService
    {
        private IBuildingRepo buildingRepository;

        public BuildingService(IBuildingRepo buildingRepository)
        {
            this.buildingRepository = buildingRepository;
        }
        
        public IEnumerable<Building> GetBuildings()
        {
            return buildingRepository.GetAll();
        }

        public Building GetBuilding(long id)
        {
            return buildingRepository.Get(id);
        }

        public void InsertBuilding(Building entity)
        {
            buildingRepository.Insert(entity);
        }
        public void UpdateBuilding(Building entity)
        {
            buildingRepository.Update(entity);
        }
        public void DeleteBuilding(long id)
        {
            Building building = GetBuilding(id);
            buildingRepository.Remove(building);
            buildingRepository.SaveChanges();
        }
    }
}
