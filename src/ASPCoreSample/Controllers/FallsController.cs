using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ASPCoreSample.Models;
using ASPCoreSample.Repository;

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
            return View(fallsRepository.FindAll());
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

        // GET: /Falls/Edit/1
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Falls obj = fallsRepository.FindByID(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);

        }

        // POST: /Falls/Edit   
        [HttpPost]
        public IActionResult Edit(Falls obj)
        {

            if (ModelState.IsValid)
            {
                fallsRepository.Update(obj);
                return RedirectToAction("Index");
            }
            return View(obj);
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
    }
}
