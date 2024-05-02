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
                        r.DefenseDate
                    FROM 
                        research r
                    JOIN 
                        teachers t ON r.TeacherID = t.TeacherID;
                ";
                DataTable researchData = new DatabaseManager().ExecuteQuery(query);
                dataGridView1.DataSource = researchData;
                dataGridView1.Columns["ResearchID"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
