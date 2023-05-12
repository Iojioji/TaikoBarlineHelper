namespace TaikoBarlineHelper
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.ToolStripFile = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadBeatmapStripButt = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdateStripButt = new System.Windows.Forms.ToolStripMenuItem();
            this.TimingPointTextBox = new System.Windows.Forms.RichTextBox();
            this.MenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripFile,
            this.UpdateStripButt});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(378, 24);
            this.MenuStrip.TabIndex = 0;
            this.MenuStrip.Text = "menuStrip1";
            // 
            // ToolStripFile
            // 
            this.ToolStripFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LoadBeatmapStripButt});
            this.ToolStripFile.Name = "ToolStripFile";
            this.ToolStripFile.Size = new System.Drawing.Size(37, 20);
            this.ToolStripFile.Text = "File";
            // 
            // LoadBeatmapStripButt
            // 
            this.LoadBeatmapStripButt.Name = "LoadBeatmapStripButt";
            this.LoadBeatmapStripButt.Size = new System.Drawing.Size(180, 22);
            this.LoadBeatmapStripButt.Text = "Load Beatmap";
            this.LoadBeatmapStripButt.Click += new System.EventHandler(this.LoadBeatmapStripButt_Click);
            // 
            // UpdateStripButt
            // 
            this.UpdateStripButt.Name = "UpdateStripButt";
            this.UpdateStripButt.Size = new System.Drawing.Size(115, 20);
            this.UpdateStripButt.Text = "Check for updates";
            this.UpdateStripButt.Click += new System.EventHandler(this.CheckForUpdates_Click);
            // 
            // TimingPointTextBox
            // 
            this.TimingPointTextBox.Location = new System.Drawing.Point(12, 27);
            this.TimingPointTextBox.Name = "TimingPointTextBox";
            this.TimingPointTextBox.Size = new System.Drawing.Size(354, 184);
            this.TimingPointTextBox.TabIndex = 1;
            this.TimingPointTextBox.Text = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 450);
            this.Controls.Add(this.TimingPointTextBox);
            this.Controls.Add(this.MenuStrip);
            this.MainMenuStrip = this.MenuStrip;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip MenuStrip;
        private ToolStripMenuItem ToolStripFile;
        private ToolStripMenuItem LoadBeatmapStripButt;
        private RichTextBox TimingPointTextBox;
        private ToolStripMenuItem UpdateStripButt;
    }
}