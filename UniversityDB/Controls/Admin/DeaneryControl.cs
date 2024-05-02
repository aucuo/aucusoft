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
    }
}
