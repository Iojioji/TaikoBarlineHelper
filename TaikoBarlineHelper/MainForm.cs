using AutoUpdaterDotNET;
using OsuParsers.Beatmaps;
using OsuParsers.Beatmaps.Objects;
using OsuParsers.Beatmaps.Objects.Taiko;
using OsuParsers.Decoders;
using OsuParsers.Enums;
using OsuParsers.Enums.Beatmaps;
using System.Diagnostics;
using System.Reflection;
using TaikoBarlineHelper.Settings;
using TaikoBarlineHelper.Gimmicks;

namespace TaikoBarlineHelper
{
    public enum GimmickType { Barline = 0, InverseBarline = 1, YellowNote = 2 }
    public enum TaikoNote { Don = 0, Kat = 1, DonFinisher = 2, KatFinisher = 3 }
    public partial class MainForm : Form
    {
        GimmickHandler _gimmickHandler = new GimmickHandler();

        bool _updateSettingsOnNoteChange = false;

        bool _applyDon;
        bool _applyKat;
        bool _applyDonFinisher;
        bool _applyKatFinisher;

        bool ApplyDon
        {
            get => _applyDon;
            set
            {
                _applyDon = value;
                UpdateBarlinePanelStatus(DonNoteBarlinePanel, DonNoteGimmickType, _applyDon);
                if (_updateSettingsOnNoteChange)
                    SettingsManager.DonSettings.Enabled = _applyDon;
            }
        }
        bool ApplyKat
        {
            get => _applyKat;
            set
            {
                _applyKat = value;
                UpdateBarlinePanelStatus(KatNoteBarlinePanel, KatNoteGimmickType, _applyKat);
                if (_updateSettingsOnNoteChange)
                    SettingsManager.KatSettings.Enabled = _applyKat;
            }
        }
        bool ApplyDonFinisher
        {
            get => _applyDonFinisher;
            set
            {
                _applyDonFinisher = value;
                UpdateBarlinePanelStatus(DonFinisherNoteBarlinePanel, DonFinisherNoteGimmickType, _applyDonFinisher);
                if (_updateSettingsOnNoteChange)
                    SettingsManager.DonFinSettings.Enabled = _applyDonFinisher;
            }
        }
        bool ApplyKatFinisher
        {
            get => _applyKatFinisher;
            set
            {
                _applyKatFinisher = value;
                UpdateBarlinePanelStatus(KatFinisherNoteBarlinePanel, KatFinisherNoteGimmickType, _applyKatFinisher);
                if (_updateSettingsOnNoteChange)
                    SettingsManager.KatFinSettings.Enabled = _applyKatFinisher;
            }
        }

        public MainForm()
        {
            InitializeComponent();
            Initialize();
        }

