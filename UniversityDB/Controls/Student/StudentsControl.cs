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
    public partial class StudentsControl : UserControl
    {
        public StudentsControl()
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
                        s.StudentID,
                        s.Full_name,
                        s.Gender,
                        s.Course,
                        s.Age,
                        s.Has_children,
                        s.Education_form,
                        sg.Name AS StudentGroup
                    FROM 
                        students s
                    JOIN 
                        student_groups sg ON s.GroupID = sg.GroupID;
                ";
                DataTable studentData = new DatabaseManager().ExecuteQuery(query);
                dataGridView1.DataSource = studentData;
                dataGridView1.Columns["StudentID"].Visible = false;  // Скрытие столбца StudentID, если необходимо
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}");
            }
        }
    }
}
