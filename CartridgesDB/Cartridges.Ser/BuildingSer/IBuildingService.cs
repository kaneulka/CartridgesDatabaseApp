using Cartridges.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cartridges.Ser.BuildingSer
{
    public interface IBuildingService
    {
        IEnumerable<Building> GetBuildings();
        Building GetBuilding(long id);
        void InsertBuilding(Building entity);
        void UpdateBuilding(Building entity);
        void DeleteBuilding(long id);
    }
}
