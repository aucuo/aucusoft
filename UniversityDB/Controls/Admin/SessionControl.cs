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

namespace UniversityDB.Controls.Admin
{
    public partial class SessionControl : UserControl
    {
        public SessionControl()
        {
            InitializeComponent();
            LoadData();
            LoadStudents();
            LoadTeaching();
            LoadFormsOfControl();
        }
        private void LoadData()
        {
            try
            {
                string query = @"
                    SELECT 
                        s.SessionID,
                        st.Full_name AS StudentName,
                        t.Full_name AS TeacherName,
                        d.Name AS DisciplineName,
                        s.Semester,
                        s.Form_of_control,
                        s.Grade,
                        s.Retake,
                        s.StudentID,
                        s.TeachingID
                    FROM 
                        session s
                    JOIN 
                        students st ON s.StudentID = st.StudentID
                    JOIN 
                        teaching te ON s.TeachingID = te.TeachingID
                    JOIN 
                        teachers t ON te.TeacherID = t.TeacherID
                    JOIN 
                        disciplines d ON te.DisciplineID = d.DisciplineID;
                ";
                DataTable sessionData = new DatabaseManager().ExecuteQuery(query);
                dataGridView1.DataSource = sessionData;
                dataGridView1.Columns["SessionID"].Visible = false;
                dataGridView1.Columns["StudentID"].Visible = false;
                dataGridView1.Columns["TeachingID"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadStudents()
        {
            try
            {
                string query = "SELECT StudentID, Full_name FROM students";
                DataTable students = new DatabaseManager().ExecuteQuery(query);
                comboBox7.DataSource = students;
                comboBox7.DisplayMember = "Full_name";
                comboBox7.ValueMember = "StudentID";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки списка студентов: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTeaching()
        {
            try
            {
                string query = @"
                    SELECT 
                        te.TeachingID, 
                        CONCAT(t.Full_name, ' - ', d.Name) AS TeachingDetail
                    FROM 
                        teaching te
                    JOIN 
                        teachers t ON te.TeacherID = t.TeacherID
                    JOIN 
                        disciplines d ON te.DisciplineID = d.DisciplineID;
                ";

                DataTable teaching = new DatabaseManager().ExecuteQuery(query);
                comboBox1.DataSource = teaching;
                comboBox1.DisplayMember = "TeachingDetail";
                comboBox1.ValueMember = "TeachingID";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных преподавания: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadFormsOfControl()
        {
            comboBox14.Items.Clear();
            comboBox14.Items.AddRange(new string[] { "Экзамен", "Зачёт", "Курсовая работа", "Курсовой проект" });
        }
        //add
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string insertQuery = @"
                    INSERT INTO session (StudentID, TeachingID, Semester, Form_of_control, Grade, Retake)
                    VALUES (@StudentID, @TeachingID, @Semester, @Form_of_control, @Grade, @Retake);
                ";

                List<MySqlParameter> parameters = new List<MySqlParameter>
                {
                    new MySqlParameter("@StudentID", comboBox7.SelectedValue),
                    new MySqlParameter("@TeachingID", comboBox1.SelectedValue),
                    new MySqlParameter("@Semester", numericUpDown4.Value),
                    new MySqlParameter("@Form_of_control", comboBox14.SelectedItem.ToString()),
                    new MySqlParameter("@Grade", textBox22.Text),
                    new MySqlParameter("@Retake", radioButton1.Checked ? "Yes" : "No")
                };

                new DatabaseManager().ExecuteQuery(insertQuery, parameters);
                MessageBox.Show("Сессия успешно добавлена.");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка добавления сессии: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //save
        private void button24_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    int sessionId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["SessionID"].Value);
                    string updateQuery = @"
                        UPDATE session
                        SET 
                            StudentID = @StudentID, 
                            TeachingID = @TeachingID, 
                            Semester = @Semester, 
                            Form_of_control = @Form_of_control, 
                            Grade = @Grade, 
                            Retake = @Retake
                        WHERE 
                            SessionID = @SessionID;
                    ";

                    List<MySqlParameter> parameters = new List<MySqlParameter>
                    {
                        new MySqlParameter("@SessionID", sessionId),
                        new MySqlParameter("@StudentID", comboBox7.SelectedValue),
                        new MySqlParameter("@TeachingID", comboBox1.SelectedValue),
                        new MySqlParameter("@Semester", numericUpDown4.Value),
                        new MySqlParameter("@Form_of_control", comboBox14.SelectedItem.ToString()),
                        new MySqlParameter("@Grade", textBox22.Text),
                        new MySqlParameter("@Retake", radioButton1.Checked ? "Yes" : "No")
                    };

                    new DatabaseManager().ExecuteQuery(updateQuery, parameters);
                    MessageBox.Show("Изменения в сессии сохранены.");
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка сохранения изменений: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Выберите сессию для сохранения изменений.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //edit
        private void button23_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                comboBox7.SelectedValue = dataGridView1.SelectedRows[0].Cells["StudentID"].Value;
                comboBox1.SelectedValue = dataGridView1.SelectedRows[0].Cells["TeachingID"].Value;
                numericUpDown4.Value = Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells["Semester"].Value);
                comboBox14.SelectedItem = dataGridView1.SelectedRows[0].Cells["Form_of_control"].Value.ToString();
                textBox22.Text = dataGridView1.SelectedRows[0].Cells["Grade"].Value.ToString();
                if (dataGridView1.SelectedRows[0].Cells["Retake"].Value.ToString() == "Yes")
                {
                    radioButton1.Checked = true;
                }
                else
                {
                    radioButton2.Checked = true;
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите сессию для редактирования.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //delete
        private void button22_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var result = MessageBox.Show("Вы уверены, что хотите удалить выбранную сессию?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        int sessionId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["SessionID"].Value);
                        string deleteQuery = "DELETE FROM session WHERE SessionID = @SessionID";

                        List<MySqlParameter> parameters = new List<MySqlParameter>
                        {
                            new MySqlParameter("@SessionID", sessionId)
                        };

                        new DatabaseManager().ExecuteQuery(deleteQuery, parameters);
                        MessageBox.Show("Сессия удалена.");
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка удаления сессии: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите сессию для удаления.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
