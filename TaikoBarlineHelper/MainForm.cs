using AutoUpdaterDotNET;
using OsuParsers.Beatmaps;
using OsuParsers.Decoders;
using System.Diagnostics;
using System.Reflection;
using TaikoBarlineHelper.Settings;

namespace TaikoBarlineHelper
{
    public partial class MainForm : Form
    {

        Beatmap _loadedBeatmap;

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
        }

        private void ParseBeatmap(string fileName)
        {
            //TimingPointTextBox.Text = fileName;
            try
            {
                _loadedBeatmap = BeatmapDecoder.Decode(fileName);

                LoadedMapLabel_Name.Text = $"{_loadedBeatmap.MetadataSection.Title}";
                LoadedMapLabel_Diff.Text = $"[{_loadedBeatmap.MetadataSection.Version}]";

                SettingsManager.LoadedMap = fileName;
                //TimingPointTextBox.Text = $"name: {_loadedBeatmap.MetadataSection.Title}";
            }
            catch (Exception ex)
            {
                _loadedBeatmap = null;
                SettingsManager.LoadedMap = "";
                MessageBox.Show(ex.Message);
            }
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
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"No updates pending; you're already up to date fam (v{SettingsManager.Version})");
        }
    }
}