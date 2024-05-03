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
    public partial class ResearchControl : UserControl
    {
        public ResearchControl()
        {
            InitializeComponent();
            LoadData();
            LoadTeachers();
            LoadResearchTypes();
        }
        private void LoadData()
        {
            try
            {
                string query = @"
                    SELECT 
                        r.ResearchID,
                        t.Full_name AS TeacherName,
                        r.ResearchType,
                        r.Title,
                        r.DefenseDate,
                        r.TeacherID
                    FROM 
                        research r
                    JOIN 
                        teachers t ON r.TeacherID = t.TeacherID;
                ";
                DataTable researchData = new DatabaseManager().ExecuteQuery(query);
                dataGridView1.DataSource = researchData;
                dataGridView1.Columns["ResearchID"].Visible = false;
                dataGridView1.Columns["TeacherID"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadTeachers()
        {
            try
            {
                string query = "SELECT TeacherID, Full_name FROM teachers";
                DataTable teachers = new DatabaseManager().ExecuteQuery(query);
                comboBox10.DataSource = teachers;
                comboBox10.DisplayMember = "Full_name";
                comboBox10.ValueMember = "TeacherID";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки списка учителей: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadResearchTypes()
        {
            comboBox9.Items.Clear(); // Очищаем текущие элементы
            comboBox9.Items.AddRange(new string[] { "Теоретическое", "Прикладное", "Экспериментальное" }); // Примерные типы исследований
        }

        // add
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string insertQuery = @"
                    INSERT INTO research (TeacherID, ResearchType, Title, DefenseDate)
                    VALUES (@TeacherID, @ResearchType, @Title, @DefenseDate);
                ";

                List<MySqlParameter> parameters = new List<MySqlParameter>
                {
                    new MySqlParameter("@TeacherID", comboBox10.SelectedValue),
                    new MySqlParameter("@ResearchType", comboBox9.SelectedItem.ToString()),
                    new MySqlParameter("@Title", textBox20.Text),
                    new MySqlParameter("@DefenseDate", dateTimePicker3.Value)
                };

                new DatabaseManager().ExecuteQuery(insertQuery, parameters);
                MessageBox.Show("Исследование успешно добавлено.");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка добавления исследования: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //save
        private void button29_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    int researchId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ResearchID"].Value);
                    string updateQuery = @"
                        UPDATE research
                        SET TeacherID = @TeacherID, ResearchType = @ResearchType, Title = @Title, DefenseDate = @DefenseDate
                        WHERE ResearchID = @ResearchID;
                    ";

                    List<MySqlParameter> parameters = new List<MySqlParameter>
                    {
                        new MySqlParameter("@ResearchID", researchId),
                        new MySqlParameter("@TeacherID", comboBox10.SelectedValue),
                        new MySqlParameter("@ResearchType", comboBox9.SelectedItem.ToString()),
                        new MySqlParameter("@Title", textBox20.Text),
                        new MySqlParameter("@DefenseDate", dateTimePicker3.Value)
                    };

                    new DatabaseManager().ExecuteQuery(updateQuery, parameters);
                    MessageBox.Show("Изменения в исследовании сохранены.");
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка сохранения изменений: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Выберите исследование для сохранения изменений.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //edit
        private void button30_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                comboBox10.SelectedValue = dataGridView1.SelectedRows[0].Cells["TeacherID"].Value;
                comboBox9.SelectedItem = dataGridView1.SelectedRows[0].Cells["ResearchType"].Value.ToString();
                textBox20.Text = dataGridView1.SelectedRows[0].Cells["Title"].Value.ToString();
                dateTimePicker3.Value = Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells["DefenseDate"].Value);
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите исследование для редактирования.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //delete
        private void button28_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var result = MessageBox.Show("Вы уверены, что хотите удалить выбранное исследование?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        int researchId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ResearchID"].Value);
                        string deleteQuery = "DELETE FROM research WHERE ResearchID = @ResearchID";

                        List<MySqlParameter> parameters = new List<MySqlParameter>
                {
                    new MySqlParameter("@ResearchID", researchId)
                };

                        new DatabaseManager().ExecuteQuery(deleteQuery, parameters);
                        MessageBox.Show("Исследование удалено.");
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка удаления исследования: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите исследование для удаления.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //ADDITIONAL: dessertation by department
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT DepartmentID, Name FROM Department";
                DataTable departments = new DatabaseManager().ExecuteQuery(query);
                comboBox6.DataSource = departments;
                comboBox6.DisplayMember = "Name";
                comboBox6.ValueMember = "DepartmentID";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки списка кафедр: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //execute
        private void button7_Click(object sender, EventArgs e)
        {
            if (comboBox6.SelectedValue == null)
            {
                MessageBox.Show("Выберите кафедру перед выполнением запроса.");
                return;
            }

            string departmentId = comboBox6.SelectedValue.ToString();
            try
            {
                string query = @"
                    SELECT 
                        Title
                    FROM 
                        Research
                    WHERE 
                        TeacherID IN (SELECT TeacherID FROM Teachers WHERE DepartmentID = @DepartmentID);
                ";

                List<MySqlParameter> parameters = new List<MySqlParameter>
                {
                    new MySqlParameter("@DepartmentID", departmentId)
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
                if (results.Rows.Count == 0)
                {
                    MessageBox.Show("Данные не найдены.");
                    return;
                }

                Form resultsForm = new Form
                {
                    Width = 600,
                    Height = 400,
                    Text = "Список тем диссертаций"
                };

                DataGridView dataGridView = new DataGridView
                {
                    Dock = DockStyle.Fill,
                    DataSource = results,
                    AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                    AllowUserToAddRows = false,
                    ReadOnly = true
                };

                Label lblCount = new Label
                {
                    Text = $"Общее количество тем: {results.Rows.Count}",
                    Dock = DockStyle.Top,
                    TextAlign = ContentAlignment.MiddleCenter
                };

                resultsForm.Controls.Add(dataGridView);
                resultsForm.Controls.Add(lblCount);
                resultsForm.ShowDialog();  // Показываем как модальное окно
            }
        }
    }
}
