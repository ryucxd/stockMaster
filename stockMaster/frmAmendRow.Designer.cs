namespace stockMaster
{
    partial class frmAmendRow
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnAmend = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnBypass = new System.Windows.Forms.Button();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(980, 43);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnAmend
            // 
            this.btnAmend.Location = new System.Drawing.Point(121, 110);
            this.btnAmend.Name = "btnAmend";
            this.btnAmend.Size = new System.Drawing.Size(96, 23);
            this.btnAmend.TabIndex = 1;
            this.btnAmend.Text = "Amend Quantity";
            this.btnAmend.UseVisualStyleBackColor = true;
            this.btnAmend.Click += new System.EventHandler(this.btnAmend_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(12, 67);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(784, 38);
            this.lblInfo.TabIndex = 2;
            this.lblInfo.Text = "THIS ROW IS NULL OR SOMETHING LIKE THIS";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(598, 108);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(96, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnBypass
            // 
            this.btnBypass.Location = new System.Drawing.Point(700, 108);
            this.btnBypass.Name = "btnBypass";
            this.btnBypass.Size = new System.Drawing.Size(96, 23);
            this.btnBypass.TabIndex = 4;
            this.btnBypass.Text = "Bypass Row";
            this.btnBypass.UseVisualStyleBackColor = true;
            this.btnBypass.Click += new System.EventHandler(this.btnBypass_Click);
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(15, 110);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(100, 20);
            this.txtQuantity.TabIndex = 5;
            this.txtQuantity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQuantity_KeyDown);
            this.txtQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantity_KeyPress);
            // 
            // frmAmendRow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 143);
            this.ControlBox = false;
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.btnBypass);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnAmend);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmAmendRow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bypass Row";
            this.Shown += new System.EventHandler(this.frmAmendRow_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnAmend;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnBypass;
        private System.Windows.Forms.TextBox txtQuantity;
    }
}