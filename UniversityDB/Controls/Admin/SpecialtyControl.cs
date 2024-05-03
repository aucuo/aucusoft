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
    public partial class SpecialtyControl : UserControl
    {
        public SpecialtyControl()
        {
            InitializeComponent();
            LoadData();
            LoadDepartments();
        }
        private void LoadData()
        {
            try
            {
                string query = @"
                    SELECT 
                        s.SpecialtyID,
                        s.Name AS SpecialtyName,
                        d.Name AS DepartmentName,
                        d.DepartmentID
                    FROM 
                        specialty s
                    JOIN 
                        department d ON s.DepartmentID = d.DepartmentID;
                ";
                DataTable specialtyData = new DatabaseManager().ExecuteQuery(query);
                dataGridView1.DataSource = specialtyData;
                dataGridView1.Columns["SpecialtyID"].Visible = false;
                dataGridView1.Columns["DepartmentID"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadDepartments()
        {
            try
            {
                string query = "SELECT DepartmentID, Name FROM department";
                DataTable departments = new DatabaseManager().ExecuteQuery(query);
                comboBox8.DataSource = departments;
                comboBox8.DisplayMember = "Name";
                comboBox8.ValueMember = "DepartmentID";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки списка отделений: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //add
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string insertQuery = @"
                    INSERT INTO specialty (Name, DepartmentID)
                    VALUES (@Name, @DepartmentID);
                ";

                List<MySqlParameter> parameters = new List<MySqlParameter>
                {
                    new MySqlParameter("@Name", textBox12.Text),
                    new MySqlParameter("@DepartmentID", comboBox8.SelectedValue)
                };

                new DatabaseManager().ExecuteQuery(insertQuery, parameters);
                MessageBox.Show("Специальность успешно добавлена.");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка добавления специальности: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //save
        private void button9_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    int specialtyId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["SpecialtyID"].Value);
                    string updateQuery = @"
                        UPDATE specialty
                        SET Name = @Name, DepartmentID = @DepartmentID
                        WHERE SpecialtyID = @SpecialtyID;
                    ";

                    List<MySqlParameter> parameters = new List<MySqlParameter>
                    {
                        new MySqlParameter("@SpecialtyID", specialtyId),
                        new MySqlParameter("@Name", textBox12.Text),
                        new MySqlParameter("@DepartmentID", comboBox8.SelectedValue)
                    };

                    new DatabaseManager().ExecuteQuery(updateQuery, parameters);
                    MessageBox.Show("Изменения в специальности сохранены.");
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка сохранения изменений: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Выберите специальность для сохранения изменений.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //edit
        private void button8_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                textBox12.Text = dataGridView1.SelectedRows[0].Cells["SpecialtyName"].Value.ToString();
                comboBox8.SelectedValue = dataGridView1.SelectedRows[0].Cells["DepartmentID"].Value;
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите специальность для редактирования.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //delete
        private void button7_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var result = MessageBox.Show("Вы уверены, что хотите удалить выбранную специальность?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        int specialtyId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["SpecialtyID"].Value);
                        string deleteQuery = "DELETE FROM specialty WHERE SpecialtyID = @SpecialtyID";

                        List<MySqlParameter> parameters = new List<MySqlParameter>
                {
                    new MySqlParameter("@SpecialtyID", specialtyId)
                };

                        new DatabaseManager().ExecuteQuery(deleteQuery, parameters);
                        MessageBox.Show("Специальность удалена.");
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка удаления специальности: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите специальность для удаления.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
