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
        private string uid;
        private string password;

        public Database()
        {
            server = "";
            database = "";
            uid = "";
            password = "";
            string connectionString;
            connectionString = server + ";" + database + ";" + uid + ";" + password + ";";

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

            if (!db.openConnection())
            {
                db.openConnection();
            }

            MySqlCommand command = new MySqlCommand(sql, db.connection);

            command.ExecuteNonQuery();

            db.closeConnection();
        }
    }
}