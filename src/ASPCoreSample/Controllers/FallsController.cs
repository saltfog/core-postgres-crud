using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ASPCoreSample.Models;
using ASPCoreSample.Repository;
using System.Linq;
using System.Collections.Generic;

namespace ASPCoreSample.Controllers
{
    public class FallsController : Controller
    {
        private readonly FallsRepository fallsRepository;

        public FallsController(IConfiguration configuration)
        {
            fallsRepository = new FallsRepository(configuration);
        }

        public IActionResult Index()
        {
            var list = fallsRepository.FindAll().ToList();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        // POST: Falls/Create
        [HttpPost]
        public IActionResult Create(Falls fall)
        {
            if (ModelState.IsValid)
            {
                fallsRepository.Add(fall);
                return RedirectToAction("Index");
            }
            return View(fall);

        }

        //GET: /Falls/Edit/1
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Falls fall = fallsRepository.FindByID(id.Value);
            if (fall == null)
            {
                return NotFound();
            }
            return View(fall);

        }

        // POST: /Falls/Edit   
        [HttpPost]
        public IActionResult Edit(Falls fall)
        {
            if (ModelState.IsValid)
            {
                fallsRepository.Update(fall);
                return RedirectToAction("Index", "Falls");
            }
            else
            {
                return View(fall);
            } 
        }

        // GET:/Falls/Delete/1
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            fallsRepository.Remove(id.Value);
            return RedirectToAction("Index");
        }

        public IActionResult CheckForDuplicates(string name)
        {
            if(name.Contains(name))
            {
                return Json("Water Fall already exists");
            }

            return Json(true);
        }

        public IActionResult OpenToPublic()
        {
            return View(fallsRepository.Public());
        }
    }
}
