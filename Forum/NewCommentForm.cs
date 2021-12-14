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
    public partial class NewCommentForm : Form
    {
        Point lastpoint;
        DB db = new();
        DateTime date = DateTime.Now;
        public NewCommentForm()
        {
            InitializeComponent();
            Default();
        }
        public void Default()
        {
            CommTextField.Text = "Введите текст комментария";
            CommTextField.ForeColor = Color.Gray;
            label1.Text = MainForm.This_PostID.ToString();
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
        private void CommTextField_Enter(object sender, EventArgs e)
        {
            if (CommTextField.Text == "Введите текст комментария")
            {
                CommTextField.Text = "";
                CommTextField.ForeColor = Color.Black;
            }
        }
        private void CommTextField_Leave(object sender, EventArgs e)
        {
            if (CommTextField.Text == "")
            {
                CommTextField.ForeColor = Color.Gray;
                CommTextField.Text = "Введите текст комментария";
            }
        }
        private void PublicationButton_Click(object sender, EventArgs e)
        {
            if (CommTextField.Text != "" || CommTextField.Text != "Введите текст комментария")
            {
                try
                {
                    db.OpenConnection();
                   
                    MySqlCommand AddCommCommand = new MySqlCommand("INSERT INTO `forum`.`comments` (`ComText`, `ComDate`, `PostID`,`UserID`) VALUES (@txt, @dtn, @pid, @uid);", db.GetConnection());
                
                    AddCommCommand.Parameters.Add("@dtn", MySqlDbType.VarChar).Value = date.ToShortDateString();
                    AddCommCommand.Parameters.Add("@pid", MySqlDbType.VarChar).Value = MainForm.This_PostID;
                    AddCommCommand.Parameters.Add("@uid", MySqlDbType.VarChar).Value = Convert.ToString(MainForm.UserID);
                    AddCommCommand.Parameters.Add("@txt", MySqlDbType.VarChar).Value = CommTextField.Text;

                    if (AddCommCommand.ExecuteNonQuery() == 0)
                    {
                        MessageBox.Show("ОшибОЧКА");
                    }
                    else MessageBox.Show("Комментарий опубликован");
                    db.CloseConnection();
                    ReturnOnMainForm();
                    Close();
                }
                catch
                {
                    MessageBox.Show("Ошибка публикации комментария");
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
