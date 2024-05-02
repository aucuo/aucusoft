using MySql.Data.MySqlClient;
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
            string username = Username.Text.ToString();
            string password = Password.Text.ToString();
            string MysqlCon = $"server=127.0.0.2;port=3306;user={username};database=university;password={password}";
            if (String.IsNullOrEmpty(username))
            {
                MessageBox.Show("Поля Логин  обязательно для заполнения!");
            }
            else
            {
                try
                {
                    MySqlConnection mySqlConnection = new MySqlConnection(MysqlCon);
                    mySqlConnection.Open();
                    /*MySqlCommand mySqlCommand = new MySqlCommand("select * from users", mySqlConnection);
                    MySqlDataReader reader = mySqlCommand.ExecuteReader();*/
                    if (mySqlConnection.State == System.Data.ConnectionState.Open)
                    {
                        MessageBox.Show("Вы успешно авторизовались");

                        // тут кода писать

                        switch (username)
                        {
                            case "admin":
                                Application.Run(new AdminScreen());
                                break;
                            default:
                                Application.Run(new AdminScreen());
                                break;
                        }
                    }
                    mySqlConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Invalid ты: {ex}");
                }
            }
        }
    }
}