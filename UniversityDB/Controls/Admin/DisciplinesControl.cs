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
    public partial class DisciplinesControl : UserControl
    {
        public DisciplinesControl()
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
                        DisciplineID,
                        Name
                    FROM 
                        disciplines;
                ";
                DataTable disciplinesData = new DatabaseManager().ExecuteQuery(query);
                dataGridView1.DataSource = disciplinesData;
                dataGridView1.Columns["DisciplineID"].Visible = false; // Скрываем колонку ID
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}");
            }
        }
    }
}