        public void Initialize()
        {
            Debug.WriteLine("MainForm.Initialize()");
            SettingsManager.Init();

            SettingsManager.Version = Assembly.GetExecutingAssembly().GetName().Version.ToString();

            TutorialCheckBox.Checked = SettingsManager.IsTutorial;
            LoadSavedNoteValues();

            _updateSettingsOnNoteChange = true;

            if (!string.IsNullOrWhiteSpace(SettingsManager.LoadedMap))
            {
                if (File.Exists(SettingsManager.LoadedMap))
                {
                    RefreshMap();
                }
                else
                {
                    MessageBox.Show($"The map you had previously loaded is no longer on the saved directory!\r\n\r\n\"{SettingsManager.LoadedMap}\"", $"Map no longer exists!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    SettingsManager.LoadedMap = "";
                }
            }

            UpdateMakeBarlineButt();


            FormClosing += OnClose;
        }

        private void OnClose(object? sender, FormClosingEventArgs e)
        {
            SettingsManager.LinesString = TimingPointTextBox.Text;
        }

        void LoadSavedNoteValues()
        {
            TimingPointTextBox.Text = SettingsManager.LinesString;

            DonNoteEnabled.Checked = ApplyDon = SettingsManager.DonSettings.Enabled;
            KatNoteEnabled.Checked = ApplyKat = SettingsManager.KatSettings.Enabled;
            DonFinisherNoteEnabled.Checked = ApplyDonFinisher = SettingsManager.DonFinSettings.Enabled;
            KatFinisherNoteEnabled.Checked = ApplyKatFinisher = SettingsManager.KatFinSettings.Enabled;

            DonNoteGimmickType.SelectedIndex = (int)SettingsManager.DonSettings.GimmickType;
            KatNoteGimmickType.SelectedIndex = (int)SettingsManager.KatSettings.GimmickType;
            DonFinisherNoteGimmickType.SelectedIndex = (int)SettingsManager.DonFinSettings.GimmickType;
            KatFinisherNoteGimmickType.SelectedIndex = (int)SettingsManager.KatFinSettings.GimmickType;

            DonNoteBarlineAmount.Value = SettingsManager.DonSettings.BarlineAmount;
            KatNoteBarlineAmount.Value = SettingsManager.KatSettings.BarlineAmount;
            DonFinisherNoteBarlineAmount.Value = SettingsManager.DonFinSettings.BarlineAmount;
            KatFinisherNoteBarlineAmount.Value = SettingsManager.KatFinSettings.BarlineAmount;

            DonNoteBarlineSpacing.Value = SettingsManager.DonSettings.BarlineSpacing;
            KatNoteBarlineSpacing.Value = SettingsManager.KatSettings.BarlineSpacing;
            DonFinisherNoteBarlineSpacing.Value = SettingsManager.DonFinSettings.BarlineSpacing;
            KatFinisherNoteBarlineSpacing.Value = SettingsManager.KatFinSettings.BarlineSpacing;

            DonNoteBarlineSVIncrease.Value = SettingsManager.DonSettings.BarlineSVIncrease;
            KatNoteBarlineSVIncrease.Value = SettingsManager.KatSettings.BarlineSVIncrease;
            DonFinisherNoteBarlineSVIncrease.Value = SettingsManager.DonFinSettings.BarlineSVIncrease;
            KatFinisherNoteBarlineSVIncrease.Value = SettingsManager.KatFinSettings.BarlineSVIncrease;
        }

        private void ParseBeatmap(string fileName)
        {
            //TimingPointTextBox.Text = fileName;
            Beatmap loadedBeatmap = null;

            try
            {
                loadedBeatmap = BeatmapDecoder.Decode(fileName);

                if (loadedBeatmap.GeneralSection.Mode == Ruleset.Taiko)
                {
                    _gimmickHandler.LoadedBeatmap = loadedBeatmap;
                    SetMapInfoToLabels($"{loadedBeatmap.MetadataSection.Title}", $"[{loadedBeatmap.MetadataSection.Version}]");
                    SettingsManager.LoadedMap = fileName;
                    //TimingPointTextBox.Text = $"name: {_loadedBeatmap.MetadataSection.Title}";
                }
                else
                {
                    MessageBox.Show($"Your map isn't taiko lmao");
                }
            }
            catch (Exception ex)
            {
                SetMapInfoToLabels("Nothing", "[Nothing]");

                SettingsManager.LoadedMap = "";
                MessageBox.Show(ex.Message);
            }
        }

        void RefreshMap()
        {
            ParseBeatmap(SettingsManager.LoadedMap);
        }

        void SetMapInfoToLabels(string name, string diff)
        {
            LoadedMapLabel_Name.Text = $"{name}";
            LoadedMapLabel_Diff.Text = $"{diff}";

            LoadedMapTooltip.SetToolTip(LoadedMapLabel_Name, $"Loaded Map: {name} - {diff}");
            LoadedMapTooltip.SetToolTip(LoadedMapLabel_Diff, $"Loaded Map: {name} - {diff}");
        }

        void UpdateBarlinePanelStatus(Panel toChange, ComboBox toChangeType, bool enabled)
        {
            toChangeType.Enabled = enabled;
            toChange.Enabled = enabled;
        }
        void UpdateMakeBarlineButt()
        {
            bool enabled = true;
            if (_gimmickHandler.LoadedBeatmap == null)
            {
                enabled = false;
            }
            if (string.IsNullOrEmpty(TimingPointTextBox.Text) || string.IsNullOrWhiteSpace(TimingPointTextBox.Text))
            {
                enabled = false;
            }
            MakeBarlineButt.Enabled = enabled;
        }

        #region Events
        private void LoadBeatmapStripButt_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "osu beatmap files (*.osu)|*.osu";
                openFileDialog.FilterIndex = 0;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ParseBeatmap(openFileDialog.FileName);
                }
            }
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            Debug.WriteLine("MainForm_Load");
            if (UpdateManager.HasUpdate())
            {
                UpdateStripButt.BackColor = Color.LightGreen;
            }
            if (SettingsManager.LoadedMap != "")
            {
                ParseBeatmap(SettingsManager.LoadedMap);
            }

        }
        private void CheckForUpdates_Click(object sender, EventArgs e)
        {
            //if (UpdateManager.HasUpdate())
            if (UpdateManager.HasUpdate())
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to update this magnificent piece of software and introduce some more bugs into it?", "Update Available", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        Debug.WriteLine($"Starting autoupdater");
                        //AutoUpdater.Start(Properties.Settings.Default.UpdateXML);
                        AutoUpdater.Start(SettingsManager.UpdateXML);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Something went wrong, tell Iojioji to get his stuff together!\r\n\r\nMessage: {ex.Message}\r\n\r\nStackTrace: {ex.StackTrace}", "Error while updating!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show($"No updates pending; you're already up to date fam (v{SettingsManager.Version})");
            }
        }

        /// <summary>
        /// TODO: How should this work? Should you add the timing points to affect the thing? Just the notes? Individual timing points????
        /// If TimingPoint, from earliest point to latest point
        /// If HitObject, from earliest object to latest object
        /// </summary>
        /// <param name="lines"></param>

        (int, int) GetPoints(List<string> lines)
        {
            (int, int) result = (-9999, -9999);

            foreach (string line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    if (line.Contains(':'))
                    {
                        //TODO: Handle HitObject
                    }
                    else
                    {
                        int offset = -999;
                        int.TryParse(line.Split(',')[0], out offset);
                        if (offset != -999)
                        {
                            result.Item1 = result.Item1 == -9999 ? offset : offset < result.Item1 ? offset : result.Item1;
                            result.Item2 = result.Item2 == -9999 ? offset : offset > result.Item2 ? offset : result.Item2;
                        }
                    }
                }
            }

            return result;
        }

        private void MakeBarlineBut_Click(object sender, EventArgs e)
        {
            List<string> lines = TrimEmptyLines(TimingPointTextBox.Text.Split('\n'));

            //TestReadLines(lines);

            //return;

            RefreshMap();
            //_gimmickHandler.MakeGimmick(lines);
            _gimmickHandler.MakeGimmick(GetPoints(lines));

            if (_gimmickHandler.BackupMap != null)
                OopsButt.Enabled = true;

            ///RefreshMap();
            ///if (_loadedBeatmap == null)
            ///{
            ///    return;
            ///}
            ///
            ///_backupMap = CloneBeatmap(_loadedBeatmap);
            ///if (_backupMap != null)
            ///    OopsButt.Enabled = true;
            ///
            ///foreach (string line in lines)
            ///{
            ///    LookForThing(line);
            ///}
            ///
            ///Debug.WriteLine($"Saving Map!");
            ///_loadedBeatmap.Save(SettingsManager.LoadedMap);
        }
        List<string> TrimEmptyLines(string[] toTrim)
        {
            List<string> trimmedLines = new List<string>();

            foreach (string line in toTrim)
            {
                if (!string.IsNullOrWhiteSpace(line))
                    trimmedLines.Add(line);
            }

            return trimmedLines;
        }

        private void OopsButt_Click(object sender, EventArgs e)
        {
            if (_gimmickHandler.BackupMap != null)
            {
                _gimmickHandler.RevertChanges();
                OopsButt.Enabled = false;
            }

            ///if (_backupMap != null)
            ///{
            ///    _backupMap.Save(SettingsManager.LoadedMap);
            ///    _backupMap = null;
            ///    _backupTimingPoints.Clear();
            ///    OopsButt.Enabled = false;
            ///}
        }
        private void NoteEnabled_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkbox = (CheckBox)sender;
            string name = checkbox.Name;
            bool isChecked = checkbox.Checked;

            switch (name)
            {
                case ("DonNoteEnabled"):
                    ApplyDon = isChecked;
                    break;
                case ("KatNoteEnabled"):
                    ApplyKat = isChecked;
                    break;
                case ("DonFinisherNoteEnabled"):
                    ApplyDonFinisher = isChecked;
                    break;
                case ("KatFinisherNoteEnabled"):
                    ApplyKatFinisher = isChecked;
                    break;
            }
        }
        private void GimmickTypeChanged(object sender, EventArgs e)
        {
            if (!_updateSettingsOnNoteChange) return;

            ComboBox comboBox = (ComboBox)sender;
            string name = (comboBox).Name;

            if (comboBox.SelectedIndex != 0)
            {
                comboBox.SelectedIndex = 0;
                MessageBox.Show($"Those other settings are not done yet, sorry!");
                return;
            }


            if (name.Contains("Don"))
            {
                if (name.Contains("DonFinisher"))
                {
                    SettingsManager.DonFinSettings.GimmickType = (GimmickType)DonFinisherNoteGimmickType.SelectedIndex;
                }
                else
                {
                    SettingsManager.DonSettings.GimmickType = (GimmickType)DonNoteGimmickType.SelectedIndex;
                }
            }
            else
            {
                if (name.Contains("KatFinisher"))
                {
                    SettingsManager.KatFinSettings.GimmickType = (GimmickType)KatFinisherNoteGimmickType.SelectedIndex;
                }
                else
                {
                    SettingsManager.KatSettings.GimmickType = (GimmickType)KatNoteGimmickType.SelectedIndex;
                }
            }
        }
        private void IsTutorial_CheckedChanged(object sender, EventArgs e)
        {
            if (!_updateSettingsOnNoteChange) return;

            CheckBox checkbox = (CheckBox)sender;
            bool isChecked = checkbox.Checked;

            SettingsManager.IsTutorial = isChecked;
        }
        private void BarlineNoteValueChanged(object sender, EventArgs e)
        {
            if (!_updateSettingsOnNoteChange) return;

            Control control = (Control)sender;
            string name = control.Name;

            if (name.Contains("Don"))
            {
                if (name.Contains("DonFinisher"))
                {
                    SettingsManager.DonFinSettings.BarlineAmount = (int)DonFinisherNoteBarlineAmount.Value;
                    SettingsManager.DonFinSettings.BarlineSpacing = (int)DonFinisherNoteBarlineSpacing.Value;
                    SettingsManager.DonFinSettings.BarlineSVIncrease = DonFinisherNoteBarlineSVIncrease.Value;
                }
                else
                {
                    SettingsManager.DonSettings.BarlineAmount = (int)DonNoteBarlineAmount.Value;
                    SettingsManager.DonSettings.BarlineSpacing = (int)DonNoteBarlineSpacing.Value;
                    SettingsManager.DonSettings.BarlineSVIncrease = DonNoteBarlineSVIncrease.Value;
                }
            }
            else
            {
                if (name.Contains("KatFinisher"))
                {
                    SettingsManager.KatFinSettings.BarlineAmount = (int)KatFinisherNoteBarlineAmount.Value;
                    SettingsManager.KatFinSettings.BarlineSpacing = (int)KatFinisherNoteBarlineSpacing.Value;
                    SettingsManager.KatFinSettings.BarlineSVIncrease = KatFinisherNoteBarlineSVIncrease.Value;
                }
                else
                {
                    SettingsManager.KatSettings.BarlineAmount = (int)KatNoteBarlineAmount.Value;
                    SettingsManager.KatSettings.BarlineSpacing = (int)KatNoteBarlineSpacing.Value;
                    SettingsManager.KatSettings.BarlineSVIncrease = KatNoteBarlineSVIncrease.Value;
                }
            }

            //Debug.WriteLine($"Don Finisher? {(name.Contains("DonFinisher") ? true : false)}");
        }

        private void TimingPointTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateMakeBarlineButt();
        }
        #endregion
    }
}