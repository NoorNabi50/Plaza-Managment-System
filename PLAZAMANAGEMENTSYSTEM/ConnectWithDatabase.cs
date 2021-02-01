
using System.Data.SqlClient;

namespace PLAZAMANAGEMENTSYSTEM
{
    public class ConnectWithDatabase
    {
        public static SqlConnection Connection;
        public static SqlConnection GetLogConnection()

        {
               Connection = new SqlConnection
                {
                    

                  ConnectionString = @"Data Source=NOORNABI-PC\SQLEXPRESS;" +
            "Initial Catalog=ParkingPlaza;Integrated Security=SSPI;" +
             "MultipleActiveResultSets=True"
            };

            
                Connection.Open();


                return Connection;
           
              
           


            }


    }
}
