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
    public partial class StudyPlanControl : UserControl
    {
        public StudyPlanControl()
        {
            InitializeComponent();
            LoadData();
            LoadTeaching();
            LoadGroups();
            LoadLessonTypesAndForms();
        }

        private void LoadData()
        {
            try
            {
                string query = @"
                    SELECT 
                        sp.StudyPlanID,
                        t.Full_name AS TeacherName,
                        g.Name AS GroupName,
                        sp.LessonType,
                        sp.HoursAmount,
                        sp.Form_of_control,
                        sp.TeachingID,
                        sp.GroupID
                    FROM 
                        studyplan sp
                    JOIN 
                        teaching te ON sp.TeachingID = te.TeachingID
                    JOIN 
                        teachers t ON te.TeacherID = t.TeacherID
                    JOIN 
                        student_groups g ON sp.GroupID = g.GroupID;
                ";
                DataTable studyPlanData = new DatabaseManager().ExecuteQuery(query);
                dataGridView1.DataSource = studyPlanData;
                dataGridView1.Columns["StudyPlanID"].Visible = false;
                dataGridView1.Columns["TeachingID"].Visible = false;
                dataGridView1.Columns["GroupID"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void LoadGroups()
        {
            try
            {
                string query = "SELECT GroupID, Name FROM student_groups";
                DataTable groups = new DatabaseManager().ExecuteQuery(query);
                comboBox15.DataSource = groups;
                comboBox15.DisplayMember = "Name";
                comboBox15.ValueMember = "GroupID";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки списка групп: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadLessonTypesAndForms()
        {
            comboBox16.Items.AddRange(new string[] { "Seminar", "Lecture", "Workshop" });
            comboBox17.Items.AddRange(new string[] { "Экзамен", "Зачёт", "Курсовая работа", "Курсовой проект" });
        }

        //add
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string insertQuery = @"
                    INSERT INTO studyplan (TeachingID, GroupID, LessonType, HoursAmount, Form_of_control)
                    VALUES (@TeachingID, @GroupID, @LessonType, @HoursAmount, @Form_of_control);
                ";

                List<MySqlParameter> parameters = new List<MySqlParameter>
                {
                    new MySqlParameter("@TeachingID", comboBox1.SelectedValue),
                    new MySqlParameter("@GroupID", comboBox15.SelectedValue),
                    new MySqlParameter("@LessonType", comboBox16.SelectedItem.ToString()),
                    new MySqlParameter("@HoursAmount", textBox23.Text),
                    new MySqlParameter("@Form_of_control", comboBox17.SelectedItem.ToString())
                };

                new DatabaseManager().ExecuteQuery(insertQuery, parameters);
                MessageBox.Show("Учебный план успешно добавлен.");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка добавления учебного плана: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //save
        private void button32_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    int studyPlanId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["StudyPlanID"].Value);
                    string updateQuery = @"
                        UPDATE studyplan
                        SET 
                            TeachingID = @TeachingID, 
                            GroupID = @GroupID, 
                            LessonType = @LessonType, 
                            HoursAmount = @HoursAmount, 
                            Form_of_control = @Form_of_control
                        WHERE 
                            StudyPlanID = @StudyPlanID;
                    ";

                    List<MySqlParameter> parameters = new List<MySqlParameter>
                    {
                        new MySqlParameter("@StudyPlanID", studyPlanId),
                        new MySqlParameter("@TeachingID", comboBox1.SelectedValue),
                        new MySqlParameter("@GroupID", comboBox15.SelectedValue),
                        new MySqlParameter("@LessonType", comboBox16.SelectedItem.ToString()),
                        new MySqlParameter("@HoursAmount", textBox23.Text),
                        new MySqlParameter("@Form_of_control", comboBox17.SelectedItem.ToString())
                    };

                    new DatabaseManager().ExecuteQuery(updateQuery, parameters);
                    MessageBox.Show("Изменения в учебном плане сохранены.");
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка сохранения изменений: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Выберите учебный план для сохранения изменений.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //edit
        private void button33_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Загрузка данных в элементы управления формы для редактирования
                comboBox1.SelectedValue = dataGridView1.SelectedRows[0].Cells["TeachingID"].Value;
                comboBox15.SelectedValue = dataGridView1.SelectedRows[0].Cells["GroupID"].Value;
                comboBox16.SelectedItem = dataGridView1.SelectedRows[0].Cells["LessonType"].Value.ToString();
                textBox23.Text = dataGridView1.SelectedRows[0].Cells["HoursAmount"].Value.ToString();
                comboBox17.SelectedItem = dataGridView1.SelectedRows[0].Cells["Form_of_control"].Value.ToString();

                // Установка фокуса на элемент управления для удобства пользователя
                textBox23.Focus();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите учебный план для редактирования.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //delete
        private void button31_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var result = MessageBox.Show("Вы уверены, что хотите удалить выбранный учебный план?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        int studyPlanId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["StudyPlanID"].Value);
                        string deleteQuery = "DELETE FROM studyplan WHERE StudyPlanID = @StudyPlanID";

                        List<MySqlParameter> parameters = new List<MySqlParameter>
                {
                    new MySqlParameter("@StudyPlanID", studyPlanId)
                };

                        new DatabaseManager().ExecuteQuery(deleteQuery, parameters);
                        MessageBox.Show("Учебный план удален.");
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка удаления учебного плана: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите учебный план для удаления.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
