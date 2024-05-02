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
    public partial class DiplomaControl : UserControl
    {
        public DiplomaControl()
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
                        d.DiplomaID,
                        st.Full_name AS StudentName,
                        t.Full_name AS TeacherName,
                        d.Topic
                    FROM 
                        diploma d
                    JOIN 
                        students st ON d.StudentID = st.StudentID
                    JOIN 
                        teachers t ON d.TeacherID = t.TeacherID;
                ";
                DataTable diplomaData = new DatabaseManager().ExecuteQuery(query);
                dataGridView1.DataSource = diplomaData;
                dataGridView1.Columns["DiplomaID"].Visible = false; // Скрываем колонку ID
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}");
            }
        }
    }
}
