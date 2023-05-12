using OsuParsers.Beatmaps;
using OsuParsers.Decoders;
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
            SettingsManager.Init();

            SettingsManager.Version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        private void ParseBeatmap(string fileName)
        {
            //TimingPointTextBox.Text = fileName;
            try
            {
                _loadedBeatmap = BeatmapDecoder.Decode(fileName);

                TimingPointTextBox.Text = $"name: {_loadedBeatmap.MetadataSection.Title}";
                //Console.WriteLine($"name: {_loadedBeatmap.MetadataSection.Title}");
            }
            catch (Exception ex)
            {
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
            if (UpdateManager.HasUpdate())
            {
                UpdateStripButt.BackColor = Color.LightGreen;
            }
        }
        private void CheckForUpdates_Click(object sender, EventArgs e)
        {
            if (UpdateManager.HasUpdate())
            {

            }
        }
        #endregion

    }
}