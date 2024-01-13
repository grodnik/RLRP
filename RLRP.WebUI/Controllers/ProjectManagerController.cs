using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RLRP.Core.Models;
using RLRP.DataAccess.InMemory;

namespace RLRP.WebUI.Controllers
{
  public class ProjectManagerController : Controller
  {
    ProjectRepository context;

    public ProjectManagerController()
    {
      context = new ProjectRepository();
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
      Project project = new Project();
      return View(project);
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
        return View(project);
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