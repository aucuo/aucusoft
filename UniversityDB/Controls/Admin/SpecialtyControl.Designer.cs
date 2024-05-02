namespace UniversityDB.Controls
{
    partial class SpecialtyControl
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
            this.panelSpecialties = new System.Windows.Forms.Panel();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.comboBox8 = new System.Windows.Forms.ComboBox();
            this.label35 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panelSpecialties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSpecialties
            // 
            this.panelSpecialties.Controls.Add(this.dataGridView1);
            this.panelSpecialties.Controls.Add(this.button7);
            this.panelSpecialties.Controls.Add(this.button8);
            this.panelSpecialties.Controls.Add(this.button9);
            this.panelSpecialties.Controls.Add(this.comboBox8);
            this.panelSpecialties.Controls.Add(this.label35);
            this.panelSpecialties.Controls.Add(this.label36);
            this.panelSpecialties.Controls.Add(this.textBox12);
            this.panelSpecialties.Controls.Add(this.label37);
            this.panelSpecialties.Location = new System.Drawing.Point(3, 2);
            this.panelSpecialties.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelSpecialties.Name = "panelSpecialties";
            this.panelSpecialties.Size = new System.Drawing.Size(1168, 602);
            this.panelSpecialties.TabIndex = 25;
            // 
            // button7
            // 
            this.button7.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Location = new System.Drawing.Point(702, 175);
            this.button7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(96, 28);
            this.button7.TabIndex = 42;
            this.button7.Text = "Delete";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Location = new System.Drawing.Point(560, 175);
            this.button8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(96, 28);
            this.button8.TabIndex = 41;
            this.button8.Text = "Edit";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Location = new System.Drawing.Point(407, 175);
            this.button9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(96, 28);
            this.button9.TabIndex = 40;
            this.button9.Text = "Save";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // comboBox8
            // 
            this.comboBox8.FormattingEnabled = true;
            this.comboBox8.Location = new System.Drawing.Point(682, 115);
            this.comboBox8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox8.Name = "comboBox8";
            this.comboBox8.Size = new System.Drawing.Size(232, 23);
            this.comboBox8.TabIndex = 33;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(682, 98);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(105, 15);
            this.label35.TabIndex = 28;
            this.label35.Text = "Department Name";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(332, 98);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(89, 15);
            this.label36.TabIndex = 27;
            this.label36.Text = "Specialty Name";
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(332, 115);
            this.textBox12.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(287, 23);
            this.textBox12.TabIndex = 25;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("Bahnschrift", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label37.Location = new System.Drawing.Point(485, 16);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(190, 42);
            this.label37.TabIndex = 24;
            this.label37.Text = "Specialties";
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
            this.dataGridView1.Location = new System.Drawing.Point(0, 290);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1168, 312);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 43;
            // 
            // SpecialtyControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelSpecialties);
            this.Name = "SpecialtyControl";
            this.Size = new System.Drawing.Size(1174, 606);
            this.panelSpecialties.ResumeLayout(false);
            this.panelSpecialties.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelSpecialties;
        private Button button7;
        private Button button8;
        private Button button9;
        private ComboBox comboBox8;
        private Label label35;
        private Label label36;
        private TextBox textBox12;
        private Label label37;
        private DataGridView dataGridView1;
    }
}
