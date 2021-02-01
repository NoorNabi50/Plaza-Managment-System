using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PLAZAMANAGEMENTSYSTEM.Models
{
    public class AmountForEachVechileType
    {


        public int AmId { get; set; }


        public int Amount { get; set; }


        public int VehicleTypeId { get; set; }


        public string TypeName {get;set; }


        public int SaveAmountForEachVehicleType()
        {

            SqlCommand cmd = new SqlCommand("SaveAmountForEachVehicleType", ConnectWithDatabase.GetLogConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@Amount", Amount);
            cmd.Parameters.AddWithValue("@VehicleTypeId", VehicleTypeId);
            int value = Convert.ToInt32(cmd.ExecuteScalar());
            return value;


        }

        public AmountForEachVechileType GetAmountForEachVehicleTypeById(int Id)
        {
            AmountForEachVechileType Vt = new AmountForEachVechileType();
            SqlCommand cmd = new SqlCommand("GetAmountForEachVehicleTypeById", ConnectWithDatabase.GetLogConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@AmId", Id);


            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Vt.AmId = Convert.ToInt32(reader["AmId"]);
                Vt.Amount = Convert.ToInt32(reader["Amount"]);
                Vt.VehicleTypeId = Convert.ToInt32(reader["VehicleTypeId"]);

            }

            reader.Close();

            return Vt;


        }


        public List<AmountForEachVechileType> GetAllAmountForEachVechileType()
        {
            List<AmountForEachVechileType> Avt = new List<AmountForEachVechileType>();
            SqlCommand cmd = new SqlCommand("GetAllAmountForEachVechileType", ConnectWithDatabase.GetLogConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {

                AmountForEachVechileType gt = new AmountForEachVechileType
                {
                    AmId = Convert.ToInt32(reader["Amid"]),
                    Amount = Convert.ToInt32(reader["Amount"]),
                    TypeName = reader["TypeName"].ToString()
                };
                Avt.Add(gt);


                
            }

            reader.Close();

            return Avt;
        }


        public int GetAmountByVehicleType(int Id)
        {

            SqlCommand cmd = new SqlCommand("GetAmountByVehicleType", ConnectWithDatabase.GetLogConnection())
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@VehicleTypeId", Id);

            int amount = Convert.ToInt32(cmd.ExecuteScalar());
            return amount;



        }


        public int DeleteAmountForEachVechileType(int Id)
        {
            SqlCommand cmd = new SqlCommand("DeleteAmountForEachVechileType", ConnectWithDatabase.GetLogConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@AmId", Id);

            int value = Convert.ToInt32(cmd.ExecuteScalar());

            return value;
        }


        public int UpdateAmountForEachVechileType()
        {
            AmountForEachVechileType Vt = new AmountForEachVechileType();
            SqlCommand cmd = new SqlCommand("UpdateAmountForEachVechileType", ConnectWithDatabase.GetLogConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@AmId", AmId);
            cmd.Parameters.AddWithValue("@Amount", Amount);
            cmd.Parameters.AddWithValue("@VehicleTypeId", VehicleTypeId);
            int value = Convert.ToInt32(cmd.ExecuteScalar());

            return value;

        }



    }
}