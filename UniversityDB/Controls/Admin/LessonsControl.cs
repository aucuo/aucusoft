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
    public partial class LessonsControl : UserControl
    {
        public LessonsControl()
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
                        l.LessonID,
                        t.Full_name AS TeacherName,
                        g.Name AS GroupName,
                        l.LessonType,
                        l.LessonDate,
                        l.LessonTime
                    FROM 
                        lessons l
                    JOIN 
                        teaching te ON l.TeachingID = te.TeachingID
                    JOIN 
                        teachers t ON te.TeacherID = t.TeacherID
                    JOIN 
                        student_groups g ON l.GroupID = g.GroupID;

                ";
                DataTable lessonsData = new DatabaseManager().ExecuteQuery(query);
                dataGridView1.DataSource = lessonsData;
                dataGridView1.Columns["LessonID"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
