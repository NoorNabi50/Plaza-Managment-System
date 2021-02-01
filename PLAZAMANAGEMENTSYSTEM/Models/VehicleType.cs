using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PLAZAMANAGEMENTSYSTEM.Models
{
    public class VehicleType
    {

        public int VehicleTypeId { get; set; }

        public string TypeName { get; set; }




        public int SaveVehicleType()
        {

            SqlCommand cmd = new SqlCommand("SaveVehicleType", ConnectWithDatabase.GetLogConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@TypeName", TypeName);
            int value = Convert.ToInt32(cmd.ExecuteScalar());

            return value;




        }


        public int DeleteVehicleType(int Id)
        {
            SqlCommand cmd = new SqlCommand("DeleteVehicleType", ConnectWithDatabase.GetLogConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@VehicleTypeId", Id);

            int value = Convert.ToInt32(cmd.ExecuteScalar());

            return value;
        }


        public List<VehicleType> GetAllVehicleType()
        {
            List<VehicleType> VTList = new List<VehicleType>();
            SqlCommand cmd = new SqlCommand("GetAllVehicleType", ConnectWithDatabase.GetLogConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                VehicleType cs = new VehicleType
                {
                    VehicleTypeId = Convert.ToInt32(reader["VehicleTypeId"]),

                    TypeName = reader["TypeName"].ToString()
                };


                VTList.Add(cs);

            }
            reader.Close();

            return VTList;

        }


        public VehicleType GetVehicleTypeById(int Id)
        {
            VehicleType Vt = new VehicleType();
            SqlCommand cmd = new SqlCommand("GetVehicleTypeById", ConnectWithDatabase.GetLogConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@VehicleTypeId", Id);


            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Vt.VehicleTypeId = Convert.ToInt32(reader["VehicleTypeId"]);
                Vt.TypeName = reader["TypeName"].ToString();


            }

            reader.Close();

            return Vt;


        }

        public int UpdateVehicleType()
        {
            VehicleType Vt = new VehicleType();
            SqlCommand cmd = new SqlCommand("UpdateVehicleType", ConnectWithDatabase.GetLogConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@VehicleTypeId", VehicleTypeId);
            cmd.Parameters.AddWithValue("@TypeName", TypeName);
            int value = Convert.ToInt32(cmd.ExecuteScalar());

            return value;

        }

    }
    }