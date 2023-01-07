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
        public List<KhoaHoc> SearchKhoaHoc(string id, string SearchString)
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
        public void DeleteKhoaHoc(int id)
        {
            //List<KhoaHoc> khoahoclist = new List<KhoaHoc>();
            //string conString2 = "data source=.; database=TrainingSystem;integrated security = true";
            string conString = ConfigurationManager.ConnectionStrings["myConnection"].ToString();
            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();
                SqlDataReader rdr = null;
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_DeactiveKhoaHoc";
                command.Parameters.Add(new SqlParameter("@id", id));
                command.CommandType = CommandType.StoredProcedure;
                rdr = command.ExecuteReader();

                connection.Close();

            }
            //return khoahoclist;
        }


        public void CreateKhoaHoc(string mamh, string manhd, string cachdanhgia, string ngaybatdau, string ngayketthuc)
        {
            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();
                string CommandText = "insert into KhoaHoc(MaMH,MaNHD,CachDanhGia,NgayBatDau,NgayKetThuc,active) value(@mamh,@manhd,@cachdanhgia,@ngaybatdau,@ngayketthuc,1)";
                var command = new SqlCommand(CommandText, connection);
                command.Parameters.Add("@mamh", SqlDbType.Int);
                command.Parameters["@mamh"].Value = Convert.ToInt32(mamh);
                command.Parameters.Add("@manhd", SqlDbType.NVarChar);
                command.Parameters["@manhd"].Value = manhd;
                command.Parameters.Add("@cachdanhgia", SqlDbType.NVarChar);
                command.Parameters["@cachdanhgia"].Value = cachdanhgia;
                command.Parameters.Add("@ngaybatdau", SqlDbType.DateTime);
                command.Parameters["@ngaybatdau"].Value = ngaybatdau;
                command.Parameters.Add("@ngayketthuc", SqlDbType.DateTime);
                command.Parameters["@ngayketthuc"].Value = ngayketthuc;
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }

   
}
