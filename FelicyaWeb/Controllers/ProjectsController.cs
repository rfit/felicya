using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FelicyaDB;
using FelicyaDB.Entities;
using FelicyaClient.Models;
using FelicyaClient.Helpers;
using Microsoft.AspNetCore.Http;
using FelicyaDB.Enums;

namespace FelicyaClient.Controllers
{
    public class ProjectsController : Controller
    {
        private const string SessionProjectKey = "ProjectID";

        private readonly FelicyaContext _context;

        public ProjectsController(FelicyaContext context)
        {
           _context = context;
        }

        public ActionResult Welcome()
        {
          WelcomeModel model = new WelcomeModel();

          return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Welcome(WelcomeModel model)
        {
          if (!ModelState.IsValid)
            return View(model);
      
          if (await _context.Projects.AnyAsync(p => p.ProjectId.ToString() == model.ProjectID))
          {
            ModelState.AddModelError(nameof(WelcomeModel.ProjectID), "Allerede brugt");
            return View(model);
          }

          HttpContext.Session.SetString(SessionProjectKey, model.ProjectID);

          return model.ProjectID == "" ? RedirectToAction("Welcome") : RedirectToAction("Edit");
        }

        // GET: Projects
        public async Task<IActionResult> Index()
        {
            return View(await _context.Projects.ToListAsync());
        }

      // GET: Projects/Details/5
      public async Task<IActionResult> Details(Guid? id)
      {
        if (id == null)
        {
            return NotFound();
        }

        var project = await _context.Projects.FirstOrDefaultAsync(m => m.ProjectId == id);
        if (project == null)
        {
            return NotFound();
        }

        return View(project);
      }

      public async Task<IActionResult> DetailsMaterial(Guid? id)
      {
        if (id == null)
        {
          return NotFound();
        }

        var project = await _context.Materials.FirstOrDefaultAsync(m => m.ProjectId == id);
        if (project == null)
        {
          return NotFound();
        }

      return View(await _context.Materials.Where(m => m.ProjectId == id).ToListAsync());
    }

    // GET: Projects/Create
    public IActionResult Create()
        {
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProjectId,ProjectName,ProjectLeader,ProjectOwner,ProjectDescription,ProjectNumber,BudgetNumber,ConstructionLeader,YearOfConstruction,FestivalDivision,Location,ConstructionPurpose,PhysicalSize,PhysicalCapacity")] Project project)
        {
          if (ModelState.IsValid)
          {
              project.ProjectId = Guid.NewGuid();
              HttpContext.Session.SetString(SessionProjectKey, project.ProjectId.ToString());
              _context.Add(project);
              await _context.SaveChangesAsync();
              return RedirectToAction(nameof(CreateMaterial));
             // return RedirectToAction(nameof(Index));
          }
          return View(project);
        }

    // GET: Projects/Create
    public IActionResult CreateMaterial()
    {
      return View();
    }

    // POST: Projects/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateMaterial([Bind("MaterialId,Type,MaterialSort,Name,Height,Length,Width,NumberOfUnits,CO2Measure,Purpose,Disposal,ProjectId")] Material material)
    {
      if (!HttpContext.Session.TryGetString(SessionProjectKey, out string projectID))
        return RedirectToAction("Welcome");
      if (ModelState.IsValid)
      {
        var enumVærdi = (WoodTypeEnum)Enum.ToObject(typeof(WoodTypeEnum), Convert.ToInt32(material.MaterialSort));
        double Co2Tal = Calculations.GetTotalCo2Pressure(material.Height, material.Length, material.Width, material.NumberOfUnits, enumVærdi);
        material.CO2Measure = Convert.ToInt32(Co2Tal);
        material.ProjectId = new Guid(projectID);
        _context.Add(material);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      return View(material);
    }

    // GET: Projects/Edit/5
    public async Task<IActionResult> Edit(Guid? id, WelcomeModel model)
    {
      if (!HttpContext.Session.TryGetString(SessionProjectKey, out string ProjectID))
        return RedirectToAction("Welcome");

      if (/*id == null &&*/ ProjectID == "")
      {
          return NotFound();
      }

      var guid = _context.Projects.Where(p => p.ProjectNumber.ToString() == ProjectID).FirstOrDefault().ProjectId;
      var project = await _context.Projects.FindAsync(guid);
      if (project == null)
      {
          return NotFound();
      }
      return View(project);
    }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ProjectId,ProjectName,ProjectLeader,ProjectOwner,ProjectDescription,ProjectNumber,BudgetNumber,ConstructionLeader,YearOfConstruction,FestivalDivision,Location,ConstructionPurpose,PhysicalSize,PhysicalCapacity")] Project project)
        {
            //TODO: Dette tjek skal laves
           /* if (id != project.ProjectId)
            {
                return NotFound();
            }*/

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(project);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(project.ProjectId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(project);
        }

        // GET: Projects/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects
                .FirstOrDefaultAsync(m => m.ProjectId == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var project = await _context.Projects.FindAsync(id);
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectExists(Guid id)
        {
            return _context.Projects.Any(e => e.ProjectId == id);
        }
    }
}
