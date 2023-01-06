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
        //string conString2 = "data source=.; database=TrainingSystem;integrated security = true";
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
        //                //MoTa = dr["MoTa"].ToString(),
        //                //MucTieu = dr["MucTieu"].ToString()
        //            });
        //        }
        //    }

        //    return monhoclist;
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

        public void CreateMonHoc(string tenmh, string mota, string muctieu)
        {
            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_CreateMonHoc";
                command.Parameters.Add(new SqlParameter("@tenmh", tenmh));
                command.Parameters.Add(new SqlParameter("@mota", mota));
                command.Parameters.Add(new SqlParameter("@muctieu", muctieu));
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();
                connection.Close();
            }

        }
        public void DeleteMonHoc(int id)
        {
            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();
                string CommandText = "update MonHoc set active = 0 where MaMH = @id";
                var command = new SqlCommand(CommandText, connection);
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@id";
                param.Value = id;
                command.Parameters.Add(param);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }

}
