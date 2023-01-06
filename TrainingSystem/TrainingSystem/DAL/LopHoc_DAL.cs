using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TrainingSystem.Models;

namespace TrainingSystem.DAL
{
    public class LopHoc_DAL
    {
        string conString = ConfigurationManager.ConnectionStrings["myConnection"].ToString();
        public List<LopHoc> SearchLopHoc(string id, string SearchString)
        {
            List<LopHoc> lophoclist = new List<LopHoc>();
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_GetAllLopHoc";
                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                DataTable dtKhoaHoc = new DataTable();

                connection.Open();
                sqlDA.Fill(dtKhoaHoc);
                connection.Close();
                if (string.IsNullOrEmpty(SearchString))
                {
                    foreach (DataRow dr in dtKhoaHoc.Rows)
                    {
                        if (id == dr["MaKH"].ToString())
                        {
                           lophoclist.Add(new LopHoc
                            {
                                MaKH = Convert.ToInt32(dr["MaKH"]),
                                MaHV = dr["MaHV"].ToString(),
                                TenHV = dr["TenHV"].ToString(),
                                Diem = Convert.ToInt32(dr["Diem"]),
                                TrangThai = Convert.ToInt32(dr["TrangThai"])
                            });
                        }
                    }
                }
                else
                {
                    foreach (DataRow dr in dtKhoaHoc.Rows)
                    {
                        if (dr["TenHV"].ToString().ToLower().Contains(SearchString.ToLower()) || dr["TrangThai"].ToString().ToLower().Contains(SearchString.ToLower()))
                        {
                            if (id == dr["MaMH"].ToString())
                            {
                                lophoclist.Add(new LopHoc
                                {
                                    MaKH = Convert.ToInt32(dr["MaKH"]),
                                    MaHV = dr["MaHV"].ToString(),
                                    TenHV = dr["TenHV"].ToString(),
                                    Diem = Convert.ToInt32(dr["Diem"]),
                                    TrangThai = Convert.ToInt32(dr["TrangThai"])
                                });
                            }
                        }
                    }
                }
                return lophoclist;
            }
        }
    }
}