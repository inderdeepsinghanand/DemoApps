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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnClose = new System.Windows.Forms.Button();
            this.dgFrontBumpers = new System.Windows.Forms.DataGridView();
            this.dgBackBumpers = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgFrontBumpers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgBackBumpers)).BeginInit();
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
            this.dgFrontBumpers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgFrontBumpers.DefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(this.dgFrontBumpers, "dgFrontBumpers");
            this.dgFrontBumpers.Name = "dgFrontBumpers";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgFrontBumpers.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgFrontBumpers.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgFrontBumpers.RowTemplate.Height = 50;
            this.dgFrontBumpers.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgFrontBumpers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgFrontBumpers_CellContentClick);
            // 
            // dgBackBumpers
            // 
            this.dgBackBumpers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgBackBumpers.DefaultCellStyle = dataGridViewCellStyle3;
            resources.ApplyResources(this.dgBackBumpers, "dgBackBumpers");
            this.dgBackBumpers.Name = "dgBackBumpers";
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgBackBumpers.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgBackBumpers.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgBackBumpers.RowTemplate.Height = 50;
            this.dgBackBumpers.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgBackBumpers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgBackBumpers_CellContentClick);
            // 
            // frmCurrentOrder
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.LightCyan;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.dgBackBumpers);
            this.Controls.Add(this.dgFrontBumpers);
            this.Controls.Add(this.btnClose);
            this.Name = "frmCurrentOrder";
            this.Load += new System.EventHandler(this.frmCurrentOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgFrontBumpers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgBackBumpers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgFrontBumpers;
        private System.Windows.Forms.DataGridView dgBackBumpers;
    }
}

