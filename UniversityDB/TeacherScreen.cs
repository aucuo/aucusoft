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
    public partial class TeacherScreen : Form
    {
        public TeacherScreen()
        {
            InitializeComponent();
        }
        private void NavigateToSection(int yPos)
        {
            MainPanel.AutoScrollPosition = new Point(0, yPos);
        }

        private void DiplomaLabel_Click(object sender, EventArgs e)
        {
            NavigateToSection(3);
        }

        private void Lessons_Click(object sender, EventArgs e)
        {
            NavigateToSection(957);
        }

        private void Groups_Click(object sender, EventArgs e)
        {
            NavigateToSection(1914);
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
            NavigateToSection(2873);
        }

        private void Study_plan_Click(object sender, EventArgs e)
        {
            NavigateToSection(3821);
        }
    }
}
