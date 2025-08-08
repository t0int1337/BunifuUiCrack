namespace BunifuLicenseGenerator
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnGenerate = new System.Windows.Forms.Button();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.cmbProduct = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbEmail = new System.Windows.Forms.Label();
            this.lbProduct = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.txtHWID = new System.Windows.Forms.TextBox();
            this.lbHWID = new System.Windows.Forms.Label();
            this.chkEnterprise = new System.Windows.Forms.CheckBox();
            this.lbLicense = new System.Windows.Forms.Label();
            this.txtLicenseKey = new System.Windows.Forms.TextBox();
            this.lbName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(12, 230);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(260, 35);
            this.btnGenerate.TabIndex = 5;
            this.btnGenerate.Text = "Generate & Save License";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(12, 105);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(260, 20);
            this.txtEmail.TabIndex = 2;
            this.txtEmail.Text = "john.doe@example.com";
            // 
            // cmbProduct
            // 
            this.cmbProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProduct.FormattingEnabled = true;
            this.cmbProduct.Items.AddRange(new object[] {
            "UIWinForms",
            "Charts",
            "DatavizBasicWinForms",
            "DatavizAdvancedWinForms"});
            this.cmbProduct.Location = new System.Drawing.Point(12, 145);
            this.cmbProduct.Name = "cmbProduct";
            this.cmbProduct.Size = new System.Drawing.Size(260, 21);
            this.cmbProduct.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Name:";
            // 
            // lbEmail
            // 
            this.lbEmail.AutoSize = true;
            this.lbEmail.Location = new System.Drawing.Point(12, 89);
            this.lbEmail.Name = "lbEmail";
            this.lbEmail.Size = new System.Drawing.Size(35, 13);
            this.lbEmail.TabIndex = 7;
            this.lbEmail.Text = "Email:";
            // 
            // lbProduct
            // 
            this.lbProduct.AutoSize = true;
            this.lbProduct.Location = new System.Drawing.Point(12, 129);
            this.lbProduct.Name = "lbProduct";
            this.lbProduct.Size = new System.Drawing.Size(47, 13);
            this.lbProduct.TabIndex = 8;
            this.lbProduct.Text = "Product:";
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(12, 270);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(0, 13);
            this.labelStatus.TabIndex = 9;
            // 
            // txtHWID
            // 
            this.txtHWID.Location = new System.Drawing.Point(12, 185);
            this.txtHWID.Name = "txtHWID";
            this.txtHWID.ReadOnly = true;
            this.txtHWID.Size = new System.Drawing.Size(260, 20);
            this.txtHWID.TabIndex = 10;
            // 
            // lbHWID
            // 
            this.lbHWID.AutoSize = true;
            this.lbHWID.Location = new System.Drawing.Point(12, 169);
            this.lbHWID.Name = "lbHWID";
            this.lbHWID.Size = new System.Drawing.Size(40, 13);
            this.lbHWID.TabIndex = 11;
            this.lbHWID.Text = "HWID:";
            // 
            // chkEnterprise
            // 
            this.chkEnterprise.AutoSize = true;
            this.chkEnterprise.Location = new System.Drawing.Point(15, 210);
            this.chkEnterprise.Name = "chkEnterprise";
            this.chkEnterprise.Size = new System.Drawing.Size(113, 17);
            this.chkEnterprise.TabIndex = 4;
            this.chkEnterprise.Text = "Enterprise License";
            this.chkEnterprise.UseVisualStyleBackColor = true;
            // 
            // lbLicense
            // 
            this.lbLicense.AutoSize = true;
            this.lbLicense.Location = new System.Drawing.Point(12, 9);
            this.lbLicense.Name = "lbLicense";
            this.lbLicense.Size = new System.Drawing.Size(68, 13);
            this.lbLicense.TabIndex = 13;
            this.lbLicense.Text = "License Key:";
            // 
            // txtLicenseKey
            // 
            this.txtLicenseKey.Location = new System.Drawing.Point(12, 25);
            this.txtLicenseKey.Name = "txtLicenseKey";
            this.txtLicenseKey.Size = new System.Drawing.Size(260, 20);
            this.txtLicenseKey.TabIndex = 0;
            this.txtLicenseKey.Text = "Fake-LICENSE-KEY-12345";
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(12, 50);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(38, 13);
            this.lbName.TabIndex = 15;
            this.lbName.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(12, 66);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(260, 20);
            this.txtName.TabIndex = 14;
            this.txtName.Text = "John Doe";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(368, 29);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(63, 13);
            this.linkLabel1.TabIndex = 16;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Link to repo";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(325, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Made by t0int1337 and RE0x0";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F);
            this.label3.Location = new System.Drawing.Point(325, 252);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(191, 26);
            this.label3.TabIndex = 18;
            this.label3.Text = "If you are a contributor, please open an\r\n issue to have your name here";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 287);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtLicenseKey);
            this.Controls.Add(this.lbLicense);
            this.Controls.Add(this.chkEnterprise);
            this.Controls.Add(this.txtHWID);
            this.Controls.Add(this.lbHWID);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.lbProduct);
            this.Controls.Add(this.lbEmail);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbProduct);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.btnGenerate);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Bunifu License Generator";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.ComboBox cmbProduct;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbEmail;
        private System.Windows.Forms.Label lbProduct;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.TextBox txtHWID;
        private System.Windows.Forms.Label lbHWID;
        private System.Windows.Forms.CheckBox chkEnterprise;
        private System.Windows.Forms.Label lbLicense;
        private System.Windows.Forms.TextBox txtLicenseKey;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}