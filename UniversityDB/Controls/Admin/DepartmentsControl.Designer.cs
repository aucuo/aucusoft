namespace UniversityDB.Controls
{
    partial class DepartmentsControl
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
            this.panelDepartments = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBox17 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.button16 = new System.Windows.Forms.Button();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.comboBox11 = new System.Windows.Forms.ComboBox();
            this.label40 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.button17 = new System.Windows.Forms.Button();
            this.label43 = new System.Windows.Forms.Label();
            this.button18 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panelDepartments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelDepartments
            // 
            this.panelDepartments.Controls.Add(this.dataGridView1);
            this.panelDepartments.Controls.Add(this.textBox17);
            this.panelDepartments.Controls.Add(this.label16);
            this.panelDepartments.Controls.Add(this.button16);
            this.panelDepartments.Controls.Add(this.textBox13);
            this.panelDepartments.Controls.Add(this.comboBox11);
            this.panelDepartments.Controls.Add(this.label40);
            this.panelDepartments.Controls.Add(this.label44);
            this.panelDepartments.Controls.Add(this.button1);
            this.panelDepartments.Controls.Add(this.button17);
            this.panelDepartments.Controls.Add(this.label43);
            this.panelDepartments.Controls.Add(this.button18);
            this.panelDepartments.Location = new System.Drawing.Point(3, 2);
            this.panelDepartments.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelDepartments.Name = "panelDepartments";
            this.panelDepartments.Size = new System.Drawing.Size(1256, 752);
            this.panelDepartments.TabIndex = 30;
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
            this.dataGridView1.Location = new System.Drawing.Point(0, 440);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1256, 312);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 76;
            // 
            // textBox17
            // 
            this.textBox17.Location = new System.Drawing.Point(780, 118);
            this.textBox17.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new System.Drawing.Size(228, 23);
            this.textBox17.TabIndex = 74;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(780, 101);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(115, 15);
            this.label16.TabIndex = 75;
            this.label16.Text = "Head of Department";
            // 
            // button16
            // 
            this.button16.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.button16.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button16.Location = new System.Drawing.Point(716, 190);
            this.button16.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(96, 28);
            this.button16.TabIndex = 73;
            this.button16.Text = "Delete";
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Click += new System.EventHandler(this.button16_Click);
            // 
            // textBox13
            // 
            this.textBox13.Location = new System.Drawing.Point(484, 118);
            this.textBox13.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(211, 23);
            this.textBox13.TabIndex = 65;
            // 
            // comboBox11
            // 
            this.comboBox11.FormattingEnabled = true;
            this.comboBox11.Location = new System.Drawing.Point(164, 118);
            this.comboBox11.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox11.Name = "comboBox11";
            this.comboBox11.Size = new System.Drawing.Size(228, 23);
            this.comboBox11.TabIndex = 67;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(164, 101);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(85, 15);
            this.label40.TabIndex = 66;
            this.label40.Text = "Deanery Name";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(485, 101);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(105, 15);
            this.label44.TabIndex = 68;
            this.label44.Text = "Department Name";
            // 
            // button17
            // 
            this.button17.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.button17.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button17.Location = new System.Drawing.Point(421, 190);
            this.button17.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(96, 28);
            this.button17.TabIndex = 71;
            this.button17.Text = "Save";
            this.button17.UseVisualStyleBackColor = true;
            this.button17.Click += new System.EventHandler(this.button17_Click);
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Font = new System.Drawing.Font("Bahnschrift", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label43.Location = new System.Drawing.Point(485, 16);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(222, 42);
            this.label43.TabIndex = 64;
            this.label43.Text = "Departments";
            // 
            // button18
            // 
            this.button18.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.button18.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button18.Location = new System.Drawing.Point(574, 190);
            this.button18.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(96, 28);
            this.button18.TabIndex = 72;
            this.button18.Text = "Edit";
            this.button18.UseVisualStyleBackColor = true;
            this.button18.Click += new System.EventHandler(this.button18_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(296, 190);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 28);
            this.button1.TabIndex = 71;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DepartmentsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelDepartments);
            this.Name = "DepartmentsControl";
            this.Size = new System.Drawing.Size(1262, 756);
            this.panelDepartments.ResumeLayout(false);
            this.panelDepartments.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelDepartments;
        private TextBox textBox17;
        private Label label16;
        private Button button16;
        private TextBox textBox13;
        private ComboBox comboBox11;
        private Label label40;
        private Label label44;
        private Button button17;
        private Label label43;
        private Button button18;
        private DataGridView dataGridView1;
        private Button button1;
    }
}
