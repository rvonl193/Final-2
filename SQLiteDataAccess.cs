// Ryan von Lutzow
// SQLite Data Access Class
// 12-8-21

using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final
{
    internal class SQLiteDataAccess
    {
        
        public static List<User> LoadUsers()
        {

            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {

                var output = cnn.Query<User>("select * from Person", new DynamicParameters());
                return output.ToList();

            }

        }

        public static string LogIn()
        {

            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {

                var output = cnn.Query<User>("select * from Users", new DynamicParameters());
                return output.ToString();

            }

        }

        public static void SaveUser(User user)
        {

            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {

                cnn.Execute("insert into Users (Username, Password) values (@Username, @Password)", user);

            }

        }

        private static string LoadConnectionString(string ID = "Default")
        {

            return ConfigurationManager.ConnectionStrings[ID].ConnectionString;

        }

    }

}
