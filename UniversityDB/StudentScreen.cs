using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniversityDB.Controls.Student;

namespace UniversityDB
{
    public partial class StudentScreen : Form
    {
        public StudentScreen()
        {
            InitializeComponent();
            ControlsManager.ShowControl("Session", MainPanel);
        }

        private void SpecialtyLabel_MouseEnter(object sender, EventArgs e)
        {
            SpecialtyLabel.ForeColor = SystemColors.ControlLight;
        }

        private void SpecialtyLabel_MouseLeave(object sender, EventArgs e)
        {
            SpecialtyLabel.ForeColor = SystemColors.ControlText;
        }

        private void SpecialtyLabel_Click(object sender, EventArgs e)
        {
            ControlsManager.ShowControl("Specialty", MainPanel);
        }

        private void DiplomaLabel_Click(object sender, EventArgs e)
        {
            ControlsManager.ShowControl("Diploma", MainPanel);
        }

        private void Lessons_Click(object sender, EventArgs e)
        {
            ControlsManager.ShowControl("Lessons", MainPanel);
        }

        private void Deanery_Click(object sender, EventArgs e)
        {
            ControlsManager.ShowControl("Deanery", MainPanel);
        }

        private void Departments_Click(object sender, EventArgs e)
        {
            ControlsManager.ShowControl("Departments", MainPanel);
        }

        private void DiplomaLabel_MouseEnter(object sender, EventArgs e)
        {
            DiplomaLabel.ForeColor = SystemColors.ControlLight;
        }

        private void DiplomaLabel_MouseLeave(object sender, EventArgs e)
        {
            DiplomaLabel.ForeColor = SystemColors.ControlText;
        }

        private void Lessons_MouseEnter(object sender, EventArgs e)
        {
            Lessons.ForeColor = SystemColors.ControlLight;
        }

        private void Lessons_MouseLeave(object sender, EventArgs e)
        {
            Lessons.ForeColor = SystemColors.ControlText;
        }

        private void Deanery_MouseEnter(object sender, EventArgs e)
        {
            Deanery.ForeColor = SystemColors.ControlLight;
        }

        private void Deanery_MouseLeave(object sender, EventArgs e)
        {
            Deanery.ForeColor = SystemColors.ControlText;
        }

        private void Departments_MouseEnter(object sender, EventArgs e)
        {
            Departments.ForeColor = SystemColors.ControlLight;
        }

        private void Departments_MouseLeave(object sender, EventArgs e)
        {
            Departments.ForeColor = SystemColors.ControlText;
        }

        private void Session_MouseEnter(object sender, EventArgs e)
        {
            Session.ForeColor = SystemColors.ControlLight;
        }

        private void Session_MouseLeave(object sender, EventArgs e)
        {
            Session.ForeColor = SystemColors.ControlText;
        }

        private void Study_plan_MouseEnter(object sender, EventArgs e)
        {
            Study_plan.ForeColor = SystemColors.ControlLight;
        }

        private void Study_plan_MouseLeave(object sender, EventArgs e)
        {
            Study_plan.ForeColor = SystemColors.ControlText;
        }

        private void Session_Click(object sender, EventArgs e)
        {
            ControlsManager.ShowControl("Session", MainPanel);
        }

        private void Study_plan_Click(object sender, EventArgs e)
        {
            ControlsManager.ShowControl("StudyPlan", MainPanel);
        }
    }
}
