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
            components = new System.ComponentModel.Container();
            MenuStrip = new MenuStrip();
            ToolStripFile = new ToolStripMenuItem();
            LoadBeatmapStripButt = new ToolStripMenuItem();
            UpdateStripButt = new ToolStripMenuItem();
            TimingPointTextBox = new RichTextBox();
            label1 = new Label();
            LoadedMapLabel_Name = new Label();
            LoadedMapNameTimer = new System.Windows.Forms.Timer(components);
            LoadedMapLabel_Diff = new Label();
            MakeBarlineButt = new Button();
            OopsButt = new Button();
            TutorialCheckBox = new CheckBox();
            NoteSettingsTablePanel = new TableLayoutPanel();
            DonSettingsPanel = new Panel();
            DonNoteBarlinePanel = new Panel();
            label4 = new Label();
            DonNoteBarlineSVIncrease = new NumericUpDown();
            label3 = new Label();
            DonNoteBarlineSpacing = new NumericUpDown();
            label2 = new Label();
            DonNoteBarlineAmount = new NumericUpDown();
            DonNoteType = new ComboBox();
            DonNoteEnabled = new CheckBox();
            BarlineAmountTooltip = new ToolTip(components);
            BarlineSpacingTooltip = new ToolTip(components);
            BarlineSVIncreaseTooltip = new ToolTip(components);
            LoadedMapTooltip = new ToolTip(components);
            comboBox2 = new ComboBox();
            MenuStrip.SuspendLayout();
            NoteSettingsTablePanel.SuspendLayout();
            DonSettingsPanel.SuspendLayout();
            DonNoteBarlinePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DonNoteBarlineSVIncrease).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DonNoteBarlineSpacing).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DonNoteBarlineAmount).BeginInit();
            SuspendLayout();
            // 
            // MenuStrip
            // 
            MenuStrip.Items.AddRange(new ToolStripItem[] { ToolStripFile, UpdateStripButt });
            MenuStrip.Location = new Point(0, 0);
            MenuStrip.Name = "MenuStrip";
            MenuStrip.Size = new Size(328, 24);
            MenuStrip.TabIndex = 0;
            MenuStrip.Text = "menuStrip1";
            // 
            // ToolStripFile
            // 
            ToolStripFile.DropDownItems.AddRange(new ToolStripItem[] { LoadBeatmapStripButt });
            ToolStripFile.Name = "ToolStripFile";
            ToolStripFile.Size = new Size(37, 20);
            ToolStripFile.Text = "File";
            // 
            // LoadBeatmapStripButt
            // 
            LoadBeatmapStripButt.Name = "LoadBeatmapStripButt";
            LoadBeatmapStripButt.Size = new Size(150, 22);
            LoadBeatmapStripButt.Text = "Load Beatmap";
            LoadBeatmapStripButt.Click += LoadBeatmapStripButt_Click;
            // 
            // UpdateStripButt
            // 
            UpdateStripButt.Name = "UpdateStripButt";
            UpdateStripButt.Size = new Size(115, 20);
            UpdateStripButt.Text = "Check for updates";
            UpdateStripButt.Click += CheckForUpdates_Click;
            // 
            // TimingPointTextBox
            // 
            TimingPointTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TimingPointTextBox.Location = new Point(12, 45);
            TimingPointTextBox.Name = "TimingPointTextBox";
            TimingPointTextBox.Size = new Size(304, 107);
            TimingPointTextBox.TabIndex = 1;
            TimingPointTextBox.Text = "8004,-100,4,1,0,80,0,0";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Consolas", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 27);
            label1.Name = "label1";
            label1.Size = new Size(67, 13);
            label1.TabIndex = 2;
            label1.Text = "Barlining:";
            // 
            // LoadedMapLabel_Name
            // 
            LoadedMapLabel_Name.Font = new Font("Consolas", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            LoadedMapLabel_Name.Location = new Point(85, 27);
            LoadedMapLabel_Name.Name = "LoadedMapLabel_Name";
            LoadedMapLabel_Name.Size = new Size(135, 15);
            LoadedMapLabel_Name.TabIndex = 3;
            LoadedMapLabel_Name.Text = "Nothing";
            // 
            // LoadedMapLabel_Diff
            // 
            LoadedMapLabel_Diff.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            LoadedMapLabel_Diff.Font = new Font("Consolas", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            LoadedMapLabel_Diff.Location = new Point(226, 27);
            LoadedMapLabel_Diff.Name = "LoadedMapLabel_Diff";
            LoadedMapLabel_Diff.Size = new Size(90, 15);
            LoadedMapLabel_Diff.TabIndex = 4;
            LoadedMapLabel_Diff.Text = "[Nothing]";
            // 
            // MakeBarlineButt
            // 
            MakeBarlineButt.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            MakeBarlineButt.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            MakeBarlineButt.Location = new Point(12, 388);
            MakeBarlineButt.Name = "MakeBarlineButt";
            MakeBarlineButt.Size = new Size(304, 33);
            MakeBarlineButt.TabIndex = 5;
            MakeBarlineButt.Text = "Barline it!";
            MakeBarlineButt.UseVisualStyleBackColor = true;
            MakeBarlineButt.Click += MakeBarlineBut_Click;
            // 
            // OopsButt
            // 
            OopsButt.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            OopsButt.Enabled = false;
            OopsButt.Location = new Point(241, 359);
            OopsButt.Name = "OopsButt";
            OopsButt.Size = new Size(75, 23);
            OopsButt.TabIndex = 6;
            OopsButt.Text = "Oops";
            OopsButt.UseVisualStyleBackColor = true;
            OopsButt.Click += OopsButt_Click;
            // 
            // TutorialCheckBox
            // 
            TutorialCheckBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            TutorialCheckBox.AutoSize = true;
            TutorialCheckBox.Location = new Point(158, 362);
            TutorialCheckBox.Name = "TutorialCheckBox";
            TutorialCheckBox.Size = new Size(77, 19);
            TutorialCheckBox.TabIndex = 0;
            TutorialCheckBox.Text = "Is Tutorial";
            TutorialCheckBox.UseVisualStyleBackColor = true;
            // 
            // NoteSettingsTablePanel
            // 
            NoteSettingsTablePanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            NoteSettingsTablePanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.OutsetPartial;
            NoteSettingsTablePanel.ColumnCount = 2;
            NoteSettingsTablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            NoteSettingsTablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            NoteSettingsTablePanel.Controls.Add(DonSettingsPanel, 0, 0);
            NoteSettingsTablePanel.Location = new Point(12, 158);
            NoteSettingsTablePanel.Name = "NoteSettingsTablePanel";
            NoteSettingsTablePanel.RowCount = 2;
            NoteSettingsTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            NoteSettingsTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            NoteSettingsTablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            NoteSettingsTablePanel.Size = new Size(304, 195);
            NoteSettingsTablePanel.TabIndex = 7;
            // 
            // DonSettingsPanel
            // 
            DonSettingsPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DonSettingsPanel.Controls.Add(DonNoteBarlinePanel);
            DonSettingsPanel.Controls.Add(DonNoteType);
            DonSettingsPanel.Controls.Add(DonNoteEnabled);
            DonSettingsPanel.Controls.Add(comboBox2);
            DonSettingsPanel.Location = new Point(3, 3);
            DonSettingsPanel.Margin = new Padding(0);
            DonSettingsPanel.Name = "DonSettingsPanel";
            DonSettingsPanel.Size = new Size(147, 93);
            DonSettingsPanel.TabIndex = 4;
            // 
            // DonNoteBarlinePanel
            // 
            DonNoteBarlinePanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DonNoteBarlinePanel.Controls.Add(label4);
            DonNoteBarlinePanel.Controls.Add(DonNoteBarlineSVIncrease);
            DonNoteBarlinePanel.Controls.Add(label3);
            DonNoteBarlinePanel.Controls.Add(DonNoteBarlineSpacing);
            DonNoteBarlinePanel.Controls.Add(label2);
            DonNoteBarlinePanel.Controls.Add(DonNoteBarlineAmount);
            DonNoteBarlinePanel.Location = new Point(0, 21);
            DonNoteBarlinePanel.Margin = new Padding(0);
            DonNoteBarlinePanel.Name = "DonNoteBarlinePanel";
            DonNoteBarlinePanel.Size = new Size(147, 72);
            DonNoteBarlinePanel.TabIndex = 3;
            // 
            // label4
            // 
            label4.Location = new Point(3, 49);
            label4.Name = "label4";
            label4.Size = new Size(78, 20);
            label4.TabIndex = 5;
            label4.Text = "SV Change:";
            label4.TextAlign = ContentAlignment.MiddleRight;
            BarlineSVIncreaseTooltip.SetToolTip(label4, "How much each consecutive barline should increase SV by");
            // 
            // DonNoteBarlineSVIncrease
            // 
            DonNoteBarlineSVIncrease.DecimalPlaces = 4;
            DonNoteBarlineSVIncrease.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            DonNoteBarlineSVIncrease.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            DonNoteBarlineSVIncrease.Location = new Point(87, 49);
            DonNoteBarlineSVIncrease.Name = "DonNoteBarlineSVIncrease";
            DonNoteBarlineSVIncrease.Size = new Size(57, 20);
            DonNoteBarlineSVIncrease.TabIndex = 4;
            BarlineSVIncreaseTooltip.SetToolTip(DonNoteBarlineSVIncrease, "How much each consecutive barline should increase SV by\r\nUse this to make \"fanning\" barlines");
            // 
            // label3
            // 
            label3.Location = new Point(3, 26);
            label3.Name = "label3";
            label3.Size = new Size(93, 20);
            label3.TabIndex = 3;
            label3.Text = "Barline Spacing:";
            label3.TextAlign = ContentAlignment.MiddleRight;
            BarlineSpacingTooltip.SetToolTip(label3, "How many MS the barlines should space away from each other \r\n(only applicable if you're adding more than 1 barline)");
            // 
            // DonNoteBarlineSpacing
            // 
            DonNoteBarlineSpacing.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            DonNoteBarlineSpacing.Location = new Point(102, 26);
            DonNoteBarlineSpacing.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            DonNoteBarlineSpacing.Name = "DonNoteBarlineSpacing";
            DonNoteBarlineSpacing.Size = new Size(42, 20);
            DonNoteBarlineSpacing.TabIndex = 2;
            BarlineSpacingTooltip.SetToolTip(DonNoteBarlineSpacing, "How many MS the barlines should space away from each other ");
            DonNoteBarlineSpacing.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // label2
            // 
            label2.Location = new Point(3, 3);
            label2.Name = "label2";
            label2.Size = new Size(93, 20);
            label2.TabIndex = 1;
            label2.Text = "Barline Amount:";
            label2.TextAlign = ContentAlignment.MiddleRight;
            BarlineAmountTooltip.SetToolTip(label2, "The amount of barlines to add after (and before) the selected object. The total barlines to add is double this number.");
            // 
            // DonNoteBarlineAmount
            // 
            DonNoteBarlineAmount.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            DonNoteBarlineAmount.Location = new Point(102, 3);
            DonNoteBarlineAmount.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            DonNoteBarlineAmount.Name = "DonNoteBarlineAmount";
            DonNoteBarlineAmount.Size = new Size(42, 20);
            DonNoteBarlineAmount.TabIndex = 0;
            BarlineAmountTooltip.SetToolTip(DonNoteBarlineAmount, "The amount of barlines to add after (and before) the selected object. The total barlines to add is double this number.");
            DonNoteBarlineAmount.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // DonNoteType
            // 
            DonNoteType.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            DonNoteType.Enabled = false;
            DonNoteType.Font = new Font("Segoe UI", 6F, FontStyle.Regular, GraphicsUnit.Point);
            DonNoteType.FormattingEnabled = true;
            DonNoteType.ItemHeight = 11;
            DonNoteType.Items.AddRange(new object[] { "Barline", "Slider" });
            DonNoteType.Location = new Point(200, 6);
            DonNoteType.Margin = new Padding(0, 3, 3, 3);
            DonNoteType.Name = "DonNoteType";
            DonNoteType.Size = new Size(98, 19);
            DonNoteType.TabIndex = 0;
            DonNoteType.Text = "Barline";
            // 
            // DonNoteEnabled
            // 
            DonNoteEnabled.Checked = true;
            DonNoteEnabled.CheckState = CheckState.Checked;
            DonNoteEnabled.Location = new Point(3, 2);
            DonNoteEnabled.Name = "DonNoteEnabled";
            DonNoteEnabled.Size = new Size(48, 16);
            DonNoteEnabled.TabIndex = 2;
            DonNoteEnabled.Text = "Don";
            DonNoteEnabled.UseVisualStyleBackColor = true;
            DonNoteEnabled.CheckedChanged += DonNoteEnabled_CheckedChanged;
            // 
            // comboBox2
            // 
            comboBox2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comboBox2.Enabled = false;
            comboBox2.Font = new Font("Segoe UI", 6F, FontStyle.Regular, GraphicsUnit.Point);
            comboBox2.FormattingEnabled = true;
            comboBox2.ItemHeight = 11;
            comboBox2.Items.AddRange(new object[] { "Barline", "Slider" });
            comboBox2.Location = new Point(54, 1);
            comboBox2.Margin = new Padding(0, 3, 3, 3);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(93, 19);
            comboBox2.TabIndex = 0;
            comboBox2.Text = "Barline";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(328, 433);
            Controls.Add(NoteSettingsTablePanel);
            Controls.Add(TutorialCheckBox);
            Controls.Add(OopsButt);
            Controls.Add(MakeBarlineButt);
            Controls.Add(LoadedMapLabel_Diff);
            Controls.Add(LoadedMapLabel_Name);
            Controls.Add(label1);
            Controls.Add(TimingPointTextBox);
            Controls.Add(MenuStrip);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            Name = "MainForm";
            Text = "Taiko Barline Helper";
            Load += MainForm_Load;
            MenuStrip.ResumeLayout(false);
            MenuStrip.PerformLayout();
            NoteSettingsTablePanel.ResumeLayout(false);
            DonSettingsPanel.ResumeLayout(false);
            DonNoteBarlinePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DonNoteBarlineSVIncrease).EndInit();
            ((System.ComponentModel.ISupportInitialize)DonNoteBarlineSpacing).EndInit();
            ((System.ComponentModel.ISupportInitialize)DonNoteBarlineAmount).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
        private Button MakeBarlineButt;
        private Button OopsButt;
        private CheckBox TutorialCheckBox;
        private TableLayoutPanel NoteSettingsTablePanel;
        private ComboBox DonNoteType;
        private Panel DonSettingsPanel;
        private CheckBox DonNoteEnabled;
        private Panel DonNoteBarlinePanel;
        private Label label2;
        private NumericUpDown DonNoteBarlineAmount;
        private ToolTip BarlineAmountTooltip;
        private Label label3;
        private NumericUpDown DonNoteBarlineSpacing;
        private ToolTip BarlineSpacingTooltip;
        private Label label4;
        private NumericUpDown DonNoteBarlineSVIncrease;
        private ToolTip BarlineSVIncreaseTooltip;
        private ToolTip LoadedMapTooltip;
        private ComboBox comboBox2;
    }
}