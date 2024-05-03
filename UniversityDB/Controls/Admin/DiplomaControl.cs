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

namespace UniversityDB.Controls
{
    public partial class DiplomaControl : UserControl
    {
        public DiplomaControl()
        {
            InitializeComponent();
            LoadData();
            LoadStudents();
            LoadTeachers();
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
                        d.Topic,
                        st.StudentID,
                        t.TeacherID
                    FROM 
                        diploma d
                    JOIN 
                        students st ON d.StudentID = st.StudentID
                    JOIN 
                        teachers t ON d.TeacherID = t.TeacherID;
                ";
                DataTable diplomaData = new DatabaseManager().ExecuteQuery(query);
                dataGridView1.DataSource = diplomaData;
                dataGridView1.Columns["DiplomaID"].Visible = false;
                dataGridView1.Columns["StudentID"].Visible = false;
                dataGridView1.Columns["TeacherID"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}");
            }
        }
        private void LoadStudents()
        {
            try
            {
                string query = "SELECT StudentID, Full_name FROM students";
                DataTable students = new DatabaseManager().ExecuteQuery(query);
                comboBoxStudent.DataSource = students;
                comboBoxStudent.DisplayMember = "Full_name";
                comboBoxStudent.ValueMember = "StudentID";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки списка студентов: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTeachers()
        {
            try
            {
                string query = "SELECT TeacherID, Full_name FROM teachers";
                DataTable teachers = new DatabaseManager().ExecuteQuery(query);
                comboBoxTeacher.DataSource = teachers;
                comboBoxTeacher.DisplayMember = "Full_name";
                comboBoxTeacher.ValueMember = "TeacherID";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки списка учителей: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //add
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string insertQuery = @"
                    INSERT INTO diploma (StudentID, TeacherID, Topic)
                    VALUES (@StudentID, @TeacherID, @Topic);
                ";

                List<MySqlParameter> parameters = new List<MySqlParameter>
                {
                    new MySqlParameter("@StudentID", comboBoxStudent.SelectedValue),
                    new MySqlParameter("@TeacherID", comboBoxTeacher.SelectedValue),
                    new MySqlParameter("@Topic", textBox5.Text)
                };

                new DatabaseManager().ExecuteQuery(insertQuery, parameters);
                MessageBox.Show("Диплом успешно добавлен.");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка добавления диплома: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //save
        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    int diplomaId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["DiplomaID"].Value);
                    string updateQuery = @"
                        UPDATE diploma
                        SET StudentID = @StudentID, TeacherID = @TeacherID, Topic = @Topic
                        WHERE DiplomaID = @DiplomaID;
                    ";

                    List<MySqlParameter> parameters = new List<MySqlParameter>
                    {
                        new MySqlParameter("@DiplomaID", diplomaId),
                        new MySqlParameter("@StudentID", comboBoxStudent.SelectedValue),
                        new MySqlParameter("@TeacherID", comboBoxTeacher.SelectedValue),
                        new MySqlParameter("@Topic", textBox5.Text)
                    };

                    new DatabaseManager().ExecuteQuery(updateQuery, parameters);
                    MessageBox.Show("Диплом успешно обновлён.");
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка сохранения изменений: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Выберите диплом для сохранения изменений.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //edit
        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                comboBoxStudent.SelectedValue = dataGridView1.SelectedRows[0].Cells["StudentID"].Value;
                comboBoxTeacher.SelectedValue = dataGridView1.SelectedRows[0].Cells["TeacherID"].Value;
                textBox5.Text = dataGridView1.SelectedRows[0].Cells["Topic"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите диплом для редактирования.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //delete
        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var result = MessageBox.Show("Вы уверены, что хотите удалить выбранный диплом?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        int diplomaId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["DiplomaID"].Value);
                        string deleteQuery = "DELETE FROM diploma WHERE DiplomaID = @DiplomaID";

                        List<MySqlParameter> parameters = new List<MySqlParameter>
                {
                    new MySqlParameter("@DiplomaID", diplomaId)
                };

                        new DatabaseManager().ExecuteQuery(deleteQuery, parameters);
                        MessageBox.Show("Диплом удалён.");
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка удаления диплома: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите диплом для удаления.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ADDITIONAL: diploma teachers by department, category
        private void button6_Click(object sender, EventArgs e)
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
        private void button7_Click(object sender, EventArgs e)
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
