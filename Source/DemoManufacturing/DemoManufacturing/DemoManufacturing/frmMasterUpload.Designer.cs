namespace DemoManufacturing
{
    partial class frmMasterUpload
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
            this.fdMasterUpload = new System.Windows.Forms.OpenFileDialog();
            this.txtSelectedFile = new System.Windows.Forms.TextBox();
            this.btnMasterUpload = new System.Windows.Forms.Button();
            this.dgMasterData = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgMasterData)).BeginInit();
            this.SuspendLayout();
            // 
            // fdMasterUpload
            // 
            this.fdMasterUpload.FileName = "fdMasterUpload";
            // 
            // txtSelectedFile
            // 
            this.txtSelectedFile.Location = new System.Drawing.Point(251, 36);
            this.txtSelectedFile.Name = "txtSelectedFile";
            this.txtSelectedFile.Size = new System.Drawing.Size(309, 20);
            this.txtSelectedFile.TabIndex = 0;
            // 
            // btnMasterUpload
            // 
            this.btnMasterUpload.Location = new System.Drawing.Point(566, 34);
            this.btnMasterUpload.Name = "btnMasterUpload";
            this.btnMasterUpload.Size = new System.Drawing.Size(111, 23);
            this.btnMasterUpload.TabIndex = 1;
            this.btnMasterUpload.Text = "Select Master File";
            this.btnMasterUpload.UseVisualStyleBackColor = true;
            this.btnMasterUpload.Click += new System.EventHandler(this.btnMasterUpload_Click);
            // 
            // dgMasterData
            // 
            this.dgMasterData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgMasterData.Location = new System.Drawing.Point(56, 94);
            this.dgMasterData.Name = "dgMasterData";
            this.dgMasterData.Size = new System.Drawing.Size(839, 475);
            this.dgMasterData.TabIndex = 2;
            // 
            // frmMasterUpload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 581);
            this.Controls.Add(this.dgMasterData);
            this.Controls.Add(this.btnMasterUpload);
            this.Controls.Add(this.txtSelectedFile);
            this.Name = "frmMasterUpload";
            this.Text = "frmMasterUpload";
            ((System.ComponentModel.ISupportInitialize)(this.dgMasterData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog fdMasterUpload;
        private System.Windows.Forms.TextBox txtSelectedFile;
        private System.Windows.Forms.Button btnMasterUpload;
        private System.Windows.Forms.DataGridView dgMasterData;
    }
}