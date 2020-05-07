using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppAzureAD.Models;

namespace WebAppAzureAD.Controllers
{
    public class PlayExceptionController : Controller
    {
        private static List<PlayException> list = new List<PlayException>();
        public static List<PlayException> List => list;
        // GET: PlayException
        public ActionResult Index()
        {
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
                // TODO: Add insert logic here
                int id = list.Any() ? list.Select(x => x.Id).Max() + 1 : 1;
                model.Id = id;
                model.Start = DateTime.Parse(collection["Start"]);
                model.Duration = int.Parse(collection["Duration"]);
                model.Reason = collection["Reason"];
                list.Add(model);
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
            return View();
        }

        // POST: PlayException/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

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
            return View();
        }

        // POST: PlayException/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}