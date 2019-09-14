namespace TvpProj
{
    partial class frmLogIn
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogIn));
            this.pnlLogIn = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRegistration = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLogIn = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.MaskedTextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLogInForm = new System.Windows.Forms.Button();
            this.pnlRegistration = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.dpBirthDate = new System.Windows.Forms.DateTimePicker();
            this.txtPhone = new System.Windows.Forms.MaskedTextBox();
            this.txtPIN = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtRegUsername = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRegPassword = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSurname = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnAdminFill = new System.Windows.Forms.Button();
            this.btnClientFill = new System.Windows.Forms.Button();
            this.pnlLogIn.SuspendLayout();
            this.pnlRegistration.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlLogIn
            // 
            this.pnlLogIn.Controls.Add(this.label4);
            this.pnlLogIn.Controls.Add(this.label3);
            this.pnlLogIn.Controls.Add(this.btnRegistration);
            this.pnlLogIn.Controls.Add(this.label1);
            this.pnlLogIn.Controls.Add(this.btnLogIn);
            this.pnlLogIn.Controls.Add(this.txtPassword);
            this.pnlLogIn.Controls.Add(this.txtUsername);
            this.pnlLogIn.Location = new System.Drawing.Point(119, 97);
            this.pnlLogIn.Name = "pnlLogIn";
            this.pnlLogIn.Size = new System.Drawing.Size(426, 144);
            this.pnlLogIn.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(135, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Password:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(135, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Username:";
            // 
            // btnRegistration
            // 
            this.btnRegistration.Location = new System.Drawing.Point(14, 53);
            this.btnRegistration.Name = "btnRegistration";
            this.btnRegistration.Size = new System.Drawing.Size(75, 23);
            this.btnRegistration.TabIndex = 3;
            this.btnRegistration.Text = "Sign up";
            this.btnRegistration.UseVisualStyleBackColor = true;
            this.btnRegistration.Click += new System.EventHandler(this.btnRegistration_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "New customer?";
            // 
            // btnLogIn
            // 
            this.btnLogIn.Location = new System.Drawing.Point(193, 101);
            this.btnLogIn.Name = "btnLogIn";
            this.btnLogIn.Size = new System.Drawing.Size(214, 34);
            this.btnLogIn.TabIndex = 2;
            this.btnLogIn.Text = "Log in";
            this.btnLogIn.UseVisualStyleBackColor = true;
            this.btnLogIn.Click += new System.EventHandler(this.btnLogIn_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(193, 60);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(214, 20);
            this.txtPassword.TabIndex = 1;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(193, 23);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(214, 20);
            this.txtUsername.TabIndex = 0;
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(194, 208);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(214, 34);
            this.btnRegister.TabIndex = 8;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Already registered?";
            // 
            // btnLogInForm
            // 
            this.btnLogInForm.Location = new System.Drawing.Point(17, 54);
            this.btnLogInForm.Name = "btnLogInForm";
            this.btnLogInForm.Size = new System.Drawing.Size(75, 23);
            this.btnLogInForm.TabIndex = 9;
            this.btnLogInForm.Text = "Log in";
            this.btnLogInForm.UseVisualStyleBackColor = true;
            this.btnLogInForm.Click += new System.EventHandler(this.btnLogInForm_Click);
            this.btnLogInForm.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnLogInForm_MouseDown);
            // 
            // pnlRegistration
            // 
            this.pnlRegistration.Controls.Add(this.label11);
            this.pnlRegistration.Controls.Add(this.dpBirthDate);
            this.pnlRegistration.Controls.Add(this.txtPhone);
            this.pnlRegistration.Controls.Add(this.txtPIN);
            this.pnlRegistration.Controls.Add(this.label5);
            this.pnlRegistration.Controls.Add(this.btnLogInForm);
            this.pnlRegistration.Controls.Add(this.label10);
            this.pnlRegistration.Controls.Add(this.label8);
            this.pnlRegistration.Controls.Add(this.label9);
            this.pnlRegistration.Controls.Add(this.txtRegUsername);
            this.pnlRegistration.Controls.Add(this.label7);
            this.pnlRegistration.Controls.Add(this.txtRegPassword);
            this.pnlRegistration.Controls.Add(this.label6);
            this.pnlRegistration.Controls.Add(this.label2);
            this.pnlRegistration.Controls.Add(this.btnRegister);
            this.pnlRegistration.Controls.Add(this.txtSurname);
            this.pnlRegistration.Controls.Add(this.txtName);
            this.pnlRegistration.Location = new System.Drawing.Point(119, 272);
            this.pnlRegistration.Name = "pnlRegistration";
            this.pnlRegistration.Size = new System.Drawing.Size(426, 319);
            this.pnlRegistration.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(135, 41);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "Password:";
            // 
            // dpBirthDate
            // 
            this.dpBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpBirthDate.Location = new System.Drawing.Point(194, 142);
            this.dpBirthDate.Name = "dpBirthDate";
            this.dpBirthDate.Size = new System.Drawing.Size(214, 20);
            this.dpBirthDate.TabIndex = 6;
            this.dpBirthDate.Validating += new System.ComponentModel.CancelEventHandler(this.dpBirthDate_Validating);
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(194, 167);
            this.txtPhone.Mask = "0000000000";
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.PromptChar = ' ';
            this.txtPhone.Size = new System.Drawing.Size(214, 20);
            this.txtPhone.SkipLiterals = false;
            this.txtPhone.TabIndex = 7;
            this.txtPhone.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtPhone.ValidatingType = typeof(int);
            this.txtPhone.Click += new System.EventHandler(this.txt_EnterClick);
            this.txtPhone.Enter += new System.EventHandler(this.txt_EnterClick);
            this.txtPhone.Validating += new System.ComponentModel.CancelEventHandler(this.txtPhone_Validating);
            // 
            // txtPIN
            // 
            this.txtPIN.Location = new System.Drawing.Point(194, 115);
            this.txtPIN.Mask = "0000000000000";
            this.txtPIN.Name = "txtPIN";
            this.txtPIN.PromptChar = ' ';
            this.txtPIN.Size = new System.Drawing.Size(214, 20);
            this.txtPIN.SkipLiterals = false;
            this.txtPIN.TabIndex = 5;
            this.txtPIN.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtPIN.ValidatingType = typeof(int);
            this.txtPIN.Click += new System.EventHandler(this.txt_EnterClick);
            this.txtPIN.Enter += new System.EventHandler(this.txt_EnterClick);
            this.txtPIN.Validating += new System.ComponentModel.CancelEventHandler(this.txtPIN_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(135, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Username:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(135, 171);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "Phone:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(136, 119);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "PIN:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(135, 146);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Birth date:";
            // 
            // txtRegUsername
            // 
            this.txtRegUsername.Location = new System.Drawing.Point(194, 14);
            this.txtRegUsername.Name = "txtRegUsername";
            this.txtRegUsername.Size = new System.Drawing.Size(214, 20);
            this.txtRegUsername.TabIndex = 0;
            this.txtRegUsername.Validating += new System.ComponentModel.CancelEventHandler(this.txtRegUsername_Validating);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(135, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Surname:";
            // 
            // txtRegPassword
            // 
            this.txtRegPassword.Location = new System.Drawing.Point(194, 37);
            this.txtRegPassword.Name = "txtRegPassword";
            this.txtRegPassword.PasswordChar = '*';
            this.txtRegPassword.Size = new System.Drawing.Size(214, 20);
            this.txtRegPassword.TabIndex = 1;
            this.txtRegPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtRegPassword_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(136, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Name:";
            // 
            // txtSurname
            // 
            this.txtSurname.Location = new System.Drawing.Point(194, 89);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(214, 20);
            this.txtSurname.TabIndex = 4;
            this.txtSurname.Validating += new System.ComponentModel.CancelEventHandler(this.txtSurname_Validating);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(194, 63);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(214, 20);
            this.txtName.TabIndex = 3;
            this.txtName.Validating += new System.ComponentModel.CancelEventHandler(this.txtName_Validating);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label12.Location = new System.Drawing.Point(71, 244);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(517, 13);
            this.label12.TabIndex = 1;
            this.label12.Text = "_________________________________________________________________________________" +
    "____";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(244, 20);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(180, 44);
            this.label13.TabIndex = 2;
            this.label13.Text = "Welcome";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 609);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // errorProvider2
            // 
            this.errorProvider2.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider2.ContainerControl = this;
            this.errorProvider2.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider2.Icon")));
            // 
            // btnAdminFill
            // 
            this.btnAdminFill.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnAdminFill.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdminFill.Location = new System.Drawing.Point(461, 20);
            this.btnAdminFill.Name = "btnAdminFill";
            this.btnAdminFill.Size = new System.Drawing.Size(84, 36);
            this.btnAdminFill.TabIndex = 4;
            this.btnAdminFill.Text = "Admin";
            this.btnAdminFill.UseVisualStyleBackColor = false;
            this.btnAdminFill.Visible = false;
            this.btnAdminFill.Click += new System.EventHandler(this.btnAdminFill_Click);
            // 
            // btnClientFill
            // 
            this.btnClientFill.BackColor = System.Drawing.Color.LightGreen;
            this.btnClientFill.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClientFill.Location = new System.Drawing.Point(461, 62);
            this.btnClientFill.Name = "btnClientFill";
            this.btnClientFill.Size = new System.Drawing.Size(84, 36);
            this.btnClientFill.TabIndex = 4;
            this.btnClientFill.Text = "Client";
            this.btnClientFill.UseVisualStyleBackColor = false;
            this.btnClientFill.Visible = false;
            this.btnClientFill.Click += new System.EventHandler(this.btnClientFill_Click);
            // 
            // frmLogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 609);
            this.Controls.Add(this.btnClientFill);
            this.Controls.Add(this.btnAdminFill);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.pnlRegistration);
            this.Controls.Add(this.pnlLogIn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Log in";
            this.Load += new System.EventHandler(this.LogIn_Load);
            this.pnlLogIn.ResumeLayout(false);
            this.pnlLogIn.PerformLayout();
            this.pnlRegistration.ResumeLayout(false);
            this.pnlRegistration.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlLogIn;
        private System.Windows.Forms.MaskedTextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Button btnLogIn;
        private System.Windows.Forms.Button btnRegistration;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLogInForm;
        private System.Windows.Forms.Panel pnlRegistration;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtSurname;
        private System.Windows.Forms.MaskedTextBox txtPIN;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dpBirthDate;
        private System.Windows.Forms.MaskedTextBox txtPhone;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox txtRegPassword;
        private System.Windows.Forms.TextBox txtRegUsername;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ErrorProvider errorProvider2;
        private System.Windows.Forms.Button btnClientFill;
        private System.Windows.Forms.Button btnAdminFill;
    }
}