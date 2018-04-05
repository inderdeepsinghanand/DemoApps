namespace BarCodePrinting{
    partial class frmDashboard
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnOrderProcessing = new System.Windows.Forms.Button();
            this.btnUploadOrder = new System.Windows.Forms.Button();
            this.btnMasterUpload = new System.Windows.Forms.Button();
            this.pnlReaLabel = new System.Windows.Forms.TableLayoutPanel();
            this.dgFrontBumpers = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblRearStats = new System.Windows.Forms.Label();
            this.lblRearBump = new System.Windows.Forms.Label();
            this.dgBackBumpers = new System.Windows.Forms.DataGridView();
            this.pnlFrontLabel = new System.Windows.Forms.Panel();
            this.lblFrontStats = new System.Windows.Forms.Label();
            this.lblFrontBump = new System.Windows.Forms.Label();
            this.tmrBlinkRecord = new System.Windows.Forms.Timer(this.components);
            this.tmrReloadGrids = new System.Windows.Forms.Timer(this.components);
            this.tmrSelectRow = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlButtons.SuspendLayout();
            this.pnlReaLabel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgFrontBumpers)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgBackBumpers)).BeginInit();
            this.pnlFrontLabel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(192, 509);
            this.panel1.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.pnlLogo, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnlButtons, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(192, 509);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // pnlLogo
            // 
            this.pnlLogo.BackColor = System.Drawing.Color.IndianRed;
            this.pnlLogo.Controls.Add(this.pictureBox1);
            this.pnlLogo.Location = new System.Drawing.Point(3, 3);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(186, 84);
            this.pnlLogo.TabIndex = 0;
            this.pnlLogo.TabStop = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::BarCodePrinting.Properties.Resources.LogoCorner;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(186, 84);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pnlButtons
            // 
            this.pnlButtons.BackColor = System.Drawing.Color.White;
            this.pnlButtons.Controls.Add(this.btnExit);
            this.pnlButtons.Controls.Add(this.btnOrderProcessing);
            this.pnlButtons.Controls.Add(this.btnUploadOrder);
            this.pnlButtons.Controls.Add(this.btnMasterUpload);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlButtons.Location = new System.Drawing.Point(3, 93);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(186, 413);
            this.pnlButtons.TabIndex = 0;
            this.pnlButtons.TabStop = true;
            // 
            // btnExit
            // 
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Image = global::BarCodePrinting.Properties.Resources.Logout_small1;
            this.btnExit.Location = new System.Drawing.Point(0, 361);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(186, 119);
            this.btnExit.TabIndex = 15;
            this.btnExit.Text = "Exit";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click_1);
            // 
            // btnOrderProcessing
            // 
            this.btnOrderProcessing.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnOrderProcessing.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrderProcessing.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrderProcessing.Image = global::BarCodePrinting.Properties.Resources.OrderProcessing_small;
            this.btnOrderProcessing.Location = new System.Drawing.Point(0, 238);
            this.btnOrderProcessing.Name = "btnOrderProcessing";
            this.btnOrderProcessing.Size = new System.Drawing.Size(186, 123);
            this.btnOrderProcessing.TabIndex = 14;
            this.btnOrderProcessing.Text = "Process Order";
            this.btnOrderProcessing.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnOrderProcessing.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnOrderProcessing.UseVisualStyleBackColor = true;
            this.btnOrderProcessing.Visible = false;
            // 
            // btnUploadOrder
            // 
            this.btnUploadOrder.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUploadOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUploadOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUploadOrder.Image = global::BarCodePrinting.Properties.Resources.Upload;
            this.btnUploadOrder.Location = new System.Drawing.Point(0, 119);
            this.btnUploadOrder.Name = "btnUploadOrder";
            this.btnUploadOrder.Size = new System.Drawing.Size(186, 119);
            this.btnUploadOrder.TabIndex = 13;
            this.btnUploadOrder.Text = "Upload Order";
            this.btnUploadOrder.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnUploadOrder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnUploadOrder.UseVisualStyleBackColor = true;
            this.btnUploadOrder.Click += new System.EventHandler(this.btnUploadOrder_Click);
            // 
            // btnMasterUpload
            // 
            this.btnMasterUpload.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMasterUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMasterUpload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMasterUpload.Image = global::BarCodePrinting.Properties.Resources.Upload;
            this.btnMasterUpload.Location = new System.Drawing.Point(0, 0);
            this.btnMasterUpload.Name = "btnMasterUpload";
            this.btnMasterUpload.Size = new System.Drawing.Size(186, 119);
            this.btnMasterUpload.TabIndex = 1;
            this.btnMasterUpload.Text = "Master Info";
            this.btnMasterUpload.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMasterUpload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnMasterUpload.UseVisualStyleBackColor = true;
            this.btnMasterUpload.Click += new System.EventHandler(this.btnMasterUpload_Click);
            // 
            // pnlReaLabel
            // 
            this.pnlReaLabel.ColumnCount = 2;
            this.pnlReaLabel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlReaLabel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlReaLabel.Controls.Add(this.dgFrontBumpers, 0, 1);
            this.pnlReaLabel.Controls.Add(this.panel4, 1, 0);
            this.pnlReaLabel.Controls.Add(this.dgBackBumpers, 1, 1);
            this.pnlReaLabel.Controls.Add(this.pnlFrontLabel, 0, 0);
            this.pnlReaLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlReaLabel.Location = new System.Drawing.Point(192, 0);
            this.pnlReaLabel.Name = "pnlReaLabel";
            this.pnlReaLabel.RowCount = 2;
            this.pnlReaLabel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.pnlReaLabel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlReaLabel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pnlReaLabel.Size = new System.Drawing.Size(638, 509);
            this.pnlReaLabel.TabIndex = 2;
            // 
            // dgFrontBumpers
            // 
            this.dgFrontBumpers.AllowUserToAddRows = false;
            this.dgFrontBumpers.AllowUserToDeleteRows = false;
            this.dgFrontBumpers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgFrontBumpers.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(80)))), ((int)(((byte)(67)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgFrontBumpers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgFrontBumpers.ColumnHeadersHeight = 40;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgFrontBumpers.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgFrontBumpers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgFrontBumpers.EnableHeadersVisualStyles = false;
            this.dgFrontBumpers.Location = new System.Drawing.Point(0, 80);
            this.dgFrontBumpers.Margin = new System.Windows.Forms.Padding(0);
            this.dgFrontBumpers.Name = "dgFrontBumpers";
            this.dgFrontBumpers.ReadOnly = true;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgFrontBumpers.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgFrontBumpers.RowHeadersVisible = false;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgFrontBumpers.RowsDefaultCellStyle = dataGridViewCellStyle11;
            this.dgFrontBumpers.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgFrontBumpers.RowTemplate.Height = 50;
            this.dgFrontBumpers.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgFrontBumpers.Size = new System.Drawing.Size(319, 549);
            this.dgFrontBumpers.TabIndex = 0;
            this.dgFrontBumpers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgFrontBumpers_CellContentClick);
            this.dgFrontBumpers.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgFrontBumpers_CellFormatting);
            this.dgFrontBumpers.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgFrontBumpers_CellMouseClick);
            this.dgFrontBumpers.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgFrontBumpers_DataBindingComplete);
            this.dgFrontBumpers.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgFrontBumpers_KeyDown);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lblRearStats);
            this.panel4.Controls.Add(this.lblRearBump);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(322, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(313, 74);
            this.panel4.TabIndex = 1;
            // 
            // lblRearStats
            // 
            this.lblRearStats.BackColor = System.Drawing.Color.White;
            this.lblRearStats.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblRearStats.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRearStats.Location = new System.Drawing.Point(0, 37);
            this.lblRearStats.Name = "lblRearStats";
            this.lblRearStats.Size = new System.Drawing.Size(313, 37);
            this.lblRearStats.TabIndex = 2;
            this.lblRearStats.Text = "Front Bumpers";
            this.lblRearStats.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRearBump
            // 
            this.lblRearBump.BackColor = System.Drawing.Color.White;
            this.lblRearBump.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRearBump.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRearBump.Location = new System.Drawing.Point(0, 0);
            this.lblRearBump.Name = "lblRearBump";
            this.lblRearBump.Size = new System.Drawing.Size(313, 37);
            this.lblRearBump.TabIndex = 1;
            this.lblRearBump.Text = "Rear";
            this.lblRearBump.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgBackBumpers
            // 
            this.dgBackBumpers.AllowUserToAddRows = false;
            this.dgBackBumpers.AllowUserToDeleteRows = false;
            this.dgBackBumpers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgBackBumpers.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(80)))), ((int)(((byte)(67)))));
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgBackBumpers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgBackBumpers.ColumnHeadersHeight = 40;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgBackBumpers.DefaultCellStyle = dataGridViewCellStyle13;
            this.dgBackBumpers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgBackBumpers.EnableHeadersVisualStyles = false;
            this.dgBackBumpers.Location = new System.Drawing.Point(319, 80);
            this.dgBackBumpers.Margin = new System.Windows.Forms.Padding(0);
            this.dgBackBumpers.Name = "dgBackBumpers";
            this.dgBackBumpers.ReadOnly = true;
            this.dgBackBumpers.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgBackBumpers.RowHeadersVisible = false;
            this.dgBackBumpers.RowHeadersWidth = 60;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgBackBumpers.RowsDefaultCellStyle = dataGridViewCellStyle14;
            this.dgBackBumpers.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgBackBumpers.RowTemplate.Height = 50;
            this.dgBackBumpers.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgBackBumpers.Size = new System.Drawing.Size(319, 549);
            this.dgBackBumpers.TabIndex = 2;
            this.dgBackBumpers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgBackBumpers_CellContentClick);
            this.dgBackBumpers.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgBackBumpers_CellFormatting);
            this.dgBackBumpers.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgBackBumpers_CellMouseClick);
            this.dgBackBumpers.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgBackBumpers_KeyDown);
            // 
            // pnlFrontLabel
            // 
            this.pnlFrontLabel.Controls.Add(this.lblFrontStats);
            this.pnlFrontLabel.Controls.Add(this.lblFrontBump);
            this.pnlFrontLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFrontLabel.Location = new System.Drawing.Point(3, 3);
            this.pnlFrontLabel.Name = "pnlFrontLabel";
            this.pnlFrontLabel.Size = new System.Drawing.Size(313, 74);
            this.pnlFrontLabel.TabIndex = 0;
            // 
            // lblFrontStats
            // 
            this.lblFrontStats.BackColor = System.Drawing.Color.White;
            this.lblFrontStats.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblFrontStats.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrontStats.Location = new System.Drawing.Point(0, 37);
            this.lblFrontStats.Name = "lblFrontStats";
            this.lblFrontStats.Size = new System.Drawing.Size(313, 37);
            this.lblFrontStats.TabIndex = 1;
            this.lblFrontStats.Text = "Front Bumpers";
            this.lblFrontStats.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFrontBump
            // 
            this.lblFrontBump.BackColor = System.Drawing.Color.White;
            this.lblFrontBump.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblFrontBump.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrontBump.Location = new System.Drawing.Point(0, 0);
            this.lblFrontBump.Name = "lblFrontBump";
            this.lblFrontBump.Size = new System.Drawing.Size(313, 37);
            this.lblFrontBump.TabIndex = 0;
            this.lblFrontBump.Text = "Front";
            this.lblFrontBump.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tmrBlinkRecord
            // 
            this.tmrBlinkRecord.Enabled = true;
            this.tmrBlinkRecord.Interval = 1000;
            this.tmrBlinkRecord.Tick += new System.EventHandler(this.tmrBlinkRecord_Tick);
            // 
            // tmrReloadGrids
            // 
            this.tmrReloadGrids.Enabled = true;
            this.tmrReloadGrids.Interval = 7000;
            this.tmrReloadGrids.Tick += new System.EventHandler(this.tmrReloadGrids_Tick);
            // 
            // tmrSelectRow
            // 
            this.tmrSelectRow.Enabled = true;
            this.tmrSelectRow.Interval = 1000;
            this.tmrSelectRow.Tick += new System.EventHandler(this.tmrSelectRow_Tick);
            // 
            // frmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.ClientSize = new System.Drawing.Size(830, 509);
            this.Controls.Add(this.pnlReaLabel);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.Name = "frmDashboard";
            this.Text = "Bar Code Printing";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDashboard_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDashboard_FormClosed);
            this.Load += new System.EventHandler(this.frmDashboard_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDashboard_KeyDown);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pnlLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlButtons.ResumeLayout(false);
            this.pnlReaLabel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgFrontBumpers)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgBackBumpers)).EndInit();
            this.pnlFrontLabel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel pnlReaLabel;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblRearBump;
        private System.Windows.Forms.Panel pnlFrontLabel;
        private System.Windows.Forms.Label lblFrontBump;
        private System.Windows.Forms.DataGridView dgBackBumpers;
        private System.Windows.Forms.DataGridView dgFrontBumpers;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.Label lblRearStats;
        private System.Windows.Forms.Label lblFrontStats;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnOrderProcessing;
        private System.Windows.Forms.Button btnUploadOrder;
        private System.Windows.Forms.Button btnMasterUpload;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer tmrBlinkRecord;
        private System.Windows.Forms.Timer tmrReloadGrids;
        private System.Windows.Forms.Timer tmrSelectRow;
    }
}