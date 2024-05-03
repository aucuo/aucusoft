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
    public partial class GroupsControl : UserControl
    {
        public GroupsControl()
        {
            InitializeComponent();
            LoadData();
            LoadSpecialties();
        }
        private void LoadData()
        {
            try
            {
                string query = @"
                    SELECT 
                        g.GroupID,
                        g.Name AS GroupName,
                        g.Course,
                        sp.Name AS SpecialtyName,
                        g.SpecialtyID
                    FROM 
                        student_groups g
                    JOIN 
                        specialty sp ON g.SpecialtyID = sp.SpecialtyID;
                ";
                DataTable groupsData = new DatabaseManager().ExecuteQuery(query);
                dataGridView1.DataSource = groupsData;
                dataGridView1.Columns["GroupID"].Visible = false;
                dataGridView1.Columns["SpecialtyID"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadSpecialties()
        {
            try
            {
                string query = "SELECT SpecialtyID, Name FROM specialty";
                DataTable specialties = new DatabaseManager().ExecuteQuery(query);
                comboBox12.DataSource = specialties;
                comboBox12.DisplayMember = "Name";
                comboBox12.ValueMember = "SpecialtyID";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки списка специальностей: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //add
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string insertQuery = @"
                    INSERT INTO student_groups (Name, Course, SpecialtyID)
                    VALUES (@Name, @Course, @SpecialtyID);
                ";

                List<MySqlParameter> parameters = new List<MySqlParameter>
                {
                    new MySqlParameter("@Name", textBox14.Text),
                    new MySqlParameter("@Course", numericUpDown2.Value),
                    new MySqlParameter("@SpecialtyID", comboBox12.SelectedValue)
                };

                new DatabaseManager().ExecuteQuery(insertQuery, parameters);
                MessageBox.Show("Новая группа успешно добавлена.");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка добавления группы: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //save
        private void button20_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    int groupId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["GroupID"].Value);
                    string updateQuery = @"
                        UPDATE student_groups
                        SET Name = @Name, Course = @Course, SpecialtyID = @SpecialtyID
                        WHERE GroupID = @GroupID;
                    ";

                    List<MySqlParameter> parameters = new List<MySqlParameter>
                    {
                        new MySqlParameter("@GroupID", groupId),
                        new MySqlParameter("@Name", textBox14.Text),
                        new MySqlParameter("@Course", numericUpDown2.Value),
                        new MySqlParameter("@SpecialtyID", comboBox12.SelectedValue)
                    };

                    new DatabaseManager().ExecuteQuery(updateQuery, parameters);
                    MessageBox.Show("Изменения в группе сохранены.");
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка сохранения изменений: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Выберите группу для сохранения изменений.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //edit
        private void button21_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                textBox14.Text = dataGridView1.SelectedRows[0].Cells["GroupName"].Value.ToString();
                numericUpDown2.Value = Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells["Course"].Value);
                comboBox12.SelectedValue = dataGridView1.SelectedRows[0].Cells["SpecialtyID"].Value;
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите группу для редактирования.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //delete
        private void button19_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var result = MessageBox.Show("Вы уверены, что хотите удалить выбранную группу?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        int groupId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["GroupID"].Value);
                        string deleteQuery = "DELETE FROM student_groups WHERE GroupID = @GroupID";

                        List<MySqlParameter> parameters = new List<MySqlParameter>
                {
                    new MySqlParameter("@GroupID", groupId)
                };

                        new DatabaseManager().ExecuteQuery(deleteQuery, parameters);
                        MessageBox.Show("Группа удалена.");
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка удаления группы: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите группу для удаления.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
