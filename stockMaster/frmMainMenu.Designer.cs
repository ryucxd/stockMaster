namespace stockMaster
{
    partial class frmMainMenu
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
            this.chkTraditional = new System.Windows.Forms.RadioButton();
            this.grpArea = new System.Windows.Forms.GroupBox();
            this.ChkSlimline = new System.Windows.Forms.RadioButton();
            this.grpType = new System.Windows.Forms.GroupBox();
            this.chkIncremental = new System.Windows.Forms.RadioButton();
            this.chkPartial = new System.Windows.Forms.RadioButton();
            this.chkFull = new System.Windows.Forms.RadioButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.prog = new System.Windows.Forms.ProgressBar();
            this.btnAttachCSV = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnSnapShot = new System.Windows.Forms.Button();
            this.btnCheckCSV = new System.Windows.Forms.Button();
            this.btnUpload = new System.Windows.Forms.Button();
            this.lblNull2 = new System.Windows.Forms.Label();
            this.lblPrice2 = new System.Windows.Forms.Label();
            this.lblQuantity2 = new System.Windows.Forms.Label();
            this.lblNull1 = new System.Windows.Forms.Label();
            this.lblQuantity1 = new System.Windows.Forms.Label();
            this.lblPrice1 = new System.Windows.Forms.Label();
            this.btnBypass = new System.Windows.Forms.Button();
            this.lblBypass1 = new System.Windows.Forms.Label();
            this.lblBypass2 = new System.Windows.Forms.Label();
            this.lblStockCode1 = new System.Windows.Forms.Label();
            this.lblStockCode2 = new System.Windows.Forms.Label();
            this.grpArea.SuspendLayout();
            this.grpType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // chkTraditional
            // 
            this.chkTraditional.AutoSize = true;
            this.chkTraditional.Location = new System.Drawing.Point(14, 32);
            this.chkTraditional.Name = "chkTraditional";
            this.chkTraditional.Size = new System.Drawing.Size(74, 17);
            this.chkTraditional.TabIndex = 0;
            this.chkTraditional.TabStop = true;
            this.chkTraditional.Text = "Traditional";
            this.chkTraditional.UseVisualStyleBackColor = true;
            // 
            // grpArea
            // 
            this.grpArea.Controls.Add(this.ChkSlimline);
            this.grpArea.Controls.Add(this.chkTraditional);
            this.grpArea.Location = new System.Drawing.Point(12, 6);
            this.grpArea.Name = "grpArea";
            this.grpArea.Size = new System.Drawing.Size(244, 68);
            this.grpArea.TabIndex = 1;
            this.grpArea.TabStop = false;
            this.grpArea.Text = "Stock Area";
            // 
            // ChkSlimline
            // 
            this.ChkSlimline.AutoSize = true;
            this.ChkSlimline.Location = new System.Drawing.Point(104, 32);
            this.ChkSlimline.Name = "ChkSlimline";
            this.ChkSlimline.Size = new System.Drawing.Size(60, 17);
            this.ChkSlimline.TabIndex = 1;
            this.ChkSlimline.TabStop = true;
            this.ChkSlimline.Text = "Slimline";
            this.ChkSlimline.UseVisualStyleBackColor = true;
            // 
            // grpType
            // 
            this.grpType.Controls.Add(this.chkIncremental);
            this.grpType.Controls.Add(this.chkPartial);
            this.grpType.Controls.Add(this.chkFull);
            this.grpType.Location = new System.Drawing.Point(12, 80);
            this.grpType.Name = "grpType";
            this.grpType.Size = new System.Drawing.Size(244, 68);
            this.grpType.TabIndex = 2;
            this.grpType.TabStop = false;
            this.grpType.Text = "Stock Take Type";
            // 
            // chkIncremental
            // 
            this.chkIncremental.AutoSize = true;
            this.chkIncremental.Location = new System.Drawing.Point(153, 32);
            this.chkIncremental.Name = "chkIncremental";
            this.chkIncremental.Size = new System.Drawing.Size(80, 17);
            this.chkIncremental.TabIndex = 2;
            this.chkIncremental.Text = "Incremental";
            this.chkIncremental.UseVisualStyleBackColor = true;
            // 
            // chkPartial
            // 
            this.chkPartial.AutoSize = true;
            this.chkPartial.Location = new System.Drawing.Point(77, 32);
            this.chkPartial.Name = "chkPartial";
            this.chkPartial.Size = new System.Drawing.Size(54, 17);
            this.chkPartial.TabIndex = 1;
            this.chkPartial.Text = "Partial";
            this.chkPartial.UseVisualStyleBackColor = true;
            // 
            // chkFull
            // 
            this.chkFull.AutoSize = true;
            this.chkFull.Checked = true;
            this.chkFull.Location = new System.Drawing.Point(14, 32);
            this.chkFull.Name = "chkFull";
            this.chkFull.Size = new System.Drawing.Size(41, 17);
            this.chkFull.TabIndex = 0;
            this.chkFull.TabStop = true;
            this.chkFull.Text = "Full";
            this.chkFull.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 183);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(895, 331);
            this.dataGridView1.TabIndex = 3;
            // 
            // prog
            // 
            this.prog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.prog.Location = new System.Drawing.Point(262, 154);
            this.prog.Name = "prog";
            this.prog.Size = new System.Drawing.Size(645, 23);
            this.prog.TabIndex = 4;
            // 
            // btnAttachCSV
            // 
            this.btnAttachCSV.Enabled = false;
            this.btnAttachCSV.Location = new System.Drawing.Point(262, 125);
            this.btnAttachCSV.Name = "btnAttachCSV";
            this.btnAttachCSV.Size = new System.Drawing.Size(104, 23);
            this.btnAttachCSV.TabIndex = 5;
            this.btnAttachCSV.Text = "Attach CSV";
            this.btnAttachCSV.UseVisualStyleBackColor = true;
            this.btnAttachCSV.Click += new System.EventHandler(this.btnAttachCSV_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(57, 154);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(154, 23);
            this.btnConfirm.TabIndex = 6;
            this.btnConfirm.Text = "Confirm Selection";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnSnapShot
            // 
            this.btnSnapShot.Enabled = false;
            this.btnSnapShot.Location = new System.Drawing.Point(592, 125);
            this.btnSnapShot.Name = "btnSnapShot";
            this.btnSnapShot.Size = new System.Drawing.Size(104, 23);
            this.btnSnapShot.TabIndex = 7;
            this.btnSnapShot.Text = "Stock Snap Shot";
            this.btnSnapShot.UseVisualStyleBackColor = true;
            this.btnSnapShot.Click += new System.EventHandler(this.btnSnapShot_Click);
            // 
            // btnCheckCSV
            // 
            this.btnCheckCSV.Enabled = false;
            this.btnCheckCSV.Location = new System.Drawing.Point(372, 125);
            this.btnCheckCSV.Name = "btnCheckCSV";
            this.btnCheckCSV.Size = new System.Drawing.Size(104, 23);
            this.btnCheckCSV.TabIndex = 8;
            this.btnCheckCSV.Text = "Check CSV";
            this.btnCheckCSV.UseVisualStyleBackColor = true;
            this.btnCheckCSV.Click += new System.EventHandler(this.btnCheckCSV_Click);
            // 
            // btnUpload
            // 
            this.btnUpload.Enabled = false;
            this.btnUpload.Location = new System.Drawing.Point(702, 125);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(104, 23);
            this.btnUpload.TabIndex = 9;
            this.btnUpload.Text = "Upload Stock";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // lblNull2
            // 
            this.lblNull2.AutoSize = true;
            this.lblNull2.BackColor = System.Drawing.SystemColors.Control;
            this.lblNull2.Location = new System.Drawing.Point(277, 68);
            this.lblNull2.Name = "lblNull2";
            this.lblNull2.Size = new System.Drawing.Size(88, 13);
            this.lblNull2.TabIndex = 10;
            this.lblNull2.Text = "= Null information";
            this.lblNull2.Visible = false;
            // 
            // lblPrice2
            // 
            this.lblPrice2.AutoSize = true;
            this.lblPrice2.Location = new System.Drawing.Point(277, 87);
            this.lblPrice2.Name = "lblPrice2";
            this.lblPrice2.Size = new System.Drawing.Size(115, 13);
            this.lblPrice2.TabIndex = 11;
            this.lblPrice2.Text = "= Exceeded Price Limit";
            this.lblPrice2.Visible = false;
            // 
            // lblQuantity2
            // 
            this.lblQuantity2.AutoSize = true;
            this.lblQuantity2.Location = new System.Drawing.Point(277, 106);
            this.lblQuantity2.Name = "lblQuantity2";
            this.lblQuantity2.Size = new System.Drawing.Size(130, 13);
            this.lblQuantity2.TabIndex = 12;
            this.lblQuantity2.Text = "= Exceeded Quantity Limit";
            this.lblQuantity2.Visible = false;
            // 
            // lblNull1
            // 
            this.lblNull1.AutoSize = true;
            this.lblNull1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.lblNull1.Location = new System.Drawing.Point(262, 68);
            this.lblNull1.Name = "lblNull1";
            this.lblNull1.Size = new System.Drawing.Size(16, 13);
            this.lblNull1.TabIndex = 13;
            this.lblNull1.Text = "   ";
            this.lblNull1.Visible = false;
            // 
            // lblQuantity1
            // 
            this.lblQuantity1.AutoSize = true;
            this.lblQuantity1.BackColor = System.Drawing.Color.PaleVioletRed;
            this.lblQuantity1.Location = new System.Drawing.Point(262, 106);
            this.lblQuantity1.Name = "lblQuantity1";
            this.lblQuantity1.Size = new System.Drawing.Size(16, 13);
            this.lblQuantity1.TabIndex = 14;
            this.lblQuantity1.Text = "   ";
            this.lblQuantity1.Visible = false;
            // 
            // lblPrice1
            // 
            this.lblPrice1.AutoSize = true;
            this.lblPrice1.BackColor = System.Drawing.Color.Goldenrod;
            this.lblPrice1.Location = new System.Drawing.Point(262, 87);
            this.lblPrice1.Name = "lblPrice1";
            this.lblPrice1.Size = new System.Drawing.Size(16, 13);
            this.lblPrice1.TabIndex = 15;
            this.lblPrice1.Text = "   ";
            this.lblPrice1.Visible = false;
            // 
            // btnBypass
            // 
            this.btnBypass.Enabled = false;
            this.btnBypass.Location = new System.Drawing.Point(482, 125);
            this.btnBypass.Name = "btnBypass";
            this.btnBypass.Size = new System.Drawing.Size(104, 23);
            this.btnBypass.TabIndex = 16;
            this.btnBypass.Text = "Bypass Warnings";
            this.btnBypass.UseVisualStyleBackColor = true;
            this.btnBypass.Click += new System.EventHandler(this.btnBypass_Click);
            // 
            // lblBypass1
            // 
            this.lblBypass1.AutoSize = true;
            this.lblBypass1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.lblBypass1.Location = new System.Drawing.Point(262, 49);
            this.lblBypass1.Name = "lblBypass1";
            this.lblBypass1.Size = new System.Drawing.Size(16, 13);
            this.lblBypass1.TabIndex = 18;
            this.lblBypass1.Text = "   ";
            this.lblBypass1.Visible = false;
            // 
            // lblBypass2
            // 
            this.lblBypass2.AutoSize = true;
            this.lblBypass2.BackColor = System.Drawing.SystemColors.Control;
            this.lblBypass2.Location = new System.Drawing.Point(277, 49);
            this.lblBypass2.Name = "lblBypass2";
            this.lblBypass2.Size = new System.Drawing.Size(62, 13);
            this.lblBypass2.TabIndex = 17;
            this.lblBypass2.Text = "= Bypassed";
            this.lblBypass2.Visible = false;
            // 
            // lblStockCode1
            // 
            this.lblStockCode1.AutoSize = true;
            this.lblStockCode1.BackColor = System.Drawing.Color.Red;
            this.lblStockCode1.Location = new System.Drawing.Point(262, 30);
            this.lblStockCode1.Name = "lblStockCode1";
            this.lblStockCode1.Size = new System.Drawing.Size(16, 13);
            this.lblStockCode1.TabIndex = 20;
            this.lblStockCode1.Text = "   ";
            this.lblStockCode1.Visible = false;
            // 
            // lblStockCode2
            // 
            this.lblStockCode2.AutoSize = true;
            this.lblStockCode2.BackColor = System.Drawing.SystemColors.Control;
            this.lblStockCode2.Location = new System.Drawing.Point(277, 30);
            this.lblStockCode2.Name = "lblStockCode2";
            this.lblStockCode2.Size = new System.Drawing.Size(89, 13);
            this.lblStockCode2.TabIndex = 19;
            this.lblStockCode2.Text = "= No Stock Code";
            this.lblStockCode2.Visible = false;
            // 
            // frmMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 526);
            this.Controls.Add(this.lblStockCode1);
            this.Controls.Add(this.lblStockCode2);
            this.Controls.Add(this.lblBypass1);
            this.Controls.Add(this.lblBypass2);
            this.Controls.Add(this.btnBypass);
            this.Controls.Add(this.lblPrice1);
            this.Controls.Add(this.lblQuantity1);
            this.Controls.Add(this.lblNull1);
            this.Controls.Add(this.lblQuantity2);
            this.Controls.Add(this.lblPrice2);
            this.Controls.Add(this.lblNull2);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.btnCheckCSV);
            this.Controls.Add(this.btnSnapShot);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnAttachCSV);
            this.Controls.Add(this.prog);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.grpType);
            this.Controls.Add(this.grpArea);
            this.Name = "frmMainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock Master";
            this.grpArea.ResumeLayout(false);
            this.grpArea.PerformLayout();
            this.grpType.ResumeLayout(false);
            this.grpType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton chkTraditional;
        private System.Windows.Forms.GroupBox grpArea;
        private System.Windows.Forms.RadioButton ChkSlimline;
        private System.Windows.Forms.GroupBox grpType;
        private System.Windows.Forms.RadioButton chkIncremental;
        private System.Windows.Forms.RadioButton chkPartial;
        private System.Windows.Forms.RadioButton chkFull;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ProgressBar prog;
        private System.Windows.Forms.Button btnAttachCSV;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnSnapShot;
        private System.Windows.Forms.Button btnCheckCSV;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Label lblNull2;
        private System.Windows.Forms.Label lblPrice2;
        private System.Windows.Forms.Label lblQuantity2;
        private System.Windows.Forms.Label lblNull1;
        private System.Windows.Forms.Label lblQuantity1;
        private System.Windows.Forms.Label lblPrice1;
        private System.Windows.Forms.Button btnBypass;
        private System.Windows.Forms.Label lblBypass1;
        private System.Windows.Forms.Label lblBypass2;
        private System.Windows.Forms.Label lblStockCode1;
        private System.Windows.Forms.Label lblStockCode2;
    }
}

