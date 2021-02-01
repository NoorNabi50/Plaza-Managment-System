using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PLAZAMANAGEMENTSYSTEM.Models
{
    public class Report
    {

        public string FromDate { get; set; }

        public string ToDate { get; set; }


        public int ReportTypeId { get; set; }


        public int UserId { get; set; }



        public int Total_Amount_of_Each_Vehicle { get; set; }

        public int TotalVehicleTypePassed { get; set; }


        public int TotalAmount { get; set; }


        public int Total_Vehicles_Passed { get; set; }


        public string Report_Name { get; set; }



        public string Date { get; set; }



        public string CreatedBy { get; set; }


        public string TypeName { get; set; }
        public List<Report> GenerateReport(Report rep)

        {
            try
            {
                List<Report> rptList = new List<Report>();
                SqlCommand cmd = new SqlCommand("GenerateReport", ConnectWithDatabase.GetLogConnection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FromDate", rep.FromDate);
                cmd.Parameters.AddWithValue("@ToDate", rep.ToDate);
                cmd.Parameters.AddWithValue("@ReportTypeId", rep.ReportTypeId);
                SqlDataReader r = cmd.ExecuteReader();

                while (r.Read())
                {

                   

                    Report re = new Report();

                    re.TotalAmount = Convert.ToInt32(r["TotalAmount"]);
                    re.TotalVehicleTypePassed = Convert.ToInt32(r["TotalVehicleTypePassed"]);
                    re.Total_Amount_of_Each_Vehicle = Convert.ToInt32(r["Total_Amount_of_Each_Vehicle"]);
                    re.Total_Vehicles_Passed = Convert.ToInt32(r["Total_Vehicles_Passed"]);
                    re.CreatedBy = r["CreatedBy"].ToString();
                    re.TypeName = r["TypeName"].ToString();
                    re.Report_Name = r["Report_Name"].ToString();
                    re.Date = r["Date"].ToString();
                    rptList.Add(re);



                }

                r.Close();
                return rptList;
            }

            catch(Exception ex)
            {
                return null;
            }

        }
    }
}