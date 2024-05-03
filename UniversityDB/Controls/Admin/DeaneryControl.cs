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
    public partial class DeaneryControl : UserControl
    {
        public DeaneryControl()
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
                        DeaneryID,
                        Name,
                        Dean,
                        Deanery_number
                    FROM 
                        deanery;
                ";
                DataTable deaneryData = new DatabaseManager().ExecuteQuery(query);
                dataGridView1.DataSource = deaneryData;
                dataGridView1.Columns["DeaneryID"].Visible = false; // Скрываем колонку ID
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}");
            }
        }
        //save
        private void button15_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    int deaneryId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["DeaneryID"].Value);
                    string updateQuery = @"
                        UPDATE deanery
                        SET Name = @Name, Dean = @Dean, Deanery_number = @DeaneryNumber
                        WHERE DeaneryID = @DeaneryID;
                    ";

                    List<MySqlParameter> parameters = new List<MySqlParameter>
                    {
                        new MySqlParameter("@DeaneryID", deaneryId),
                        new MySqlParameter("@Name", textBox15.Text),
                        new MySqlParameter("@Dean", textBox10.Text),
                        new MySqlParameter("@DeaneryNumber", textBox16.Text)
                    };

                    new DatabaseManager().ExecuteQuery(updateQuery, parameters);
                    MessageBox.Show("Изменения в деканате сохранены.");
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка сохранения изменений: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Выберите деканат для сохранения изменений.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //edit
        private void button14_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                textBox15.Text = dataGridView1.SelectedRows[0].Cells["Name"].Value.ToString();
                textBox10.Text = dataGridView1.SelectedRows[0].Cells["Dean"].Value.ToString();
                textBox16.Text = dataGridView1.SelectedRows[0].Cells["Deanery_number"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите деканат для редактирования.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //delete
        private void button13_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var result = MessageBox.Show("Вы уверены, что хотите удалить выбранный деканат?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        int deaneryId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["DeaneryID"].Value);
                        string deleteQuery = "DELETE FROM deanery WHERE DeaneryID = @DeaneryID";

                        List<MySqlParameter> parameters = new List<MySqlParameter>
                        {
                            new MySqlParameter("@DeaneryID", deaneryId)
                        };

                        new DatabaseManager().ExecuteQuery(deleteQuery, parameters);
                        MessageBox.Show("Деканат удален.");
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка удаления деканата: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите деканат для удаления.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //add
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string insertQuery = @"
                    INSERT INTO deanery (Name, Dean, Deanery_number)
                    VALUES (@Name, @Dean, @DeaneryNumber);
                ";

                List<MySqlParameter> parameters = new List<MySqlParameter>
                {
                    new MySqlParameter("@Name", textBox15.Text),
                    new MySqlParameter("@Dean", textBox10.Text),
                    new MySqlParameter("@DeaneryNumber", textBox16.Text) // предполагаем, что это номер деканата
                };

                new DatabaseManager().ExecuteQuery(insertQuery, parameters);
                MessageBox.Show("Новый деканат успешно добавлен.");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка добавления деканата: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
