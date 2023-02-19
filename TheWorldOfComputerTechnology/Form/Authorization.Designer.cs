
namespace TheWorldOfComputerTechnology
{
    partial class Authorization
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Authorization));
            this.form_authorization = new System.Windows.Forms.Panel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.login_out = new System.Windows.Forms.Button();
            this.login_label = new System.Windows.Forms.Label();
            this.password_label = new System.Windows.Forms.Label();
            this.login_textbox = new System.Windows.Forms.TextBox();
            this.login_up = new System.Windows.Forms.Button();
            this.password_textbox = new System.Windows.Forms.TextBox();
            this.visible_password = new System.Windows.Forms.Panel();
            this.pictureBox_logo = new System.Windows.Forms.PictureBox();
            this.form_authorization.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_logo)).BeginInit();
            this.SuspendLayout();
            // 
            // form_authorization
            // 
            this.form_authorization.BackColor = System.Drawing.Color.White;
            this.form_authorization.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.form_authorization.Controls.Add(this.labelTitle);
            this.form_authorization.Controls.Add(this.login_out);
            this.form_authorization.Controls.Add(this.login_label);
            this.form_authorization.Controls.Add(this.password_label);
            this.form_authorization.Controls.Add(this.login_textbox);
            this.form_authorization.Controls.Add(this.visible_password);
            this.form_authorization.Controls.Add(this.login_up);
            this.form_authorization.Controls.Add(this.password_textbox);
            this.form_authorization.Controls.Add(this.pictureBox_logo);
            this.form_authorization.Dock = System.Windows.Forms.DockStyle.Fill;
            this.form_authorization.Location = new System.Drawing.Point(0, 0);
            this.form_authorization.Name = "form_authorization";
            this.form_authorization.Size = new System.Drawing.Size(654, 450);
            this.form_authorization.TabIndex = 8;
            this.form_authorization.MouseDown += new System.Windows.Forms.MouseEventHandler(this.form_authorization_MouseDown);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTitle.Location = new System.Drawing.Point(15, 20);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(227, 38);
            this.labelTitle.TabIndex = 6;
            this.labelTitle.Text = "Авторизация";
            this.labelTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.form_authorization_MouseDown);
            // 
            // login_out
            // 
            this.login_out.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.login_out.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.login_out.Location = new System.Drawing.Point(316, 321);
            this.login_out.Name = "login_out";
            this.login_out.Size = new System.Drawing.Size(145, 44);
            this.login_out.TabIndex = 3;
            this.login_out.Text = "Отмена";
            this.login_out.UseVisualStyleBackColor = true;
            this.login_out.Click += new System.EventHandler(this.login_out_Click);
            // 
            // login_label
            // 
            this.login_label.AutoSize = true;
            this.login_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.login_label.Location = new System.Drawing.Point(152, 148);
            this.login_label.Name = "login_label";
            this.login_label.Size = new System.Drawing.Size(59, 20);
            this.login_label.TabIndex = 3;
            this.login_label.Text = "Логин";
            // 
            // password_label
            // 
            this.password_label.AutoSize = true;
            this.password_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.password_label.Location = new System.Drawing.Point(152, 237);
            this.password_label.Name = "password_label";
            this.password_label.Size = new System.Drawing.Size(72, 20);
            this.password_label.TabIndex = 4;
            this.password_label.Text = "Пароль";
            // 
            // login_textbox
            // 
            this.login_textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.login_textbox.Location = new System.Drawing.Point(153, 171);
            this.login_textbox.Name = "login_textbox";
            this.login_textbox.Size = new System.Drawing.Size(308, 34);
            this.login_textbox.TabIndex = 0;
            this.login_textbox.Text = "Yrmen45";
            // 
            // login_up
            // 
            this.login_up.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.login_up.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.login_up.Location = new System.Drawing.Point(153, 321);
            this.login_up.Name = "login_up";
            this.login_up.Size = new System.Drawing.Size(157, 44);
            this.login_up.TabIndex = 2;
            this.login_up.Text = "Войти";
            this.login_up.UseVisualStyleBackColor = true;
            this.login_up.Click += new System.EventHandler(this.login_up_Click);
            // 
            // password_textbox
            // 
            this.password_textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.password_textbox.Location = new System.Drawing.Point(155, 260);
            this.password_textbox.Name = "password_textbox";
            this.password_textbox.Size = new System.Drawing.Size(306, 34);
            this.password_textbox.TabIndex = 1;
            this.password_textbox.Text = "Yrmen45";
            this.password_textbox.UseSystemPasswordChar = true;
            // 
            // visible_password
            // 
            this.visible_password.BackgroundImage = global::TheWorldOfComputerTechnology.Properties.Resources.open;
            this.visible_password.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.visible_password.Location = new System.Drawing.Point(467, 260);
            this.visible_password.Name = "visible_password";
            this.visible_password.Size = new System.Drawing.Size(40, 34);
            this.visible_password.TabIndex = 5;
            this.visible_password.Click += new System.EventHandler(this.visible_password_Click);
            // 
            // pictureBox_logo
            // 
            this.pictureBox_logo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox_logo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_logo.Image")));
            this.pictureBox_logo.Location = new System.Drawing.Point(468, -1);
            this.pictureBox_logo.Name = "pictureBox_logo";
            this.pictureBox_logo.Size = new System.Drawing.Size(185, 157);
            this.pictureBox_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_logo.TabIndex = 7;
            this.pictureBox_logo.TabStop = false;
            this.pictureBox_logo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.form_authorization_MouseDown);
            // 
            // Authorization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 450);
            this.Controls.Add(this.form_authorization);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Authorization";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Authorization";
            this.form_authorization.ResumeLayout(false);
            this.form_authorization.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel form_authorization;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button login_out;
        private System.Windows.Forms.Label login_label;
        private System.Windows.Forms.Label password_label;
        private System.Windows.Forms.TextBox login_textbox;
        private System.Windows.Forms.Panel visible_password;
        private System.Windows.Forms.Button login_up;
        private System.Windows.Forms.TextBox password_textbox;
        private System.Windows.Forms.PictureBox pictureBox_logo;
    }
}