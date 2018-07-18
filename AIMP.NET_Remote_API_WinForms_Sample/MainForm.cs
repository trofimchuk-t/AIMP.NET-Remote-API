using AIMP.NET.RemoteAPI;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace AimpApi_Remote_test
{
    public partial class MainForm : Form
    {
        private IAimpRemote aimp;
        private Timer timer;
        private bool isRegistered;

        public MainForm(IAimpRemote aimp)
        {
            this.aimp = aimp;
            InitializeComponent();

            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += timer_Tick;
            timer.Enabled = true;

            aimp.AimpPropertyChanged += OnAimpPropertyChanged;
            aimp.AlbumArtChanged += aimp_AlbumArtLoaded;
            aimp.TrackStarted += aimp_TrackStarted;

            UpdateInfo();

            this.FormClosing += MainForm_FormClosing;
        }

        void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Enabled = false;
            aimp.Dispose();
        }

        void aimp_TrackStarted(object sender, AimpEventArgs<AimpTrackInfo> e)
        {
            var info = e.Value;
            lblDuration.Text = info.Duration.ToString("hh\\:mm\\:ss");
        }

        private void UpdateInfo()
        {
            trBarVolume.Value = aimp.Volume;
            lblVersion.Text = "Version: " + aimp.Version.ToString();
            lblDuration.Text = aimp.Duration.ToString("hh\\:mm\\:ss");
            lblPosition.Text = aimp.Position.ToString("hh\\:mm\\:ss");
            lblState.Text = aimp.PlayerState.ToString();

            chbMute.Checked = aimp.IsMuteEnabled;
            chbShuffle.Checked = aimp.IsShuffleEnabled;
            chbRepeat.Checked = aimp.IsRepeatEnabled;
            chbRadioCap.Checked = aimp.IsRadioCapEnabled;
        }

        void timer_Tick(object sender, EventArgs e)
        {
            bool isStarted = aimp.IsStarted;
            if (isRegistered != isStarted)
            {
                if (!isRegistered)
                {
                    aimp.RegisterNotify();
                    UpdateInfo();
                }

                isRegistered = !isRegistered;
            }
        }

        #region Commands

        private void btnAddFiles_Click(object sender, EventArgs e)
        {
            aimp.ExecuteAddFilesDialog();
        }

        private void btnVisPrev_Click(object sender, EventArgs e)
        {
            aimp.PrevVisualization();
        }

        private void btnVisNext_Click(object sender, EventArgs e)
        {
            aimp.NextVisualization();
        }

        private void btnVisStart_Click(object sender, EventArgs e)
        {
            aimp.StartVisualization();
        }

        private void btnVisStop_Click(object sender, EventArgs e)
        {
            aimp.StopVisualization();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            aimp.Next();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            aimp.Prev();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            aimp.Play();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            aimp.Stop();
        }

        private void btnPlayPause_Click(object sender, EventArgs e)
        {
            aimp.PlayOrPause();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            aimp.Pause();
        }

        private void btnOpenFiles_Click(object sender, EventArgs e)
        {
            aimp.ExecuteOpenFilesDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            aimp.Close();
        }

        #endregion

        private void aimp_AlbumArtLoaded(object sender, AimpEventArgs<Image> eventArgs)
        {
            iAlbumArt.Image = eventArgs.Value;
        }

        private void OnAimpPropertyChanged(object sender, AimpEventArgs<AimpPropertyType> eventArgs)
        {
            switch (eventArgs.Value)
            {
                case AimpPropertyType.Volume:
                    trBarVolume.Value = aimp.Volume;
                    break;
                case AimpPropertyType.PlayerState:
                    lblState.Text = aimp.PlayerState.ToString();
                    if (aimp.PlayerState == PlayerState.Stopped)
                    {
                        lblDuration.Text = "";
                        lblPosition.Text = "";
                    }
                    break;
                case AimpPropertyType.Mute:
                    chbMute.Checked = aimp.IsMuteEnabled;
                    break;
                case AimpPropertyType.Repeat:
                    chbRepeat.Checked = aimp.IsRepeatEnabled;
                    break;
                case AimpPropertyType.Shuffle:
                    chbShuffle.Checked = aimp.IsShuffleEnabled;
                    break;
                case AimpPropertyType.RadioCap:
                    chbRadioCap.Checked = aimp.IsRadioCapEnabled;
                    break;
                case AimpPropertyType.Position:
                    lblPosition.Text = aimp.Position.ToString("hh\\:mm\\:ss");
                    break;
                case AimpPropertyType.Duration:
                    lblDuration.Text = aimp.Duration.ToString("hh\\:mm\\:ss");
                    break;
            }
        }

        private void trBarVolume_VallueChanged(object sender, EventArgs e)
        {
            lblVolume.Text = "Volume: " + trBarVolume.Value.ToString() + " %";
        }

        private void trBarVolume_Scroll(object sender, EventArgs e)
        {
            aimp.Volume = trBarVolume.Value;
        }

        private void btnGetAlbumArt_Click(object sender, EventArgs e)
        {
            aimp.SendAlbumArtRequest();
        }

        private void btnGetTrackInfo_Click(object sender, EventArgs e)
        {
            var trackInfo = aimp.CurrentTrackInfo;
            if (trackInfo != null)
                MessageBox.Show(trackInfo.FileName, "Current file");
        }

        //=====================================================================

        private void btnTryStart_Click(object sender, EventArgs e)
        {
            // Try to start AIMP v4.0+
            if (TryStartAimp("AIMP")) return;
            // Try to start AIMP3
            if (TryStartAimp("AIMP3")) return;

            MessageBox.Show("The system cannot find the file specified");
        }

        private bool TryStartAimp(string processName)
        {
            var p = new Process();
            p.StartInfo.FileName = processName;
            try
            {
                p.Start();
                return true;
            }
            catch (Win32Exception)
            {
                return false;
            }
        }

        private void chbMute_CheckedChanged(object sender, EventArgs e)
        {
            aimp.IsMuteEnabled = (sender as CheckBox).Checked;
        }

        private void chbShuffle_CheckedChanged(object sender, EventArgs e)
        {
            aimp.IsShuffleEnabled = (sender as CheckBox).Checked;
        }

        private void chbRepeat_CheckedChanged(object sender, EventArgs e)
        {
            aimp.IsRepeatEnabled = (sender as CheckBox).Checked;
        }

        private void chbRadioCap_CheckedChanged(object sender, EventArgs e)
        {
            aimp.IsRadioCapEnabled = (sender as CheckBox).Checked;
        }

        private void chbVisualFullScr_CheckedChanged(object sender, EventArgs e)
        {
            aimp.IsVisualInFullScreen = chbVisualFullScr.Checked;
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}