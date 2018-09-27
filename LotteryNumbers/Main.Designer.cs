namespace LotteryNumbers
{
    partial class FrmMain
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gbxDate = new System.Windows.Forms.GroupBox();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgvDrawings = new System.Windows.Forms.DataGridView();
            this.gbxSpecialPlay = new System.Windows.Forms.GroupBox();
            this.txtSpecialPlay = new System.Windows.Forms.TextBox();
            this.gbxSpecialNumber = new System.Windows.Forms.GroupBox();
            this.txtSpecialNumber = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNumber5 = new System.Windows.Forms.TextBox();
            this.txtNumber3 = new System.Windows.Forms.TextBox();
            this.txtNumber4 = new System.Windows.Forms.TextBox();
            this.txtNumber1 = new System.Windows.Forms.TextBox();
            this.txtNumber2 = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbxByNumber = new System.Windows.Forms.CheckBox();
            this.cbxLeastFirst = new System.Windows.Forms.CheckBox();
            this.dgvNumberOccurrences = new System.Windows.Forms.DataGridView();
            this.dgvGenerated = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.nudTotalDrawings = new System.Windows.Forms.NumericUpDown();
            this.cbxFilter = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.cbxLotteries = new System.Windows.Forms.ComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tslblLotteryName = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.gbxDate.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDrawings)).BeginInit();
            this.gbxSpecialPlay.SuspendLayout();
            this.gbxSpecialNumber.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNumberOccurrences)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGenerated)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotalDrawings)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 71);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(702, 355);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gbxDate);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.gbxSpecialPlay);
            this.tabPage1.Controls.Add(this.gbxSpecialNumber);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(694, 329);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Numbers";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // gbxDate
            // 
            this.gbxDate.BackColor = System.Drawing.Color.Transparent;
            this.gbxDate.Controls.Add(this.txtDate);
            this.gbxDate.Location = new System.Drawing.Point(6, 6);
            this.gbxDate.Name = "gbxDate";
            this.gbxDate.Size = new System.Drawing.Size(208, 48);
            this.gbxDate.TabIndex = 9;
            this.gbxDate.TabStop = false;
            this.gbxDate.Text = "Date";
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(6, 17);
            this.txtDate.Name = "txtDate";
            this.txtDate.ReadOnly = true;
            this.txtDate.Size = new System.Drawing.Size(196, 20);
            this.txtDate.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.dgvDrawings);
            this.groupBox4.Location = new System.Drawing.Point(6, 65);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(678, 258);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Past Numers";
            // 
            // dgvDrawings
            // 
            this.dgvDrawings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDrawings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvDrawings.Location = new System.Drawing.Point(6, 19);
            this.dgvDrawings.MultiSelect = false;
            this.dgvDrawings.Name = "dgvDrawings";
            this.dgvDrawings.ReadOnly = true;
            this.dgvDrawings.RowHeadersVisible = false;
            this.dgvDrawings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDrawings.Size = new System.Drawing.Size(662, 233);
            this.dgvDrawings.TabIndex = 0;
            this.dgvDrawings.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DgvDrawings_CellFormatting);
            this.dgvDrawings.SelectionChanged += new System.EventHandler(this.DgvDrawings_SelectionChanged);
            // 
            // gbxSpecialPlay
            // 
            this.gbxSpecialPlay.BackColor = System.Drawing.Color.Transparent;
            this.gbxSpecialPlay.Controls.Add(this.txtSpecialPlay);
            this.gbxSpecialPlay.Location = new System.Drawing.Point(594, 6);
            this.gbxSpecialPlay.Name = "gbxSpecialPlay";
            this.gbxSpecialPlay.Size = new System.Drawing.Size(90, 48);
            this.gbxSpecialPlay.TabIndex = 7;
            this.gbxSpecialPlay.TabStop = false;
            // 
            // txtSpecialPlay
            // 
            this.txtSpecialPlay.Location = new System.Drawing.Point(6, 17);
            this.txtSpecialPlay.Name = "txtSpecialPlay";
            this.txtSpecialPlay.ReadOnly = true;
            this.txtSpecialPlay.Size = new System.Drawing.Size(74, 20);
            this.txtSpecialPlay.TabIndex = 0;
            this.txtSpecialPlay.TextChanged += new System.EventHandler(this.Txt_TextChanged);
            // 
            // gbxSpecialNumber
            // 
            this.gbxSpecialNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.gbxSpecialNumber.Controls.Add(this.txtSpecialNumber);
            this.gbxSpecialNumber.Location = new System.Drawing.Point(498, 6);
            this.gbxSpecialNumber.Name = "gbxSpecialNumber";
            this.gbxSpecialNumber.Size = new System.Drawing.Size(90, 48);
            this.gbxSpecialNumber.TabIndex = 6;
            this.gbxSpecialNumber.TabStop = false;
            // 
            // txtSpecialNumber
            // 
            this.txtSpecialNumber.Location = new System.Drawing.Point(6, 17);
            this.txtSpecialNumber.Name = "txtSpecialNumber";
            this.txtSpecialNumber.ReadOnly = true;
            this.txtSpecialNumber.Size = new System.Drawing.Size(78, 20);
            this.txtSpecialNumber.TabIndex = 0;
            this.txtSpecialNumber.TextChanged += new System.EventHandler(this.Txt_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNumber5);
            this.groupBox1.Controls.Add(this.txtNumber3);
            this.groupBox1.Controls.Add(this.txtNumber4);
            this.groupBox1.Controls.Add(this.txtNumber1);
            this.groupBox1.Controls.Add(this.txtNumber2);
            this.groupBox1.Location = new System.Drawing.Point(220, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 48);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Numbers";
            // 
            // txtNumber5
            // 
            this.txtNumber5.Location = new System.Drawing.Point(214, 17);
            this.txtNumber5.Name = "txtNumber5";
            this.txtNumber5.ReadOnly = true;
            this.txtNumber5.Size = new System.Drawing.Size(46, 20);
            this.txtNumber5.TabIndex = 5;
            this.txtNumber5.TextChanged += new System.EventHandler(this.Txt_TextChanged);
            // 
            // txtNumber3
            // 
            this.txtNumber3.Location = new System.Drawing.Point(110, 17);
            this.txtNumber3.Name = "txtNumber3";
            this.txtNumber3.ReadOnly = true;
            this.txtNumber3.Size = new System.Drawing.Size(46, 20);
            this.txtNumber3.TabIndex = 3;
            this.txtNumber3.TextChanged += new System.EventHandler(this.Txt_TextChanged);
            // 
            // txtNumber4
            // 
            this.txtNumber4.Location = new System.Drawing.Point(162, 17);
            this.txtNumber4.Name = "txtNumber4";
            this.txtNumber4.ReadOnly = true;
            this.txtNumber4.Size = new System.Drawing.Size(46, 20);
            this.txtNumber4.TabIndex = 4;
            this.txtNumber4.TextChanged += new System.EventHandler(this.Txt_TextChanged);
            // 
            // txtNumber1
            // 
            this.txtNumber1.Location = new System.Drawing.Point(6, 17);
            this.txtNumber1.Name = "txtNumber1";
            this.txtNumber1.ReadOnly = true;
            this.txtNumber1.Size = new System.Drawing.Size(46, 20);
            this.txtNumber1.TabIndex = 0;
            this.txtNumber1.TextChanged += new System.EventHandler(this.Txt_TextChanged);
            // 
            // txtNumber2
            // 
            this.txtNumber2.Location = new System.Drawing.Point(58, 17);
            this.txtNumber2.Name = "txtNumber2";
            this.txtNumber2.ReadOnly = true;
            this.txtNumber2.Size = new System.Drawing.Size(46, 20);
            this.txtNumber2.TabIndex = 2;
            this.txtNumber2.TextChanged += new System.EventHandler(this.Txt_TextChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.dgvGenerated);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(694, 329);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Stats";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbxByNumber);
            this.groupBox3.Controls.Add(this.cbxLeastFirst);
            this.groupBox3.Controls.Add(this.dgvNumberOccurrences);
            this.groupBox3.Location = new System.Drawing.Point(515, 68);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(173, 255);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Most && Least";
            // 
            // cbxByNumber
            // 
            this.cbxByNumber.AutoSize = true;
            this.cbxByNumber.Location = new System.Drawing.Point(92, 21);
            this.cbxByNumber.Name = "cbxByNumber";
            this.cbxByNumber.Size = new System.Drawing.Size(77, 17);
            this.cbxByNumber.TabIndex = 2;
            this.cbxByNumber.Text = "by Number";
            this.cbxByNumber.UseVisualStyleBackColor = true;
            this.cbxByNumber.CheckedChanged += new System.EventHandler(this.CbxLeastFirst_CheckedChanged);
            // 
            // cbxLeastFirst
            // 
            this.cbxLeastFirst.AutoSize = true;
            this.cbxLeastFirst.Location = new System.Drawing.Point(12, 21);
            this.cbxLeastFirst.Name = "cbxLeastFirst";
            this.cbxLeastFirst.Size = new System.Drawing.Size(74, 17);
            this.cbxLeastFirst.TabIndex = 1;
            this.cbxLeastFirst.Text = "Least First";
            this.cbxLeastFirst.UseVisualStyleBackColor = true;
            this.cbxLeastFirst.CheckedChanged += new System.EventHandler(this.CbxLeastFirst_CheckedChanged);
            // 
            // dgvNumberOccurrences
            // 
            this.dgvNumberOccurrences.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvNumberOccurrences.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNumberOccurrences.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNumberOccurrences.Location = new System.Drawing.Point(6, 45);
            this.dgvNumberOccurrences.Name = "dgvNumberOccurrences";
            this.dgvNumberOccurrences.ReadOnly = true;
            this.dgvNumberOccurrences.RowHeadersVisible = false;
            this.dgvNumberOccurrences.Size = new System.Drawing.Size(161, 204);
            this.dgvNumberOccurrences.TabIndex = 0;
            // 
            // dgvGenerated
            // 
            this.dgvGenerated.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvGenerated.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGenerated.Location = new System.Drawing.Point(6, 68);
            this.dgvGenerated.Name = "dgvGenerated";
            this.dgvGenerated.RowHeadersVisible = false;
            this.dgvGenerated.Size = new System.Drawing.Size(503, 255);
            this.dgvGenerated.TabIndex = 7;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.nudTotalDrawings);
            this.groupBox2.Controls.Add(this.cbxFilter);
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(575, 56);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filter";
            // 
            // nudTotalDrawings
            // 
            this.nudTotalDrawings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudTotalDrawings.Location = new System.Drawing.Point(467, 19);
            this.nudTotalDrawings.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudTotalDrawings.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudTotalDrawings.Name = "nudTotalDrawings";
            this.nudTotalDrawings.Size = new System.Drawing.Size(99, 20);
            this.nudTotalDrawings.TabIndex = 5;
            this.nudTotalDrawings.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // cbxFilter
            // 
            this.cbxFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxFilter.FormattingEnabled = true;
            this.cbxFilter.Location = new System.Drawing.Point(6, 19);
            this.cbxFilter.Name = "cbxFilter";
            this.cbxFilter.Size = new System.Drawing.Size(455, 21);
            this.cbxFilter.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(587, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 46);
            this.button1.TabIndex = 5;
            this.button1.Text = "Generate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnUpdate);
            this.groupBox5.Controls.Add(this.cbxLotteries);
            this.groupBox5.Location = new System.Drawing.Point(12, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(702, 51);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Lottery";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Location = new System.Drawing.Point(572, 19);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(120, 21);
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // cbxLotteries
            // 
            this.cbxLotteries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxLotteries.FormattingEnabled = true;
            this.cbxLotteries.Location = new System.Drawing.Point(10, 19);
            this.cbxLotteries.Name = "cbxLotteries";
            this.cbxLotteries.Size = new System.Drawing.Size(552, 21);
            this.cbxLotteries.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar,
            this.tslblLotteryName});
            this.statusStrip1.Location = new System.Drawing.Point(0, 436);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(726, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tslblLotteryName
            // 
            this.tslblLotteryName.Name = "tslblLotteryName";
            this.tslblLotteryName.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripProgressBar.AutoSize = false;
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 458);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmMain";
            this.Text = "Lottery Numbers Generator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.gbxDate.ResumeLayout(false);
            this.gbxDate.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDrawings)).EndInit();
            this.gbxSpecialPlay.ResumeLayout(false);
            this.gbxSpecialPlay.PerformLayout();
            this.gbxSpecialNumber.ResumeLayout(false);
            this.gbxSpecialNumber.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNumberOccurrences)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGenerated)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudTotalDrawings)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dgvDrawings;
        private System.Windows.Forms.GroupBox gbxSpecialPlay;
        private System.Windows.Forms.TextBox txtSpecialPlay;
        private System.Windows.Forms.GroupBox gbxSpecialNumber;
        private System.Windows.Forms.TextBox txtSpecialNumber;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtNumber5;
        private System.Windows.Forms.TextBox txtNumber3;
        private System.Windows.Forms.TextBox txtNumber4;
        private System.Windows.Forms.TextBox txtNumber1;
        private System.Windows.Forms.TextBox txtNumber2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox cbxLotteries;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel tslblLotteryName;
        private System.Windows.Forms.GroupBox gbxDate;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.DataGridView dgvGenerated;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbxFilter;
        private System.Windows.Forms.NumericUpDown nudTotalDrawings;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox cbxLeastFirst;
        private System.Windows.Forms.DataGridView dgvNumberOccurrences;
        private System.Windows.Forms.CheckBox cbxByNumber;
    }
}

