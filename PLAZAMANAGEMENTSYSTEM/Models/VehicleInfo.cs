using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PLAZAMANAGEMENTSYSTEM.Models
{
    public class VehicleInfo
    {
        public int VehicleId { get; set; }

        public string VehicleNoPlate { get; set; }

        public int VehicleTypeId { get; set; }


        public string Color { get; set; }

        public int Amount { get; set; }


        public int SlotId { get; set; }


        public int FloorId { get; set; }
        public string FloorName { get; set; }


        public string Date { get; set; }

        public string SlotName { get; set; }


        public string TypeName { get; set; }


        public int SaveVehicleInfo()
        {

           
                VehicleInfo v = new VehicleInfo();
            SqlCommand cmd = new SqlCommand("SaveVehicleInfo", ConnectWithDatabase.GetLogConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@VehicleNoPlate", VehicleNoPlate);
                cmd.Parameters.AddWithValue("@VehicleTypeId", VehicleTypeId);
                cmd.Parameters.AddWithValue("@Color", Color);
                cmd.Parameters.AddWithValue("@Amount", Amount);
                cmd.Parameters.AddWithValue("@SlotId", SlotId);
            
                int message = Convert.ToInt32(cmd.ExecuteScalar());
                
                return message;

            
            
           
        }


        public VehicleInfo GetVehicleByVehicleNoPlate(int Id)

        {
            VehicleInfo vt = new VehicleInfo();

            SqlCommand cmd = new SqlCommand("GetVehicleByVehicleNoPlate", ConnectWithDatabase.GetLogConnection())
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@Id", Id);

            SqlDataReader reader = cmd.ExecuteReader();

            while(reader.Read())
            {
                vt.VehicleNoPlate = reader["VehicleNoPlate"].ToString();
                vt.SlotName = reader["SlotName"].ToString();
                vt.FloorName = reader["FloorName"].ToString();
                vt.Color = reader["Color"].ToString();
                vt.Date = reader["Date"].ToString();
               
            }

            reader.Close();
            return vt;
           

        }

        public int CountVehiclesForDay()
        {
            VehicleInfo v = new VehicleInfo();
            SqlCommand cmd = new SqlCommand("CountVehiclesForDay", ConnectWithDatabase.GetLogConnection())
            {
                CommandType = CommandType.StoredProcedure
            };


            int message = Convert.ToInt32(cmd.ExecuteScalar());

            return message;




        }


        public int AmountcollectedForDay()
        {


            VehicleInfo v = new VehicleInfo();
            SqlCommand cmd = new SqlCommand("AmountcollectedForDay", ConnectWithDatabase.GetLogConnection())
            {
                CommandType = CommandType.StoredProcedure
            };


            int message = Convert.ToInt32(cmd.ExecuteScalar());

           

               
            return message;




        }

        public List<VehicleInfo> GetAllVehicle()
        {

            try
            {
                List<VehicleInfo> vehicles = new List<VehicleInfo>();
                SqlCommand cmd = new SqlCommand("GetAllVehicle", ConnectWithDatabase.GetLogConnection())
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    VehicleInfo gt = new VehicleInfo
                    { VehicleNoPlate = reader["VehicleNoPlate"].ToString(),

                        VehicleId = Convert.ToInt32(reader["VehicleId"]),
                        Amount = Convert.ToInt32(reader["Amount"]),
                        TypeName = reader["TypeName"].ToString(),
                        Date = reader["Date"].ToString(),
                        Color = reader["Color"].ToString()
                    };
                    vehicles.Add(gt);



                }

                reader.Close();

                return vehicles;
            }
            catch(Exception e)
            {
                return null;
            }
        }



    }
}