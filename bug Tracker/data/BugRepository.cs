using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace bug_Tracker.data
{
    public class BugRepository 
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

       public  void CreateBug(int reference, string bugDescription, string author, string status = "not solved")
        {
            // id must be automatic (programmation not MYSQL)
            string sqlQuery = "INSERT INTO Bug VALUES(@id , @bugDescription , @author , @status)";

            MySqlCommand cmd = new(sqlQuery, connection);
             
            cmd.Parameters.AddWithValue("@bugDescription", bugDescription);
            cmd.Parameters.AddWithValue("@author", author);
            cmd.Parameters.AddWithValue("@status", status);

            try
            {
                OpenConnection();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
            }

        }

        public string GetBugStatus(int reference)
        {
            string sqlQuery = "SELECT status FROM Bug where id = @id";
            MySqlCommand cmd = new(sqlQuery, connection);
            cmd.Parameters.Add("@ref", MySqlDbType.Int32);
            cmd.Parameters["@ref"].Value = reference;

            //cmd.Parameters.AddWithValue("@id", id);



            try
            {
                OpenConnection();
                // lezm nalgou hall 
                string? status = (string)cmd.ExecuteScalar();

                return status;

            }
            catch (Exception e)
            {
                return e.Message;

            }
        }
        public void ReadBug(int reference)
        {
            string sqlQuery = "SELECT * FROM Bug  WHERE id = @id";



            // zeda najmou nekhdhou lista mte3 el bugs lkoll
            // open connection 
            OpenConnection();

            MySqlCommand cmd = new(sqlQuery, connection);
            cmd.Parameters.Add("@ref", MySqlDbType.Int32);

            cmd.Parameters["@ref"].Value = reference;


            try
            {
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int idd = (int)reader["ref"]; // 0
                    string des = (string)reader["description"]; // 1
                    string author = (string)reader["author"]; // 2 
                    string status = (string)reader["status"]; // 3
                    // barra lawej esh bch na3mlou behom
                }
                reader.Close();

            }
            catch (Exception e)
            {
                string error = e.Message;

            }

            // close connection
            CloseConnection();
        }

        public void UpdateBug(int reference, string bugDescription, string status)
        {

            string sqlQuery = "UPDATE article SET description = '@bugDescription', status = @status WHERE id = @id";
            // open connection 
            OpenConnection();



            // close connection
            CloseConnection();
        }

        public string DeleteBug(int reference)
        {
            string sqlQuery = "DELETE FROM Bug WHERE ref = @ref";



            MySqlCommand cmd = new(sqlQuery, connection);
            cmd.Parameters.Add("@ref", MySqlDbType.Int32);

            cmd.Parameters["@ref"].Value = reference;



            try
            {
                OpenConnection();

                cmd.ExecuteNonQuery();
                CloseConnection();
                return "Success !";
            }
            catch (Exception ex)
            {

                return string.Format("Failed :(  {0} ", ex.Message);
            }




        }


    }
}

