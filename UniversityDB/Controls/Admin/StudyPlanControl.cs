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
    public partial class StudyPlanControl : UserControl
    {
        public StudyPlanControl()
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
                sp.StudyPlanID,
                t.Full_name AS TeacherName,
                g.Name AS GroupName,
                sp.LessonType,
                sp.HoursAmount,
                sp.Form_of_control
            FROM 
                studyplan sp
            JOIN 
                teaching te ON sp.TeachingID = te.TeachingID
            JOIN 
                teachers t ON te.TeacherID = t.TeacherID
            JOIN 
                student_groups g ON sp.GroupID = g.GroupID;
        ";
                DataTable studyPlanData = new DatabaseManager().ExecuteQuery(query);
                dataGridView1.DataSource = studyPlanData;
                dataGridView1.Columns["StudyPlanID"].Visible = false; // Скрываем колонку ID для лучшей читаемости
                                                                      // Опционально, если требуется форматировать или настроить видимость других колонок
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
