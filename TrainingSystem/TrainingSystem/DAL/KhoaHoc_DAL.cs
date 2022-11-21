using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using TrainingSystem.Models;

namespace TrainingSystem.DAL
{
    public class KhoaHoc_DAL
    {
        string conString = ConfigurationManager.ConnectionStrings["myConnection"].ToString();
        string conString2= "data source=.; database=TrainingSystem;integrated security = true"; 
        public List<KhoaHoc> GetAllKhoaHoc()
        {
            List<KhoaHoc> khoahoclist = new List<KhoaHoc>();
            using (SqlConnection connection = new SqlConnection(conString2))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_GetAllKhoaHoc";
                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                DataTable dtKhoaHoc = new DataTable();

                connection.Open();
                sqlDA.Fill(dtKhoaHoc);
                connection.Close();

                foreach (DataRow dr in dtKhoaHoc.Rows)
                {
                    khoahoclist.Add(new KhoaHoc
                    {
                        MaKhoaHoc = Convert.ToInt32(dr["MaKhoaHoc"]),
                        TenKhoaHoc = dr["TenKhoaHoc"].ToString(),
                        NguoiHuongDan = dr["TenNHD"].ToString()
                    });
                 }
            } 

                return khoahoclist;
        }

        public List<KhoaHoc> SearchKhoaHoc(string SearchString)
        {
            List<KhoaHoc> khoahoclist = new List<KhoaHoc>();
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_GetAllKhoaHoc";
                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                DataTable dtKhoaHoc = new DataTable();

                connection.Open();
                sqlDA.Fill(dtKhoaHoc);
                connection.Close();

                foreach (DataRow dr in dtKhoaHoc.Rows)
                {
                    if (dr["TenKhoaHoc"].ToString().ToLower().Contains(SearchString.ToLower()) || dr["TenNHD"].ToString().ToLower().Contains(SearchString.ToLower()))
                    {
                        khoahoclist.Add(new KhoaHoc
                        {
                            MaKhoaHoc = Convert.ToInt32(dr["MaKhoaHoc"]),
                            TenKhoaHoc = dr["TenKhoaHoc"].ToString(),
                            NguoiHuongDan = dr["TenNHD"].ToString()
                        });
                    }
                }
            }
            return khoahoclist;
        }

        public List<KhoaHoc> DeleteKhoaHoc(int id)
        {
            List<KhoaHoc> khoahoclist = new List<KhoaHoc>();
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
            return khoahoclist;
        }
    }
}