namespace ASCOM.ShellyRelayController.Switch
{
    partial class SetupDialogForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetupDialogForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.picASCOM = new System.Windows.Forms.PictureBox();
            this.chkTrace = new System.Windows.Forms.CheckBox();
            this.SwitchMapDataGrid = new System.Windows.Forms.DataGridView();
            this.SwitchColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IPAddressColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MACAddressColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RelayColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RelayName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddDeviceButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.IPTextBox = new System.Windows.Forms.TextBox();
            this.ClearButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picASCOM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SwitchMapDataGrid)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdOK.Location = new System.Drawing.Point(270, 382);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(59, 24);
            this.cmdOK.TabIndex = 0;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.CmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(335, 381);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(59, 25);
            this.cmdCancel.TabIndex = 1;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.CmdCancel_Click);
            // 
            // picASCOM
            // 
            this.picASCOM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picASCOM.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picASCOM.Image = ((System.Drawing.Image)(resources.GetObject("picASCOM.Image")));
            this.picASCOM.Location = new System.Drawing.Point(12, 8);
            this.picASCOM.Name = "picASCOM";
            this.picASCOM.Size = new System.Drawing.Size(48, 56);
            this.picASCOM.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picASCOM.TabIndex = 3;
            this.picASCOM.TabStop = false;
            this.picASCOM.Click += new System.EventHandler(this.BrowseToAscom);
            this.picASCOM.DoubleClick += new System.EventHandler(this.BrowseToAscom);
            // 
            // chkTrace
            // 
            this.chkTrace.AutoSize = true;
            this.chkTrace.Location = new System.Drawing.Point(12, 374);
            this.chkTrace.Name = "chkTrace";
            this.chkTrace.Size = new System.Drawing.Size(69, 17);
            this.chkTrace.TabIndex = 6;
            this.chkTrace.Text = "Trace on";
            this.chkTrace.UseVisualStyleBackColor = true;
            // 
            // SwitchMapDataGrid
            // 
            this.SwitchMapDataGrid.AllowUserToAddRows = false;
            this.SwitchMapDataGrid.AllowUserToDeleteRows = false;
            this.SwitchMapDataGrid.AllowUserToResizeColumns = false;
            this.SwitchMapDataGrid.AllowUserToResizeRows = false;
            this.SwitchMapDataGrid.BackgroundColor = System.Drawing.Color.PaleTurquoise;
            this.SwitchMapDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SwitchMapDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SwitchColumn,
            this.IPAddressColumn,
            this.MACAddressColumn,
            this.RelayColumn,
            this.RelayName});
            this.SwitchMapDataGrid.Location = new System.Drawing.Point(12, 70);
            this.SwitchMapDataGrid.Name = "SwitchMapDataGrid";
            this.SwitchMapDataGrid.RowHeadersVisible = false;
            this.SwitchMapDataGrid.RowHeadersWidth = 82;
            this.SwitchMapDataGrid.Size = new System.Drawing.Size(382, 298);
            this.SwitchMapDataGrid.TabIndex = 10;
            // 
            // SwitchColumn
            // 
            this.SwitchColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.SwitchColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.SwitchColumn.HeaderText = "Switch";
            this.SwitchColumn.MinimumWidth = 10;
            this.SwitchColumn.Name = "SwitchColumn";
            this.SwitchColumn.Width = 64;
            // 
            // IPAddressColumn
            // 
            this.IPAddressColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.IPAddressColumn.HeaderText = "IP Address";
            this.IPAddressColumn.MinimumWidth = 10;
            this.IPAddressColumn.Name = "IPAddressColumn";
            this.IPAddressColumn.Width = 83;
            // 
            // MACAddressColumn
            // 
            this.MACAddressColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.MACAddressColumn.HeaderText = "MAC Address";
            this.MACAddressColumn.MinimumWidth = 10;
            this.MACAddressColumn.Name = "MACAddressColumn";
            this.MACAddressColumn.Width = 96;
            // 
            // RelayColumn
            // 
            this.RelayColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.RelayColumn.HeaderText = "Relay";
            this.RelayColumn.MinimumWidth = 10;
            this.RelayColumn.Name = "RelayColumn";
            this.RelayColumn.Width = 59;
            // 
            // RelayName
            // 
            this.RelayName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.RelayName.HeaderText = "Relay Name";
            this.RelayName.MinimumWidth = 10;
            this.RelayName.Name = "RelayName";
            this.RelayName.Width = 90;
            // 
            // AddDeviceButton
            // 
            this.AddDeviceButton.Location = new System.Drawing.Point(274, 13);
            this.AddDeviceButton.Name = "AddDeviceButton";
            this.AddDeviceButton.Size = new System.Drawing.Size(46, 34);
            this.AddDeviceButton.TabIndex = 11;
            this.AddDeviceButton.Text = "Add";
            this.AddDeviceButton.UseVisualStyleBackColor = true;
            this.AddDeviceButton.Click += new System.EventHandler(this.AddDeviceButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "IP Address";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.DarkTurquoise;
            this.groupBox1.Controls.Add(this.IPTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.AddDeviceButton);
            this.groupBox1.Location = new System.Drawing.Point(67, 8);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(327, 56);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add Device";
            // 
            // IPTextBox
            // 
            this.IPTextBox.Location = new System.Drawing.Point(110, 21);
            this.IPTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.IPTextBox.Name = "IPTextBox";
            this.IPTextBox.Size = new System.Drawing.Size(159, 20);
            this.IPTextBox.TabIndex = 13;
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(167, 382);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(65, 24);
            this.ClearButton.TabIndex = 14;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // SetupDialogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.ClientSize = new System.Drawing.Size(406, 418);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.SwitchMapDataGrid);
            this.Controls.Add(this.chkTrace);
            this.Controls.Add(this.picASCOM);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetupDialogForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ShellyPowerRelay Setup";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.SetupDialogForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picASCOM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SwitchMapDataGrid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.PictureBox picASCOM;
        private System.Windows.Forms.CheckBox chkTrace;
        private System.Windows.Forms.DataGridView SwitchMapDataGrid;
        private System.Windows.Forms.Button AddDeviceButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.TextBox IPTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn SwitchColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn IPAddressColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn MACAddressColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn RelayColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn RelayName;
    }
}
