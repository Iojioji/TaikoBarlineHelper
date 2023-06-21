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
            DonNoteEnabled = new CheckBox();
            DonNoteGimmickType = new ComboBox();
            KatSettingsPanel = new Panel();
            KatNoteBarlinePanel = new Panel();
            label5 = new Label();
            KatNoteBarlineSVIncrease = new NumericUpDown();
            label6 = new Label();
            KatNoteBarlineSpacing = new NumericUpDown();
            label7 = new Label();
            KatNoteBarlineAmount = new NumericUpDown();
            KatNoteEnabled = new CheckBox();
            comboBox3 = new ComboBox();
            DonFinisherSettingsPanel = new Panel();
            DonFinisherNoteBarlinePanel = new Panel();
            label8 = new Label();
            DonFinisherNoteBarlineSVIncrease = new NumericUpDown();
            label9 = new Label();
            DonFinisherNoteBarlineSpacing = new NumericUpDown();
            label10 = new Label();
            DonFinisherNoteBarlineAmount = new NumericUpDown();
            DonFinisherNoteEnabled = new CheckBox();
            comboBox5 = new ComboBox();
            KatFinisherSettingsPanel = new Panel();
            KatFinisherNoteBarlinePanel = new Panel();
            label11 = new Label();
            KatFinisherNoteBarlineSVIncrease = new NumericUpDown();
            label12 = new Label();
            KatFinisherNoteBarlineSpacing = new NumericUpDown();
            label13 = new Label();
            KatFinisherNoteBarlineAmount = new NumericUpDown();
            KatFinisherNoteEnabled = new CheckBox();
            comboBox7 = new ComboBox();
            BarlineAmountTooltip = new ToolTip(components);
            BarlineSpacingTooltip = new ToolTip(components);
            BarlineSVIncreaseTooltip = new ToolTip(components);
            LoadedMapTooltip = new ToolTip(components);
            MenuStrip.SuspendLayout();
            NoteSettingsTablePanel.SuspendLayout();
            DonSettingsPanel.SuspendLayout();
            DonNoteBarlinePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DonNoteBarlineSVIncrease).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DonNoteBarlineSpacing).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DonNoteBarlineAmount).BeginInit();
            KatSettingsPanel.SuspendLayout();
            KatNoteBarlinePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)KatNoteBarlineSVIncrease).BeginInit();
            ((System.ComponentModel.ISupportInitialize)KatNoteBarlineSpacing).BeginInit();
            ((System.ComponentModel.ISupportInitialize)KatNoteBarlineAmount).BeginInit();
            DonFinisherSettingsPanel.SuspendLayout();
            DonFinisherNoteBarlinePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DonFinisherNoteBarlineSVIncrease).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DonFinisherNoteBarlineSpacing).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DonFinisherNoteBarlineAmount).BeginInit();
            KatFinisherSettingsPanel.SuspendLayout();
            KatFinisherNoteBarlinePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)KatFinisherNoteBarlineSVIncrease).BeginInit();
            ((System.ComponentModel.ISupportInitialize)KatFinisherNoteBarlineSpacing).BeginInit();
            ((System.ComponentModel.ISupportInitialize)KatFinisherNoteBarlineAmount).BeginInit();
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
            TimingPointTextBox.Text = "";
            TimingPointTextBox.TextChanged += TimingPointTextBox_TextChanged;
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
            NoteSettingsTablePanel.Controls.Add(KatSettingsPanel, 1, 0);
            NoteSettingsTablePanel.Controls.Add(DonFinisherSettingsPanel, 0, 1);
            NoteSettingsTablePanel.Controls.Add(KatFinisherSettingsPanel, 1, 1);
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
            DonSettingsPanel.Controls.Add(DonNoteEnabled);
            DonSettingsPanel.Controls.Add(DonNoteGimmickType);
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
            // DonNoteEnabled
            // 
            DonNoteEnabled.Checked = true;
            DonNoteEnabled.CheckState = CheckState.Checked;
            DonNoteEnabled.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            DonNoteEnabled.Location = new Point(3, 2);
            DonNoteEnabled.Name = "DonNoteEnabled";
            DonNoteEnabled.Size = new Size(68, 16);
            DonNoteEnabled.TabIndex = 2;
            DonNoteEnabled.Text = "Don";
            DonNoteEnabled.UseVisualStyleBackColor = true;
            DonNoteEnabled.CheckedChanged += NoteEnabled_CheckedChanged;
            // 
            // DonNoteGimmickType
            // 
            DonNoteGimmickType.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            DonNoteGimmickType.Enabled = false;
            DonNoteGimmickType.Font = new Font("Segoe UI", 6F, FontStyle.Regular, GraphicsUnit.Point);
            DonNoteGimmickType.FormattingEnabled = true;
            DonNoteGimmickType.ItemHeight = 11;
            DonNoteGimmickType.Items.AddRange(new object[] { "Barline", "Inv. Barline", "Slider" });
            DonNoteGimmickType.Location = new Point(74, 2);
            DonNoteGimmickType.Margin = new Padding(0, 3, 3, 3);
            DonNoteGimmickType.Name = "DonNoteGimmickType";
            DonNoteGimmickType.Size = new Size(71, 19);
            DonNoteGimmickType.TabIndex = 0;
            DonNoteGimmickType.Text = "Barline";
            // 
            // KatSettingsPanel
            // 
            KatSettingsPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            KatSettingsPanel.Controls.Add(KatNoteBarlinePanel);
            KatSettingsPanel.Controls.Add(KatNoteEnabled);
            KatSettingsPanel.Controls.Add(comboBox3);
            KatSettingsPanel.Location = new Point(153, 3);
            KatSettingsPanel.Margin = new Padding(0);
            KatSettingsPanel.Name = "KatSettingsPanel";
            KatSettingsPanel.Size = new Size(148, 93);
            KatSettingsPanel.TabIndex = 4;
            // 
            // KatNoteBarlinePanel
            // 
            KatNoteBarlinePanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            KatNoteBarlinePanel.Controls.Add(label5);
            KatNoteBarlinePanel.Controls.Add(KatNoteBarlineSVIncrease);
            KatNoteBarlinePanel.Controls.Add(label6);
            KatNoteBarlinePanel.Controls.Add(KatNoteBarlineSpacing);
            KatNoteBarlinePanel.Controls.Add(label7);
            KatNoteBarlinePanel.Controls.Add(KatNoteBarlineAmount);
            KatNoteBarlinePanel.Location = new Point(0, 21);
            KatNoteBarlinePanel.Margin = new Padding(0);
            KatNoteBarlinePanel.Name = "KatNoteBarlinePanel";
            KatNoteBarlinePanel.Size = new Size(148, 72);
            KatNoteBarlinePanel.TabIndex = 3;
            // 
            // label5
            // 
            label5.Location = new Point(3, 49);
            label5.Name = "label5";
            label5.Size = new Size(78, 20);
            label5.TabIndex = 5;
            label5.Text = "SV Change:";
            label5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // KatNoteBarlineSVIncrease
            // 
            KatNoteBarlineSVIncrease.DecimalPlaces = 4;
            KatNoteBarlineSVIncrease.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            KatNoteBarlineSVIncrease.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            KatNoteBarlineSVIncrease.Location = new Point(87, 49);
            KatNoteBarlineSVIncrease.Name = "KatNoteBarlineSVIncrease";
            KatNoteBarlineSVIncrease.Size = new Size(57, 20);
            KatNoteBarlineSVIncrease.TabIndex = 4;
            // 
            // label6
            // 
            label6.Location = new Point(3, 26);
            label6.Name = "label6";
            label6.Size = new Size(93, 20);
            label6.TabIndex = 3;
            label6.Text = "Barline Spacing:";
            label6.TextAlign = ContentAlignment.MiddleRight;
            // 
            // KatNoteBarlineSpacing
            // 
            KatNoteBarlineSpacing.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            KatNoteBarlineSpacing.Location = new Point(102, 26);
            KatNoteBarlineSpacing.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            KatNoteBarlineSpacing.Name = "KatNoteBarlineSpacing";
            KatNoteBarlineSpacing.Size = new Size(42, 20);
            KatNoteBarlineSpacing.TabIndex = 2;
            KatNoteBarlineSpacing.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // label7
            // 
            label7.Location = new Point(3, 3);
            label7.Name = "label7";
            label7.Size = new Size(93, 20);
            label7.TabIndex = 1;
            label7.Text = "Barline Amount:";
            label7.TextAlign = ContentAlignment.MiddleRight;
            // 
            // KatNoteBarlineAmount
            // 
            KatNoteBarlineAmount.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            KatNoteBarlineAmount.Location = new Point(102, 3);
            KatNoteBarlineAmount.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            KatNoteBarlineAmount.Name = "KatNoteBarlineAmount";
            KatNoteBarlineAmount.Size = new Size(42, 20);
            KatNoteBarlineAmount.TabIndex = 0;
            KatNoteBarlineAmount.Value = new decimal(new int[] { 4, 0, 0, 0 });
            // 
            // KatNoteEnabled
            // 
            KatNoteEnabled.Checked = true;
            KatNoteEnabled.CheckState = CheckState.Checked;
            KatNoteEnabled.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            KatNoteEnabled.Location = new Point(3, 2);
            KatNoteEnabled.Name = "KatNoteEnabled";
            KatNoteEnabled.Size = new Size(68, 16);
            KatNoteEnabled.TabIndex = 2;
            KatNoteEnabled.Text = "Kat";
            KatNoteEnabled.UseVisualStyleBackColor = true;
            KatNoteEnabled.CheckedChanged += NoteEnabled_CheckedChanged;
            // 
            // comboBox3
            // 
            comboBox3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comboBox3.Enabled = false;
            comboBox3.Font = new Font("Segoe UI", 6F, FontStyle.Regular, GraphicsUnit.Point);
            comboBox3.FormattingEnabled = true;
            comboBox3.ItemHeight = 11;
            comboBox3.Items.AddRange(new object[] { "Barline", "Inv. Barline", "Slider" });
            comboBox3.Location = new Point(74, 2);
            comboBox3.Margin = new Padding(0, 3, 3, 3);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(72, 19);
            comboBox3.TabIndex = 0;
            comboBox3.Text = "Barline";
            // 
            // DonFinisherSettingsPanel
            // 
            DonFinisherSettingsPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DonFinisherSettingsPanel.Controls.Add(DonFinisherNoteBarlinePanel);
            DonFinisherSettingsPanel.Controls.Add(DonFinisherNoteEnabled);
            DonFinisherSettingsPanel.Controls.Add(comboBox5);
            DonFinisherSettingsPanel.Location = new Point(3, 99);
            DonFinisherSettingsPanel.Margin = new Padding(0);
            DonFinisherSettingsPanel.Name = "DonFinisherSettingsPanel";
            DonFinisherSettingsPanel.Size = new Size(147, 93);
            DonFinisherSettingsPanel.TabIndex = 4;
            // 
            // DonFinisherNoteBarlinePanel
            // 
            DonFinisherNoteBarlinePanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DonFinisherNoteBarlinePanel.Controls.Add(label8);
            DonFinisherNoteBarlinePanel.Controls.Add(DonFinisherNoteBarlineSVIncrease);
            DonFinisherNoteBarlinePanel.Controls.Add(label9);
            DonFinisherNoteBarlinePanel.Controls.Add(DonFinisherNoteBarlineSpacing);
            DonFinisherNoteBarlinePanel.Controls.Add(label10);
            DonFinisherNoteBarlinePanel.Controls.Add(DonFinisherNoteBarlineAmount);
            DonFinisherNoteBarlinePanel.Location = new Point(0, 21);
            DonFinisherNoteBarlinePanel.Margin = new Padding(0);
            DonFinisherNoteBarlinePanel.Name = "DonFinisherNoteBarlinePanel";
            DonFinisherNoteBarlinePanel.Size = new Size(147, 72);
            DonFinisherNoteBarlinePanel.TabIndex = 3;
            // 
            // label8
            // 
            label8.Location = new Point(3, 49);
            label8.Name = "label8";
            label8.Size = new Size(78, 20);
            label8.TabIndex = 5;
            label8.Text = "SV Change:";
            label8.TextAlign = ContentAlignment.MiddleRight;
            // 
            // DonFinisherNoteBarlineSVIncrease
            // 
            DonFinisherNoteBarlineSVIncrease.DecimalPlaces = 4;
            DonFinisherNoteBarlineSVIncrease.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            DonFinisherNoteBarlineSVIncrease.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            DonFinisherNoteBarlineSVIncrease.Location = new Point(87, 49);
            DonFinisherNoteBarlineSVIncrease.Name = "DonFinisherNoteBarlineSVIncrease";
            DonFinisherNoteBarlineSVIncrease.Size = new Size(57, 20);
            DonFinisherNoteBarlineSVIncrease.TabIndex = 4;
            DonFinisherNoteBarlineSVIncrease.Value = new decimal(new int[] { 25, 0, 0, 196608 });
            // 
            // label9
            // 
            label9.Location = new Point(3, 26);
            label9.Name = "label9";
            label9.Size = new Size(93, 20);
            label9.TabIndex = 3;
            label9.Text = "Barline Spacing:";
            label9.TextAlign = ContentAlignment.MiddleRight;
            // 
            // DonFinisherNoteBarlineSpacing
            // 
            DonFinisherNoteBarlineSpacing.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            DonFinisherNoteBarlineSpacing.Location = new Point(102, 26);
            DonFinisherNoteBarlineSpacing.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            DonFinisherNoteBarlineSpacing.Name = "DonFinisherNoteBarlineSpacing";
            DonFinisherNoteBarlineSpacing.Size = new Size(42, 20);
            DonFinisherNoteBarlineSpacing.TabIndex = 2;
            DonFinisherNoteBarlineSpacing.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // label10
            // 
            label10.Location = new Point(3, 3);
            label10.Name = "label10";
            label10.Size = new Size(93, 20);
            label10.TabIndex = 1;
            label10.Text = "Barline Amount:";
            label10.TextAlign = ContentAlignment.MiddleRight;
            // 
            // DonFinisherNoteBarlineAmount
            // 
            DonFinisherNoteBarlineAmount.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            DonFinisherNoteBarlineAmount.Location = new Point(102, 3);
            DonFinisherNoteBarlineAmount.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            DonFinisherNoteBarlineAmount.Name = "DonFinisherNoteBarlineAmount";
            DonFinisherNoteBarlineAmount.Size = new Size(42, 20);
            DonFinisherNoteBarlineAmount.TabIndex = 0;
            DonFinisherNoteBarlineAmount.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // DonFinisherNoteEnabled
            // 
            DonFinisherNoteEnabled.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            DonFinisherNoteEnabled.Location = new Point(3, 2);
            DonFinisherNoteEnabled.Name = "DonFinisherNoteEnabled";
            DonFinisherNoteEnabled.Size = new Size(68, 16);
            DonFinisherNoteEnabled.TabIndex = 2;
            DonFinisherNoteEnabled.Text = "Don Fin";
            DonFinisherNoteEnabled.UseVisualStyleBackColor = true;
            DonFinisherNoteEnabled.CheckedChanged += NoteEnabled_CheckedChanged;
            // 
            // comboBox5
            // 
            comboBox5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comboBox5.Enabled = false;
            comboBox5.Font = new Font("Segoe UI", 6F, FontStyle.Regular, GraphicsUnit.Point);
            comboBox5.FormattingEnabled = true;
            comboBox5.ItemHeight = 11;
            comboBox5.Items.AddRange(new object[] { "Barline", "Inv. Barline", "Slider" });
            comboBox5.Location = new Point(74, 2);
            comboBox5.Margin = new Padding(0, 3, 3, 3);
            comboBox5.Name = "comboBox5";
            comboBox5.Size = new Size(71, 19);
            comboBox5.TabIndex = 0;
            comboBox5.Text = "Barline";
            // 
            // KatFinisherSettingsPanel
            // 
            KatFinisherSettingsPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            KatFinisherSettingsPanel.Controls.Add(KatFinisherNoteBarlinePanel);
            KatFinisherSettingsPanel.Controls.Add(KatFinisherNoteEnabled);
            KatFinisherSettingsPanel.Controls.Add(comboBox7);
            KatFinisherSettingsPanel.Location = new Point(153, 99);
            KatFinisherSettingsPanel.Margin = new Padding(0);
            KatFinisherSettingsPanel.Name = "KatFinisherSettingsPanel";
            KatFinisherSettingsPanel.Size = new Size(148, 93);
            KatFinisherSettingsPanel.TabIndex = 4;
            // 
            // KatFinisherNoteBarlinePanel
            // 
            KatFinisherNoteBarlinePanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            KatFinisherNoteBarlinePanel.Controls.Add(label11);
            KatFinisherNoteBarlinePanel.Controls.Add(KatFinisherNoteBarlineSVIncrease);
            KatFinisherNoteBarlinePanel.Controls.Add(label12);
            KatFinisherNoteBarlinePanel.Controls.Add(KatFinisherNoteBarlineSpacing);
            KatFinisherNoteBarlinePanel.Controls.Add(label13);
            KatFinisherNoteBarlinePanel.Controls.Add(KatFinisherNoteBarlineAmount);
            KatFinisherNoteBarlinePanel.Location = new Point(0, 21);
            KatFinisherNoteBarlinePanel.Margin = new Padding(0);
            KatFinisherNoteBarlinePanel.Name = "KatFinisherNoteBarlinePanel";
            KatFinisherNoteBarlinePanel.Size = new Size(148, 72);
            KatFinisherNoteBarlinePanel.TabIndex = 3;
            // 
            // label11
            // 
            label11.Location = new Point(3, 49);
            label11.Name = "label11";
            label11.Size = new Size(78, 20);
            label11.TabIndex = 5;
            label11.Text = "SV Change:";
            label11.TextAlign = ContentAlignment.MiddleRight;
            // 
            // KatFinisherNoteBarlineSVIncrease
            // 
            KatFinisherNoteBarlineSVIncrease.DecimalPlaces = 4;
            KatFinisherNoteBarlineSVIncrease.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            KatFinisherNoteBarlineSVIncrease.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            KatFinisherNoteBarlineSVIncrease.Location = new Point(87, 49);
            KatFinisherNoteBarlineSVIncrease.Name = "KatFinisherNoteBarlineSVIncrease";
            KatFinisherNoteBarlineSVIncrease.Size = new Size(57, 20);
            KatFinisherNoteBarlineSVIncrease.TabIndex = 4;
            KatFinisherNoteBarlineSVIncrease.Value = new decimal(new int[] { 25, 0, 0, 196608 });
            // 
            // label12
            // 
            label12.Location = new Point(3, 26);
            label12.Name = "label12";
            label12.Size = new Size(93, 20);
            label12.TabIndex = 3;
            label12.Text = "Barline Spacing:";
            label12.TextAlign = ContentAlignment.MiddleRight;
            // 
            // KatFinisherNoteBarlineSpacing
            // 
            KatFinisherNoteBarlineSpacing.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            KatFinisherNoteBarlineSpacing.Location = new Point(102, 26);
            KatFinisherNoteBarlineSpacing.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            KatFinisherNoteBarlineSpacing.Name = "KatFinisherNoteBarlineSpacing";
            KatFinisherNoteBarlineSpacing.Size = new Size(42, 20);
            KatFinisherNoteBarlineSpacing.TabIndex = 2;
            KatFinisherNoteBarlineSpacing.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // label13
            // 
            label13.Location = new Point(3, 3);
            label13.Name = "label13";
            label13.Size = new Size(93, 20);
            label13.TabIndex = 1;
            label13.Text = "Barline Amount:";
            label13.TextAlign = ContentAlignment.MiddleRight;
            // 
            // KatFinisherNoteBarlineAmount
            // 
            KatFinisherNoteBarlineAmount.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            KatFinisherNoteBarlineAmount.Location = new Point(102, 3);
            KatFinisherNoteBarlineAmount.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            KatFinisherNoteBarlineAmount.Name = "KatFinisherNoteBarlineAmount";
            KatFinisherNoteBarlineAmount.Size = new Size(42, 20);
            KatFinisherNoteBarlineAmount.TabIndex = 0;
            KatFinisherNoteBarlineAmount.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // KatFinisherNoteEnabled
            // 
            KatFinisherNoteEnabled.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            KatFinisherNoteEnabled.Location = new Point(3, 2);
            KatFinisherNoteEnabled.Name = "KatFinisherNoteEnabled";
            KatFinisherNoteEnabled.Size = new Size(68, 16);
            KatFinisherNoteEnabled.TabIndex = 2;
            KatFinisherNoteEnabled.Text = "Kat Fin";
            KatFinisherNoteEnabled.UseVisualStyleBackColor = true;
            KatFinisherNoteEnabled.CheckedChanged += NoteEnabled_CheckedChanged;
            // 
            // comboBox7
            // 
            comboBox7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comboBox7.Enabled = false;
            comboBox7.Font = new Font("Segoe UI", 6F, FontStyle.Regular, GraphicsUnit.Point);
            comboBox7.FormattingEnabled = true;
            comboBox7.ItemHeight = 11;
            comboBox7.Items.AddRange(new object[] { "Barline", "Inv. Barline", "Slider" });
            comboBox7.Location = new Point(74, 2);
            comboBox7.Margin = new Padding(0, 3, 3, 3);
            comboBox7.Name = "comboBox7";
            comboBox7.Size = new Size(72, 19);
            comboBox7.TabIndex = 0;
            comboBox7.Text = "Barline";
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
            KatSettingsPanel.ResumeLayout(false);
            KatNoteBarlinePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)KatNoteBarlineSVIncrease).EndInit();
            ((System.ComponentModel.ISupportInitialize)KatNoteBarlineSpacing).EndInit();
            ((System.ComponentModel.ISupportInitialize)KatNoteBarlineAmount).EndInit();
            DonFinisherSettingsPanel.ResumeLayout(false);
            DonFinisherNoteBarlinePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DonFinisherNoteBarlineSVIncrease).EndInit();
            ((System.ComponentModel.ISupportInitialize)DonFinisherNoteBarlineSpacing).EndInit();
            ((System.ComponentModel.ISupportInitialize)DonFinisherNoteBarlineAmount).EndInit();
            KatFinisherSettingsPanel.ResumeLayout(false);
            KatFinisherNoteBarlinePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)KatFinisherNoteBarlineSVIncrease).EndInit();
            ((System.ComponentModel.ISupportInitialize)KatFinisherNoteBarlineSpacing).EndInit();
            ((System.ComponentModel.ISupportInitialize)KatFinisherNoteBarlineAmount).EndInit();
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
        private ComboBox DonNoteGimmickType;
        private Panel KatSettingsPanel;
        private CheckBox KatNoteEnabled;
        private ComboBox comboBox3;
        private Panel DonFinisherSettingsPanel;
        private Panel DonFinisherNoteBarlinePanel;
        private Label label8;
        private NumericUpDown DonFinisherNoteBarlineSVIncrease;
        private Label label9;
        private NumericUpDown DonFinisherNoteBarlineSpacing;
        private Label label10;
        private NumericUpDown DonFinisherNoteBarlineAmount;
        private CheckBox DonFinisherNoteEnabled;
        private ComboBox comboBox5;
        private Panel KatFinisherSettingsPanel;
        private Panel KatFinisherNoteBarlinePanel;
        private Label label11;
        private NumericUpDown KatFinisherNoteBarlineSVIncrease;
        private Label label12;
        private NumericUpDown KatFinisherNoteBarlineSpacing;
        private Label label13;
        private NumericUpDown KatFinisherNoteBarlineAmount;
        private CheckBox KatFinisherNoteEnabled;
        private ComboBox comboBox7;
        private Panel KatNoteBarlinePanel;
        private Label label5;
        private NumericUpDown KatNoteBarlineSVIncrease;
        private Label label6;
        private NumericUpDown KatNoteBarlineSpacing;
        private Label label7;
        private NumericUpDown KatNoteBarlineAmount;
    }
}