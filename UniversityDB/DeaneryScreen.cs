using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniversityDB
{
    public partial class DeaneryScreen : Form
    {
        public DeaneryScreen()
        {
            InitializeComponent();
        }

        private void NavigateToSection(int yPos)
        {
            MainPanel.AutoScrollPosition = new Point(0, yPos);
        }

        private void StudentsLabel_MouseEnter(object sender, EventArgs e)
        {
            StudentsLabel.ForeColor = SystemColors.ControlLight;
        }

        private void StudentsLabel_MouseLeave(object sender, EventArgs e)
        {
            StudentsLabel.ForeColor = SystemColors.ControlText;
        }

        private void StudentsLabel_Click(object sender, EventArgs e)
        {
            NavigateToSection(3);
        }

        private void DiplomaLabel_Click(object sender, EventArgs e)
        {
            NavigateToSection(921);
        }

        private void Lessons_Click(object sender, EventArgs e)
        {
            NavigateToSection(1875);
        }

        private void Departments_Click(object sender, EventArgs e)
        {
            NavigateToSection(2832);
        }

        private void Groups_Click(object sender, EventArgs e)
        {
            NavigateToSection(3778);
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

        private void Departments_MouseEnter(object sender, EventArgs e)
        {
            Departments.ForeColor = SystemColors.ControlLight;
        }

        private void Departments_MouseLeave(object sender, EventArgs e)
        {
            Departments.ForeColor = SystemColors.ControlText;
        }

        private void Groups_MouseEnter(object sender, EventArgs e)
        {
            Groups.ForeColor = SystemColors.ControlLight;
        }

        private void Groups_MouseLeave(object sender, EventArgs e)
        {
            Groups.ForeColor = SystemColors.ControlText;
        }

        private void Session_MouseEnter(object sender, EventArgs e)
        {
            Session.ForeColor = SystemColors.ControlLight;
        }

        private void Session_MouseLeave(object sender, EventArgs e)
        {
            Session.ForeColor = SystemColors.ControlText;
        }

        private void Research_MouseEnter(object sender, EventArgs e)
        {
            Research.ForeColor = SystemColors.ControlLight;
        }

        private void Research_MouseLeave(object sender, EventArgs e)
        {
            Research.ForeColor = SystemColors.ControlText;
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
            NavigateToSection(4737);
        }

        private void Research_Click(object sender, EventArgs e)
        {
            NavigateToSection(5685);
        }

        private void Study_plan_Click(object sender, EventArgs e)
        {
            NavigateToSection(6635);
        }
    }
}
