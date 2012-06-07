using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace imgurdl
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            LoadSettings();
            fLog = new FileLogger();
            Log.AddReader(fLog);
        }

        private void LoadSettings()
        {
            Settings.Instance = Settings.Load("settings.xml");
            LoadedSubreddits = new List<Subreddit>();
            foreach (var sr in Settings.Instance.Subreddits)
                LoadedSubreddits.Add(new Subreddit(sr));
            dgData.DataSource = LoadedSubreddits;
        }

        private FileLogger fLog;
        private SettingsForm settingsForm;
        private List<Subreddit> LoadedSubreddits;
        private bool IsRunning = false;
        private Thread _worker;
        private DateTime startTime;

        private void btnToggle_Click(object sender, EventArgs e)
        {
            IsRunning = !IsRunning;
            if (IsRunning)
                Start();
            else
                Stop();
        }

        private void Start()
        {
            btnSettings.Enabled = false;
            startTime = DateTime.Now;
            _worker = new Thread(Worker);
            _worker.Start();
            timer1.Start();

            btnToggle.Text = "Stop";
            btnToggle.Image = global::imgurdl.Properties.Resources.control_stop_blue;
            tslRunning.Text = "Running";
            tslRunning.Image = global::imgurdl.Properties.Resources.accept;
        }

        private void Stop()
        {
            foreach (var sr in LoadedSubreddits.Where(x => !x.Done))
                sr.Stop();

            if (_worker != null)
                _worker.Abort();
            _worker = null;
            timer1.Stop();

            btnToggle.Text = "Start";
            btnToggle.Image = global::imgurdl.Properties.Resources.control_play_blue;
            tslRunning.Text = "Not running";
            tslRunning.Image = global::imgurdl.Properties.Resources.cross;
            btnSettings.Enabled = true;

            Log.WriteLine("------- STATS -------");
            Log.WriteLine("Downloaded: {0} - Skipped: {1} - Total: {2}",
                    LoadedSubreddits.Sum(x => x.Downloaded),
                    LoadedSubreddits.Sum(x => x.Skipped),
                    LoadedSubreddits.Sum(x => x.Total));

            var timeSpan = DateTime.Now - startTime;
            Log.WriteLine(string.Format("Session lasted {0}mins {1}secs",
                timeSpan.Minutes,
                timeSpan.Seconds));
        }

        private void Worker()
        {
            if (dgData.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow dgv in dgData.SelectedRows)
                {
                    var sr = LoadedSubreddits.FirstOrDefault(x => x.Name == dgv.Cells[0].Value as string);
                    sr.Download(Settings.Instance.StoragePath);
                }
            }
            else
            {
                foreach (var sr in LoadedSubreddits)
                {
                    sr.Download(Settings.Instance.StoragePath);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (IsRunning)
            {
                dgData.Invalidate();

                tslStats.Text = string.Format("Downloaded: {0} - Skipped: {1} - Total: {2}",
                    LoadedSubreddits.Sum(x => x.Downloaded),
                    LoadedSubreddits.Sum(x => x.Skipped),
                    LoadedSubreddits.Sum(x => x.Total));

                var timeSpan = DateTime.Now - startTime;
                tslRuntime.Text = string.Format("{0}mins {1}secs",
                    timeSpan.Minutes,
                    timeSpan.Seconds);

                if (LoadedSubreddits.All(x => x.Done))
                {
                    IsRunning = false;
                    Stop();
                }
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Stop();
            Settings.Instance.Save();
            fLog = null;
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            btnToggle.Enabled = false;
            settingsForm = new SettingsForm();
            settingsForm.FormClosing += settingsForm_FormClosing;
            settingsForm.Show();
        }

        private void settingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Instance.Save();
            LoadSettings();
            btnToggle.Enabled = true;
        }

        private void dgData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var sr = LoadedSubreddits.FirstOrDefault(x => x.Name == dgData.Rows[e.RowIndex].Cells[0].Value as string);
            // Sometimes it doesn't exist
            var dir = Path.Combine(Settings.Instance.StoragePath, sr.Name);
            Directory.CreateDirectory(dir);
            Process.Start(dir);
        }
    }
}
