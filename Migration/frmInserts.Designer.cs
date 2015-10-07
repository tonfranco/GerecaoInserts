namespace Migration
{
    partial class frmInserts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInserts));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbExecute = new System.Windows.Forms.ToolStripButton();
            this.grpResults = new System.Windows.Forms.GroupBox();
            this.lklArqGerado = new System.Windows.Forms.LinkLabel();
            this.lblErrorInfo = new System.Windows.Forms.Label();
            this.grpSelects = new System.Windows.Forms.GroupBox();
            this.txtInserts = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboBases = new System.Windows.Forms.ComboBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtServerName = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.rbWindowsAut = new System.Windows.Forms.RadioButton();
            this.rbSQLAut = new System.Windows.Forms.RadioButton();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.toolStrip1.SuspendLayout();
            this.grpResults.SuspendLayout();
            this.grpSelects.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbExecute});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(922, 39);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbExecute
            // 
            this.tsbExecute.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbExecute.Image = global::Migration.Resource1.execute;
            this.tsbExecute.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExecute.Name = "tsbExecute";
            this.tsbExecute.Size = new System.Drawing.Size(36, 36);
            this.tsbExecute.Text = "toolStripButton1";
            this.tsbExecute.ToolTipText = "Executar";
            this.tsbExecute.Click += new System.EventHandler(this.tsbExecute_Click);
            // 
            // grpResults
            // 
            this.grpResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpResults.Controls.Add(this.linkLabel1);
            this.grpResults.Controls.Add(this.lklArqGerado);
            this.grpResults.Controls.Add(this.lblErrorInfo);
            this.grpResults.Location = new System.Drawing.Point(1, 399);
            this.grpResults.Name = "grpResults";
            this.grpResults.Size = new System.Drawing.Size(919, 70);
            this.grpResults.TabIndex = 6;
            this.grpResults.TabStop = false;
            this.grpResults.Text = "Results";
            // 
            // lklArqGerado
            // 
            this.lklArqGerado.AutoSize = true;
            this.lklArqGerado.Location = new System.Drawing.Point(150, 20);
            this.lklArqGerado.Name = "lklArqGerado";
            this.lklArqGerado.Size = new System.Drawing.Size(49, 13);
            this.lklArqGerado.TabIndex = 75;
            this.lklArqGerado.TabStop = true;
            this.lklArqGerado.Text = "_______";
            this.lklArqGerado.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lklArqGerado_LinkClicked);
            // 
            // lblErrorInfo
            // 
            this.lblErrorInfo.AutoSize = true;
            this.lblErrorInfo.ForeColor = System.Drawing.Color.Red;
            this.lblErrorInfo.Location = new System.Drawing.Point(7, 20);
            this.lblErrorInfo.Name = "lblErrorInfo";
            this.lblErrorInfo.Size = new System.Drawing.Size(35, 13);
            this.lblErrorInfo.TabIndex = 74;
            this.lblErrorInfo.Text = "label4";
            // 
            // grpSelects
            // 
            this.grpSelects.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpSelects.Controls.Add(this.txtInserts);
            this.grpSelects.Location = new System.Drawing.Point(2, 120);
            this.grpSelects.Name = "grpSelects";
            this.grpSelects.Size = new System.Drawing.Size(918, 273);
            this.grpSelects.TabIndex = 5;
            this.grpSelects.TabStop = false;
            this.grpSelects.Text = "Select\'s";
            // 
            // txtInserts
            // 
            this.txtInserts.Location = new System.Drawing.Point(8, 16);
            this.txtInserts.Multiline = true;
            this.txtInserts.Name = "txtInserts";
            this.txtInserts.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtInserts.Size = new System.Drawing.Size(902, 249);
            this.txtInserts.TabIndex = 0;
            this.txtInserts.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtInserts_KeyUp);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblInfo);
            this.groupBox1.Location = new System.Drawing.Point(1, 468);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(918, 33);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Info";
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(10, 15);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(0, 13);
            this.lblInfo.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.cboBases);
            this.groupBox4.Location = new System.Drawing.Point(700, 42);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(221, 72);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Choose Data Base";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Data Base";
            // 
            // cboBases
            // 
            this.cboBases.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBases.FormattingEnabled = true;
            this.cboBases.Location = new System.Drawing.Point(8, 35);
            this.cboBases.Name = "cboBases";
            this.cboBases.Size = new System.Drawing.Size(204, 21);
            this.cboBases.TabIndex = 8;
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(438, 12);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(82, 20);
            this.txtUser.TabIndex = 0;
            this.txtUser.Text = "sa";
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(438, 41);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(82, 20);
            this.txtPwd.TabIndex = 1;
            this.txtPwd.Text = "super";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(399, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "User";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(176, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Server";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(379, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Password";
            // 
            // txtServerName
            // 
            this.txtServerName.Location = new System.Drawing.Point(215, 17);
            this.txtServerName.Name = "txtServerName";
            this.txtServerName.Size = new System.Drawing.Size(178, 20);
            this.txtServerName.TabIndex = 5;
            this.txtServerName.Text = " D4010S001E869\\SQL2000";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(619, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(73, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Connect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(619, 10);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(73, 23);
            this.btnDisconnect.TabIndex = 7;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // rbWindowsAut
            // 
            this.rbWindowsAut.AutoSize = true;
            this.rbWindowsAut.Location = new System.Drawing.Point(10, 20);
            this.rbWindowsAut.Name = "rbWindowsAut";
            this.rbWindowsAut.Size = new System.Drawing.Size(140, 17);
            this.rbWindowsAut.TabIndex = 8;
            this.rbWindowsAut.Text = "Windows Authentication";
            this.rbWindowsAut.UseVisualStyleBackColor = true;
            // 
            // rbSQLAut
            // 
            this.rbSQLAut.AutoSize = true;
            this.rbSQLAut.Checked = true;
            this.rbSQLAut.Location = new System.Drawing.Point(10, 37);
            this.rbSQLAut.Name = "rbSQLAut";
            this.rbSQLAut.Size = new System.Drawing.Size(151, 17);
            this.rbSQLAut.TabIndex = 9;
            this.rbSQLAut.TabStop = true;
            this.rbSQLAut.Text = "SQL Server Authentication";
            this.rbSQLAut.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(529, 14);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(89, 17);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.Text = "Criptografado";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBox1);
            this.groupBox3.Controls.Add(this.rbSQLAut);
            this.groupBox3.Controls.Add(this.rbWindowsAut);
            this.groupBox3.Controls.Add(this.btnDisconnect);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.txtServerName);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.txtPwd);
            this.groupBox3.Controls.Add(this.txtUser);
            this.groupBox3.Location = new System.Drawing.Point(2, 42);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(698, 72);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Connection";
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkColor = System.Drawing.Color.Red;
            this.linkLabel1.Location = new System.Drawing.Point(150, 49);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(115, 13);
            this.linkLabel1.TabIndex = 77;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Deletar arquivo gerado";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // frmInserts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 505);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.grpResults);
            this.Controls.Add(this.grpSelects);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmInserts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmInserts";
            this.Load += new System.EventHandler(this.frmInserts_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.grpResults.ResumeLayout(false);
            this.grpResults.PerformLayout();
            this.grpSelects.ResumeLayout(false);
            this.grpSelects.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbExecute;
        private System.Windows.Forms.GroupBox grpResults;
        private System.Windows.Forms.Label lblErrorInfo;
        private System.Windows.Forms.GroupBox grpSelects;
        private System.Windows.Forms.TextBox txtInserts;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtServerName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.RadioButton rbWindowsAut;
        private System.Windows.Forms.RadioButton rbSQLAut;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboBases;
        private System.Windows.Forms.LinkLabel lklArqGerado;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}