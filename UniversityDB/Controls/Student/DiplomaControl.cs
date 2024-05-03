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
using UniversityDB.Database;

namespace UniversityDB.Controls.Student
{
    public partial class DiplomaControl : UserControl
    {
        public DiplomaControl()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                string query = @"
                    SELECT 
                        d.DiplomaID,
                        st.Full_name AS StudentName,
                        t.Full_name AS TeacherName,
                        d.Topic
                    FROM 
                        diploma d
                    JOIN 
                        students st ON d.StudentID = st.StudentID
                    JOIN 
                        teachers t ON d.TeacherID = t.TeacherID;
                ";
                DataTable diplomaData = new DatabaseManager().ExecuteQuery(query);
                dataGridView1.DataSource = diplomaData;
                dataGridView1.Columns["DiplomaID"].Visible = false; // Скрываем колонку ID
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}");
            }
        }

        // ADDITIONAL: diploma teachers by department, category
        private void button6_Click_1(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT DepartmentID, Name FROM Department";
                DataTable departments = new DatabaseManager().ExecuteQuery(query);
                comboBox6.DataSource = departments;
                comboBox6.DisplayMember = "Name";
                comboBox6.ValueMember = "DepartmentID";

                query = "SELECT Teachers_CategoryID, Category FROM Teachers_Category";
                DataTable categories = new DatabaseManager().ExecuteQuery(query);
                comboBox1.DataSource = categories;
                comboBox1.DisplayMember = "Category";
                comboBox1.ValueMember = "Teachers_CategoryID";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //execute
        private void button7_Click_1(object sender, EventArgs e)
        {
            if (comboBox6.SelectedValue == null || comboBox1.SelectedValue == null)
            {
                MessageBox.Show("Выберите кафедру и категорию преподавателя перед выполнением запроса.");
                return;
            }

            string departmentId = comboBox6.SelectedValue.ToString();
            string categoryID = comboBox1.SelectedValue.ToString();
            try
            {
                string query = @"
                    SELECT 
                        Full_name, Teachers_CategoryID
                    FROM 
                        Teachers
                    WHERE 
                        DepartmentID = @DepartmentID AND Teachers_CategoryID = @Teachers_CategoryID;
                ";

                List<MySqlParameter> parameters = new List<MySqlParameter>
                {
                    new MySqlParameter("@DepartmentID", departmentId),
                    new MySqlParameter("@Teachers_CategoryID", categoryID)
                };

                DataTable results = new DatabaseManager().ExecuteQuery(query, parameters);
                ShowResults(results);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка выполнения запроса: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            void ShowResults(DataTable results)
            {
                Form resultsForm = new Form
                {
                    Width = 500,
                    Height = 400,
                    Text = "Результаты поиска"
                };

                DataGridView dataGridView = new DataGridView
                {
                    Dock = DockStyle.Fill,
                    DataSource = results,
                    AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                    AllowUserToAddRows = false,
                    ReadOnly = true
                };
                resultsForm.Controls.Add(dataGridView);
                resultsForm.ShowDialog();  // Показываем как модальное окно
            }
        }
    }
}
