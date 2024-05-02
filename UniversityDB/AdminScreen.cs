﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniversityDB.Controls.Admin;

namespace UniversityDB
{
    public partial class AdminScreen : Form
    {
        public AdminScreen()
        {
            InitializeComponent();
            ControlsManager.ShowControl("StudyPlan", MainPanel);
        }

        private void StudentsLabel_MouseEnter(object sender, EventArgs e)
        {
            StudentsLabel.ForeColor = SystemColors.ControlLight;
        }

        private void StudentsLabel_MouseLeave(object sender, EventArgs e)
        {
            StudentsLabel.ForeColor = SystemColors.ControlText;
        }

        private void TeachersLabel_MouseEnter(object sender, EventArgs e)
        {
            TeachersLabel.ForeColor = SystemColors.ControlLight;
        }

        private void TeachersLabel_MouseLeave(object sender, EventArgs e)
        {
            TeachersLabel.ForeColor = SystemColors.ControlText;
        }

        private void SpecialtyLabel_MouseEnter(object sender, EventArgs e)
        {
            SpecialtyLabel.ForeColor = SystemColors.ControlLight;
        }

        private void SpecialtyLabel_MouseLeave(object sender, EventArgs e)
        {
            SpecialtyLabel.ForeColor = SystemColors.ControlText;
        }

        private void StudentsLabel_Click(object sender, EventArgs e)
        {
            ControlsManager.ShowControl("Students", MainPanel);
        }

        private void TeachersLabel_Click(object sender, EventArgs e)
        {
            ControlsManager.ShowControl("Teachers", MainPanel);
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

        private void Groups_Click(object sender, EventArgs e)
        {
            ControlsManager.ShowControl("Groups", MainPanel);
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

        private void Disciplines_MouseEnter(object sender, EventArgs e)
        {
            Disciplines.ForeColor = SystemColors.ControlLight;
        }

        private void Disciplines_MouseLeave(object sender, EventArgs e)
        {
            Disciplines.ForeColor = SystemColors.ControlText;
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
            ControlsManager.ShowControl("Session", MainPanel);
        }

        private void Disciplines_Click(object sender, EventArgs e)
        {
            ControlsManager.ShowControl("Disciplines", MainPanel);
        }

        private void Research_Click(object sender, EventArgs e)
        {
            ControlsManager.ShowControl("Research", MainPanel);
        }

        private void Study_plan_Click(object sender, EventArgs e)
        {
            ControlsManager.ShowControl("StudyPlan", MainPanel);
        }
    }
}