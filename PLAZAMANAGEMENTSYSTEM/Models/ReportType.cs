using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PLAZAMANAGEMENTSYSTEM.Models
{
    public class ReportType
    {
        public int ReportTypeId { get; set; }


        public string ReportName { get; set; }




        public int SaveReportType()
        {

            SqlCommand cmd = new SqlCommand("SaveReportType", ConnectWithDatabase.GetLogConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@ReportName", ReportName);
            int Isuccess = Convert.ToInt32(cmd.ExecuteScalar());

            return Isuccess;
            


        }




        public List<ReportType> GetAllReportType()
        {
            List<ReportType> VTList = new List<ReportType>();
            SqlCommand cmd = new SqlCommand("GetAllReportType", ConnectWithDatabase.GetLogConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ReportType cs = new ReportType
                {
                    ReportTypeId = Convert.ToInt32(reader["ReportTypeId"]),

                    ReportName = reader["ReportName"].ToString()
                };


                VTList.Add(cs);

            }
            reader.Close();

            return VTList;

        }


        public ReportType GetReportTypeById(int Id)
        {
            ReportType Vt = new ReportType();
            SqlCommand cmd = new SqlCommand("GetReportTypeById", ConnectWithDatabase.GetLogConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@ReportTypeId", Id);


            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Vt.ReportTypeId = Convert.ToInt32(reader["ReportTypeId"]);
                Vt.ReportName = reader["ReportName"].ToString();
                
            }

            reader.Close();

            return Vt;


        }


        public int DeleteReportType(int Id)
        {
            SqlCommand cmd = new SqlCommand("DeleteReportType", ConnectWithDatabase.GetLogConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@ReportType", Id);

            int value = Convert.ToInt32(cmd.ExecuteScalar());

            return value;
        }

     


    }
}