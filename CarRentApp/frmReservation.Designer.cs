namespace TvpProj
{
    partial class frmReservation
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbMake = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbModel = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbCubage = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbBody = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbDoors = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbFuel = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbDrivetrain = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbTransmission = new System.Windows.Forms.ComboBox();
            this.btnShowTerms = new System.Windows.Forms.Button();
            this.lbTerms = new System.Windows.Forms.ListBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpPick = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.dtpReturn = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.btnReserve = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Choose a make:";
            // 
            // cmbMake
            // 
            this.cmbMake.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMake.FormattingEnabled = true;
            this.cmbMake.Location = new System.Drawing.Point(36, 50);
            this.cmbMake.Name = "cmbMake";
            this.cmbMake.Size = new System.Drawing.Size(147, 21);
            this.cmbMake.TabIndex = 0;
            this.cmbMake.SelectedValueChanged += new System.EventHandler(this.cmbMake_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(33, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Choose a model";
            // 
            // cmbModel
            // 
            this.cmbModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbModel.FormattingEnabled = true;
            this.cmbModel.Location = new System.Drawing.Point(36, 96);
            this.cmbModel.Name = "cmbModel";
            this.cmbModel.Size = new System.Drawing.Size(147, 21);
            this.cmbModel.TabIndex = 1;
            this.cmbModel.SelectedValueChanged += new System.EventHandler(this.cmbModel_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(33, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 18);
            this.label3.TabIndex = 0;
            this.label3.Text = "Choose a year:";
            // 
            // cmbYear
            // 
            this.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(36, 145);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(147, 21);
            this.cmbYear.TabIndex = 2;
            this.cmbYear.SelectedValueChanged += new System.EventHandler(this.cmbYear_SelectedValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(203, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 18);
            this.label4.TabIndex = 0;
            this.label4.Text = "Choose a cubage:";
            // 
            // cmbCubage
            // 
            this.cmbCubage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCubage.FormattingEnabled = true;
            this.cmbCubage.Location = new System.Drawing.Point(206, 50);
            this.cmbCubage.Name = "cmbCubage";
            this.cmbCubage.Size = new System.Drawing.Size(152, 21);
            this.cmbCubage.TabIndex = 3;
            this.cmbCubage.SelectedValueChanged += new System.EventHandler(this.cmbCubage_SelectedValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(203, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 18);
            this.label5.TabIndex = 0;
            this.label5.Text = "Choose a body:";
            // 
            // cmbBody
            // 
            this.cmbBody.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBody.FormattingEnabled = true;
            this.cmbBody.Location = new System.Drawing.Point(206, 96);
            this.cmbBody.Name = "cmbBody";
            this.cmbBody.Size = new System.Drawing.Size(152, 21);
            this.cmbBody.TabIndex = 4;
            this.cmbBody.SelectedValueChanged += new System.EventHandler(this.cmbBody_SelectedValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(203, 124);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(141, 18);
            this.label6.TabIndex = 0;
            this.label6.Text = "Choose door count:";
            // 
            // cmbDoors
            // 
            this.cmbDoors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDoors.FormattingEnabled = true;
            this.cmbDoors.Location = new System.Drawing.Point(206, 145);
            this.cmbDoors.Name = "cmbDoors";
            this.cmbDoors.Size = new System.Drawing.Size(152, 21);
            this.cmbDoors.TabIndex = 5;
            this.cmbDoors.SelectedValueChanged += new System.EventHandler(this.cmbDoors_SelectedValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(376, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 18);
            this.label7.TabIndex = 0;
            this.label7.Text = "Choose a fuel:";
            // 
            // cmbFuel
            // 
            this.cmbFuel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFuel.FormattingEnabled = true;
            this.cmbFuel.Location = new System.Drawing.Point(379, 50);
            this.cmbFuel.Name = "cmbFuel";
            this.cmbFuel.Size = new System.Drawing.Size(157, 21);
            this.cmbFuel.TabIndex = 6;
            this.cmbFuel.SelectedValueChanged += new System.EventHandler(this.cmbFuel_SelectedValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(376, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(140, 18);
            this.label8.TabIndex = 0;
            this.label8.Text = "Choose a drivetrain:";
            // 
            // cmbDrivetrain
            // 
            this.cmbDrivetrain.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDrivetrain.FormattingEnabled = true;
            this.cmbDrivetrain.Location = new System.Drawing.Point(379, 96);
            this.cmbDrivetrain.Name = "cmbDrivetrain";
            this.cmbDrivetrain.Size = new System.Drawing.Size(157, 21);
            this.cmbDrivetrain.TabIndex = 7;
            this.cmbDrivetrain.SelectedValueChanged += new System.EventHandler(this.cmbDrivetrain_SelectedValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(376, 124);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(166, 18);
            this.label9.TabIndex = 0;
            this.label9.Text = "Choose a transmission:";
            // 
            // cmbTransmission
            // 
            this.cmbTransmission.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTransmission.FormattingEnabled = true;
            this.cmbTransmission.Location = new System.Drawing.Point(379, 145);
            this.cmbTransmission.Name = "cmbTransmission";
            this.cmbTransmission.Size = new System.Drawing.Size(157, 21);
            this.cmbTransmission.TabIndex = 8;
            this.cmbTransmission.SelectedValueChanged += new System.EventHandler(this.cmbTransmission_SelectedValueChanged);
            // 
            // btnShowTerms
            // 
            this.btnShowTerms.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowTerms.Location = new System.Drawing.Point(36, 174);
            this.btnShowTerms.Name = "btnShowTerms";
            this.btnShowTerms.Size = new System.Drawing.Size(500, 46);
            this.btnShowTerms.TabIndex = 2;
            this.btnShowTerms.Text = "Show available terms of a chosen car:";
            this.btnShowTerms.UseVisualStyleBackColor = true;
            this.btnShowTerms.Click += new System.EventHandler(this.btnShowTerms_Click);
            // 
            // lbTerms
            // 
            this.lbTerms.FormattingEnabled = true;
            this.lbTerms.Location = new System.Drawing.Point(36, 226);
            this.lbTerms.Name = "lbTerms";
            this.lbTerms.Size = new System.Drawing.Size(500, 134);
            this.lbTerms.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(33, 363);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(128, 18);
            this.label10.TabIndex = 0;
            this.label10.Text = "Choose pick date:";
            // 
            // dtpPick
            // 
            this.dtpPick.Location = new System.Drawing.Point(36, 383);
            this.dtpPick.Name = "dtpPick";
            this.dtpPick.Size = new System.Drawing.Size(200, 20);
            this.dtpPick.TabIndex = 4;
            this.dtpPick.ValueChanged += new System.EventHandler(this.dtp_ValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(33, 409);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(139, 18);
            this.label11.TabIndex = 0;
            this.label11.Text = "Choose return date:";
            // 
            // dtpReturn
            // 
            this.dtpReturn.Location = new System.Drawing.Point(36, 429);
            this.dtpReturn.Name = "dtpReturn";
            this.dtpReturn.Size = new System.Drawing.Size(200, 20);
            this.dtpReturn.TabIndex = 4;
            this.dtpReturn.ValueChanged += new System.EventHandler(this.dtp_ValueChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(378, 394);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(158, 18);
            this.label12.TabIndex = 5;
            this.label12.Text = "Total reservation price:";
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(379, 417);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(157, 20);
            this.txtTotal.TabIndex = 6;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnReserve
            // 
            this.btnReserve.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReserve.Location = new System.Drawing.Point(36, 456);
            this.btnReserve.Name = "btnReserve";
            this.btnReserve.Size = new System.Drawing.Size(500, 46);
            this.btnReserve.TabIndex = 2;
            this.btnReserve.Text = "Reserve";
            this.btnReserve.UseVisualStyleBackColor = true;
            this.btnReserve.Click += new System.EventHandler(this.btnReserve_Click);
            // 
            // frmReservation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 538);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.dtpReturn);
            this.Controls.Add(this.dtpPick);
            this.Controls.Add(this.lbTerms);
            this.Controls.Add(this.btnReserve);
            this.Controls.Add(this.btnShowTerms);
            this.Controls.Add(this.cmbTransmission);
            this.Controls.Add(this.cmbDoors);
            this.Controls.Add(this.cmbYear);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbDrivetrain);
            this.Controls.Add(this.cmbBody);
            this.Controls.Add(this.cmbModel);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbFuel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbCubage);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbMake);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReservation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reservation";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmReservation_FormClosing);
            this.Shown += new System.EventHandler(this.frmReservation_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbMake;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbModel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbCubage;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbBody;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbDoors;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbFuel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbDrivetrain;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbTransmission;
        private System.Windows.Forms.Button btnShowTerms;
        private System.Windows.Forms.ListBox lbTerms;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpPick;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dtpReturn;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Button btnReserve;
    }
}