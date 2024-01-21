using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RLRP.Core.Contracts;
using RLRP.Core.Models;
using RLRP.DataAccess.InMemory;

namespace RLRP.WebUI.Controllers
{
  public class AreaManagerController : Controller
  {
   IRepository<Area> context;

    public AreaManagerController(IRepository<Area> areaContext)
    {
      context = areaContext; 
    }

    // GET: AreaManager
    public ActionResult Index()
    {
      List<Area> areas = context.Collection().ToList();
      return View(areas);
    }

    // CREATE
    public ActionResult Create()
    {
      Area area = new Area();
      return View(area);
    }

    [HttpPost]
    public ActionResult Create(Area area)
    {
      if (!ModelState.IsValid)
      {
        return View(area);
      }
      else
      {
        context.Insert(area);
        context.Commit();

        return RedirectToAction("Index");
      }
    }

    // EDIT: Area

    public ActionResult Edit(string Id)
    {
      Area area = context.Find(Id);
      if (area == null)
      {
        return HttpNotFound();
      }
      else
      {
        return View(area);
      }
    }

    [HttpPost]
    public ActionResult Edit(Area area, string Id)
    {
      Area areaToEdit = context.Find(Id);
      if (areaToEdit == null)
      {
        return HttpNotFound();
      }
      else
      {
        if (!ModelState.IsValid)
        {
          return View(area);
        }

      
        areaToEdit.AreaName = area.AreaName;


        context.Commit();


        return RedirectToAction("Index");
      }
    }

    // DELETE

    public ActionResult Delete(string Id)
    {
      Area areaToDelete = context.Find(Id);
      if (areaToDelete == null)
      {
        return HttpNotFound();
      }
      else
      {
        return View(areaToDelete);
      }

    }

    [HttpPost]
    [ActionName("Delete")]
    public ActionResult ConfirmDelete(string Id)
    {
      Area areaToDelete = context.Find(Id);
      if (areaToDelete == null)
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