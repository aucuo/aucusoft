namespace UniversityDB
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            Username = new TextBox();
            Password = new TextBox();
            EnterButton = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Bahnschrift SemiBold SemiConden", 36F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(17, 38);
            label1.Name = "label1";
            label1.Size = new Size(337, 72);
            label1.TabIndex = 0;
            label1.Text = "Авторизация";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(72, 152);
            label2.Name = "label2";
            label2.Size = new Size(52, 20);
            label2.TabIndex = 1;
            label2.Text = "Логин";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(72, 209);
            label3.Name = "label3";
            label3.Size = new Size(62, 20);
            label3.TabIndex = 2;
            label3.Text = "Пароль";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources._2203549_admin_avatar_human_login_user_icon;
            pictureBox1.Location = new Point(23, 172);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(28, 30);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources._1564520_code_open_password_icon;
            pictureBox2.Location = new Point(23, 229);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(28, 30);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 4;
            pictureBox2.TabStop = false;
            // 
            // Username
            // 
            Username.Location = new Point(72, 175);
            Username.Name = "Username";
            Username.Size = new Size(262, 27);
            Username.TabIndex = 5;
            // 
            // Password
            // 
            Password.Location = new Point(72, 232);
            Password.Name = "Password";
            Password.PasswordChar = '*';
            Password.Size = new Size(262, 27);
            Password.TabIndex = 6;
            Password.UseSystemPasswordChar = true;
            // 
            // EnterButton
            // 
            EnterButton.BackColor = Color.LightYellow;
            EnterButton.Font = new Font("Bahnschrift SemiCondensed", 12F, FontStyle.Regular, GraphicsUnit.Point);
            EnterButton.ForeColor = SystemColors.ControlText;
            EnterButton.Location = new Point(132, 313);
            EnterButton.Name = "EnterButton";
            EnterButton.Size = new Size(100, 40);
            EnterButton.TabIndex = 7;
            EnterButton.Text = "Войти";
            EnterButton.UseVisualStyleBackColor = false;
            EnterButton.Click += EnterButton_Click;
            EnterButton.MouseEnter += EnterButton_MouseEnter;
            EnterButton.MouseLeave += EnterButton_MouseLeave;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkSeaGreen;
            ClientSize = new Size(366, 405);
            Controls.Add(EnterButton);
            Controls.Add(Password);
            Controls.Add(Username);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Авторизация";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private TextBox Username;
        private TextBox Password;
        private Button EnterButton;
    }
}