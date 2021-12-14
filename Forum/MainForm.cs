using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Forum
{
    public partial class MainForm : Form
    {
        Point lastpoint;
        public static int UserID, This_PostID;
        readonly DB db = new();
        readonly List<GroupBox> grb_list = new();
        public int NextCountClick = 0;
        private int newgroupBoxPosY = 33;
        public MainForm()
        {
            InitializeComponent();
            LoginLabelName();
            ConnectDB();
        }
        private void LoginLabelName()
        {
            LoginLabel.Text = LoginForm.UserIDlogin;
        }
        private void main_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Left += e.X - lastpoint.X;
                Top += e.Y - lastpoint.Y;
            }
        }
        private void main_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint = new Point(e.X, e.Y);
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
        private void AccOut_Click(object sender, EventArgs e)
        {
            Hide();
            LoginForm loginForm = new();
            loginForm.Show();
        }
        private void AccOut_MouseEnter(object sender, EventArgs e)
        {
            AccOut.ForeColor = Color.Black;
        }
        private void AccOut_MouseLeave(object sender, EventArgs e)
        {
            AccOut.ForeColor = Color.White;
        }
        //соединение с бд и получение id пользователя
        private void ConnectDB() 
        {
            MySqlCommand command_id;
            string query_id;

            db.OpenConnection();

            //получение id пользователя по логину из LoginForm
            query_id = "select UserID from `users` where `Login` = @ul";
            command_id = new (query_id, db.GetConnection());
            command_id.Parameters.Add("@ul", MySqlDbType.VarChar).Value = LoginForm.UserIDlogin;
            UserID = Convert.ToInt32(command_id.ExecuteScalar().ToString());

            db.CloseConnection();
        }
        // получение списка постов пользователя и вывод каждого из них в новом groupBox
        private void UsersPostQuery(int userid, DB db, string query_posts) 
        {
            db.OpenConnection();
            //Запрос на получение PostID и Text из постов по UserID 
            MySqlCommand command_posts;
            //query_posts = "select postid,text,comcount from `posts` where `userid` = @id";
            command_posts = new(query_posts, db.GetConnection());
            command_posts.Parameters.Add("@id", MySqlDbType.VarChar).Value = userid;

            // получение каждого поста пользователя и создание для него нового groupbox
            MySqlDataReader post_reader = command_posts.ExecuteReader();
            int count = 0;
            //форматирование списка комментариев при повторном вызове метода
            for (int i = 0; i < grb_list.Count; i++)
            {
                main.Controls.Remove(grb_list[i]);
            }
            grb_list.Clear();
            ////создания groupbox к каждому посту пользователя
            while (post_reader.Read())
            {
                CreateNewBox(post_reader[0].ToString(), post_reader[1].ToString(), 184, newgroupBoxPosY, Convert.ToInt32(post_reader[2]));
                count++;
                if (count == 4)
                {
                    newgroupBoxPosY = 33;
                    count = 0;
                }
            }
            post_reader.Close();
            db.CloseConnection();
        }
        // получение списка постов всех пользователей с наибольшим количеством комментариев
        private void TopPostQuery(DB db)
        {
            db.OpenConnection();

            MySqlCommand command_posts;
            string query_posts = "SELECT postid,text,comcount FROM `posts` WHERE comcount > 0 ORDER BY comcount DESC";
            command_posts = new(query_posts, db.GetConnection());

            // получение каждого поста пользователя и создание для него нового groupbox
            MySqlDataReader post_reader = command_posts.ExecuteReader();
            int count = 0;
            int count2 = 0;
            //форматирование списка комментариев при повторном вызове метода
            for (int i = 0; i < grb_list.Count; i++)
            {
                main.Controls.Remove(grb_list[i]);
            }
            grb_list.Clear();
            ////создания groupbox к каждому посту пользователя
            while (post_reader.Read())
            {
                CreateNewBox(post_reader[0].ToString(), post_reader[1].ToString(), 184, newgroupBoxPosY, Convert.ToInt32(post_reader[2]));
                count++;
                if (count == 4)
                {
                    newgroupBoxPosY = 33;
                    count = 0;
                    count2 ++;
                }
                if (count2 == 2)
                {
                    break;
                }
            }
            post_reader.Close();

            db.CloseConnection();
        }
        // получение списка самых новых постов
        private void NewPostsQuery(DB db)
        {
            db.OpenConnection();

            MySqlCommand command_posts;
            string query_posts = "SELECT postid,text,comcount FROM `posts` ORDER BY postid DESC";
            command_posts = new(query_posts, db.GetConnection());

            // получение каждого поста пользователя и создание для него нового groupbox
            MySqlDataReader post_reader = command_posts.ExecuteReader();
            // счетчики для корректного отображения постов на странице
            int count = 0;
            int count2 = 0;
            // форматирование списка комментариев при повторном вызове метода
            for (int i = 0; i < grb_list.Count; i++)
            {
                main.Controls.Remove(grb_list[i]);
            }
            grb_list.Clear();
            ////создания groupbox к каждому посту пользователя
            while (post_reader.Read())
            {
                CreateNewBox(post_reader[0].ToString(), post_reader[1].ToString(), 184, newgroupBoxPosY, Convert.ToInt32(post_reader[2]));
                count++;
                if (count == 4)
                {
                    newgroupBoxPosY = 33;
                    count = 0;
                    count2++;
                }
                if (count2 == 2)
                {
                    break;
                }
            }
            post_reader.Close();

            db.CloseConnection();
        }
        // Создание нового groupBox
        private void CreateNewBox(string grbtext, string text, int x,int y, int commcount) 
        {
            
            GroupBox newgroupBox = new ();
            TextBox newtextBox = new ();
            Button newbuttonBox = new();
            PictureBox newCommPictBox = new();
            Label newCommCount = new();

            //создание groupbox
            newgroupBox.Anchor = AnchorStyles.None;
            newgroupBox.Location = new Point(x, y);
            newgroupBox.Size = new Size(700, 90);
            newgroupBox.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            newgroupBox.Text = "Post #" + grbtext;
            newgroupBox.Name = grbtext;
            newgroupBox.ForeColor = Color.Black;

            //создание textbox in groupbox
            newgroupBox.Controls.Add(newtextBox);
            newtextBox.BackColor = Color.FromArgb(136,231,221);
            newtextBox.Location = new Point(6, 22);
            newtextBox.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            newtextBox.ForeColor = Color.White;
            newtextBox.Location = new Point(6, 22);
            newtextBox.MaxLength = 100;
            newtextBox.Multiline = true;
            newtextBox.BorderStyle = BorderStyle.None;
            newtextBox.Size = new Size(687, 30);
            newtextBox.TabIndex = 8;
            newtextBox.ReadOnly = true;
            newtextBox.Text = text;
            newtextBox.ScrollBars = ScrollBars.Both;

            //создаем button in groupbox
            newgroupBox.Controls.Add(newbuttonBox);
            newbuttonBox.Font = new Font("Segoe UI", 6F, FontStyle.Bold, GraphicsUnit.Point);
            newbuttonBox.Location = new Point(6, 64);
            newbuttonBox.Size = new Size(90, 20);
            newbuttonBox.TabIndex = 9;
            newbuttonBox.Text = "Комментировать";
            newbuttonBox.Name = grbtext;
            newbuttonBox.UseVisualStyleBackColor = true;
            newbuttonBox.Click += new EventHandler(Button_Click);

            //создаем picturebox in groupbox
            newgroupBox.Controls.Add(newCommPictBox);
            newCommPictBox.Cursor = Cursors.Hand;
            newCommPictBox.Image = Properties.Resources._1737374_comment_comments_description_note_notice_icon;
            newCommPictBox.Location = new Point(100, 64);
            newCommPictBox.Name = grbtext;
            newCommPictBox.Size = new Size(18, 20);
            newCommPictBox.SizeMode = PictureBoxSizeMode.StretchImage;
            newCommPictBox.TabIndex = 13;
            newCommPictBox.TabStop = false;
            newCommPictBox.Click += new EventHandler(CommPict_Click);

            //создаем счетчик комментариев in groupbox
            newgroupBox.Controls.Add(newCommCount);
            newCommCount.AutoSize = true;
            newCommCount.Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point);
            newCommCount.Location = new Point(115, 67);
            newCommCount.Name = "CommCount";
            newCommCount.Size = new Size(38, 13);
            newCommCount.TabIndex = 14;
            newCommCount.Text = commcount.ToString();
            newCommCount.ForeColor = Color.Black;

            //инкрементируем положение groupBox по оси Y
            newgroupBoxPosY += 90;

            main.Controls.Add(newgroupBox);
            grb_list.Add(newgroupBox);
        }
        // обработка нажатия на иконку комментариев
        private void CommPict_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            This_PostID = Convert.ToInt32(pictureBox.Name);
            CheckPostForm newform = new();
            newform.Show();
        }
        // обработка нажатия на кнопку "Мои посты" и вызов методов, отвечающих за подгрузку их на mainpanel
        private void MyPosts_Click(object sender, EventArgs e)
        {
            NextCountClick = 0;
            if (NextCountClick == 0) BackPageBut.Visible = false;
            newgroupBoxPosY = 33;
            UsersPostQuery(UserID, db, "select postid,text,comcount from `posts` where `userid` = @id");
            PostsLoadInForm(NextCountClick);
            comboBox.Visible = true;
            
        }
        private void MyPosts_MouseEnter(object sender, EventArgs e)
        {
            MyPosts.ForeColor = Color.Black;
        }
        private void MyPosts_MouseLeave(object sender, EventArgs e)
        {
            MyPosts.ForeColor = Color.White;
        }
        private void PostsLoadInFormFirst() // выводит первые 4 поста
        {
            for (int i = 4; i < grb_list.Count; i++)
            {
                main.Controls.Remove(grb_list[i]);
            }
            for (int i = 0; i < grb_list.Count; i++)
            {
                main.Controls.Add(grb_list[i]);
            }
            if (grb_list.Count > 4)
            {
                NextPageBut.Visible = true;
            }
            if (grb_list.Count == 0)
            {
                MessageBox.Show("Вы еще не опубликовали ни одного поста!\nНажмите на иконку ручки чтобы создать новый пост");
            }
        }
        private void PostsLoadInForm(int NextCountClick) // выводит все посты
        {
            int count = 0;
            if (NextCountClick == 0)
            {
                    PostsLoadInFormFirst();
            }
            if (NextCountClick > 0)
            {
                for (int i = 0; i < NextCountClick * 4; i++)
                {
                    main.Controls.Remove(grb_list[i]);
                }
                for (int i = NextCountClick * 4; i < grb_list.Count; i++)
                {
                    count++;
                    main.Controls.Add(grb_list[i]);
                    if (count > 4)
                    {
                        NextPageBut.Visible = true;
                    }
                    else
                    {
                        NextPageBut.Visible = false;
                    }
                }
            }

        }
        private void NextPageBut_Click(object sender, EventArgs e)
        {
            NextCountClick++;
            BackPageBut.Visible = true;
            PostsLoadInForm(NextCountClick);
        }
        private void NextPageBut_MouseEnter(object sender, EventArgs e)
        {
            NextPageBut.ForeColor = Color.FromArgb(0, 0, 0);
        }
        private void NextPageBut_MouseLeave(object sender, EventArgs e)
        {
            NextPageBut.ForeColor = Color.White;
        }
        private void BackPageBut_Click(object sender, EventArgs e)
        {
            NextCountClick--;
            if (NextCountClick == 0)
            {
                BackPageBut.Visible = false;
            }
            PostsLoadInForm(NextCountClick);
            NextPageBut.Visible = true;
        }
        private void BackPageBut_MouseEnter(object sender, EventArgs e)
        {
            BackPageBut.ForeColor = Color.FromArgb(0, 0, 0);
        }
        private void BackPageBut_MouseLeave(object sender, EventArgs e)
        {
            BackPageBut.ForeColor = Color.White;
        }
        public void Button_Click(object sender, EventArgs e)// обработка нажатия кнопки на посте
        {
            Button butt = (Button)sender;
            This_PostID = Convert.ToInt32(butt.Name);
            NewCommentForm newform = new();
            newform.Show();
            
        }
        private void PenBox_Click(object sender, EventArgs e)
        {
            NewPostForm newpostform = new();
            newpostform.Show();
        }
        //обработка нажатия на кнопку "Топ" и наведения на нее
        private void TopPosts_Click(object sender, EventArgs e)
        {
            db.OpenConnection();
            NextCountClick = 0;
            if (NextCountClick == 0) BackPageBut.Visible = false;
            newgroupBoxPosY = 33;
            TopPostQuery(db);
            PostsLoadInForm(NextCountClick);
            db.CloseConnection();
            comboBox.Visible = false;
        }
        private void TopPosts_MouseEnter(object sender, EventArgs e)
        {
            TopPosts.ForeColor = Color.Black;
        }
        private void TopPosts_MouseLeave(object sender, EventArgs e)
        {
            TopPosts.ForeColor = Color.White;
        }
        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox.SelectedIndex)
            {
                case 0:
                    NextCountClick = 0;
                    newgroupBoxPosY = 33;
                    UsersPostQuery(UserID, db, "select postid,text,comcount from `posts` where `userid` = @id ORDER BY postid ASC");
                    PostsLoadInForm(NextCountClick);
                    break;
                case 1:
                    NextCountClick = 0;
                    newgroupBoxPosY = 33;
                    UsersPostQuery(UserID, db, "select postid,text,comcount from `posts` where `userid` = @id ORDER BY postid DESC");
                    PostsLoadInForm(NextCountClick);
                    break;
                case 2:
                    NextCountClick = 0;
                    newgroupBoxPosY = 33;
                    UsersPostQuery(UserID, db, "select postid,text,comcount from `posts` where `userid` = @id ORDER BY comcount DESC");
                    PostsLoadInForm(NextCountClick);
                    break;
                default:
                    MessageBox.Show("ОШИБОЧКА ВЫБОРА СОРТИРОВКИ");
                    break;
            }
        }
        //обработка нажатия на кнопку "Лента" и наведения на нее
        private void News_Click(object sender, EventArgs e)
        {
            db.OpenConnection();
            NextCountClick = 0;
            if (NextCountClick == 0) BackPageBut.Visible = false;
            newgroupBoxPosY = 33;
            NewPostsQuery(db);
            PostsLoadInForm(NextCountClick);
            db.CloseConnection();
            comboBox.Visible = false;
        }
        private void News_MouseEnter(object sender, EventArgs e)
        {
            News.ForeColor = Color.Black;
        }
        private void News_MouseLeave(object sender, EventArgs e)
        {
            News.ForeColor = Color.White;
        }
        //обработка нажатия на кнопку "Настройки" и наведения на нее
        private void Settings_Click(object sender, EventArgs e)
        {
            Close();
            SettingsForm setform = new();
            setform.Show();
        }
        private void Settings_MouseEnter(object sender, EventArgs e)
        {
            Settings.ForeColor = Color.Black;
        }
        private void Settings_MouseLeave(object sender, EventArgs e)
        {
            Settings.ForeColor = Color.White;
        }
        
    }
}
