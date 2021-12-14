using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum
{
    class DB
    {
        readonly MySqlConnection connection = new("server=127.0.0.1;port=3306;username=root;password=Vladik3214;database=forum");

        public void OpenConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            SyncPostsWithComments();
        }
        public void SyncPostsWithComments()
        {
            MySqlCommand update_posts = new MySqlCommand
                ("UPDATE `posts` " +
                "SET `ComCount` = (SELECT COUNT(*) " +
                "FROM `comments` " +
                "WHERE comments.postid = posts.postid);"
                , connection);

            update_posts.ExecuteNonQuery();
        }
        public void CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
        public MySqlConnection GetConnection()
        {
            return connection;
        }
    }
}
