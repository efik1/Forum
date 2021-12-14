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
    public partial class RegisterForm : Form
    {
        private Point lastpoint;
        readonly DB db = new();
        readonly DataTable table = new();
        readonly MySqlDataAdapter adapter = new();
        static readonly string char_p = "(){}[]-_+=*/|?!,.$%^&;:`!";
        static readonly string number = "1234567890";

        public RegisterForm()
        {
            InitializeComponent();
            DefaultField();
        }
        private void DefaultField()
        {
            UserName.Text = "Введите имя";
            UserName.ForeColor = Color.Gray;

            Surename.Text = "Введите фамилию";
            Surename.ForeColor = Color.Gray;

            Login.Text = "Придумайте логин";
            Login.ForeColor = Color.Gray;

            Password.Text = "Придумайте пароль";
            Password.ForeColor = Color.Gray;

        }
        private void ErrorMessage(string ErrorMsg)
        {
            ErrorPanel.Visible = true;
            ErrorPanel.Text = ErrorMsg;
        }
        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Exit_MouseEnter(object sender, EventArgs e)
        {
            Exit.ForeColor = Color.Black;
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
            lastpoint = new Point(e.X, e.Y);
        }
        private void UserName_Enter(object sender, EventArgs e)
        {
            if (UserName.Text == "Введите имя")
            {
                UserName.Text = "";
                UserName.ForeColor = Color.FromArgb(0, 158, 142);
            }
        }
        private void Surename_Enter(object sender, EventArgs e)
        {
            if (Surename.Text == "Введите фамилию")
            {
                Surename.Text = "";
                Surename.ForeColor = Color.FromArgb(0, 158, 142);
            }
        }
        private void Login_Enter(object sender, EventArgs e)
        {
            if (Login.Text == "Придумайте логин")
            {
                Login.Text = "";
                Login.ForeColor = Color.FromArgb(0, 158, 142);
            }
        }
        private void Password_Enter(object sender, EventArgs e)
        {
            if (Password.Text == "Придумайте пароль")
            {
                Password.Text = "";
                Password.ForeColor = Color.FromArgb(0, 158, 142);
            }
        }
        private void UserName_Leave(object sender, EventArgs e)
        {
            if (UserName.Text == "")
            {
                UserName.Text = "Введите имя";
                UserName.ForeColor = Color.Gray;
            }
        }
        private void Surename_Leave(object sender, EventArgs e)
        {
            if (Surename.Text == "")
            {
                Surename.Text = "Введите фамилию";
                Surename.ForeColor = Color.Gray;
            }
        }
        private void Login_Leave(object sender, EventArgs e)
        {
            if (Login.Text == "")
            {
                Login.Text = "Придумайте логин";
                Login.ForeColor = Color.Gray;
            }
        }
        private void Password_Leave(object sender, EventArgs e)
        {
            if (Password.Text == "")
            {
                Password.Text = "Придумайте пароль";
                Password.ForeColor = Color.Gray;
            }
        }
        private void Regbutton_Click(object sender, EventArgs e) // Запуск обработки регистрации пользователя
        {
            string comm = "INSERT INTO `forum`.`users` (`Name`, `SureName`, `Login`, `Password`) VALUES (@name, @sname, @login, @pass);";
            string checkuniq = "SELECT * FROM `users` WHERE `login` = @login;";
            
            MySqlCommand InsertComm = new MySqlCommand(comm, db.GetConnection());
            MySqlCommand CheckUniqComm = new MySqlCommand(checkuniq, db.GetConnection());

            if (CheckInsertUserData(CheckUniqComm))
            {
                InsertDataOnDB(InsertComm, db);
                Hide();
                LoginForm loginform = new();
                loginform.Show();
            }
            else
            {
                ErrorMessage("Проверьте введенные данные");
            }
        }
        private void InsertDataOnDB(MySqlCommand InsertComm, DB db) // Запрос на добавление нового пользователя в БД
        {
            InsertComm.Parameters.Add("@name", MySqlDbType.VarChar).Value = UserName.Text;
            InsertComm.Parameters.Add("@sname", MySqlDbType.VarChar).Value = Surename.Text;
            InsertComm.Parameters.Add("@login", MySqlDbType.VarChar).Value = Login.Text;
            InsertComm.Parameters.Add("@pass", MySqlDbType.VarChar).Value = Password.Text;
           
            db.OpenConnection();

            if (InsertComm.ExecuteNonQuery() == 1) // Проверка отклика на запрос в БД 
            {
                MessageBox.Show("Аккаунт создан");
            }
            else
            {
                ErrorMessage("Ошибка сети");
            }

            db.CloseConnection();
        }
        public bool CheckInsertUserData(MySqlCommand command) // Проверка введеных пользователем данных
        {
            // Проверка полей ввода
            // проверка полей на наличие текста
            if (UserName.Text == "Введите фамилию")
            {
                return false;
            }
            if (Surename.Text == "Введите фамилию")
            {
                return false;
            }
            if (Login.Text == "Придумайте логин")
            {
                return false;
            }
            if (Password.Text == "Придумайте пароль")
            {
                return false;
            }

            // Проверка полей на валидность введенных данных
            if (CheckOnValidChar(UserName) == false)
            {
                MessageBox.Show("Имя не должно содержать символов и цифр");
                return false;
            }
            if (CheckOnValidNumber(UserName) == false)
            {
                MessageBox.Show("Имя не должно содержать символов и цифр");
                return false;
            }
            if (CheckOnValidChar(Surename) == false)
            {
                MessageBox.Show("Фамилия не должна содержать символов и цифр");
                return false;
            }
            if (CheckOnValidNumber(Surename) == false)
            {
                MessageBox.Show("Фамилия не должна содержать символов и цифр");
                return false;
            }
            if (CheckOnValidChar(Login) == false)
            {
                MessageBox.Show("Логин может содержать только буквы и цифры");
                return false;
            }
            if (CheckOnValidChar(Password) == false)
            {
                MessageBox.Show("Пароль должен содержать только буквы и цифры");
                return false;
            }
            if (CheckOnValidNumber(Password) == true)
            {
                MessageBox.Show("Пароль должен содержать цифры");
                return false;
            }

            // проверка логина на уникальность
            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = Login.Text;
            adapter.SelectCommand = command;
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
        public static bool CheckOnValidChar(TextBox textbox) // Проверка поля на символы
        {
            int count = 0;
            foreach (char item in textbox.Text)
            {
                for (int i = 0; i < char_p.Length; i++)
                {
                    if (item == char_p[i])
                    {
                        count++;
                    }
                }
            }
            if (count > 0) return false;
            else return true;
        }
        public static bool CheckOnValidNumber(TextBox textbox) // Проверка поля на числа
        {
            int count = 0;
            foreach (char item in textbox.Text)
            {
                for (int i = 0; i < number.Length; i++)
                {
                    if (item == number[i])
                    {
                        count++;
                    }
                }
            }
            if (count > 0) return false;
            else return true;
        }
    }
}
