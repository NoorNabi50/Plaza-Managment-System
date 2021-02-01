using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PLAZAMANAGEMENTSYSTEM.Models
{
    public class UserAuthentication
    {
        public string Username { get; set; }


        public string Password { get; set; }



        public int UserLogin()
        {

            SqlCommand cmd = new SqlCommand("UserLogin", ConnectWithDatabase.GetLogConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@Username", Username);
            cmd.Parameters.AddWithValue("@Password", Password);
            int value = Convert.ToInt32(cmd.ExecuteScalar());
            return value;


        }


    }
}