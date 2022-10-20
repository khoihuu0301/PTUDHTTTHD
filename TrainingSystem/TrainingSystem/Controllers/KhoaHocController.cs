using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TrainingSystem.DAL;

namespace TrainingSystem.Controllers
{
    public class KhoaHocController : Controller
    {
        KhoaHoc_DAL _khoahocDAL = new KhoaHoc_DAL();
        // GET: KhoaHoc
        public ActionResult XemKhoaHoc(string SearchString)
        {
            
            if (string.IsNullOrEmpty(SearchString))
            {
                var khoahoclist = _khoahocDAL.GetAllKhoaHoc();
                return View(khoahoclist);
            }
            else
            {
                var khoahocsearch = _khoahocDAL.SearchKhoaHoc(SearchString); 
                return View(khoahocsearch);
            }
        }
        public ActionResult Index()
        {
            return View();
        }

        // GET: KhoaHoc/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: KhoaHoc/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KhoaHoc/Create
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

        // GET: KhoaHoc/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: KhoaHoc/Edit/5
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

        // GET: KhoaHoc/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: KhoaHoc/Delete/5
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

        public ActionResult SearchKhoaHoc(string SearchString)
        {
            var khoahocsearch = _khoahocDAL.SearchKhoaHoc(SearchString);
            return View(khoahocsearch);
        }
    }
}
