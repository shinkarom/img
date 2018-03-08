namespace img
{
    partial class Form1
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItemNext = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemPrev = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemReload = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemStats = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(284, 262);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemNext,
            this.ToolStripMenuItemPrev,
            this.ToolStripMenuItemDelete,
            this.ToolStripMenuItemReload,
            this.ToolStripMenuItemStats,
            this.ToolStripMenuItemSettings,
            this.ToolStripMenuItemExit});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(126, 158);
            // 
            // ToolStripMenuItemNext
            // 
            this.ToolStripMenuItemNext.Name = "ToolStripMenuItemNext";
            this.ToolStripMenuItemNext.Size = new System.Drawing.Size(125, 22);
            this.ToolStripMenuItemNext.Text = "Next";
            this.ToolStripMenuItemNext.Click += new System.EventHandler(this.nextToolStripMenuItem_Click);
            // 
            // ToolStripMenuItemPrev
            // 
            this.ToolStripMenuItemPrev.Name = "ToolStripMenuItemPrev";
            this.ToolStripMenuItemPrev.Size = new System.Drawing.Size(125, 22);
            this.ToolStripMenuItemPrev.Text = "Previous";
            this.ToolStripMenuItemPrev.Click += new System.EventHandler(this.previousToolStripMenuItem_Click);
            // 
            // ToolStripMenuItemDelete
            // 
            this.ToolStripMenuItemDelete.Name = "ToolStripMenuItemDelete";
            this.ToolStripMenuItemDelete.Size = new System.Drawing.Size(125, 22);
            this.ToolStripMenuItemDelete.Text = "Delete...";
            this.ToolStripMenuItemDelete.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // ToolStripMenuItemReload
            // 
            this.ToolStripMenuItemReload.Name = "ToolStripMenuItemReload";
            this.ToolStripMenuItemReload.Size = new System.Drawing.Size(125, 22);
            this.ToolStripMenuItemReload.Text = "Reload";
            this.ToolStripMenuItemReload.Click += new System.EventHandler(this.reloadToolStripMenuItem_Click);
            // 
            // ToolStripMenuItemStats
            // 
            this.ToolStripMenuItemStats.Name = "ToolStripMenuItemStats";
            this.ToolStripMenuItemStats.Size = new System.Drawing.Size(125, 22);
            this.ToolStripMenuItemStats.Text = "Stats...";
            this.ToolStripMenuItemStats.Click += new System.EventHandler(this.statsToolStripMenuItem_Click);
            // 
            // ToolStripMenuItemSettings
            // 
            this.ToolStripMenuItemSettings.Name = "ToolStripMenuItemSettings";
            this.ToolStripMenuItemSettings.Size = new System.Drawing.Size(125, 22);
            this.ToolStripMenuItemSettings.Text = "Settings...";
            this.ToolStripMenuItemSettings.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // ToolStripMenuItemExit
            // 
            this.ToolStripMenuItemExit.Name = "ToolStripMenuItemExit";
            this.ToolStripMenuItemExit.Size = new System.Drawing.Size(125, 22);
            this.ToolStripMenuItemExit.Text = "Exit";
            this.ToolStripMenuItemExit.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "img";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemNext;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemStats;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemExit;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemPrev;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemSettings;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemDelete;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemReload;
    }
}

