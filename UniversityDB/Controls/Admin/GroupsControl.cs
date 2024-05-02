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
                        sp.Name AS SpecialtyName
                    FROM 
                        student_groups g
                    JOIN 
                        specialty sp ON g.SpecialtyID = sp.SpecialtyID;
                ";
                DataTable groupsData = new DatabaseManager().ExecuteQuery(query);
                dataGridView1.DataSource = groupsData;
                dataGridView1.Columns["GroupID"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
