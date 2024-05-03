namespace UniversityDB.Controls
{
    partial class DisciplinesControl
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
            this.panelDisciplines = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button25 = new System.Windows.Forms.Button();
            this.label52 = new System.Windows.Forms.Label();
            this.button27 = new System.Windows.Forms.Button();
            this.textBox19 = new System.Windows.Forms.TextBox();
            this.button26 = new System.Windows.Forms.Button();
            this.label50 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.panelDisciplines.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelDisciplines
            // 
            this.panelDisciplines.Controls.Add(this.button4);
            this.panelDisciplines.Controls.Add(this.dataGridView1);
            this.panelDisciplines.Controls.Add(this.button25);
            this.panelDisciplines.Controls.Add(this.label52);
            this.panelDisciplines.Controls.Add(this.button27);
            this.panelDisciplines.Controls.Add(this.textBox19);
            this.panelDisciplines.Controls.Add(this.button26);
            this.panelDisciplines.Controls.Add(this.label50);
            this.panelDisciplines.Location = new System.Drawing.Point(3, 2);
            this.panelDisciplines.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelDisciplines.Name = "panelDisciplines";
            this.panelDisciplines.Size = new System.Drawing.Size(1341, 773);
            this.panelDisciplines.TabIndex = 33;
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
            this.dataGridView1.Location = new System.Drawing.Point(0, 461);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1341, 312);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 108;
            // 
            // button25
            // 
            this.button25.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.button25.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button25.Location = new System.Drawing.Point(682, 189);
            this.button25.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button25.Name = "button25";
            this.button25.Size = new System.Drawing.Size(96, 28);
            this.button25.TabIndex = 107;
            this.button25.Text = "Delete";
            this.button25.UseVisualStyleBackColor = true;
            this.button25.Click += new System.EventHandler(this.button25_Click);
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(467, 102);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(93, 15);
            this.label52.TabIndex = 104;
            this.label52.Text = "Discipline Name";
            // 
            // button27
            // 
            this.button27.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.button27.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button27.Location = new System.Drawing.Point(387, 189);
            this.button27.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button27.Name = "button27";
            this.button27.Size = new System.Drawing.Size(96, 28);
            this.button27.TabIndex = 105;
            this.button27.Text = "Save";
            this.button27.UseVisualStyleBackColor = true;
            this.button27.Click += new System.EventHandler(this.button27_Click);
            // 
            // textBox19
            // 
            this.textBox19.Location = new System.Drawing.Point(466, 119);
            this.textBox19.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox19.Name = "textBox19";
            this.textBox19.Size = new System.Drawing.Size(271, 23);
            this.textBox19.TabIndex = 101;
            // 
            // button26
            // 
            this.button26.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.button26.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button26.Location = new System.Drawing.Point(540, 189);
            this.button26.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button26.Name = "button26";
            this.button26.Size = new System.Drawing.Size(96, 28);
            this.button26.TabIndex = 106;
            this.button26.Text = "Edit";
            this.button26.UseVisualStyleBackColor = true;
            this.button26.Click += new System.EventHandler(this.button26_Click);
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Font = new System.Drawing.Font("Bahnschrift", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label50.Location = new System.Drawing.Point(485, 16);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(189, 42);
            this.label50.TabIndex = 100;
            this.label50.Text = "Disciplines";
            // 
            // button4
            // 
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(263, 189);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(96, 28);
            this.button4.TabIndex = 73;
            this.button4.Text = "Add";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // DisciplinesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelDisciplines);
            this.Name = "DisciplinesControl";
            this.Size = new System.Drawing.Size(1347, 777);
            this.panelDisciplines.ResumeLayout(false);
            this.panelDisciplines.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelDisciplines;
        private Button button25;
        private Label label52;
        private Button button27;
        private TextBox textBox19;
        private Button button26;
        private Label label50;
        private DataGridView dataGridView1;
        private Button button4;
    }
}
