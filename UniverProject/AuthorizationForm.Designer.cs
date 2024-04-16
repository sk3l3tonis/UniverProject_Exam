namespace UniverProject
{
    partial class AuthorizationForm
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
            textBoxLogin = new TextBox();
            textBoxPassword = new TextBox();
            buttonRegistration = new Button();
            buttonLogin = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(105, 119);
            label1.Name = "label1";
            label1.Size = new Size(55, 20);
            label1.TabIndex = 0;
            label1.Text = "Логин:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(95, 171);
            label2.Name = "label2";
            label2.Size = new Size(65, 20);
            label2.TabIndex = 1;
            label2.Text = "Пароль:";
            // 
            // textBoxLogin
            // 
            textBoxLogin.Location = new Point(166, 119);
            textBoxLogin.Name = "textBoxLogin";
            textBoxLogin.Size = new Size(175, 27);
            textBoxLogin.TabIndex = 2;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(166, 168);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(175, 27);
            textBoxPassword.TabIndex = 3;
            // 
            // buttonRegistration
            // 
            buttonRegistration.Location = new Point(95, 215);
            buttonRegistration.Name = "buttonRegistration";
            buttonRegistration.Size = new Size(120, 56);
            buttonRegistration.TabIndex = 4;
            buttonRegistration.Text = "Пройти регистрацию";
            buttonRegistration.UseVisualStyleBackColor = true;
            // 
            // buttonLogin
            // 
            buttonLogin.Location = new Point(240, 227);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new Size(107, 33);
            buttonLogin.TabIndex = 5;
            buttonLogin.Text = "Войти";
            buttonLogin.UseVisualStyleBackColor = true;
            // 
            // AuthorizationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(443, 413);
            Controls.Add(buttonLogin);
            Controls.Add(buttonRegistration);
            Controls.Add(textBoxPassword);
            Controls.Add(textBoxLogin);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "AuthorizationForm";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textBoxLogin;
        private TextBox textBoxPassword;
        private Button buttonRegistration;
        private Button buttonLogin;
    }
}
