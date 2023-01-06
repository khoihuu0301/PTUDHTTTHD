using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrainingSystem.Controllers
{
    public class HocVienController : Controller
    {
        // GET: HocVien
        public ActionResult Index()
        {
            return View();
        }

        // GET: HocVien/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HocVien/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HocVien/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: HocVien/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HocVien/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: HocVien/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HocVien/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
