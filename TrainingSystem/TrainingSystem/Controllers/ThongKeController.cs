using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainingSystem.DAL;
namespace TrainingSystem.Controllers
{
    public class ThongKeController : Controller
    {
        ThongKeKhoaHoc_DAL _thongkeDAL = new ThongKeKhoaHoc_DAL();
        // GET: ThongKe
        public ActionResult Index(string year, string time)
        {
            var thongke = _thongkeDAL.ThongKe(year, time);
            return View(thongke);
        }

        // GET: ThongKe/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ThongKe/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ThongKe/Create
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

        // GET: ThongKe/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ThongKe/Edit/5
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

        // GET: ThongKe/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ThongKe/Delete/5
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
