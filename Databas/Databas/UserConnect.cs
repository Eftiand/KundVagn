using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User
{
    public class UserConnect
    {
        MySqlConnection dbConn;
        public String SERVER = "127.0.0.1";
        public String DATABASE = "logins";
        public String UID = "root";
        public String PASSWORD = "1234";

        public int Id { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }


        public UserConnect(int id, string u, string p)
        {
            StartDataBase();
            Id = id;
            UserName = u;
            Password = p;
        }
        void StartDataBase()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = SERVER;
            builder.UserID = UID;
            builder.Password = PASSWORD;
            builder.Database = DATABASE;

            string connString = builder.ToString();
            builder = null;
            dbConn = new MySqlConnection(connString);
        }
        void Login()
        {

        }
        public void CreateNewUser(string u, string p)
        {
            Console.WriteLine("Connecting server...");
            string query = string.Format("INSERT INTO users(id, username, password) VALUES (@i,@Us,@Ps)");
            MySqlCommand cmd = new MySqlCommand(query, dbConn);
            dbConn.Open();
            int id = (int)cmd.LastInsertedId;

            cmd.Parameters.AddWithValue("@i", id);
            cmd.Parameters.AddWithValue("@Us", u);
            cmd.Parameters.AddWithValue("@Ps", p);
            cmd.ExecuteNonQuery();
            

            dbConn.Close();
        }
    }
}
