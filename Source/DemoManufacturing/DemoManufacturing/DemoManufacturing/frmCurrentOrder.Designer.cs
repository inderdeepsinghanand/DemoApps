namespace DemoManufacturing
{
    partial class frmCurrentOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCurrentOrder));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnClose = new System.Windows.Forms.Button();
            this.dgFrontBumpers = new System.Windows.Forms.DataGridView();
            this.dgBackBumpers = new System.Windows.Forms.DataGridView();
            this.pnlData = new System.Windows.Forms.Panel();
            this.btnMasterUpload = new System.Windows.Forms.Button();
            this.btnUploadOrder = new System.Windows.Forms.Button();
            this.txtSelectedFile = new System.Windows.Forms.TextBox();
            this.fdOrderUpload = new System.Windows.Forms.OpenFileDialog();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgFrontBumpers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgBackBumpers)).BeginInit();
            this.pnlData.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.Name = "btnClose";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgFrontBumpers
            // 
            resources.ApplyResources(this.dgFrontBumpers, "dgFrontBumpers");
            this.dgFrontBumpers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgFrontBumpers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle19;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgFrontBumpers.DefaultCellStyle = dataGridViewCellStyle20;
            this.dgFrontBumpers.Name = "dgFrontBumpers";
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgFrontBumpers.RowsDefaultCellStyle = dataGridViewCellStyle21;
            this.dgFrontBumpers.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgFrontBumpers.RowTemplate.Height = 50;
            this.dgFrontBumpers.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgFrontBumpers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgFrontBumpers_CellContentClick);
            // 
            // dgBackBumpers
            // 
            resources.ApplyResources(this.dgBackBumpers, "dgBackBumpers");
            this.dgBackBumpers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgBackBumpers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle22;
            this.dgBackBumpers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgBackBumpers.DefaultCellStyle = dataGridViewCellStyle23;
            this.dgBackBumpers.Name = "dgBackBumpers";
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgBackBumpers.RowsDefaultCellStyle = dataGridViewCellStyle24;
            this.dgBackBumpers.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgBackBumpers.RowTemplate.Height = 50;
            this.dgBackBumpers.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // pnlData
            // 
            resources.ApplyResources(this.pnlData, "pnlData");
            this.pnlData.BackColor = System.Drawing.Color.Aquamarine;
            this.pnlData.Controls.Add(this.dgFrontBumpers);
            this.pnlData.Controls.Add(this.dgBackBumpers);
            this.pnlData.Name = "pnlData";
            // 
            // btnMasterUpload
            // 
            resources.ApplyResources(this.btnMasterUpload, "btnMasterUpload");
            this.btnMasterUpload.Name = "btnMasterUpload";
            this.btnMasterUpload.UseVisualStyleBackColor = true;
            this.btnMasterUpload.Click += new System.EventHandler(this.btnMasterUpload_Click);
            // 
            // btnUploadOrder
            // 
            resources.ApplyResources(this.btnUploadOrder, "btnUploadOrder");
            this.btnUploadOrder.Name = "btnUploadOrder";
            this.btnUploadOrder.UseVisualStyleBackColor = true;
            // 
            // txtSelectedFile
            // 
            resources.ApplyResources(this.txtSelectedFile, "txtSelectedFile");
            this.txtSelectedFile.Name = "txtSelectedFile";
            // 
            // fdOrderUpload
            // 
            this.fdOrderUpload.FileName = "fdMasterUpload";
            // 
            // btnRefresh
            // 
            resources.ApplyResources(this.btnRefresh, "btnRefresh");
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // btnClose1
            // 
            resources.ApplyResources(this.btnClose1, "btnClose1");
            this.btnClose1.Name = "btnClose1";
            this.btnClose1.UseVisualStyleBackColor = true;
            this.btnClose1.Click += new System.EventHandler(this.btnClose1_Click);
            // 
            // frmCurrentOrder
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.LightCyan;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.btnClose1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnUploadOrder);
            this.Controls.Add(this.txtSelectedFile);
            this.Controls.Add(this.btnMasterUpload);
            this.Controls.Add(this.pnlData);
            this.Controls.Add(this.btnClose);
            this.Name = "frmCurrentOrder";
            this.Load += new System.EventHandler(this.frmCurrentOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgFrontBumpers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgBackBumpers)).EndInit();
            this.pnlData.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgFrontBumpers;
        private System.Windows.Forms.DataGridView dgBackBumpers;
        private System.Windows.Forms.Panel pnlData;
        private System.Windows.Forms.Button btnMasterUpload;
        private System.Windows.Forms.Button btnUploadOrder;
        private System.Windows.Forms.TextBox txtSelectedFile;
        private System.Windows.Forms.OpenFileDialog fdOrderUpload;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose1;
    }
}

