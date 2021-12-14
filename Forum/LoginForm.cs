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
    public partial class LoginForm : Form
    {
        Point lastpoint;
        public static string UserIDlogin;
        public LoginForm()
        {
            InitializeComponent();
            DefaultField();
        }
        private void DefaultField()
        {
            login.Text = "Введите логин";
            login.ForeColor = Color.Gray;

            password.Text = "Введите пароль";
            password.ForeColor = Color.Gray;

        }
        private void login_Enter(object sender, EventArgs e)
        {
            if (login.Text == "Введите логин")
            {
                login.Text = "";
                password.ForeColor = Color.FromArgb(0, 158, 142);
            }
        }
        private void login_Leave(object sender, EventArgs e)
        {
            if (login.Text == "")
            {
                login.Text = "Введите логин";
                login.ForeColor = Color.Gray;
            }
        }
        private void password_Enter(object sender, EventArgs e)
        {
            if (password.Text == "Введите пароль")
            {
                password.Text = "";
                password.ForeColor = Color.FromArgb(0, 158, 142);
            }
        }
        private void password_Leave(object sender, EventArgs e)
        {
            if (password.Text == "")
            {
                password.Text = "Введите пароль";
                password.ForeColor = Color.Gray;
            }
        }
        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Exit_MouseEnter(object sender, EventArgs e)
        {
            Exit.ForeColor = Color.FromArgb(0,0,0);
        }
        private void Exit_MouseLeave(object sender, EventArgs e)
        {
            Exit.ForeColor = Color.White;
        }
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Left += e.X - lastpoint.X;
                Top += e.Y - lastpoint.Y;
            }
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint = new Point (e.X, e.Y);
        }
        private void Loginbutton_Click(object sender, EventArgs e)
        {
            string userlogin = login.Text;
            string userpassword = password.Text;

            DB dB = new();

            DataTable table = new();

            MySqlDataAdapter adapter = new();

            MySqlCommand command = new ("SELECT * FROM `users` WHERE `Login` = @ul AND `password` = @up", dB.GetConnection());
   
            command.Parameters.Add("@ul", MySqlDbType.VarChar).Value = userlogin;
            command.Parameters.Add("@up", MySqlDbType.VarChar).Value = userpassword;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                UserIDlogin = login.Text;
                Hide();
                MainForm mainform = new();
                mainform.Show();
            }
            else
            {
                MessageBox.Show("Ошибка авторизации");
            }
            
        } // Начало процесса авторизации по кнопке
        private void Reglabel_Click(object sender, EventArgs e)
        {
            Hide();
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
        } // Переход на страницу регистрации
        private void reglabel_MouseEnter(object sender, EventArgs e)
        {
            Exit.ForeColor = Color.FromArgb(0, 0, 0);
        } // доп. кнопки регистрации...
        private void reglabel_MouseLeave(object sender, EventArgs e)
        {
            Exit.ForeColor = Color.White;
        } // доп. кнопки регистрации...
    }
}
