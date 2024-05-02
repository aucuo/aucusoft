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

namespace UniversityDB.Controls.Admin
{
    public partial class SessionControl : UserControl
    {
        public SessionControl()
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
                        s.SessionID,
                        st.Full_name AS StudentName,
                        t.Full_name AS TeacherName,
                        d.Name AS DisciplineName,
                        s.Semester,
                        s.Form_of_control,
                        s.Grade,
                        s.Retake
                    FROM 
                        session s
                    JOIN 
                        students st ON s.StudentID = st.StudentID
                    JOIN 
                        teaching te ON s.TeachingID = te.TeachingID
                    JOIN 
                        teachers t ON te.TeacherID = t.TeacherID
                    JOIN 
                        disciplines d ON te.DisciplineID = d.DisciplineID;
                ";
                DataTable sessionData = new DatabaseManager().ExecuteQuery(query);
                dataGridView1.DataSource = sessionData;
                dataGridView1.Columns["SessionID"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
