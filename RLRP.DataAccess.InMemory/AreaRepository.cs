using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using RLRP.Core.Models;

namespace RLRP.DataAccess.InMemory
{
  public class AreaRepository
  {
    ObjectCache cache = MemoryCache.Default;
    List<Area> areas;

    public AreaRepository()
    {
      areas = cache["areas"] as List<Area>;
      if (areas == null)
      {
        areas = new List<Area>();
      }
    }

    public void Commit()
    {
      cache["areas"] = areas;
    }

    public void Insert(Area p)
    {
      areas.Add(p);
    }

    public void Update(Area area)
    {
      Area areaToUpdate = areas.Find(p => p.Id == area.Id);

      if (areaToUpdate != null)
      {
        areaToUpdate = area;
      }
      else
      {
        throw new Exception("Area Not Found");
      }
    }

    public Area Find(string Id)
    {
      Area area = areas.Find(p => p.Id == Id);

      if (area != null)
      {
        return area;
      }
      else
      {
        throw new Exception("Area Not Found");
      }
    }

    public IQueryable<Area> Collection()
    {
      return areas.AsQueryable();
    }

    public void Delete(string Id)
    {
      Area areaToDelete = areas.Find(p => p.Id == Id);

      if (areaToDelete != null)
      {
        areas.Remove(areaToDelete);
      }
      else
      {
        throw new Exception("Area Not Found");
      }
    }
  }
}
