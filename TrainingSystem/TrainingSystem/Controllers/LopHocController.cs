using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainingSystem.DAL;

namespace TrainingSystem.Controllers
{
    public class LopHocController : Controller
    {
        // GET: LopHoc
        LopHoc_DAL _lophocDAL = new LopHoc_DAL();
        public ActionResult XemLopHoc (string id, string SearchString)
        {
            var lophoclist = _lophocDAL.SearchLopHoc(id, SearchString);
            return View(lophoclist);
        }
        public ActionResult Index()
        {
            return View();
        }

        // GET: LopHoc/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LopHoc/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LopHoc/Create
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

        // GET: LopHoc/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LopHoc/Edit/5
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

        // GET: LopHoc/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LopHoc/Delete/5
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
