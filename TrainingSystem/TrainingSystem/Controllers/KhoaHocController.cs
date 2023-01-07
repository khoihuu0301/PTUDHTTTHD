using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using TrainingSystem.DAL;
using TrainingSystem.Models;

namespace TrainingSystem.Controllers
{
    public class KhoaHocController : Controller
    {

        KhoaHoc_DAL _khoahocDAL = new KhoaHoc_DAL();
        public ActionResult XemKhoaHoc(string id, string SearchString)
        {
            var khoahoclist = _khoahocDAL.SearchKhoaHoc(id, SearchString);
            return View(khoahoclist);
        }
        // GET: KhoaHoc
        public ActionResult Index()
        {
            return View();
        }

        // GET: KhoaHoc/Details/5
        public ActionResult Details(int id,string SearchString)
        {
            return RedirectToAction("XemLopHoc","LopHoc",new { id = id, SearchString = SearchString });
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
                List<string> parameters = new List<string>();
                if (ModelState.IsValid)
                {
                    foreach (string key in collection.AllKeys)
                    {
                        if (string.IsNullOrEmpty(collection[key]))
                        {
                            return RedirectToAction("XemMonHoc", new { SearchString = ' ' }); ;
                        }
                        else parameters.Add(collection[key]);
                    }
                    _khoahocDAL.CreateKhoaHoc(parameters[1], parameters[2], parameters[3],parameters[4],parameters[5]);
                    ViewBag.Message = "Thêm khóa học mới THÀNH CÔNG!";
                    return RedirectToAction("XemMonHoc", new { SearchString = ' ' });
                }
                else
                {
                    ViewBag.Message = "Thêm khóa học mới THẤT BẠI!";
                    return RedirectToAction("XemMonHoc", new { SearchString = ' ' });
                }
            }
            catch (Exception ex)
            {
                return View(ex);
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
            _khoahocDAL.DeleteKhoaHoc(id);
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
            return RedirectToAction("XemMonHoc","MonHoc", new { SearchString = ' '});
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
    }
}
