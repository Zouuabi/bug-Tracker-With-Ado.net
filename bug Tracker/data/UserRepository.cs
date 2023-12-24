using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using bug_Tracker.data.models;

namespace bug_Tracker.data
{
    public class UserRepository
    {
        private static readonly string connectionString = "server=localhost;uid=root;pwd=Doudy2k23!;database=bug_tracker";
        private readonly MySqlConnection connection = new(connectionString);

        


        private void OpenConnection()
        {
            connection.Open();
            
        }

        private void CloseConnection()
        {
            connection.Close();
        }

        public void CreateUser(User user ) {
            string sql = "INSERT INTO user VALUES(@id,@name,@email,@password)";

            MySqlCommand cmd = new(sql, connection);

            cmd.Parameters.AddWithValue("@id",user.Id );
            cmd.Parameters.AddWithValue("@name",user.Name );
            cmd.Parameters.AddWithValue("@email",user.Email );
            cmd.Parameters.AddWithValue("@password",user.Password );

            try
            {
                OpenConnection();
                cmd.ExecuteNonQuery();
                CloseConnection();
            }catch(Exception ex)
            {
                CloseConnection();
                throw new Exception(ex.Message);

            }
        }
        public String? ReadUser(string email) {
            string sql = "SELECT password from user WHERE email=@email";
            MySqlCommand cmd = new(sql, connection);

            cmd.Parameters.AddWithValue("@email", email);

            try
            {
                OpenConnection();
               String? password = (String?) cmd.ExecuteScalar();
                CloseConnection();

                
                    return password; 
                 
            }
            catch 
            {
                CloseConnection();
                throw new Exception("Something Went Wrong Try Again Ame laktharya Email Already Used");

            }

        }

    }
}
