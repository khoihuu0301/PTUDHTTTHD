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
    public class MonHoc_DAL
    {
        string conString = ConfigurationManager.ConnectionStrings["myConnection"].ToString();
        string conString2= "data source=.; database=TrainingSystem;integrated security = true"; 
        //public List<MonHoc> GetAllMonHoc()
        //{
        //    List<MonHoc> monhoclist = new List<MonHoc>();
        //    using (SqlConnection connection = new SqlConnection(conString))
        //    {
        //        SqlCommand command = connection.CreateCommand();
        //        command.CommandType = CommandType.StoredProcedure;
        //        command.CommandText = "sp_GetAllKhoaHoc";
        //        SqlDataAdapter sqlDA = new SqlDataAdapter(command);
        //        DataTable dtMonHoc = new DataTable();

        //        connection.Open();
        //        sqlDA.Fill(dtMonHoc);
        //        connection.Close();

        //        foreach (DataRow dr in dtMonHoc.Rows)
        //        {
        //            monhoclist.Add(new MonHoc
        //            {
        //                MaMH = Convert.ToInt32(dr["MaMH"]),
        //                TenMH = dr["TenMH"].ToString(),
        //                MoTa = dr["MoTa"].ToString(),
        //                MucTieu = dr["MucTieu"].ToString()
        //            });
        //        }
        //    } 

        //        return monhoclist;
        //}

        public List<MonHoc> SearchMonHoc(string SearchString)
        {
            List<MonHoc> monhoclist = new List<MonHoc>();
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_GetAllMonHoc";
                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                DataTable dtMonHoc = new DataTable();

                connection.Open();
                sqlDA.Fill(dtMonHoc);
                connection.Close();
                if (string.IsNullOrEmpty(SearchString))
                {
                    foreach (DataRow dr in dtMonHoc.Rows)
                    {
                        monhoclist.Add(new MonHoc
                        {
                            MaMH = Convert.ToInt32(dr["MaMH"]),
                            TenMH = dr["TenMH"].ToString(),
                            MoTa = dr["MoTa"].ToString(),
                            MucTieu = dr["MucTieu"].ToString()
                        });
                    }
                }
                else
                {
                    foreach (DataRow dr in dtMonHoc.Rows)
                    {
                        if (dr["TenMH"].ToString().ToLower().Contains(SearchString.ToLower()) /*|| dr["TenNHD"].ToString().ToLower().Contains(SearchString.ToLower()*/)
                        {
                            monhoclist.Add(new MonHoc
                            {
                                MaMH = Convert.ToInt32(dr["MaMH"]),
                                TenMH = dr["TenMH"].ToString(),
                                MoTa = dr["MoTa"].ToString(),
                                MucTieu = dr["MucTieu"].ToString()
                            });
                        }
                    }
                }
                return monhoclist;
            }
        }

        //public List<KhoaHoc> DeleteKhoaHoc(int id)
        //{
        //    List<KhoaHoc> khoahoclist = new List<KhoaHoc>();
        //    string conString2 = "data source=.; database=TrainingSystem;integrated security = true";

        //    using (SqlConnection connection = new SqlConnection(conString2))
        //    {
        //        connection.Open();
        //        SqlDataReader rdr = null;
        //        SqlCommand command = connection.CreateCommand();
        //        command.CommandType = CommandType.StoredProcedure;
        //        command.CommandText = "sp_DeactiveKhoaHoc";
        //        command.Parameters.Add(new SqlParameter("@ID", id));
        //        command.CommandType = CommandType.StoredProcedure;
        //        rdr = command.ExecuteReader();             
                
        //        connection.Close();
                
        //    }
        //    return khoahoclist;
        //}
    }
    public class KhoaHoc_DAL
    {
        string conString = ConfigurationManager.ConnectionStrings["myConnection"].ToString();
        public List<KhoaHoc> SearchKhoaHoc(string id,string SearchString)
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
                if (string.IsNullOrEmpty(SearchString))
                {
                    foreach (DataRow dr in dtKhoaHoc.Rows)
                    {
                        if (id == dr["MaMH"].ToString())
                        {
                            khoahoclist.Add(new KhoaHoc
                            {
                                MaKH = Convert.ToInt32(dr["MaKH"]),
                                TenMH = dr["TenMH"].ToString(),
                                TenNHD = dr["TenNHD"].ToString(),
                                CachDanhGia = dr["CachDanhGia"].ToString(),
                                NgayBatDau = dr["NgayBatDau"].ToString(),
                                NgayKetThuc = dr["NgayKetThuc"].ToString()
                            });
                        }
                    }
                }
                else
                {
                    foreach (DataRow dr in dtKhoaHoc.Rows)
                    {
                        if (dr["TenMH"].ToString().ToLower().Contains(SearchString.ToLower()) || dr["TenNHD"].ToString().ToLower().Contains(SearchString.ToLower()))
                        {
                            if (id == dr["MaMH"].ToString())
                            {
                                khoahoclist.Add(new KhoaHoc
                                {
                                    MaKH = Convert.ToInt32(dr["MaKH"]),
                                    TenMH = dr["TenMH"].ToString(),
                                    TenNHD = dr["TenNHD"].ToString(),
                                    CachDanhGia = dr["CachDanhGia"].ToString(),
                                    NgayBatDau = dr["NgayBatDau"].ToString(),
                                    NgayKetThuc = dr["NgayKetThuc"].ToString()
                                });
                            }
                        }
                    }
                }
                return khoahoclist;
            }
        }

    }
}