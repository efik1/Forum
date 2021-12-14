using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Forum
{
    public partial class CheckPostForm : Form
    {
        Point lastpoint;
        DB db = new();
        string Login = "";
        string Comment_Author_Login = "";
        int UserID, Comment_AuthorID;
        public CheckPostForm()
        {
            InitializeComponent();
            PostViev();
            CommentsForPostViev();
            if (CommentsBox.Text == "")
            {
                CommentsBox.Text = "Здесь еще нет комментариев \n Будьте первым";
                CommentsBox.ForeColor = Color.Gray;
            }
        }

        public void PostViev()
        {
            label2.Text = MainForm.This_PostID.ToString();

            db.OpenConnection();

            MySqlCommand newcommand = new MySqlCommand("select * from `posts` where `postid` = @pid", db.GetConnection());
            MySqlCommand login_check = new MySqlCommand("select Login from `users` where `UserID` = @uid", db.GetConnection());

            newcommand.Parameters.Add("@pid", MySqlDbType.Int32).Value = MainForm.This_PostID;

            MySqlDataReader reader = newcommand.ExecuteReader();
            while (reader.Read())
            {
                UserID = (int)reader[3];

                PostTextBox.Text = reader[1].ToString();
            }
            reader.Close();
            login_check.Parameters.Add("@uid", MySqlDbType.Int32).Value = UserID;
            Login = login_check.ExecuteScalar().ToString();
            label5.Text = Login;

            db.CloseConnection();
        }
        public void CommentsForPostViev()
        {
            db.OpenConnection();

            MySqlCommand newcommand = new MySqlCommand("select * from `comments` where `postid` = @pid", db.GetConnection());
            newcommand.Parameters.Add("@pid", MySqlDbType.Int32).Value = MainForm.This_PostID;

            DataTable dataTable = new();
            MySqlDataAdapter adapter = new();
            adapter.SelectCommand = new MySqlCommand("select userid,login from `users`", db.GetConnection());
            adapter.Fill(dataTable);

            MySqlDataReader reader_comments = newcommand.ExecuteReader();
            while (reader_comments.Read())
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    if (reader_comments[4].ToString() == dataTable.Rows[i][0].ToString())
                    {
                        Comment_Author_Login = dataTable.Rows[i][1].ToString();
                    
                    }
                }
                DateTime dt = (DateTime)reader_comments[2];
                    CommentsBox.Text = CommentsBox.Text +
                    Comment_Author_Login.ToString() + " : " +
                    Environment.NewLine +
                    reader_comments[1].ToString() + "  " +
                    dt.ToShortDateString() + "  " +
                    Environment.NewLine +
                    Environment.NewLine;

            }
            reader_comments.Close();

            label5.Text = Login;
            db.CloseConnection();
        }
        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void Exit_MouseEnter(object sender, EventArgs e)
        {
            Exit.ForeColor = Color.Black;
        }
        private void Exit_MouseLeave(object sender, EventArgs e)
        {
            Exit.ForeColor = Color.White;
        }
        private void main_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint = new Point(e.X, e.Y);
        }
        private void main_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Left += e.X - lastpoint.X;
                Top += e.Y - lastpoint.Y;
            }
        }

        private void ReloadButton_Click(object sender, EventArgs e)
        {
            Close();
            CheckPostForm newform = new();
            newform.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NewCommentForm newform = new();
            newform.Show();
        }

    }
}
