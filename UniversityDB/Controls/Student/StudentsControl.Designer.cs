namespace UniversityDB.Controls.Student
{
    partial class StudentsControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelStudents = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.StudentHavingKids = new System.Windows.Forms.RadioButton();
            this.StudentNotHavingKids = new System.Windows.Forms.RadioButton();
            this.DeleteStudentButton = new System.Windows.Forms.Button();
            this.EditStudentButton = new System.Windows.Forms.Button();
            this.SaveStudentButton = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.StudentGenderFemale = new System.Windows.Forms.RadioButton();
            this.StudentGenderMale = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.StudentsPanelTopic = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panelStudents.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelStudents
            // 
            this.panelStudents.Controls.Add(this.dataGridView1);
            this.panelStudents.Controls.Add(this.panel3);
            this.panelStudents.Controls.Add(this.DeleteStudentButton);
            this.panelStudents.Controls.Add(this.EditStudentButton);
            this.panelStudents.Controls.Add(this.SaveStudentButton);
            this.panelStudents.Controls.Add(this.label10);
            this.panelStudents.Controls.Add(this.textBox2);
            this.panelStudents.Controls.Add(this.label9);
            this.panelStudents.Controls.Add(this.comboBox2);
            this.panelStudents.Controls.Add(this.label8);
            this.panelStudents.Controls.Add(this.label7);
            this.panelStudents.Controls.Add(this.comboBox1);
            this.panelStudents.Controls.Add(this.numericUpDown1);
            this.panelStudents.Controls.Add(this.label5);
            this.panelStudents.Controls.Add(this.StudentGenderFemale);
            this.panelStudents.Controls.Add(this.StudentGenderMale);
            this.panelStudents.Controls.Add(this.label4);
            this.panelStudents.Controls.Add(this.label3);
            this.panelStudents.Controls.Add(this.textBox3);
            this.panelStudents.Controls.Add(this.textBox1);
            this.panelStudents.Controls.Add(this.StudentsPanelTopic);
            this.panelStudents.Location = new System.Drawing.Point(3, 2);
            this.panelStudents.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelStudents.Name = "panelStudents";
            this.panelStudents.Size = new System.Drawing.Size(1290, 621);
            this.panelStudents.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.StudentHavingKids);
            this.panel3.Controls.Add(this.StudentNotHavingKids);
            this.panel3.Location = new System.Drawing.Point(637, 157);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(74, 66);
            this.panel3.TabIndex = 23;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "Kids";
            // 
            // StudentHavingKids
            // 
            this.StudentHavingKids.AutoSize = true;
            this.StudentHavingKids.Location = new System.Drawing.Point(15, 21);
            this.StudentHavingKids.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.StudentHavingKids.Name = "StudentHavingKids";
            this.StudentHavingKids.Size = new System.Drawing.Size(42, 19);
            this.StudentHavingKids.TabIndex = 9;
            this.StudentHavingKids.TabStop = true;
            this.StudentHavingKids.Text = "Yes";
            this.StudentHavingKids.UseVisualStyleBackColor = true;
            // 
            // StudentNotHavingKids
            // 
            this.StudentNotHavingKids.AutoSize = true;
            this.StudentNotHavingKids.Location = new System.Drawing.Point(15, 44);
            this.StudentNotHavingKids.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.StudentNotHavingKids.Name = "StudentNotHavingKids";
            this.StudentNotHavingKids.Size = new System.Drawing.Size(41, 19);
            this.StudentNotHavingKids.TabIndex = 10;
            this.StudentNotHavingKids.TabStop = true;
            this.StudentNotHavingKids.Text = "No";
            this.StudentNotHavingKids.UseVisualStyleBackColor = true;
            // 
            // DeleteStudentButton
            // 
            this.DeleteStudentButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.DeleteStudentButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteStudentButton.Location = new System.Drawing.Point(702, 264);
            this.DeleteStudentButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DeleteStudentButton.Name = "DeleteStudentButton";
            this.DeleteStudentButton.Size = new System.Drawing.Size(96, 28);
            this.DeleteStudentButton.TabIndex = 22;
            this.DeleteStudentButton.Text = "Delete";
            this.DeleteStudentButton.UseVisualStyleBackColor = true;
            // 
            // EditStudentButton
            // 
            this.EditStudentButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.EditStudentButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EditStudentButton.Location = new System.Drawing.Point(560, 264);
            this.EditStudentButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EditStudentButton.Name = "EditStudentButton";
            this.EditStudentButton.Size = new System.Drawing.Size(96, 28);
            this.EditStudentButton.TabIndex = 21;
            this.EditStudentButton.Text = "Edit";
            this.EditStudentButton.UseVisualStyleBackColor = true;
            // 
            // SaveStudentButton
            // 
            this.SaveStudentButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.SaveStudentButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveStudentButton.Location = new System.Drawing.Point(407, 264);
            this.SaveStudentButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SaveStudentButton.Name = "SaveStudentButton";
            this.SaveStudentButton.Size = new System.Drawing.Size(96, 28);
            this.SaveStudentButton.TabIndex = 20;
            this.SaveStudentButton.Text = "Save";
            this.SaveStudentButton.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(997, 82);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 15);
            this.label10.TabIndex = 19;
            this.label10.Text = "Scholarship";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(997, 100);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(110, 23);
            this.textBox2.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(794, 82);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 15);
            this.label9.TabIndex = 17;
            this.label9.Text = "Education Form";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(794, 100);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(160, 23);
            this.comboBox2.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(677, 82);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 15);
            this.label8.TabIndex = 15;
            this.label8.Text = "Course";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(572, 82);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 15);
            this.label7.TabIndex = 14;
            this.label7.Text = "Age";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(407, 100);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(120, 23);
            this.comboBox1.TabIndex = 13;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(677, 100);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(74, 23);
            this.numericUpDown1.TabIndex = 12;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(502, 157);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Gender";
            // 
            // StudentGenderFemale
            // 
            this.StudentGenderFemale.AutoSize = true;
            this.StudentGenderFemale.Location = new System.Drawing.Point(502, 196);
            this.StudentGenderFemale.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.StudentGenderFemale.Name = "StudentGenderFemale";
            this.StudentGenderFemale.Size = new System.Drawing.Size(63, 19);
            this.StudentGenderFemale.TabIndex = 7;
            this.StudentGenderFemale.TabStop = true;
            this.StudentGenderFemale.Text = "Female";
            this.StudentGenderFemale.UseVisualStyleBackColor = true;
            // 
            // StudentGenderMale
            // 
            this.StudentGenderMale.AutoSize = true;
            this.StudentGenderMale.Location = new System.Drawing.Point(502, 174);
            this.StudentGenderMale.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.StudentGenderMale.Name = "StudentGenderMale";
            this.StudentGenderMale.Size = new System.Drawing.Size(51, 19);
            this.StudentGenderMale.TabIndex = 6;
            this.StudentGenderMale.TabStop = true;
            this.StudentGenderMale.Text = "Male";
            this.StudentGenderMale.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(407, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Group Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(71, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Student Name";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(572, 100);
            this.textBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(59, 23);
            this.textBox3.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(71, 101);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(287, 23);
            this.textBox1.TabIndex = 1;
            // 
            // StudentsPanelTopic
            // 
            this.StudentsPanelTopic.AutoSize = true;
            this.StudentsPanelTopic.Font = new System.Drawing.Font("Bahnschrift", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.StudentsPanelTopic.Location = new System.Drawing.Point(485, 16);
            this.StudentsPanelTopic.Name = "StudentsPanelTopic";
            this.StudentsPanelTopic.Size = new System.Drawing.Size(157, 42);
            this.StudentsPanelTopic.TabIndex = 0;
            this.StudentsPanelTopic.Text = "Students";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.DarkSeaGreen;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 309);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1290, 312);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 27;
            // 
            // StudentsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelStudents);
            this.Name = "StudentsControl";
            this.Size = new System.Drawing.Size(1296, 625);
            this.panelStudents.ResumeLayout(false);
            this.panelStudents.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelStudents;
        private Panel panel3;
        private Label label6;
        private RadioButton StudentHavingKids;
        private RadioButton StudentNotHavingKids;
        private Button DeleteStudentButton;
        private Button EditStudentButton;
        private Button SaveStudentButton;
        private Label label10;
        private TextBox textBox2;
        private Label label9;
        private ComboBox comboBox2;
        private Label label8;
        private Label label7;
        private ComboBox comboBox1;
        private NumericUpDown numericUpDown1;
        private Label label5;
        private RadioButton StudentGenderFemale;
        private RadioButton StudentGenderMale;
        private Label label4;
        private Label label3;
        private TextBox textBox3;
        private TextBox textBox1;
        private Label StudentsPanelTopic;
        private DataGridView dataGridView1;
    }
}
