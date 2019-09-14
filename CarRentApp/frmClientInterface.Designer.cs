namespace TvpProj
{
    partial class frmClientInterface
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
            this.lblClientName = new System.Windows.Forms.Label();
            this.btnNewRes = new System.Windows.Forms.Button();
            this.btnCancelRes = new System.Windows.Forms.Button();
            this.dgvReservations = new System.Windows.Forms.DataGridView();
            this.lblLogOut = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblNoReservations = new System.Windows.Forms.Label();
            this.colResID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClientID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCarID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CarInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDateFrom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDateTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblClientName
            // 
            this.lblClientName.AutoSize = true;
            this.lblClientName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClientName.Location = new System.Drawing.Point(211, 61);
            this.lblClientName.Name = "lblClientName";
            this.lblClientName.Size = new System.Drawing.Size(144, 24);
            this.lblClientName.TabIndex = 1;
            this.lblClientName.Text = "\'s reservations";
            this.lblClientName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnNewRes
            // 
            this.btnNewRes.Location = new System.Drawing.Point(30, 32);
            this.btnNewRes.Name = "btnNewRes";
            this.btnNewRes.Size = new System.Drawing.Size(123, 40);
            this.btnNewRes.TabIndex = 2;
            this.btnNewRes.Text = "New reservation";
            this.btnNewRes.UseVisualStyleBackColor = true;
            this.btnNewRes.Click += new System.EventHandler(this.btnNewRes_Click);
            // 
            // btnCancelRes
            // 
            this.btnCancelRes.Location = new System.Drawing.Point(528, 552);
            this.btnCancelRes.Name = "btnCancelRes";
            this.btnCancelRes.Size = new System.Drawing.Size(102, 36);
            this.btnCancelRes.TabIndex = 3;
            this.btnCancelRes.Text = "Cancel reservation";
            this.btnCancelRes.UseVisualStyleBackColor = true;
            this.btnCancelRes.Click += new System.EventHandler(this.btnCancelRes_Click);
            // 
            // dgvReservations
            // 
            this.dgvReservations.AllowUserToAddRows = false;
            this.dgvReservations.AllowUserToDeleteRows = false;
            this.dgvReservations.AllowUserToResizeColumns = false;
            this.dgvReservations.AllowUserToResizeRows = false;
            this.dgvReservations.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvReservations.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvReservations.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvReservations.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvReservations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReservations.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colResID,
            this.colClientID,
            this.colCarID,
            this.CarInfo,
            this.colDateFrom,
            this.colDateTo,
            this.colPrice});
            this.dgvReservations.Location = new System.Drawing.Point(30, 105);
            this.dgvReservations.MultiSelect = false;
            this.dgvReservations.Name = "dgvReservations";
            this.dgvReservations.ReadOnly = true;
            this.dgvReservations.RowHeadersVisible = false;
            this.dgvReservations.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvReservations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReservations.Size = new System.Drawing.Size(600, 411);
            this.dgvReservations.TabIndex = 14;
            this.dgvReservations.SelectionChanged += new System.EventHandler(this.dgvReservations_SelectionChanged);
            // 
            // lblLogOut
            // 
            this.lblLogOut.AutoSize = true;
            this.lblLogOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblLogOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogOut.Location = new System.Drawing.Point(587, 32);
            this.lblLogOut.Name = "lblLogOut";
            this.lblLogOut.Size = new System.Drawing.Size(43, 13);
            this.lblLogOut.TabIndex = 15;
            this.lblLogOut.Text = "Log out";
            this.lblLogOut.Click += new System.EventHandler(this.lblLogOut_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(30, 570);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(41, 35);
            this.dataGridView1.TabIndex = 16;
            // 
            // lblNoReservations
            // 
            this.lblNoReservations.AutoSize = true;
            this.lblNoReservations.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoReservations.Location = new System.Drawing.Point(185, 252);
            this.lblNoReservations.Name = "lblNoReservations";
            this.lblNoReservations.Size = new System.Drawing.Size(217, 25);
            this.lblNoReservations.TabIndex = 1;
            this.lblNoReservations.Text = "No reservations yet";
            this.lblNoReservations.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblNoReservations.Visible = false;
            // 
            // colResID
            // 
            this.colResID.HeaderText = "ReservationID";
            this.colResID.Name = "colResID";
            this.colResID.ReadOnly = true;
            this.colResID.Visible = false;
            this.colResID.Width = 81;
            // 
            // colClientID
            // 
            this.colClientID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colClientID.HeaderText = "ClientID";
            this.colClientID.Name = "colClientID";
            this.colClientID.ReadOnly = true;
            this.colClientID.Visible = false;
            this.colClientID.Width = 50;
            // 
            // colCarID
            // 
            this.colCarID.HeaderText = "CarID";
            this.colCarID.Name = "colCarID";
            this.colCarID.ReadOnly = true;
            this.colCarID.Visible = false;
            this.colCarID.Width = 40;
            // 
            // CarInfo
            // 
            this.CarInfo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CarInfo.HeaderText = "Car information";
            this.CarInfo.Name = "CarInfo";
            this.CarInfo.ReadOnly = true;
            // 
            // colDateFrom
            // 
            this.colDateFrom.HeaderText = "Pick date";
            this.colDateFrom.Name = "colDateFrom";
            this.colDateFrom.ReadOnly = true;
            this.colDateFrom.Width = 77;
            // 
            // colDateTo
            // 
            this.colDateTo.HeaderText = "Return date";
            this.colDateTo.Name = "colDateTo";
            this.colDateTo.ReadOnly = true;
            this.colDateTo.Width = 88;
            // 
            // colPrice
            // 
            this.colPrice.HeaderText = "Price";
            this.colPrice.Name = "colPrice";
            this.colPrice.ReadOnly = true;
            this.colPrice.Width = 56;
            // 
            // frmClientInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 607);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblLogOut);
            this.Controls.Add(this.dgvReservations);
            this.Controls.Add(this.btnCancelRes);
            this.Controls.Add(this.btnNewRes);
            this.Controls.Add(this.lblNoReservations);
            this.Controls.Add(this.lblClientName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmClientInterface";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reservations";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClientReservations_FormClosing);
            this.Shown += new System.EventHandler(this.ClientReservations_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblClientName;
        private System.Windows.Forms.Button btnNewRes;
        private System.Windows.Forms.Button btnCancelRes;
        private System.Windows.Forms.DataGridView dgvReservations;
        private System.Windows.Forms.Label lblLogOut;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblNoReservations;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClientID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCarID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CarInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDateFrom;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDateTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
    }
}