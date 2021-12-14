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
    public partial class SettingsForm : Form
    {
        readonly DB db = new();
        private Point lastpoint;
        private string _username, _password, _surename, _login;

        public SettingsForm()
        {
            InitializeComponent();
            Default();
        }
        public void Default()
        {
            db.OpenConnection();

            MySqlCommand default_data_command = new MySqlCommand("SELECT * FROM `users` where UserID = @uid", db.GetConnection());
            default_data_command.Parameters.Add("@uid", MySqlDbType.VarChar).Value = MainForm.UserID;
            
            MySqlDataReader default_reader = default_data_command.ExecuteReader();
            while(default_reader.Read())
            {
                UserName.Text = default_reader[1].ToString();
                _username = UserName.Text;
                Surename.Text = default_reader[2].ToString();
                _surename = Surename.Text;
                Login.Text = default_reader[3].ToString();
                _login = Login.Text;
                Password.Text = default_reader[4].ToString();
                _password = Password.Text;
            }
            default_reader.Close();

            db.CloseConnection();
        }
        private void SaveChangeButton_Click(object sender, EventArgs e)
        {
            db.OpenConnection();

            MySqlCommand update_data = new ("UPDATE `forum`.`users` " +
                "SET `Name` = @newn, `Surename` = @newsn, `Login` = @newlog, `Password` = @newpas " +
                "WHERE (`UserID` = @uid);", db.GetConnection());

            if (CheckUserDataUpdate())
            {
                update_data.Parameters.Add("@newlog", MySqlDbType.VarChar).Value = Login.Text;
                update_data.Parameters.Add("@uid", MySqlDbType.VarChar).Value = MainForm.UserID;
                update_data.Parameters.Add("@newpas", MySqlDbType.VarChar).Value = Password.Text;
                update_data.Parameters.Add("@newn", MySqlDbType.VarChar).Value = UserName.Text;
                update_data.Parameters.Add("@newsn", MySqlDbType.VarChar).Value = Surename.Text;

                if (update_data.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Изменения Сохранены \nВы будете перенаправлены на страницу авторизации");
                    Hide();
                    LoginForm loginForm = new();
                    loginForm.Show();
                }
                else
                {
                    MessageBox.Show("Ошибка изменения данных \nПроверьте подключение к сети");
                }
            }
            else
            {
                MessageBox.Show("Ошибка изменения данных \nПроверьте введеные данные");
            }

            db.CloseConnection();
        }
        private bool CheckUserDataUpdate()
        {

            MySqlCommand check_data = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @login;", db.GetConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter(check_data);
            DataTable table = new();

            //Проверка на измение полей пользователем и проверка этих изменений
            if (UserName.Text.ToUpper() != _username.ToUpper() || 
                Password.Text.ToUpper() != _password.ToUpper() || 
                Login.Text.ToUpper() != _login.ToUpper() || 
                Surename.Text.ToUpper() != _surename.ToUpper())
            {
                if (RegisterForm.CheckOnValidChar(UserName) == false)
                {
                    MessageBox.Show("Имя не должно содержать символов и цифр");
                    return false;
                }
                if (RegisterForm.CheckOnValidNumber(UserName) == false)
                {
                    MessageBox.Show("Имя не должно содержать символов и цифр");
                    return false;
                }
                if (RegisterForm.CheckOnValidChar(Surename) == false)
                {
                    MessageBox.Show("Фамилия не должна содержать символов и цифр");
                    return false;
                }
                if (RegisterForm.CheckOnValidNumber(Surename) == false)
                {
                    MessageBox.Show("Фамилия не должна содержать символов и цифр");
                    return false;
                }
                if (RegisterForm.CheckOnValidChar(Login) == false)
                {
                    MessageBox.Show("Логин может содержать только буквы и цифры");
                    return false;
                }
                if (RegisterForm.CheckOnValidChar(Password) == false)
                {
                    MessageBox.Show("Пароль должен содержать только буквы и цифры");
                    return false;
                }
                if (RegisterForm.CheckOnValidNumber(Password) == true)
                {
                    MessageBox.Show("Пароль должен содержать буквы и цифры");
                    return false;
                }

                //Проверка логина пользователя на нименение и на уникальность 
                if (Login.Text.ToUpper() != LoginForm.UserIDlogin.ToUpper())
                {
                    check_data.Parameters.Add("@login", MySqlDbType.VarChar).Value = Login.Text;
                    adapter.SelectCommand = check_data;
                    adapter.Fill(table);

                    if (table.Rows.Count > 0)
                    {
                        MessageBox.Show("Oh shit here you go again! Данный логин уже зарегистрирован!");
                        table.Clear();
                        Login.ForeColor = Color.Red;
                        return false;
                    }
                    else return true;
                }
                else
                {
                    return true;
                }

            }
            else
            {
                MessageBox.Show("Вы не внесли измений");
                return false;
            }
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
        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
            MainForm mainForm = new();
            mainForm.Show();
        }
        private void Exit_MouseEnter(object sender, EventArgs e)
        {
            Exit.ForeColor = Color.Black;
        }
        private void Exit_MouseLeave(object sender, EventArgs e)
        {
            Exit.ForeColor = Color.White;
        }
    }
}
