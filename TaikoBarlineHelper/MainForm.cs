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

namespace TaikoBarlineHelper
{
    public enum GimmickType { Barline = 0, Slider = 1 }
    public partial class MainForm : Form
    {
        Beatmap _loadedBeatmap;

        List<TimingPoint> _backupTimingPoints;

        Beatmap _backupMap;

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
                UpdateBarlinePanelStatus(DonNoteBarlinePanel, _applyDon);
            }
        }
        bool ApplyKat
        {
            get => _applyKat;
            set
            {
                _applyKat = value;
                UpdateBarlinePanelStatus(KatNoteBarlinePanel, _applyKat);
            }
        }
        bool ApplyDonFinisher
        {
            get => _applyDonFinisher;
            set
            {
                _applyDonFinisher = value;
                UpdateBarlinePanelStatus(DonFinisherNoteBarlinePanel, _applyDonFinisher);
            }
        }
        bool ApplyKatFinisher
        {
            get => _applyKatFinisher;
            set
            {
                _applyKatFinisher = value;
                UpdateBarlinePanelStatus(KatFinisherNoteBarlinePanel, _applyKatFinisher);
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

            //TODO: Load this from settings, along with the values lmao
            ApplyDon = true;
            ApplyKat = true;
            ApplyDonFinisher = true;
            ApplyKatFinisher = true;

            UpdateMakeBarlineButt();
        }

        private void ParseBeatmap(string fileName)
        {
            //TimingPointTextBox.Text = fileName;
            try
            {
                _loadedBeatmap = BeatmapDecoder.Decode(fileName);

                if (_loadedBeatmap.GeneralSection.Mode == Ruleset.Taiko)
                {
                    SetMapInfoToLabels($"{_loadedBeatmap.MetadataSection.Title}", $"[{_loadedBeatmap.MetadataSection.Version}]");

                    SettingsManager.LoadedMap = fileName;
                    //TimingPointTextBox.Text = $"name: {_loadedBeatmap.MetadataSection.Title}";
                }
                else
                {
                    _loadedBeatmap = null;
                    MessageBox.Show($"Your map isn't taiko lmao");
                }
            }
            catch (Exception ex)
            {
                _loadedBeatmap = null;

                SetMapInfoToLabels("Nothing", "[Nothing]");

                SettingsManager.LoadedMap = "";
                MessageBox.Show(ex.Message);
            }
        }

        void RefreshMap()
        {
            ParseBeatmap(SettingsManager.LoadedMap);
        }


        void LookForThing(string timingLine)
        {
            string targetTimingPoint = timingLine;
            string barlineMSString = targetTimingPoint.Split(',')[0];

            if (string.IsNullOrEmpty(barlineMSString) || string.IsNullOrWhiteSpace(barlineMSString))
            {
                return;
            }

            int barlineMS = -1;
            int.TryParse(barlineMSString, out barlineMS);

            if (barlineMS == -1)
            {
                return;
            }

            TimingPoint currentPoint = null;
            TimingPoint lastRedline = null;

            currentPoint = _loadedBeatmap.TimingPoints.Find(x => x.Offset == barlineMS && x.BeatLength < 0);

            if (currentPoint == null)
            {
                Debug.WriteLine($"No such point as {barlineMS}");
                return;
            }

            foreach (TimingPoint tp in _loadedBeatmap.TimingPoints)
            {
                //bool isTarget = tp.Offset == barlineMS;
                bool isRedline = tp.BeatLength >= 0;

                if (isRedline)
                {
                    if (tp.Offset <= barlineMS)
                    {
                        lastRedline = tp;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            if (lastRedline == null)
            {
                Debug.WriteLine($"No redline lmao {barlineMS}");
                return;
            }

            GenerateBarlines(currentPoint, lastRedline);
            Debug.WriteLine($"TP {currentPoint.Offset} -> {barlineMS}\r\n  SV: {currentPoint.BeatLength}\r\n");
        }
        TaikoHit GetNoteInOffset(int offset)
        {
            TaikoHit hitObject = null;
            foreach (HitObject ho in _loadedBeatmap.HitObjects)
            {
                if (ho.StartTime != offset)
                    continue;

                TaikoHit? hit = ho as TaikoHit;
                if (hit != null)
                {
                    hitObject = hit;
                    break;
                }
            }
            return hitObject;
        }

        void GenerateBarlines(TimingPoint origin, TimingPoint lastRedline)
        {
            if (origin == null)
            {
                //TODO: Tell user wtf are you doing lmao
                return;
            }
            if (lastRedline == null)
            {
                //TODO: uuuh, no previous redline wtf
                return;
            }


            double svValue = -100 / origin.BeatLength;
            double bpm = 60000 / lastRedline.BeatLength;
            int originalOffset = origin.Offset;
            TaikoHit note = GetNoteInOffset(originalOffset);

            if (note == null)
            {
                return;
            }

            bool isKiai = (int)origin.Effects == 9 || origin.Effects == Effects.Kiai;

            if (!ShouldAddBarline(note))
            {
                return;
            }

            if (!TutorialCheckBox.Checked)
            {
                GenerateBarline(originalOffset, 10000, 10, origin.TimeSignature, origin.SampleSet, origin.CustomSampleSet, origin.Volume, isKiai, true);
            }

            if (note.IsBig)
            {
                if (note.Color == TaikoColor.Blue)
                {
                    //GenerateBarlines(origin, bpm, isKiai, 6, 2, 0.0125);
                    GenerateBarlines(origin, bpm, isKiai, (int)KatFinisherNoteBarlineAmount.Value, (int)KatFinisherNoteBarlineSpacing.Value, (double)KatFinisherNoteBarlineSVIncrease.Value);
                }
                else
                {
                    //GenerateBarlines(origin, bpm, isKiai, 10, 3, 0.06);
                    GenerateBarlines(origin, bpm, isKiai, (int)DonFinisherNoteBarlineAmount.Value, (int)DonFinisherNoteBarlineSpacing.Value, (double)DonFinisherNoteBarlineSVIncrease.Value);
                }
            }
            else
            {
                if (note.Color == TaikoColor.Blue)
                {
                    //GenerateBarlines(origin, bpm, isKiai, 4, 3, 0);
                    GenerateBarlines(origin, bpm, isKiai, (int)KatNoteBarlineAmount.Value, (int)KatNoteBarlineSpacing.Value, (double)KatNoteBarlineSVIncrease.Value);
                }
                else
                {
                    //GenerateBarlines(origin, bpm, isKiai, 1, 1, 0);
                    GenerateBarlines(origin, bpm, isKiai, (int)DonNoteBarlineAmount.Value, (int)DonNoteBarlineSpacing.Value, (double)DonNoteBarlineSVIncrease.Value);
                }
            }

            //_loadedBeatmap.TimingPoints.Add(centerRedline);
            if (!TutorialCheckBox.Checked)
            {
                _loadedBeatmap.TimingPoints.Remove(origin);
            }

            _loadedBeatmap.TimingPoints = _loadedBeatmap.TimingPoints.OrderBy(x => x.Offset).ToList();

            //_loadedBeatmap.Save(SettingsManager.LoadedMap);
        }

        void GenerateBarlines(TimingPoint origin, double bpm, bool isKiai, int extraBarlines, int offsetIncrease, double svIncrease)
        {
            double svValue = -100 / origin.BeatLength;
            int originalOffset = origin.Offset;

            for (int i = 0; i < extraBarlines; i++)
            {
                int barOffset = 1 + (i * offsetIncrease);
                double svOffset = (i * svIncrease);

                GenerateBarline(originalOffset + barOffset, bpm, svValue + svOffset, origin.TimeSignature, origin.SampleSet, origin.CustomSampleSet, origin.Volume, isKiai, false);
                GenerateBarline(originalOffset - barOffset, bpm, svValue - svOffset, origin.TimeSignature, origin.SampleSet, origin.CustomSampleSet, origin.Volume, isKiai, false);
            }
        }

        void GenerateBarline(int offset, double bpm, double sv, TimeSignature timeSignature, SampleSet sampleSet, int customSampleSet, int volume, bool kiai, bool omitFirstBarline)
        {
            int redlineEffects = 0;
            if (kiai)
                redlineEffects += 1;
            if (omitFirstBarline)
                redlineEffects += 8;

            TimingPoint redline = new TimingPoint()
            {
                Offset = offset,
                BeatLength = 60000 / bpm,
                TimeSignature = timeSignature,
                SampleSet = sampleSet,
                CustomSampleSet = customSampleSet,
                Volume = volume,
                Inherited = false,
                Effects = (Effects)redlineEffects
            };

            TimingPoint greenline = new TimingPoint()
            {
                Offset = offset,
                BeatLength = -100 / sv,
                TimeSignature = timeSignature,
                SampleSet = sampleSet,
                CustomSampleSet = customSampleSet,
                Volume = volume,
                Inherited = true,
                Effects = (Effects)redlineEffects
            };

            _loadedBeatmap.TimingPoints.Add(redline);
            _loadedBeatmap.TimingPoints.Add(greenline);
        }

        Beatmap CloneBeatmap(Beatmap toClone)
        {
            _backupTimingPoints = toClone.TimingPoints.ToList();
            Beatmap beatmap = new Beatmap()
            {
                GeneralSection = toClone.GeneralSection,
                EditorSection = toClone.EditorSection,
                MetadataSection = toClone.MetadataSection,
                DifficultySection = toClone.DifficultySection,
                EventsSection = toClone.EventsSection,
                ColoursSection = toClone.ColoursSection,
                TimingPoints = _backupTimingPoints,
                HitObjects = toClone.HitObjects,
            };

            return beatmap;
        }

        bool ShouldAddBarline(TaikoHit hit)
        {
            bool result = false;

            if (hit.IsBig)
            {
                if (hit.Color == TaikoColor.Blue)
                {
                    result = ApplyKatFinisher;
                }
                else
                {
                    result = ApplyDonFinisher;
                }
            }
            else
            {
                if (hit.Color == TaikoColor.Blue)
                {
                    result = ApplyKat;
                }
                else
                {
                    result = ApplyDon;
                }
            }

            return result;
        }

        void SetMapInfoToLabels(string name, string diff)
        {
            LoadedMapLabel_Name.Text = $"{name}";
            LoadedMapLabel_Diff.Text = $"{diff}";

            LoadedMapTooltip.SetToolTip(LoadedMapLabel_Name, $"Loaded Map: {name} - {diff}");
            LoadedMapTooltip.SetToolTip(LoadedMapLabel_Diff, $"Loaded Map: {name} - {diff}");
        }

        void UpdateBarlinePanelStatus(Panel toChange, bool enabled)
        {
            toChange.Enabled = enabled;
        }
        void UpdateMakeBarlineButt()
        {
            bool enabled = true;
            if (_loadedBeatmap == null)
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
                        AutoUpdater.Start(Properties.Settings.Default.UpdateXML);
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
        private void MakeBarlineBut_Click(object sender, EventArgs e)
        {
            string[] lines = TimingPointTextBox.Text.Split('\n');

            RefreshMap();
            if (_loadedBeatmap == null)
            {

                return;
            }

            _backupMap = CloneBeatmap(_loadedBeatmap);
            if (_backupMap != null)
                OopsButt.Enabled = true;

            foreach (string line in lines)
            {
                LookForThing(line);
            }

            Debug.WriteLine($"Saving Map!");
            _loadedBeatmap.Save(SettingsManager.LoadedMap);
        }
        private void OopsButt_Click(object sender, EventArgs e)
        {
            if (_backupMap != null)
            {
                _backupMap.Save(SettingsManager.LoadedMap);
                _backupMap = null;
                _backupTimingPoints.Clear();
                OopsButt.Enabled = false;
            }
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
        private void TimingPointTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateMakeBarlineButt();
        }
        #endregion

    }
}