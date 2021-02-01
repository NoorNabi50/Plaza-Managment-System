using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PLAZAMANAGEMENTSYSTEM.Models
{
    public class ParkingFloors
    {
        public int FloorId { get; set; }

        public string FloorName { get; set; }

        public string TotalSpace { get; set; }

        public List<ParkingFloors> GetAllParkingFloors()
        {

           
                List<ParkingFloors> VTList = new List<ParkingFloors>();
            SqlCommand cmd = new SqlCommand("GetAllParkingFloors", ConnectWithDatabase.GetLogConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                ParkingFloors cs = new ParkingFloors
                {
                    FloorId = Convert.ToInt32(reader["FloorId"]),

                    FloorName = reader["FloorName"].ToString(),

                    TotalSpace = reader["TotalSpace"].ToString()
                };
                   VTList.Add(cs);

                }
                reader.Close();

                return VTList;
            }

          
        

        public int DeleteParkingFloors(int Id)
        {
            SqlCommand cmd = new SqlCommand("DeleteParkingFloors", ConnectWithDatabase.GetLogConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@FloorId", Id);

            int value = Convert.ToInt32(cmd.ExecuteScalar());

            return value;
        }
        public int SaveParkingFloors()
        {

            SqlCommand cmd = new SqlCommand("SaveParkingFloors", ConnectWithDatabase.GetLogConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@FloorName",FloorName);
            cmd.Parameters.AddWithValue("@TotalSpace", TotalSpace);
            int value = Convert.ToInt32(cmd.ExecuteScalar());

            return value;

        }


        public ParkingFloors GetParkingFloorById(int Id)
        {
            ParkingFloors Vt = new ParkingFloors();
            SqlCommand cmd = new SqlCommand("GetParkingFloorById", ConnectWithDatabase.GetLogConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@FloorId", Id);


            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Vt.FloorId = Convert.ToInt32(reader["FloorId"]);
                Vt.FloorName = reader["FloorName"].ToString();
                Vt.TotalSpace = reader["TotalSpace"].ToString();

            }

            reader.Close();

            return Vt;


        }

        public int UpdateParkingFloor()
        {
            ParkingFloors Vt = new ParkingFloors();
            SqlCommand cmd = new SqlCommand("UpdateParkingFloor", ConnectWithDatabase.GetLogConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@FloorId", FloorId);
            cmd.Parameters.AddWithValue("@FloorName", FloorName);
            cmd.Parameters.AddWithValue("@TotalSpace", TotalSpace);
            int value = Convert.ToInt32(cmd.ExecuteScalar());

            return value;

        }



        public int TotalSpaceAvailable()
        {

            ParkingFloors pf = new ParkingFloors();

            SqlCommand cmd = new SqlCommand("TotalSpaceAvailable", ConnectWithDatabase.GetLogConnection());

            int SpaceAvailable = Convert.ToInt32(cmd.ExecuteScalar());

            return SpaceAvailable;
        }





    }
}