using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forum
{
    public partial class NewPostForm : Form
    {
        Point lastpoint;
        DB db = new();
        public NewPostForm()
        {
            InitializeComponent();
            DefaultField();

        }
        private void DefaultField()
        {
            PostTextField.Text = "Введите текст нового поста";
            PostTextField.ForeColor = Color.Gray;
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
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint = new Point(e.X, e.Y);
        }
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Left += e.X - lastpoint.X;
                Top += e.Y - lastpoint.Y;
            }
        }
        private void PostTextField_Enter(object sender, EventArgs e)
        {
            if (PostTextField.Text == "Введите текст нового поста")
            {
                PostTextField.Text = "";
                PostTextField.ForeColor = Color.Black;
            }
        }
        private void PostTextField_Leave(object sender, EventArgs e)
        {
            if (PostTextField.Text == "")
            {
                PostTextField.ForeColor = Color.Gray;
                PostTextField.Text = "Введите текст нового поста";
            }
        }
        private void ClearButton_Click(object sender, EventArgs e)
        {
            PostTextField.Text = "";
        }
        private void PublicationButton_Click(object sender, EventArgs e)
        {
            if (PostTextField.Text != "" || PostTextField.Text != "Введите текст нового поста")
            {
                try
                {
                    db.OpenConnection();
                    MySqlCommand AddPostCommand = new MySqlCommand("INSERT INTO `forum`.`posts` (`Text`, `ComCount`, `UserID`) VALUES (@txt, '0', @uid);", db.GetConnection());
                    MySqlCommand CheckAddNewPost = new MySqlCommand("select postid from posts where `Text` = @txt;", db.GetConnection());

                    AddPostCommand.Parameters.Add("@uid", MySqlDbType.VarChar).Value = Convert.ToString(MainForm.UserID);
                    AddPostCommand.Parameters.Add("@txt", MySqlDbType.VarChar).Value = PostTextField.Text;
                    CheckAddNewPost.Parameters.Add("@txt", MySqlDbType.VarChar).Value = PostTextField.Text;

                    if (AddPostCommand.ExecuteNonQuery() == 0)
                    {
                        MessageBox.Show("ОшибОЧКА");
                    }
                    else MessageBox.Show("Succefull, добавлен новый пост");
                    db.CloseConnection();
                    ReturnOnMainForm();
                    Close();
                }
                catch
                {
                    MessageBox.Show("ОшибОЧКА");
                    db.CloseConnection();
                }
            }
        }
        private void ReturnOnMainForm()
        {
            Close();
        }
    }

}
