using MySql.Data.MySqlClient;
using System.Data;
using UniversityDB.Database;

namespace UniversityDB.Controls
{
    public partial class TeachersControl : UserControl
    {
        private List<MySqlParameter> CreateSqlParameters()
        {
            return new List<MySqlParameter>
        {
            new MySqlParameter("@FullName", textBox9.Text),
            new MySqlParameter("@Gender", radioButton8.Checked ? "Male" : "Female"),
            new MySqlParameter("@Age", Convert.ToInt32(textBox8.Text)),
            new MySqlParameter("@ChildrenCount", Convert.ToInt32(numericUpDown3.Value)),
            new MySqlParameter("@Salary", Convert.ToDecimal(textBox7.Text)),
            new MySqlParameter("@DepartmentID", comboBox6.SelectedValue),
            new MySqlParameter("@TeachersCategoryID", comboBox5.SelectedValue)
        };
        }
        public TeachersControl()
        {
            InitializeComponent();
            LoadData();
            LoadDepartments();
            LoadTeacherCategories();
        }
        private void LoadData()
        {
            try
            {
                string query = @"
                    SELECT 
                        t.TeacherID,
                        t.Full_name,
                        t.Gender,
                        t.Age,
                        t.Children_count,
                        t.Salary,
                        d.Name AS DepartmentName,
                        tc.Category AS TeacherCategory
                    FROM 
                        teachers t
                    JOIN 
                        department d ON t.DepartmentID = d.DepartmentID
                    JOIN 
                        teachers_category tc ON t.Teachers_CategoryID = tc.Teachers_CategoryID;
                ";
                DataTable teachersData = new DatabaseManager().ExecuteQuery(query);
                dataGridView1.DataSource = teachersData;
                dataGridView1.Columns["TeacherID"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}");
            }
        }
        private void LoadDepartments()
        {
            string query = "SELECT DepartmentID, Name FROM department";
            DataTable departments = new DatabaseManager().ExecuteQuery(query);
            comboBox6.DataSource = departments;
            comboBox6.DisplayMember = "Name";
            comboBox6.ValueMember = "DepartmentID";
        }

        private void LoadTeacherCategories()
        {
            string query = "SELECT Teachers_CategoryID, Category FROM teachers_category";
            DataTable categories = new DatabaseManager().ExecuteQuery(query);
            comboBox5.DataSource = categories;
            comboBox5.DisplayMember = "Category";
            comboBox5.ValueMember = "Teachers_CategoryID";
        }
        private void ExecuteSql(string query, List<MySqlParameter> parameters, string successMessage)
        {
            try
            {
                new DatabaseManager().ExecuteQuery(query, parameters);
                MessageBox.Show(successMessage);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка выполнения операции с базой данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int teacherId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["TeacherID"].Value);
                radioButton8.Checked = false;
                radioButton7.Checked = false;
                try
                {
                    string query = "SELECT * FROM teachers WHERE TeacherID = @TeacherID";
                    List<MySqlParameter> parameters = new List<MySqlParameter>
                    {
                        new MySqlParameter("@TeacherID", teacherId)
                    };
                    DataTable teacherDetails = new DatabaseManager().ExecuteQuery(query, parameters);
                    if (teacherDetails.Rows.Count > 0)
                    {
                        DataRow row = teacherDetails.Rows[0];
                        textBox9.Text = row["Full_name"].ToString();
                        textBox8.Text = row["Age"].ToString();
                        textBox7.Text = row["Salary"].ToString();
                        numericUpDown3.Value = row["Children_count"] != DBNull.Value ? Convert.ToDecimal(row["Children_count"]) : 0;
                        comboBox6.SelectedValue = row["DepartmentID"];
                        comboBox5.SelectedValue = row["Teachers_CategoryID"];
                        if (row["Gender"].ToString() == "Male")
                            radioButton8.Checked = true;
                        else
                            radioButton7.Checked = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка загрузки данных: {ex.Message}");
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Add new teacher
            string insertQuery = @"
                INSERT INTO teachers (Full_name, Gender, Age, Children_count, Salary, DepartmentID, Teachers_CategoryID)
                VALUES (@FullName, @Gender, @Age, @ChildrenCount, @Salary, @DepartmentID, @TeachersCategoryID);
            ";
            var parameters = CreateSqlParameters();
            ExecuteSql(insertQuery, parameters, "Новый учитель успешно добавлен.");
        }
        private void updateTeacher(object sender, EventArgs e)
        {
            // Update existing teacher
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int teacherId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["TeacherID"].Value);
                string updateQuery = @"
                    UPDATE teachers
                    SET
                        Full_name = @FullName,
                        Gender = @Gender,
                        Age = @Age,
                        Salary = @Salary,
                        Children_count = @ChildrenCount,
                        DepartmentID = @DepartmentID,
                        Teachers_CategoryID = @TeachersCategoryID
                    WHERE TeacherID = @TeacherID;
                ";
                var parameters = CreateSqlParameters();
                parameters.Add(new MySqlParameter("@TeacherID", teacherId));
                ExecuteSql(updateQuery, parameters, "Данные учителя успешно обновлены.");
            }
            else
            {
                MessageBox.Show("Выберите учителя для обновления.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //delete
        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var result = MessageBox.Show("Вы уверены, что хотите удалить выбранных учителей?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    {
                        if (!row.IsNewRow) // Проверка на новую строку, которая еще не сохранена в базе
                        {
                            int teacherId = Convert.ToInt32(row.Cells["TeacherID"].Value);
                            string deleteQuery = "DELETE FROM teachers WHERE TeacherID = @TeacherID";

                            List<MySqlParameter> parameters = new List<MySqlParameter>
                            {
                                new MySqlParameter("@TeacherID", teacherId)
                            };

                            new DatabaseManager().ExecuteQuery(deleteQuery, parameters);
                        }
                    }
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите учителя для удаления.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
