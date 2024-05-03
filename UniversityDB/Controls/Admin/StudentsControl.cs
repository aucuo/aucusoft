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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UniversityDB.Controls.Admin
{
    public partial class StudentsControl : UserControl
    {
        public StudentsControl()
        {
            InitializeComponent();
            LoadData();
            LoadGroups();
            LoadEducationForm();
        }
        private void LoadData()
        {
            try
            {
                string query = @"
                    SELECT 
                        s.StudentID,
                        s.GroupID,
                        s.Full_name,
                        s.Gender,
                        s.Course,
                        s.Age,
                        s.Has_children,
                        s.Education_form,
                        s.Scholarship,
                        sg.Name AS StudentGroup
                    FROM 
                        students s
                    JOIN 
                        student_groups sg ON s.GroupID = sg.GroupID;
                ";
                DataTable studentData = new DatabaseManager().ExecuteQuery(query);
                dataGridView1.DataSource = studentData;
                dataGridView1.Columns["StudentID"].Visible = false;
                dataGridView1.Columns["GroupID"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}");
            }
        }
        private void LoadGroups()
        {
            try
            {
                string query = "SELECT GroupID, Name FROM student_groups";
                DataTable groups = new DatabaseManager().ExecuteQuery(query);
                comboBox1.DataSource = groups;
                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "GroupID";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки списка групп: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadEducationForm()
        {
            comboBox2.Items.Clear();
            comboBox2.Items.AddRange(new string[] { "Budget", "Paid" });
        }
        //add
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string insertQuery = @"
                    INSERT INTO students (Full_name, Gender, Course, Age, Has_children, Education_form, Scholarship, GroupID)
                    VALUES (@Full_name, @Gender, @Course, @Age, @Has_children, @Education_form, @Scholarship, @GroupID);
                ";

                List<MySqlParameter> parameters = new List<MySqlParameter>
                {
                    new MySqlParameter("@Full_name", textBox1.Text),
                    new MySqlParameter("@Gender", StudentGenderMale.Checked ? "Male" : "Female"),
                    new MySqlParameter("@Course", numericUpDown1.Value),
                    new MySqlParameter("@Age", textBox3.Text),
                    new MySqlParameter("@Scholarship", textBox3.Text),
                    new MySqlParameter("@Has_children", StudentHavingKids.Checked ? "Yes" : "No"),
                    new MySqlParameter("@Education_form", comboBox2.SelectedItem.ToString()),
                    new MySqlParameter("@GroupID", comboBox1.SelectedValue)
                };

                new DatabaseManager().ExecuteQuery(insertQuery, parameters);
                MessageBox.Show("Студент успешно добавлен.");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка добавления студента: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //save
        private void SaveStudentButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    int studentId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["StudentID"].Value);
                    string updateQuery = @"
                        UPDATE students
                        SET Full_name = @Full_name, Gender = @Gender, Course = @Course, Age = @Age, Has_children = @Has_children, Education_form = @Education_form, Scholarship = @Scholarship, GroupID = @GroupID
                        WHERE StudentID = @StudentID;
                    ";

                    List<MySqlParameter> parameters = new List<MySqlParameter>
                    {
                        new MySqlParameter("@StudentID", studentId),
                        new MySqlParameter("@Full_name", textBox1.Text),
                        new MySqlParameter("@Scholarship", decimal.Parse(textBox2.Text)),
                        new MySqlParameter("@Gender", StudentGenderMale.Checked ? "Male" : "Female"),
                        new MySqlParameter("@Course", numericUpDown1.Value),
                        new MySqlParameter("@Age", textBox3.Text),
                        new MySqlParameter("@Has_children", StudentHavingKids.Checked ? "Yes" : "No"),
                        new MySqlParameter("@Education_form", comboBox2.SelectedItem.ToString()),
                        new MySqlParameter("@GroupID", comboBox1.SelectedValue)
                    };

                    new DatabaseManager().ExecuteQuery(updateQuery, parameters);
                    MessageBox.Show("Изменения в данных студента сохранены.");
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка сохранения изменений: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Выберите студента для сохранения изменений.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //edit
        private void EditStudentButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                textBox1.Text = dataGridView1.SelectedRows[0].Cells["Full_name"].Value.ToString();
                textBox2.Text = dataGridView1.SelectedRows[0].Cells["Scholarship"].Value.ToString();
                comboBox1.SelectedValue = dataGridView1.SelectedRows[0].Cells["GroupID"].Value;
                textBox3.Text = dataGridView1.SelectedRows[0].Cells["Age"].Value.ToString();
                numericUpDown1.Value = Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells["Course"].Value);
                comboBox2.SelectedItem = dataGridView1.SelectedRows[0].Cells["Education_form"].Value.ToString();
                string gender = dataGridView1.SelectedRows[0].Cells["Gender"].Value.ToString();
                StudentGenderMale.Checked = (gender == "Male");
                StudentGenderFemale.Checked = (gender == "Female");
                string hasChildren = dataGridView1.SelectedRows[0].Cells["Has_children"].Value.ToString();
                StudentHavingKids.Checked = (hasChildren == "Yes");
                StudentNotHavingKids.Checked = (hasChildren == "No");
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите студента для редактирования.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //delete
        private void DeleteStudentButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var result = MessageBox.Show("Вы уверены, что хотите удалить выбранного студента?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        int studentId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["StudentID"].Value);
                        string deleteQuery = "DELETE FROM students WHERE StudentID = @StudentID";

                        List<MySqlParameter> parameters = new List<MySqlParameter>
                        {
                            new MySqlParameter("@StudentID", studentId)
                        };

                        new DatabaseManager().ExecuteQuery(deleteQuery, parameters);
                        MessageBox.Show("Студент удален.");
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка удаления студента: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите студента для удаления.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ADDITIONAL: DIPLOMA WORKS
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Загрузка кафедр
                string depQuery = "SELECT DepartmentID, Name FROM Department";
                DataTable departments = new DatabaseManager().ExecuteQuery(depQuery);
                comboBoxDepartment.DataSource = departments;
                comboBoxDepartment.DisplayMember = "Name";
                comboBoxDepartment.ValueMember = "DepartmentID";

                // Загрузка преподавателей
                string teachQuery = "SELECT TeacherID, Full_name FROM Teachers";
                DataTable teachers = new DatabaseManager().ExecuteQuery(teachQuery);
                comboBoxTeacher.DataSource = teachers;
                comboBoxTeacher.DisplayMember = "Full_name";
                comboBoxTeacher.ValueMember = "TeacherID";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // execute
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string query = @"
                    SELECT 
                        Students.Full_name, 
                        Diploma.Topic
                    FROM 
                        Students
                    JOIN 
                        Diploma ON Students.StudentID = Diploma.StudentID
                    JOIN 
                        Teachers ON Diploma.TeacherID = Teachers.TeacherID
                    WHERE 
                        Teachers.DepartmentID = @DepartmentID OR Diploma.TeacherID = @TeacherID;
                ";

                List<MySqlParameter> parameters = new List<MySqlParameter>
                {
                    new MySqlParameter("@DepartmentID", comboBoxDepartment.SelectedValue),
                    new MySqlParameter("@TeacherID", comboBoxTeacher.SelectedValue)
                };

                DataTable results = new DatabaseManager().ExecuteQuery(query, parameters);
                // Показываем результаты в новом окне или на новой форме
                ShowResults(results);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка выполнения запроса: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            void ShowResults(DataTable results)
            {
                // Создаем новую форму для показа результатов
                Form resultsForm = new Form
                {
                    Width = 500,
                    Height = 500
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

        // ADDITIONAL: students by grade
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT TeacherID, Full_name FROM Teachers";
                DataTable teachers = new DatabaseManager().ExecuteQuery(query);
                comboBox3.DataSource = teachers;
                comboBox3.DisplayMember = "Full_name";
                comboBox3.ValueMember = "TeacherID";

                comboBox4.Items.Clear();
                comboBox4.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });

                comboBox5.Items.Clear();
                comboBox5.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6" });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки списка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //execute
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string query = @"
                    SELECT 
                        Students.StudentID, 
                        Students.Full_name
                    FROM 
                        Session
                    JOIN 
                        Students ON Session.StudentID = Students.StudentID
                    WHERE 
                        Session.TeachingID IN (SELECT TeachingID FROM Teaching WHERE TeacherID = @TeacherID AND Semester = @Semester)
                        AND Session.Grade = @Grade;
                ";

                List<MySqlParameter> parameters = new List<MySqlParameter>
                {
                    new MySqlParameter("@TeacherID", comboBox3.SelectedValue),
                    new MySqlParameter("@Semester", comboBox5.SelectedItem.ToString()),
                    new MySqlParameter("@Grade", comboBox4.SelectedItem.ToString())
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
                    Height = 500
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
                resultsForm.ShowDialog();
            }
        }

        // ADDITIONAL: good students by course
        private void button6_Click(object sender, EventArgs e)
        {
            comboBox6.Items.Clear();
            comboBox6.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6" });
        }
        //execute
        private void button7_Click(object sender, EventArgs e)
        {
            if (comboBox6.SelectedItem == null)
            {
                MessageBox.Show("Выберите курс перед выполнением запроса.");
                return;
            }

            string selectedCourse = comboBox6.SelectedItem.ToString();
            try
            {
                // Запрос для подсчета студентов
                string countQuery = @"
                    SELECT 
                        COUNT(DISTINCT StudentID) AS TotalStudents
                    FROM 
                        Session
                    WHERE 
                        StudentID IN (SELECT StudentID FROM Students WHERE Course = @Course)
                        AND Grade >= '4';
                ";

                // Запрос для получения списка студентов и их оценок
                string listQuery = @"
                    SELECT 
                        s.Full_name AS StudentName,
                        ses.Grade AS Grade
                    FROM 
                        Students s
                    JOIN 
                        Session ses ON s.StudentID = ses.StudentID
                    WHERE 
                        s.Course = @Course AND ses.Grade >= '4';
                ";

                List<MySqlParameter> parameters = new List<MySqlParameter>
                {
                    new MySqlParameter("@Course", selectedCourse)
                };

                DataTable countResults = new DatabaseManager().ExecuteQuery(countQuery, parameters);
                DataTable listResults = new DatabaseManager().ExecuteQuery(listQuery, parameters);

                // Показать общее количество студентов
                if (countResults.Rows.Count > 0)
                {
                    MessageBox.Show("Общее число студентов указанного курса, сдавших сессию на отлично, без троек и двоек: " + countResults.Rows[0]["TotalStudents"].ToString());
                }
                else
                {
                    MessageBox.Show("Данных не найдено.");
                }

                // Показать список студентов и их оценки
                ShowResults(listResults);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка выполнения запроса: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            void ShowResults(DataTable results)
            {
                if (results.Rows.Count == 0)
                {
                    MessageBox.Show("Список студентов пуст.");
                    return;
                }

                Form resultsForm = new Form
                {
                    Width = 600,
                    Height = 400,
                    Text = "Результаты сессии"
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
