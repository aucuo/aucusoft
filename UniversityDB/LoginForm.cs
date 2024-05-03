using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace UniversityDB
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void EnterButton_MouseEnter(object sender, EventArgs e)
        {
            EnterButton.BackColor = Color.DarkGreen;
        }

        private void EnterButton_MouseLeave(object sender, EventArgs e)
        {
            EnterButton.BackColor = Color.LightYellow;
        }

        private void EnterButton_Click(object sender, EventArgs e)
        {
            string username = Username.Text;
            string password = Password.Text;
            string MysqlCon = $"server=127.0.0.2;port=3306;user={username};database=university;password={password};";

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Поля обязательны для заполнения!");
                return;
            }

            try
            {
                using (MySqlConnection mySqlConnection = new MySqlConnection(MysqlCon))
                {
                    mySqlConnection.Open();
                    if (mySqlConnection.State == System.Data.ConnectionState.Open)
                    {
                        MessageBox.Show("Вы успешно авторизовались");
                        ShowRoleSpecificScreen(username);
                    }
                    mySqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Логин или пароль неправильные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowRoleSpecificScreen(string username)
        {
            Form screen = username switch
            {
                "root" => new AdminScreen(),
                "teacher" => new TeacherScreen(),
                "deanery" => new DeaneryScreen(),
                "student" => new StudentScreen(),
                _ => new StudentScreen()
            };
            this.Hide();
            screen.ShowDialog();
            this.Close();
        }
    }
}
