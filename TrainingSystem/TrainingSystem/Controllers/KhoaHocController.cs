using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
        /*public ActionResult Delete(int id)
        {   

            return View();
        }*/

        // POST: KhoaHoc/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                string conString2 = "data source=.; database=TrainingSystem;integrated security = true";

                using (SqlConnection connection = new SqlConnection(conString2))
                {
                    connection.Open();
                    SqlDataReader rdr = null;
                    SqlCommand command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "sp_DeactiveKhoaHoc";
                    command.Parameters.Add(new SqlParameter("@ID", id));
                    command.CommandType = CommandType.StoredProcedure;
                    rdr = command.ExecuteReader();

                    connection.Close();

                }
                var khoahoclist = _khoahocDAL.GetAllKhoaHoc();
                Response.Write("<script>alert('success')</script>");
                return View(khoahoclist);

            }
            catch
            {
                var khoahoclist = _khoahocDAL.GetAllKhoaHoc();
                Response.Write("<script>alert('failed')</script>");
                return View(khoahoclist);
            }
        }

        public ActionResult SearchKhoaHoc(string SearchString)
        {
            var khoahocsearch = _khoahocDAL.SearchKhoaHoc(SearchString);
            return View(khoahocsearch);
        }
    }
}
