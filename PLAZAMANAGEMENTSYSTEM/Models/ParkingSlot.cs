using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PLAZAMANAGEMENTSYSTEM.Models
{
    public class ParkingSlot
    {
        public int SlotId { get; set; }

        public string SlotName { get; set; }


        public int FloorId { get; set; }



        public string FloorName { get; set; }

        public int SaveParkingSlot()
        {
            SqlCommand cmd = new SqlCommand("SaveParkingSlot", ConnectWithDatabase.GetLogConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@SlotName",SlotName);
            cmd.Parameters.AddWithValue("@FloorId",FloorId);
            int value = Convert.ToInt32(cmd.ExecuteScalar());
            return value;


        }

        


        public List<ParkingSlot> GetAllParkingSlot()
        {
            List<ParkingSlot> VTList = new List<ParkingSlot>();
            SqlCommand cmd = new SqlCommand("GetAllParkingSlot", ConnectWithDatabase.GetLogConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ParkingSlot cs = new ParkingSlot
                {
                    SlotId = Convert.ToInt32(reader["SlotId"]),

                    FloorName = reader["FloorName"].ToString(),

                    SlotName = reader["SlotName"].ToString()
                };
                VTList.Add(cs);

            }
            reader.Close();

            return VTList;

        }



        public List<ParkingSlot> GetAllParkingSlotHavingSpace()
        {
            List<ParkingSlot> VTList = new List<ParkingSlot>();
            SqlCommand cmd = new SqlCommand("GetAllParkingSlotHavingSpace", ConnectWithDatabase.GetLogConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ParkingSlot cs = new ParkingSlot
                {
                    SlotId = Convert.ToInt32(reader["SlotId"]),

                    FloorName = reader["FloorName"].ToString(),

                    SlotName = reader["SlotName"].ToString()
                };
                VTList.Add(cs);

            }
            reader.Close();

            return VTList;

        }



        public ParkingSlot GetFloorNameBySlotId(int Id)
        {


            ParkingSlot mps = new ParkingSlot();
            SqlCommand cmd = new SqlCommand("GetFloorNameBySlotId", ConnectWithDatabase.GetLogConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@SlotId", Id);
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                mps.FloorId = Convert.ToInt32(reader["FloorId"]);
                mps.FloorName = reader["FloorName"].ToString();
               
            }

            reader.Close();
            return mps;
        }

        public int DeleteParkingSlot(int Id)
        {
            SqlCommand cmd = new SqlCommand("DeleteParkingSlot", ConnectWithDatabase.GetLogConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@SlotId", Id);

            int value = Convert.ToInt32(cmd.ExecuteScalar());

            return value;
        }


        public ParkingSlot GetParkingSlotById(int Id)
        {
            ParkingSlot Vt = new ParkingSlot();
            SqlCommand cmd = new SqlCommand("GetParkingSlotById", ConnectWithDatabase.GetLogConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@SlotId", Id);


            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Vt.SlotId = Convert.ToInt32(reader["SlotId"]);
                Vt.SlotName = reader["SlotName"].ToString();
                Vt.FloorId = Convert.ToInt32(reader["FloorId"]);
              

            }

            reader.Close();

            return Vt;


        }

        public int UpdateParkingSlot()
        {
            ParkingSlot Vt = new ParkingSlot();
            SqlCommand cmd = new SqlCommand("UpdateParkingSlot", ConnectWithDatabase.GetLogConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@SlotId", SlotId);
            cmd.Parameters.AddWithValue("@SlotName", SlotName);
            cmd.Parameters.AddWithValue("@FloorId", FloorId);
            int value = Convert.ToInt32(cmd.ExecuteScalar());

            return value;

        }
    }
}