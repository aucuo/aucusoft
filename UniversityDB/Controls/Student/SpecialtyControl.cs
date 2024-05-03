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

namespace UniversityDB.Controls.Student
{
    public partial class SpecialtyControl : UserControl
    {
        public SpecialtyControl()
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
                dataGridView1.Columns["SpecialtyID"].Visible = false; // Скрываем колонку ID для лучшей читаемости
                dataGridView1.Columns["DepartmentID"].Visible = false; // Скрываем колонку DepartmentID если не требуется видеть
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
