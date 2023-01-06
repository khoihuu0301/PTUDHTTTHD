﻿using System;
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

    }
}
