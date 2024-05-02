namespace UniversityDB.Controls
{
    partial class GroupsControl
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
            this.panelGroups = new System.Windows.Forms.Panel();
            this.label29 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.button19 = new System.Windows.Forms.Button();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.button21 = new System.Windows.Forms.Button();
            this.comboBox12 = new System.Windows.Forms.ComboBox();
            this.label49 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.button20 = new System.Windows.Forms.Button();
            this.label47 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panelGroups.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelGroups
            // 
            this.panelGroups.Controls.Add(this.dataGridView1);
            this.panelGroups.Controls.Add(this.label29);
            this.panelGroups.Controls.Add(this.numericUpDown2);
            this.panelGroups.Controls.Add(this.button19);
            this.panelGroups.Controls.Add(this.textBox14);
            this.panelGroups.Controls.Add(this.button21);
            this.panelGroups.Controls.Add(this.comboBox12);
            this.panelGroups.Controls.Add(this.label49);
            this.panelGroups.Controls.Add(this.label46);
            this.panelGroups.Controls.Add(this.button20);
            this.panelGroups.Controls.Add(this.label47);
            this.panelGroups.Location = new System.Drawing.Point(3, 2);
            this.panelGroups.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelGroups.Name = "panelGroups";
            this.panelGroups.Size = new System.Drawing.Size(1206, 772);
            this.panelGroups.TabIndex = 31;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(830, 107);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(44, 15);
            this.label29.TabIndex = 89;
            this.label29.Text = "Course";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(830, 124);
            this.numericUpDown2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numericUpDown2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(131, 23);
            this.numericUpDown2.TabIndex = 88;
            this.numericUpDown2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // button19
            // 
            this.button19.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.button19.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button19.Location = new System.Drawing.Point(702, 196);
            this.button19.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(96, 28);
            this.button19.TabIndex = 87;
            this.button19.Text = "Delete";
            this.button19.UseVisualStyleBackColor = true;
            // 
            // textBox14
            // 
            this.textBox14.Location = new System.Drawing.Point(548, 124);
            this.textBox14.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(168, 23);
            this.textBox14.TabIndex = 79;
            // 
            // button21
            // 
            this.button21.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.button21.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button21.Location = new System.Drawing.Point(560, 196);
            this.button21.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(96, 28);
            this.button21.TabIndex = 86;
            this.button21.Text = "Edit";
            this.button21.UseVisualStyleBackColor = true;
            // 
            // comboBox12
            // 
            this.comboBox12.FormattingEnabled = true;
            this.comboBox12.Location = new System.Drawing.Point(193, 124);
            this.comboBox12.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox12.Name = "comboBox12";
            this.comboBox12.Size = new System.Drawing.Size(224, 23);
            this.comboBox12.TabIndex = 81;
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Font = new System.Drawing.Font("Bahnschrift", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label49.Location = new System.Drawing.Point(485, 16);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(131, 42);
            this.label49.TabIndex = 78;
            this.label49.Text = "Groups";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(193, 107);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(89, 15);
            this.label46.TabIndex = 80;
            this.label46.Text = "Specialty Name";
            // 
            // button20
            // 
            this.button20.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.button20.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button20.Location = new System.Drawing.Point(407, 196);
            this.button20.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(96, 28);
            this.button20.TabIndex = 85;
            this.button20.Text = "Save";
            this.button20.UseVisualStyleBackColor = true;
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(549, 107);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(75, 15);
            this.label47.TabIndex = 82;
            this.label47.Text = "Group Name";
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
            this.dataGridView1.Location = new System.Drawing.Point(0, 460);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1206, 312);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 90;
            // 
            // GroupsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelGroups);
            this.Name = "GroupsControl";
            this.Size = new System.Drawing.Size(1212, 776);
            this.panelGroups.ResumeLayout(false);
            this.panelGroups.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelGroups;
        private Label label29;
        private NumericUpDown numericUpDown2;
        private Button button19;
        private TextBox textBox14;
        private Button button21;
        private ComboBox comboBox12;
        private Label label49;
        private Label label46;
        private Button button20;
        private Label label47;
        private DataGridView dataGridView1;
    }
}
