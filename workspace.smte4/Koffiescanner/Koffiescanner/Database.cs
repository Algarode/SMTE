using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Koffiescanner
{
    class Database
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string user;
        private string password;

        public Database()
        {
            server = "31.186.175.188";
            database = "devimo_pts";
            user = "devimo_pts";
            password = "Ob88hLHd";
            string connectionString;
            connectionString = "Server=" + server + "; Port=3306; " + "Database=" + database + "; " + "Uid=" + user + "; " + "Pwd=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        private bool openConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        private bool closeConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public static void insert(string sql)
        {
            Database db = new Database();

            db.openConnection();

            MySqlCommand command = new MySqlCommand(sql, db.connection);

            command.ExecuteNonQuery();

            db.closeConnection();
        }
    }
}