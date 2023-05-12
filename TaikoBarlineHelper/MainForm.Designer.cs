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
            this.components = new System.ComponentModel.Container();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.ToolStripFile = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadBeatmapStripButt = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdateStripButt = new System.Windows.Forms.ToolStripMenuItem();
            this.TimingPointTextBox = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LoadedMapLabel_Name = new System.Windows.Forms.Label();
            this.LoadedMapNameTimer = new System.Windows.Forms.Timer(this.components);
            this.LoadedMapLabel_Diff = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
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
            this.LoadBeatmapStripButt.Size = new System.Drawing.Size(150, 22);
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
            this.TimingPointTextBox.Location = new System.Drawing.Point(12, 45);
            this.TimingPointTextBox.Name = "TimingPointTextBox";
            this.TimingPointTextBox.Size = new System.Drawing.Size(354, 184);
            this.TimingPointTextBox.TabIndex = 1;
            this.TimingPointTextBox.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Barlining:";
            // 
            // LoadedMapLabel_Name
            // 
            this.LoadedMapLabel_Name.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LoadedMapLabel_Name.Location = new System.Drawing.Point(85, 27);
            this.LoadedMapLabel_Name.Name = "LoadedMapLabel_Name";
            this.LoadedMapLabel_Name.Size = new System.Drawing.Size(178, 15);
            this.LoadedMapLabel_Name.TabIndex = 3;
            this.LoadedMapLabel_Name.Text = "Nothing";
            // 
            // LoadedMapLabel_Diff
            // 
            this.LoadedMapLabel_Diff.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LoadedMapLabel_Diff.Location = new System.Drawing.Point(263, 27);
            this.LoadedMapLabel_Diff.Name = "LoadedMapLabel_Diff";
            this.LoadedMapLabel_Diff.Size = new System.Drawing.Size(103, 15);
            this.LoadedMapLabel_Diff.TabIndex = 4;
            this.LoadedMapLabel_Diff.Text = "[Nothing]";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(12, 405);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(354, 33);
            this.button1.TabIndex = 5;
            this.button1.Text = "Barline it!";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.LoadedMapLabel_Diff);
            this.Controls.Add(this.LoadedMapLabel_Name);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TimingPointTextBox);
            this.Controls.Add(this.MenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainForm";
            this.Text = "Taiko Barline Helper";
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
        private Label label1;
        private Label LoadedMapLabel_Name;
        private System.Windows.Forms.Timer LoadedMapNameTimer;
        private Label LoadedMapLabel_Diff;
        private Button button1;
    }
}