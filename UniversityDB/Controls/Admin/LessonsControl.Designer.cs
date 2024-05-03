namespace UniversityDB.Controls
{
    partial class LessonsControl
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
            this.panelLessons = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label14 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.button10 = new System.Windows.Forms.Button();
            this.label32 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.button11 = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.button12 = new System.Windows.Forms.Button();
            this.label30 = new System.Windows.Forms.Label();
            this.panelLessons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelLessons
            // 
            this.panelLessons.Controls.Add(this.button4);
            this.panelLessons.Controls.Add(this.dataGridView1);
            this.panelLessons.Controls.Add(this.label14);
            this.panelLessons.Controls.Add(this.dateTimePicker2);
            this.panelLessons.Controls.Add(this.label13);
            this.panelLessons.Controls.Add(this.dateTimePicker1);
            this.panelLessons.Controls.Add(this.button10);
            this.panelLessons.Controls.Add(this.label32);
            this.panelLessons.Controls.Add(this.label17);
            this.panelLessons.Controls.Add(this.comboBox1);
            this.panelLessons.Controls.Add(this.comboBox4);
            this.panelLessons.Controls.Add(this.comboBox3);
            this.panelLessons.Controls.Add(this.button11);
            this.panelLessons.Controls.Add(this.label15);
            this.panelLessons.Controls.Add(this.button12);
            this.panelLessons.Controls.Add(this.label30);
            this.panelLessons.Location = new System.Drawing.Point(3, 2);
            this.panelLessons.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelLessons.Name = "panelLessons";
            this.panelLessons.Size = new System.Drawing.Size(1188, 718);
            this.panelLessons.TabIndex = 28;
            // 
            // button4
            // 
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(319, 194);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(96, 28);
            this.button4.TabIndex = 75;
            this.button4.Text = "Add";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
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
            this.dataGridView1.Location = new System.Drawing.Point(0, 406);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1188, 312);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 50;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(883, 104);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(72, 15);
            this.label14.TabIndex = 49;
            this.label14.Text = "Lesson Time";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker2.Location = new System.Drawing.Point(883, 122);
            this.dateTimePicker2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(97, 23);
            this.dateTimePicker2.TabIndex = 48;
            this.dateTimePicker2.Value = new System.DateTime(2024, 5, 3, 0, 0, 0, 0);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(716, 106);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(70, 15);
            this.label13.TabIndex = 47;
            this.label13.Text = "Lesson Date";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(716, 124);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(111, 23);
            this.dateTimePicker1.TabIndex = 46;
            // 
            // button10
            // 
            this.button10.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button10.Location = new System.Drawing.Point(716, 194);
            this.button10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(96, 28);
            this.button10.TabIndex = 43;
            this.button10.Text = "Delete";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Bahnschrift", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label32.Location = new System.Drawing.Point(485, 16);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(150, 42);
            this.label32.TabIndex = 26;
            this.label32.Text = "Lessons";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(346, 105);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(65, 15);
            this.label17.TabIndex = 35;
            this.label17.Text = "TeachingID";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(346, 122);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(146, 23);
            this.comboBox1.TabIndex = 34;
            // 
            // comboBox4
            // 
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(164, 122);
            this.comboBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(146, 23);
            this.comboBox4.TabIndex = 34;
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(520, 123);
            this.comboBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(134, 23);
            this.comboBox3.TabIndex = 37;
            // 
            // button11
            // 
            this.button11.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button11.Location = new System.Drawing.Point(574, 194);
            this.button11.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(96, 28);
            this.button11.TabIndex = 42;
            this.button11.Text = "Edit";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(520, 105);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(70, 15);
            this.label15.TabIndex = 38;
            this.label15.Text = "Lesson Type";
            // 
            // button12
            // 
            this.button12.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.button12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button12.Location = new System.Drawing.Point(421, 194);
            this.button12.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(96, 28);
            this.button12.TabIndex = 41;
            this.button12.Text = "Save";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(164, 105);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(75, 15);
            this.label30.TabIndex = 30;
            this.label30.Text = "Group Name";
            // 
            // LessonsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelLessons);
            this.Name = "LessonsControl";
            this.Size = new System.Drawing.Size(1194, 722);
            this.panelLessons.ResumeLayout(false);
            this.panelLessons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelLessons;
        private Label label14;
        private DateTimePicker dateTimePicker2;
        private Label label13;
        private DateTimePicker dateTimePicker1;
        private Button button10;
        private Label label32;
        private Label label17;
        private ComboBox comboBox4;
        private ComboBox comboBox3;
        private Button button11;
        private Label label15;
        private Button button12;
        private Label label30;
        private DataGridView dataGridView1;
        private Button button4;
        private ComboBox comboBox1;
    }
}
