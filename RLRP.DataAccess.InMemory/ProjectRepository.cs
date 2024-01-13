using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using RLRP.Core.Models;

namespace RLRP.DataAccess.InMemory
{ 
  public class ProjectRepository
  {
    ObjectCache cache = MemoryCache.Default;
    List<Project> projects;

    public ProjectRepository()
    {
      projects = cache["projects"] as List<Project>;
      if (projects == null)
      {
        projects = new List<Project>();
      }
    }

    public void Commit()
    {
      cache["projects"] = projects;
    }

    public void Insert(Project p)
    {
      projects.Add(p);
    }

    public void Update(Project project)
    {
      Project projectToUpdate = projects.Find(p => p.Id == project.Id);

      if (projectToUpdate != null)
      {
        projectToUpdate = project;
      }
      else
      {
        throw new Exception("Project Not Found");
      }
    }

    public Project Find(string Id)
    {
      Project project = projects.Find(p => p.Id == Id);

      if (project != null)
      {
        return project;
      }
      else
      {
        throw new Exception("Project Not Found");
      }
    }

    public IQueryable<Project> Collection()
    {
      return projects.AsQueryable();
    }

    public void Delete(string Id)
    {
      Project projectToDelete = projects.Find(p => p.Id == Id);

      if (projectToDelete != null)
      {
        projects.Remove(projectToDelete);
      }
      else
      {
        throw new Exception("Project Not Found");
      }
    }

  }
}
