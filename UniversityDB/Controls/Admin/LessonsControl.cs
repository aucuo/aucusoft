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

namespace UniversityDB.Controls
{
    public partial class LessonsControl : UserControl
    {
        public LessonsControl()
        {
            InitializeComponent();
            LoadData();
            LoadGroups();
            LoadTeaching();
            LoadLessonTypes();
        }
        private void LoadData()
        {
            try
            {
                string query = @"
                    SELECT 
                        l.LessonID,
                        t.Full_name AS TeacherName,
                        g.Name AS GroupName,
                        l.LessonType,
                        l.LessonDate,
                        l.LessonTime,
                        l.TeachingID,
                        l.GroupID
                    FROM 
                        lessons l
                    JOIN 
                        teaching te ON l.TeachingID = te.TeachingID
                    JOIN 
                        teachers t ON te.TeacherID = t.TeacherID
                    JOIN 
                        student_groups g ON l.GroupID = g.GroupID;

                ";
                DataTable lessonsData = new DatabaseManager().ExecuteQuery(query);
                dataGridView1.DataSource = lessonsData;
                dataGridView1.Columns["LessonID"].Visible = false;
                dataGridView1.Columns["TeachingID"].Visible = false;
                dataGridView1.Columns["GroupID"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadGroups()
        {
            try
            {
                string query = "SELECT GroupID, Name FROM student_groups";
                DataTable groups = new DatabaseManager().ExecuteQuery(query);
                comboBox4.DataSource = groups;
                comboBox4.DisplayMember = "Name";
                comboBox4.ValueMember = "GroupID";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки списка групп: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show($"Ошибка загрузки преподавания: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LoadLessonTypes()
        {
            comboBox3.Items.AddRange(new string[] { "Seminar", "Lecture", "Workshop" });
        }

        //add
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string insertQuery = @"
                    INSERT INTO lessons (TeachingID, GroupID, LessonType, LessonDate, LessonTime)
                    VALUES (@TeachingID, @GroupID, @LessonType, @LessonDate, @LessonTime);
                ";

                List<MySqlParameter> parameters = new List<MySqlParameter>
                {
                    new MySqlParameter("@TeachingID", comboBox1.SelectedValue),
                    new MySqlParameter("@GroupID", comboBox4.SelectedValue),
                    new MySqlParameter("@LessonType", comboBox3.SelectedItem.ToString()),
                    new MySqlParameter("@LessonDate", dateTimePicker1.Value),
                    new MySqlParameter("@LessonTime", dateTimePicker2.Value)
                };

                new DatabaseManager().ExecuteQuery(insertQuery, parameters);
                MessageBox.Show("Новое занятие успешно добавлено.");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка добавления занятия: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //save
        private void button12_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    int lessonId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["LessonID"].Value);
                    string updateQuery = @"
                        UPDATE lessons
                        SET TeachingID = @TeachingID, GroupID = @GroupID, LessonType = @LessonType, LessonDate = @LessonDate, LessonTime = @LessonTime
                        WHERE LessonID = @LessonID;
                    ";

                    List<MySqlParameter> parameters = new List<MySqlParameter>
                    {
                        new MySqlParameter("@LessonID", lessonId),
                        new MySqlParameter("@TeachingID", comboBox1.SelectedValue),
                        new MySqlParameter("@GroupID", comboBox4.SelectedValue),
                        new MySqlParameter("@LessonType", comboBox3.SelectedItem.ToString()),
                        new MySqlParameter("@LessonDate", dateTimePicker1.Value),
                        new MySqlParameter("@LessonTime", dateTimePicker2.Value)
                    };

                    new DatabaseManager().ExecuteQuery(updateQuery, parameters);
                    MessageBox.Show("Изменения в занятии сохранены.");
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка сохранения изменений: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Выберите занятие для сохранения изменений.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //edit
        private void button11_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                comboBox1.SelectedValue = dataGridView1.SelectedRows[0].Cells["TeachingID"].Value;
                comboBox4.SelectedValue = dataGridView1.SelectedRows[0].Cells["GroupID"].Value;
                comboBox3.SelectedItem = dataGridView1.SelectedRows[0].Cells["LessonType"].Value;
                dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells["LessonDate"].Value);

                if (dataGridView1.SelectedRows[0].Cells["LessonTime"].Value is TimeSpan lessonTime)
                {
                    DateTime time = DateTime.Today.Add(lessonTime); // Добавляем время к текущей дате
                    dateTimePicker2.Value = time;
                }
                else
                {
                    MessageBox.Show("Формат времени занятия не распознан.", "Ошибка формата", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите занятие для редактирования.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //delete
        private void button10_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var result = MessageBox.Show("Вы уверены, что хотите удалить выбранное занятие?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        int lessonId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["LessonID"].Value);
                        string deleteQuery = "DELETE FROM lessons WHERE LessonID = @LessonID";

                        List<MySqlParameter> parameters = new List<MySqlParameter>
                        {
                            new MySqlParameter("@LessonID", lessonId)
                        };

                        new DatabaseManager().ExecuteQuery(deleteQuery, parameters);
                        MessageBox.Show("Занятие удалено.");
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка удаления занятия: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите занятие для удаления.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
