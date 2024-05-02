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
                        dy.Name AS DeaneryName
                    FROM 
                        department d
                    LEFT JOIN 
                        deanery dy ON d.DeaneryID = dy.DeaneryID;
                ";

                DataTable departmentsData = new DatabaseManager().ExecuteQuery(query);
                dataGridView1.DataSource = departmentsData;
                dataGridView1.Columns["DepartmentID"].Visible = false; // Скрываем колонку ID для лучшей читаемости
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}");
            }
        }
    }
}
