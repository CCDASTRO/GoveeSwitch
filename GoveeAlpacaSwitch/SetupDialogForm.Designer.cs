namespace GoveeSwitch
{
    partial class SetupDialogForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblMAC;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.Label lblApiKey;
        private System.Windows.Forms.TextBox txtMAC_1;
        private System.Windows.Forms.TextBox txtModel_1;
        private System.Windows.Forms.TextBox txtApiKey_1;
        private System.Windows.Forms.Button btnOK_1;
        private System.Windows.Forms.Button btnCancel_1;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblMAC = new System.Windows.Forms.Label();
            this.lblModel = new System.Windows.Forms.Label();
            this.lblApiKey = new System.Windows.Forms.Label();
            this.txtMAC_1 = new System.Windows.Forms.TextBox();
            this.txtModel_1 = new System.Windows.Forms.TextBox();
            this.txtApiKey_1 = new System.Windows.Forms.TextBox();
            this.btnOK_1 = new System.Windows.Forms.Button();
            this.btnCancel_1 = new System.Windows.Forms.Button();
            this.btnAdd_1 = new System.Windows.Forms.Button();
            this.btnEdit_1 = new System.Windows.Forms.Button();
            this.btnDelete_1 = new System.Windows.Forms.Button();
            this.lstDevices_1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDeviceName_1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblMAC
            // 
            this.lblMAC.AutoSize = true;
            this.lblMAC.Location = new System.Drawing.Point(12, 15);
            this.lblMAC.Name = "lblMAC";
            this.lblMAC.Size = new System.Drawing.Size(70, 13);
            this.lblMAC.TabIndex = 0;
            this.lblMAC.Text = "Device MAC:";
            // 
            // lblModel
            // 
            this.lblModel.AutoSize = true;
            this.lblModel.Location = new System.Drawing.Point(12, 45);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(76, 13);
            this.lblModel.TabIndex = 2;
            this.lblModel.Text = "Device Model:";
            // 
            // lblApiKey
            // 
            this.lblApiKey.AutoSize = true;
            this.lblApiKey.Location = new System.Drawing.Point(12, 75);
            this.lblApiKey.Name = "lblApiKey";
            this.lblApiKey.Size = new System.Drawing.Size(48, 13);
            this.lblApiKey.TabIndex = 4;
            this.lblApiKey.Text = "API Key:";
            // 
            // txtMAC_1
            // 
            this.txtMAC_1.Location = new System.Drawing.Point(90, 12);
            this.txtMAC_1.Name = "txtMAC_1";
            this.txtMAC_1.Size = new System.Drawing.Size(210, 20);
            this.txtMAC_1.TabIndex = 1;
            // 
            // txtModel_1
            // 
            this.txtModel_1.Location = new System.Drawing.Point(90, 42);
            this.txtModel_1.Name = "txtModel_1";
            this.txtModel_1.Size = new System.Drawing.Size(210, 20);
            this.txtModel_1.TabIndex = 3;
            // 
            // txtApiKey_1
            // 
            this.txtApiKey_1.Location = new System.Drawing.Point(90, 72);
            this.txtApiKey_1.Name = "txtApiKey_1";
            this.txtApiKey_1.Size = new System.Drawing.Size(210, 20);
            this.txtApiKey_1.TabIndex = 5;
            // 
            // btnOK_1
            // 
            this.btnOK_1.Location = new System.Drawing.Point(87, 282);
            this.btnOK_1.Name = "btnOK_1";
            this.btnOK_1.Size = new System.Drawing.Size(75, 23);
            this.btnOK_1.TabIndex = 6;
            this.btnOK_1.Text = "OK";
            this.btnOK_1.UseVisualStyleBackColor = true;
            this.btnOK_1.Click += new System.EventHandler(this.btnOK_Click_1);
            // 
            // btnCancel_1
            // 
            this.btnCancel_1.Location = new System.Drawing.Point(168, 282);
            this.btnCancel_1.Name = "btnCancel_1";
            this.btnCancel_1.Size = new System.Drawing.Size(75, 23);
            this.btnCancel_1.TabIndex = 7;
            this.btnCancel_1.Text = "Cancel";
            this.btnCancel_1.UseVisualStyleBackColor = true;
            this.btnCancel_1.Click += new System.EventHandler(this.btnCancel_Click_1);
            // 
            // btnAdd_1
            // 
            this.btnAdd_1.Location = new System.Drawing.Point(41, 253);
            this.btnAdd_1.Name = "btnAdd_1";
            this.btnAdd_1.Size = new System.Drawing.Size(75, 23);
            this.btnAdd_1.TabIndex = 8;
            this.btnAdd_1.Text = "Add";
            this.btnAdd_1.UseVisualStyleBackColor = true;
            this.btnAdd_1.Click += new System.EventHandler(this.btnAdd_Click_1);
            // 
            // btnEdit_1
            // 
            this.btnEdit_1.Location = new System.Drawing.Point(122, 253);
            this.btnEdit_1.Name = "btnEdit_1";
            this.btnEdit_1.Size = new System.Drawing.Size(75, 23);
            this.btnEdit_1.TabIndex = 9;
            this.btnEdit_1.Text = "Edit";
            this.btnEdit_1.UseVisualStyleBackColor = true;
            this.btnEdit_1.Click += new System.EventHandler(this.btnEdit_Click_1);
            // 
            // btnDelete_1
            // 
            this.btnDelete_1.Location = new System.Drawing.Point(203, 253);
            this.btnDelete_1.Name = "btnDelete_1";
            this.btnDelete_1.Size = new System.Drawing.Size(75, 23);
            this.btnDelete_1.TabIndex = 10;
            this.btnDelete_1.Text = "Delete";
            this.btnDelete_1.UseVisualStyleBackColor = true;
            this.btnDelete_1.Click += new System.EventHandler(this.btnDelete_Click_1);
            // 
            // lstDevices_1
            // 
            this.lstDevices_1.FormattingEnabled = true;
            this.lstDevices_1.Location = new System.Drawing.Point(12, 136);
            this.lstDevices_1.Name = "lstDevices_1";
            this.lstDevices_1.Size = new System.Drawing.Size(294, 108);
            this.lstDevices_1.TabIndex = 11;
            this.lstDevices_1.SelectedIndexChanged += new System.EventHandler(this.lstDevices_1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Name";
            // 
            // txtDeviceName_1
            // 
            this.txtDeviceName_1.Location = new System.Drawing.Point(90, 101);
            this.txtDeviceName_1.Name = "txtDeviceName_1";
            this.txtDeviceName_1.Size = new System.Drawing.Size(210, 20);
            this.txtDeviceName_1.TabIndex = 13;
            // 
            // SetupDialogForm
            // 
            this.ClientSize = new System.Drawing.Size(321, 319);
            this.Controls.Add(this.txtDeviceName_1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstDevices_1);
            this.Controls.Add(this.btnDelete_1);
            this.Controls.Add(this.btnEdit_1);
            this.Controls.Add(this.btnAdd_1);
            this.Controls.Add(this.lblMAC);
            this.Controls.Add(this.txtMAC_1);
            this.Controls.Add(this.lblModel);
            this.Controls.Add(this.txtModel_1);
            this.Controls.Add(this.lblApiKey);
            this.Controls.Add(this.txtApiKey_1);
            this.Controls.Add(this.btnOK_1);
            this.Controls.Add(this.btnCancel_1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetupDialogForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Govee Setup";
            this.Load += new System.EventHandler(this.SetupDialogForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Button btnAdd_1;
        private System.Windows.Forms.Button btnEdit_1;
        private System.Windows.Forms.Button btnDelete_1;
        private System.Windows.Forms.ListBox lstDevices_1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDeviceName_1;
    }
}