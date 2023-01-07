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
    public class ThongKeKhoaHoc_DAL
    {
        string conString = ConfigurationManager.ConnectionStrings["myConnection"].ToString();

        public List<ThongKeKhoaHoc> ThongKe(string year, string time)
        {
            var thongke = new List<ThongKeKhoaHoc>();
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                if (time == "Quy")
                {
                    command.CommandText = "sp_ThongKeKhoaHoc_Quarter";
                    command.Parameters.Add(new SqlParameter("@year", Convert.ToInt32(year)));
                    SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                    DataTable dtThongKe = new DataTable();

                    connection.Open();
                    sqlDA.Fill(dtThongKe);
                    connection.Close();
                    foreach (DataRow dr in dtThongKe.Rows)
                    {
                        thongke.Add(new ThongKeKhoaHoc
                        {
                            Quarter = Convert.ToInt32(dr["Quy"]),
                            TenMH = (dr["TenMH"]).ToString(),
                            SoLuongHocVien = Convert.ToInt32(dr["SoLuongHocVien"]),
                            DTB = float.Parse(dr["DTB"].ToString()),
                        });
                    }
                }
                else if (time == "Thang")
                {
                    command.CommandText = "sp_ThongKeKhoaHoc_Month";
                    command.Parameters.Add(new SqlParameter("@year", Convert.ToInt32(year)));
                    SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                    DataTable dtThongKe = new DataTable();

                    connection.Open();
                    sqlDA.Fill(dtThongKe);
                    connection.Close();
                    foreach (DataRow dr in dtThongKe.Rows)
                    {
                        thongke.Add(new ThongKeKhoaHoc
                        {
                            Month = Convert.ToInt32(dr["Thang"]),
                            TenMH = (dr["TenMH"]).ToString(),
                            SoLuongHocVien = Convert.ToInt32(dr["SoLuongHocVien"]),
                            DTB = float.Parse(dr["DTB"].ToString()),
                        });
                    }
                }
                return thongke;
            }
        }
    }
}