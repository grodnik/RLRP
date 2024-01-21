using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RLRP.Core.Contracts;
using RLRP.Core.Models;
using RLRP.Core.ViewModels;
using RLRP.DataAccess.InMemory;

namespace RLRP.WebUI.Controllers
{
  public class ProjectManagerController : Controller
  {
    IRepository<Project> context;
    IRepository<Area> areas;

    public ProjectManagerController(IRepository<Project> projectContext, IRepository<Area> areaContext)
    {
      context = projectContext;
      areas = areaContext;
    }
        
    // GET: ProjectManager
    public ActionResult Index()
    {
      List <Project> projects = context.Collection().ToList();
      return View(projects);
    }

    // CREATE
    public ActionResult Create()
    {
      ProjectManagerViewModel viewModel = new ProjectManagerViewModel();

      viewModel.Project = new Project();
      viewModel.Areas = areas.Collection();
      return View(viewModel);
    }

    [HttpPost]
    public ActionResult Create(Project project)
    {
      if (!ModelState.IsValid)
      {
        return View(project);
      }
      else
      {
        context.Insert(project);
        context.Commit();

        return RedirectToAction("Index");
      }
    }

    // EDIT: Project

    public ActionResult Edit(string Id)
    {
      Project project = context.Find(Id);
      if (project == null)
      {
        return HttpNotFound();
      }
      else
      {
        ProjectManagerViewModel viewModel = new ProjectManagerViewModel();
        viewModel.Project = project;
        viewModel.Areas = areas.Collection();

        return View(viewModel);
      }
    }

    [HttpPost]
    public ActionResult Edit(Project project, string Id)
    {
      Project projectToEdit = context.Find(Id);
      if (projectToEdit == null)
      {
        return HttpNotFound();
      }
      else
      {
        if(!ModelState.IsValid)
        {
          return View(project);
        }

        projectToEdit.Title = project.Title;
        projectToEdit.Area = project.Area;
        projectToEdit.Status = project.Status;
        projectToEdit.OldNbr = project.OldNbr;
        projectToEdit.DefinedDate = project.DefinedDate;
        projectToEdit.BudgetYear = project.BudgetYear;
        projectToEdit.BudgetCost = project.BudgetCost;
        projectToEdit.BudgetLife = project.BudgetLife;
        projectToEdit.OddEven = project.OddEven;
        projectToEdit.Notes = project.Notes;

        context.Commit();


        return RedirectToAction("Index");
      }
    }

    // DELETE

    public ActionResult Delete(string Id)
    {
      Project projectToDelete = context.Find(Id);
      if (projectToDelete == null)
      {
        return HttpNotFound();
      }
      else
      {
        return View(projectToDelete);
      }

    }

    [HttpPost]
    [ActionName("Delete")]
    public ActionResult ConfirmDelete(string Id)
    {
      Project projectToDelete = context.Find(Id);
      if (projectToDelete == null)
      {
        return HttpNotFound();
      }
      else
      {
        context.Delete(Id);
        context.Commit();
        return RedirectToAction("Index");
      }
    }
     
  }
} 