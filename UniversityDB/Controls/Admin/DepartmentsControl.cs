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
    public partial class DepartmentsControl : UserControl
    {
        public DepartmentsControl()
        {
            InitializeComponent();
            LoadData();
            LoadDeaneries();
        }
        private void LoadData()
        {
            try
            {
                string query = @"
                    SELECT 
                        d.DepartmentID,
                        d.Name AS DepartmentName,
                        d.Head_Of_Department,
                        dy.Name AS DeaneryName,
                        d.DeaneryID
                    FROM 
                        department d
                    LEFT JOIN 
                        deanery dy ON d.DeaneryID = dy.DeaneryID;
                ";

                DataTable departmentsData = new DatabaseManager().ExecuteQuery(query);
                dataGridView1.DataSource = departmentsData;
                dataGridView1.Columns["DepartmentID"].Visible = false;
                dataGridView1.Columns["DeaneryID"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}");
            }
        }
        private void LoadDeaneries()
        {
            try
            {
                string query = "SELECT DeaneryID, Name FROM deanery";
                DataTable deaneries = new DatabaseManager().ExecuteQuery(query);
                comboBox11.DataSource = deaneries;
                comboBox11.DisplayMember = "Name";
                comboBox11.ValueMember = "DeaneryID";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки списка деканатов: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //save
        private void button17_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    int departmentId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["DepartmentID"].Value);
                    string updateQuery = @"
                        UPDATE department
                        SET Name = @Name, Head_Of_Department = @HeadOfDepartment, DeaneryID = @DeaneryID
                        WHERE DepartmentID = @DepartmentID;
                    ";

                    List<MySqlParameter> parameters = new List<MySqlParameter>
                    {
                        new MySqlParameter("@DepartmentID", departmentId),
                        new MySqlParameter("@Name", textBox13.Text),
                        new MySqlParameter("@HeadOfDepartment", textBox17.Text),
                        new MySqlParameter("@DeaneryID", comboBox11.SelectedValue)
                    };

                    new DatabaseManager().ExecuteQuery(updateQuery, parameters);
                    MessageBox.Show("Изменения в отделении сохранены.");
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения изменений: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //edit
        private void button18_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int departmentId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["DepartmentID"].Value);
                textBox13.Text = dataGridView1.SelectedRows[0].Cells["DepartmentName"].Value.ToString();
                textBox17.Text = dataGridView1.SelectedRows[0].Cells["Head_Of_Department"].Value.ToString();
                comboBox11.SelectedValue = dataGridView1.SelectedRows[0].Cells["DeaneryID"].Value;
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите отделение для редактирования.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //delete
        private void button16_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var result = MessageBox.Show("Вы уверены, что хотите удалить выбранное отделение?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        int departmentId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["DepartmentID"].Value);
                        string deleteQuery = "DELETE FROM department WHERE DepartmentID = @DepartmentID";

                        List<MySqlParameter> parameters = new List<MySqlParameter>
                        {
                            new MySqlParameter("@DepartmentID", departmentId)
                        };

                        new DatabaseManager().ExecuteQuery(deleteQuery, parameters);
                        MessageBox.Show("Отделение удалено.");
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка удаления отделения: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите отделение для удаления.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //add
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string insertQuery = @"
                    INSERT INTO department (Name, Head_Of_Department, DeaneryID)
                    VALUES (@Name, @HeadOfDepartment, @DeaneryID);
                ";

                List<MySqlParameter> parameters = new List<MySqlParameter>
                {
                    new MySqlParameter("@Name", textBox13.Text),
                    new MySqlParameter("@HeadOfDepartment", textBox17.Text),
                    new MySqlParameter("@DeaneryID", comboBox11.SelectedValue)
                };

                new DatabaseManager().ExecuteQuery(insertQuery, parameters);
                MessageBox.Show("Отделение успешно добавлено.");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка добавления отделения: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
