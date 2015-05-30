using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SystemOfTrainingAndTesting
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private IContainer components = null;

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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelLogin = new Label();
            this.labelPassword = new Label();
            this.textBoxLogin = new TextBox();
            this.textBoxPassword = new TextBox();
            this.buttonAuthorization = new Button();
            this.SuspendLayout();
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.Location = new Point(13, 52);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new Size(103, 13);
            this.labelLogin.TabIndex = 0;
            this.labelLogin.Text = "Имя пользователя";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new Point(13, 78);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new Size(45, 13);
            this.labelPassword.TabIndex = 1;
            this.labelPassword.Text = "Пароль";
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.Location = new Point(122, 49);
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new Size(206, 20);
            this.textBoxLogin.TabIndex = 2;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new Point(122, 75);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new Size(206, 20);
            this.textBoxPassword.TabIndex = 3;
            this.textBoxPassword.UseSystemPasswordChar = true;
            // 
            // buttonAuthorization
            // 
            this.buttonAuthorization.Location = new Point(122, 112);
            this.buttonAuthorization.Name = "buttonAuthorization";
            this.buttonAuthorization.Size = new Size(75, 23);
            this.buttonAuthorization.TabIndex = 4;
            this.buttonAuthorization.Text = "Вход";
            this.buttonAuthorization.UseVisualStyleBackColor = true;
            this.buttonAuthorization.Click += new EventHandler(this.buttonAuthorization_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new Size(340, 172);
            this.Controls.Add(this.buttonAuthorization);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxLogin);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelLogin);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Система обучения и тестирования";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal Label labelLogin;
        private Label labelPassword;
        private TextBox textBoxLogin;
        private TextBox textBoxPassword;
        private Button buttonAuthorization;


    }
}

