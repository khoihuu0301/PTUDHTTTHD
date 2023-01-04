﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TrainingSystem.DAL;
using TrainingSystem.Models;

namespace TrainingSystem.Controllers
{
    public class MonHocController : Controller
    {
        MonHoc_DAL _monhocDAL = new MonHoc_DAL();
        // GET: KhoaHoc
        public ActionResult XemMonHoc(string SearchString)
        {
            
                var monhoclist = _monhocDAL.SearchMonHoc(SearchString);
                return View(monhoclist);
        }
        public ActionResult Index()
        {
            var monhoclist = _monhocDAL.GetAllMonHoc();
            return RedirectToAction("XemMonHoc",new { SearchString = ' ' });
        }

        // GET: KhoaHoc/Details/5
        public ActionResult Details(string id, string SearchString)
        {
            //var khoahoclist = new KhoaHocController().XemKhoaHoc(id,SearchString);
            //return View(khoahoclist);
            //var controller = DependencyResolver.Current.GetService<KhoaHocController>();
            //controller.ControllerContext = new ControllerContext(this.Request.RequestContext, controller);

            ////Call your method
            //ActionInvoker.InvokeAction(controller.ControllerContext, "XemKhoaHoc");
            //return controller.XemKhoaHoc(id, SearchString);
            return RedirectToAction("XemKhoaHoc", "KhoaHoc" ,new {id = id, SearchString = SearchString});
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
        /*public ActionResult Delete(int id)
        {   

            return View();
        }*/

        // POST: KhoaHoc/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        string conString2 = "data source=.; database=TrainingSystem;integrated security = true";

        //        using (SqlConnection connection = new SqlConnection(conString2))
        //        {
        //            connection.Open();
        //            SqlDataReader rdr = null;
        //            SqlCommand command = connection.CreateCommand();
        //            command.CommandType = CommandType.StoredProcedure;
        //            command.CommandText = "sp_DeactiveKhoaHoc";
        //            command.Parameters.Add(new SqlParameter("@ID", id));
        //            command.CommandType = CommandType.StoredProcedure;
        //            rdr = command.ExecuteReader();

        //            connection.Close();

        //        }
        //        var khoahoclist = _khoahocDAL.GetAllKhoaHoc();
        //        Response.Write("<script>alert('success')</script>");
        //        return View(khoahoclist);

        //    }
        //    catch
        //    {
        //        var khoahoclist = _khoahocDAL.GetAllKhoaHoc();
        //        Response.Write("<script>alert('failed')</script>");
        //        return View(khoahoclist);
        //    }
        //}

        //public ActionResult SearchKhoaHoc(string SearchString)
        //{
        //    var khoahocsearch = _khoahocDAL.SearchKhoaHoc(SearchString);
        //    return View(khoahocsearch);
        //}
    }
}
