using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComputerTime.Shared;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Data;
using WebAppAzureAD.Models;

namespace WebAppAzureAD.Controllers
{
    public class PlayExceptionController : Controller
    {
        private readonly IPlayExceptionRepository repository;

        public PlayExceptionController(IWebHostEnvironment hostEnvironment, IPlayExceptionRepository repository)
        {
            var dbPath = System.IO.Path.Combine(hostEnvironment.WebRootPath, "App_Data", "ex.json");
            this.repository = repository;
            this.repository.DbPath = dbPath;
        }
        // GET: PlayException
        public ActionResult Index()
        {
            var list = repository.Get();
            return View(list);
        }

        // GET: PlayException/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PlayException/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PlayException/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var model = new PlayException();
                model.Start = DateTime.Parse(collection["Start"]);
                model.Duration = int.Parse(collection["Duration"]);
                model.Reason = collection["Reason"];
                repository.Create(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PlayException/Edit/5
        public ActionResult Edit(int id)
        {
            var model = repository.Get(id);
            return View(model);
        }

        // POST: PlayException/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                var model = new PlayException()
                {
                    Id = id
                };
                model.Start = DateTime.Parse(collection["Start"]);
                model.Duration = int.Parse(collection["Duration"]);
                model.Reason = collection["Reason"];
                repository.Update(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PlayException/Delete/5
        public ActionResult Delete(int id)
        {
            var model = repository.Get(id);
            return View(model);
        }

        // POST: PlayException/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                repository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}