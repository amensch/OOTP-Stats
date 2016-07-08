namespace OOTP_Stats
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.dgView = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbBatters = new System.Windows.Forms.ToolStripButton();
            this.tsbPitchers = new System.Windows.Forms.ToolStripButton();
            this.tsbYearByYear = new System.Windows.Forms.ToolStripButton();
            this.tsbCareer = new System.Windows.Forms.ToolStripButton();
            this.tsbSingleSeason = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgView)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgView
            // 
            this.dgView.AllowUserToAddRows = false;
            this.dgView.AllowUserToDeleteRows = false;
            this.dgView.AllowUserToOrderColumns = true;
            this.dgView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgView.Location = new System.Drawing.Point(0, 25);
            this.dgView.Name = "dgView";
            this.dgView.ReadOnly = true;
            this.dgView.Size = new System.Drawing.Size(916, 553);
            this.dgView.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbBatters,
            this.tsbPitchers,
            this.tsbYearByYear,
            this.tsbCareer,
            this.tsbSingleSeason});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(916, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbBatters
            // 
            this.tsbBatters.CheckOnClick = true;
            this.tsbBatters.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbBatters.Image = ((System.Drawing.Image)(resources.GetObject("tsbBatters.Image")));
            this.tsbBatters.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBatters.Name = "tsbBatters";
            this.tsbBatters.Size = new System.Drawing.Size(47, 22);
            this.tsbBatters.Text = "Batters";
            this.tsbBatters.Click += new System.EventHandler(this.tsbBatters_Click);
            // 
            // tsbPitchers
            // 
            this.tsbPitchers.CheckOnClick = true;
            this.tsbPitchers.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbPitchers.Image = ((System.Drawing.Image)(resources.GetObject("tsbPitchers.Image")));
            this.tsbPitchers.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPitchers.Name = "tsbPitchers";
            this.tsbPitchers.Size = new System.Drawing.Size(53, 22);
            this.tsbPitchers.Text = "Pitchers";
            this.tsbPitchers.Click += new System.EventHandler(this.tsbPitchers_Click);
            // 
            // tsbYearByYear
            // 
            this.tsbYearByYear.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbYearByYear.CheckOnClick = true;
            this.tsbYearByYear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbYearByYear.Image = ((System.Drawing.Image)(resources.GetObject("tsbYearByYear.Image")));
            this.tsbYearByYear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbYearByYear.Name = "tsbYearByYear";
            this.tsbYearByYear.Size = new System.Drawing.Size(76, 22);
            this.tsbYearByYear.Text = "Year by Year";
            this.tsbYearByYear.Click += new System.EventHandler(this.tsbYearByYear_Click);
            // 
            // tsbCareer
            // 
            this.tsbCareer.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbCareer.CheckOnClick = true;
            this.tsbCareer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbCareer.Image = ((System.Drawing.Image)(resources.GetObject("tsbCareer.Image")));
            this.tsbCareer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCareer.Name = "tsbCareer";
            this.tsbCareer.Size = new System.Drawing.Size(45, 22);
            this.tsbCareer.Text = "Career";
            this.tsbCareer.Click += new System.EventHandler(this.tsbCareer_Click);
            // 
            // tsbSingleSeason
            // 
            this.tsbSingleSeason.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbSingleSeason.CheckOnClick = true;
            this.tsbSingleSeason.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbSingleSeason.Image = ((System.Drawing.Image)(resources.GetObject("tsbSingleSeason.Image")));
            this.tsbSingleSeason.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSingleSeason.Name = "tsbSingleSeason";
            this.tsbSingleSeason.Size = new System.Drawing.Size(83, 22);
            this.tsbSingleSeason.Text = "Single Season";
            this.tsbSingleSeason.Click += new System.EventHandler(this.tsbSingleSeason_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 578);
            this.Controls.Add(this.dgView);
            this.Controls.Add(this.toolStrip1);
            this.Name = "MainForm";
            this.Text = "OOTP Statistics";
            ((System.ComponentModel.ISupportInitialize)(this.dgView)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgView;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbBatters;
        private System.Windows.Forms.ToolStripButton tsbPitchers;
        private System.Windows.Forms.ToolStripButton tsbYearByYear;
        private System.Windows.Forms.ToolStripButton tsbCareer;
        private System.Windows.Forms.ToolStripButton tsbSingleSeason;
    }
}

