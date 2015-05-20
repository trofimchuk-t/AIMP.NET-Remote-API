namespace AimpApi_Remote_test
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            if (aimp != null)
            {
                aimp.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabs = new System.Windows.Forms.TabControl();
            this.tabPageProperties = new System.Windows.Forms.TabPage();
            this.chbVisualFullScr = new System.Windows.Forms.CheckBox();
            this.lblPosition = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblState = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDuration = new System.Windows.Forms.Label();
            this.chbRadioCap = new System.Windows.Forms.CheckBox();
            this.chbRepeat = new System.Windows.Forms.CheckBox();
            this.chbShuffle = new System.Windows.Forms.CheckBox();
            this.chbMute = new System.Windows.Forms.CheckBox();
            this.lblVersion = new System.Windows.Forms.Label();
            this.btnTryStart = new System.Windows.Forms.Button();
            this.btnGetTrackInfo = new System.Windows.Forms.Button();
            this.trBarVolume = new System.Windows.Forms.TrackBar();
            this.lblVolume = new System.Windows.Forms.Label();
            this.tabPageCommands = new System.Windows.Forms.TabPage();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnVisPrev = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnVisStop = new System.Windows.Forms.Button();
            this.btnPlayPause = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnVisStart = new System.Windows.Forms.Button();
            this.btnVisNext = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnOpenFiles = new System.Windows.Forms.Button();
            this.btnAddFiles = new System.Windows.Forms.Button();
            this.tabPageAlbumArt = new System.Windows.Forms.TabPage();
            this.btnGetAlbumArt = new System.Windows.Forms.Button();
            this.iAlbumArt = new System.Windows.Forms.PictureBox();
            this.tabs.SuspendLayout();
            this.tabPageProperties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trBarVolume)).BeginInit();
            this.tabPageCommands.SuspendLayout();
            this.tabPageAlbumArt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iAlbumArt)).BeginInit();
            this.SuspendLayout();
            // 
            // tabs
            // 
            this.tabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabs.Controls.Add(this.tabPageProperties);
            this.tabs.Controls.Add(this.tabPageCommands);
            this.tabs.Controls.Add(this.tabPageAlbumArt);
            this.tabs.Location = new System.Drawing.Point(12, 12);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(395, 342);
            this.tabs.TabIndex = 14;
            // 
            // tabPageProperties
            // 
            this.tabPageProperties.Controls.Add(this.chbVisualFullScr);
            this.tabPageProperties.Controls.Add(this.lblPosition);
            this.tabPageProperties.Controls.Add(this.label1);
            this.tabPageProperties.Controls.Add(this.lblState);
            this.tabPageProperties.Controls.Add(this.label2);
            this.tabPageProperties.Controls.Add(this.lblDuration);
            this.tabPageProperties.Controls.Add(this.chbRadioCap);
            this.tabPageProperties.Controls.Add(this.chbRepeat);
            this.tabPageProperties.Controls.Add(this.chbShuffle);
            this.tabPageProperties.Controls.Add(this.chbMute);
            this.tabPageProperties.Controls.Add(this.lblVersion);
            this.tabPageProperties.Controls.Add(this.btnTryStart);
            this.tabPageProperties.Controls.Add(this.btnGetTrackInfo);
            this.tabPageProperties.Controls.Add(this.trBarVolume);
            this.tabPageProperties.Controls.Add(this.lblVolume);
            this.tabPageProperties.Location = new System.Drawing.Point(4, 22);
            this.tabPageProperties.Name = "tabPageProperties";
            this.tabPageProperties.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageProperties.Size = new System.Drawing.Size(387, 316);
            this.tabPageProperties.TabIndex = 0;
            this.tabPageProperties.Text = "Properties";
            this.tabPageProperties.UseVisualStyleBackColor = true;
            // 
            // chbVisualFullScr
            // 
            this.chbVisualFullScr.AutoSize = true;
            this.chbVisualFullScr.Location = new System.Drawing.Point(6, 98);
            this.chbVisualFullScr.Name = "chbVisualFullScr";
            this.chbVisualFullScr.Size = new System.Drawing.Size(140, 17);
            this.chbVisualFullScr.TabIndex = 23;
            this.chbVisualFullScr.Text = "Full Screen Visualization";
            this.chbVisualFullScr.UseVisualStyleBackColor = true;
            this.chbVisualFullScr.CheckedChanged += new System.EventHandler(this.chbVisualFullScr_CheckedChanged);
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Location = new System.Drawing.Point(56, 177);
            this.lblPosition.Margin = new System.Windows.Forms.Padding(0);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(0, 13);
            this.lblPosition.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 177);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Position: ";
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Location = new System.Drawing.Point(3, 155);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(44, 13);
            this.lblState.TabIndex = 20;
            this.lblState.Text = "Stoped ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 199);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Duration: ";
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Location = new System.Drawing.Point(56, 199);
            this.lblDuration.Margin = new System.Windows.Forms.Padding(0);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(0, 13);
            this.lblDuration.TabIndex = 20;
            // 
            // chbRadioCap
            // 
            this.chbRadioCap.AutoSize = true;
            this.chbRadioCap.Location = new System.Drawing.Point(6, 75);
            this.chbRadioCap.Name = "chbRadioCap";
            this.chbRadioCap.Size = new System.Drawing.Size(94, 17);
            this.chbRadioCap.TabIndex = 19;
            this.chbRadioCap.Text = "Radio Capture";
            this.chbRadioCap.UseVisualStyleBackColor = true;
            this.chbRadioCap.CheckedChanged += new System.EventHandler(this.chbRadioCap_CheckedChanged);
            // 
            // chbRepeat
            // 
            this.chbRepeat.AutoSize = true;
            this.chbRepeat.Location = new System.Drawing.Point(6, 52);
            this.chbRepeat.Name = "chbRepeat";
            this.chbRepeat.Size = new System.Drawing.Size(61, 17);
            this.chbRepeat.TabIndex = 19;
            this.chbRepeat.Text = "Repeat";
            this.chbRepeat.UseVisualStyleBackColor = true;
            this.chbRepeat.CheckedChanged += new System.EventHandler(this.chbRepeat_CheckedChanged);
            // 
            // chbShuffle
            // 
            this.chbShuffle.AutoSize = true;
            this.chbShuffle.Location = new System.Drawing.Point(6, 29);
            this.chbShuffle.Name = "chbShuffle";
            this.chbShuffle.Size = new System.Drawing.Size(59, 17);
            this.chbShuffle.TabIndex = 19;
            this.chbShuffle.Text = "Shuffle";
            this.chbShuffle.UseVisualStyleBackColor = true;
            this.chbShuffle.CheckedChanged += new System.EventHandler(this.chbShuffle_CheckedChanged);
            // 
            // chbMute
            // 
            this.chbMute.AutoSize = true;
            this.chbMute.Location = new System.Drawing.Point(6, 6);
            this.chbMute.Name = "chbMute";
            this.chbMute.Size = new System.Drawing.Size(50, 17);
            this.chbMute.TabIndex = 19;
            this.chbMute.Text = "Mute";
            this.chbMute.UseVisualStyleBackColor = true;
            this.chbMute.CheckedChanged += new System.EventHandler(this.chbMute_CheckedChanged);
            // 
            // lblVersion
            // 
            this.lblVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(3, 222);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(48, 13);
            this.lblVersion.TabIndex = 18;
            this.lblVersion.Text = "Version: ";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnTryStart
            // 
            this.btnTryStart.Location = new System.Drawing.Point(225, 6);
            this.btnTryStart.Name = "btnTryStart";
            this.btnTryStart.Size = new System.Drawing.Size(156, 23);
            this.btnTryStart.TabIndex = 17;
            this.btnTryStart.Text = "Try Start AIMP";
            this.btnTryStart.UseVisualStyleBackColor = true;
            this.btnTryStart.Click += new System.EventHandler(this.btnTryStart_Click);
            // 
            // btnGetTrackInfo
            // 
            this.btnGetTrackInfo.Location = new System.Drawing.Point(225, 35);
            this.btnGetTrackInfo.Name = "btnGetTrackInfo";
            this.btnGetTrackInfo.Size = new System.Drawing.Size(156, 23);
            this.btnGetTrackInfo.TabIndex = 16;
            this.btnGetTrackInfo.Text = "Get Current Track Info";
            this.btnGetTrackInfo.UseVisualStyleBackColor = true;
            this.btnGetTrackInfo.Click += new System.EventHandler(this.btnGetTrackInfo_Click);
            // 
            // trBarVolume
            // 
            this.trBarVolume.Location = new System.Drawing.Point(9, 263);
            this.trBarVolume.Maximum = 100;
            this.trBarVolume.Name = "trBarVolume";
            this.trBarVolume.Size = new System.Drawing.Size(372, 45);
            this.trBarVolume.TabIndex = 15;
            this.trBarVolume.TickFrequency = 5;
            this.trBarVolume.Scroll += new System.EventHandler(this.trBarVolume_Scroll);
            this.trBarVolume.ValueChanged += new System.EventHandler(this.trBarVolume_VallueChanged);
            // 
            // lblVolume
            // 
            this.lblVolume.AutoSize = true;
            this.lblVolume.Location = new System.Drawing.Point(8, 247);
            this.lblVolume.Name = "lblVolume";
            this.lblVolume.Size = new System.Drawing.Size(0, 13);
            this.lblVolume.TabIndex = 14;
            // 
            // tabPageCommands
            // 
            this.tabPageCommands.Controls.Add(this.btnClose);
            this.tabPageCommands.Controls.Add(this.btnVisPrev);
            this.tabPageCommands.Controls.Add(this.btnPrev);
            this.tabPageCommands.Controls.Add(this.btnVisStop);
            this.tabPageCommands.Controls.Add(this.btnPlayPause);
            this.tabPageCommands.Controls.Add(this.btnPause);
            this.tabPageCommands.Controls.Add(this.btnVisStart);
            this.tabPageCommands.Controls.Add(this.btnVisNext);
            this.tabPageCommands.Controls.Add(this.btnPlay);
            this.tabPageCommands.Controls.Add(this.btnStop);
            this.tabPageCommands.Controls.Add(this.button2);
            this.tabPageCommands.Controls.Add(this.btnOpenFiles);
            this.tabPageCommands.Controls.Add(this.btnAddFiles);
            this.tabPageCommands.Location = new System.Drawing.Point(4, 22);
            this.tabPageCommands.Name = "tabPageCommands";
            this.tabPageCommands.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCommands.Size = new System.Drawing.Size(387, 316);
            this.tabPageCommands.TabIndex = 1;
            this.tabPageCommands.Text = "Commands";
            this.tabPageCommands.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(289, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(89, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close AIMP";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnVisPrev
            // 
            this.btnVisPrev.Location = new System.Drawing.Point(6, 131);
            this.btnVisPrev.Name = "btnVisPrev";
            this.btnVisPrev.Size = new System.Drawing.Size(89, 23);
            this.btnVisPrev.TabIndex = 1;
            this.btnVisPrev.Text = "Prev Vis";
            this.btnVisPrev.UseVisualStyleBackColor = true;
            this.btnVisPrev.Click += new System.EventHandler(this.btnVisPrev_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(149, 102);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(89, 23);
            this.btnPrev.TabIndex = 1;
            this.btnPrev.Text = "PREV";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnVisStop
            // 
            this.btnVisStop.Location = new System.Drawing.Point(6, 189);
            this.btnVisStop.Name = "btnVisStop";
            this.btnVisStop.Size = new System.Drawing.Size(89, 23);
            this.btnVisStop.TabIndex = 1;
            this.btnVisStop.Text = "Stop Vis";
            this.btnVisStop.UseVisualStyleBackColor = true;
            this.btnVisStop.Click += new System.EventHandler(this.btnVisStop_Click);
            // 
            // btnPlayPause
            // 
            this.btnPlayPause.Location = new System.Drawing.Point(149, 192);
            this.btnPlayPause.Name = "btnPlayPause";
            this.btnPlayPause.Size = new System.Drawing.Size(89, 23);
            this.btnPlayPause.TabIndex = 1;
            this.btnPlayPause.Text = "PLAY-PAUSE";
            this.btnPlayPause.UseVisualStyleBackColor = true;
            this.btnPlayPause.Click += new System.EventHandler(this.btnPlayPause_Click);
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(149, 222);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(89, 23);
            this.btnPause.TabIndex = 1;
            this.btnPause.Text = "PAUSE";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnVisStart
            // 
            this.btnVisStart.Location = new System.Drawing.Point(6, 160);
            this.btnVisStart.Name = "btnVisStart";
            this.btnVisStart.Size = new System.Drawing.Size(89, 23);
            this.btnVisStart.TabIndex = 1;
            this.btnVisStart.Text = "Start Vis";
            this.btnVisStart.UseVisualStyleBackColor = true;
            this.btnVisStart.Click += new System.EventHandler(this.btnVisStart_Click);
            // 
            // btnVisNext
            // 
            this.btnVisNext.Location = new System.Drawing.Point(6, 102);
            this.btnVisNext.Name = "btnVisNext";
            this.btnVisNext.Size = new System.Drawing.Size(89, 23);
            this.btnVisNext.TabIndex = 1;
            this.btnVisNext.Text = "Next Vis";
            this.btnVisNext.UseVisualStyleBackColor = true;
            this.btnVisNext.Click += new System.EventHandler(this.btnVisNext_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(149, 132);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(89, 23);
            this.btnPlay.TabIndex = 1;
            this.btnPlay.Text = "PLAY";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(149, 162);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(89, 23);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "STOP";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(149, 72);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(89, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "NEXT";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnOpenFiles
            // 
            this.btnOpenFiles.Location = new System.Drawing.Point(6, 35);
            this.btnOpenFiles.Name = "btnOpenFiles";
            this.btnOpenFiles.Size = new System.Drawing.Size(89, 23);
            this.btnOpenFiles.TabIndex = 1;
            this.btnOpenFiles.Text = "Open Files...";
            this.btnOpenFiles.UseVisualStyleBackColor = true;
            this.btnOpenFiles.Click += new System.EventHandler(this.btnOpenFiles_Click);
            // 
            // btnAddFiles
            // 
            this.btnAddFiles.Location = new System.Drawing.Point(6, 6);
            this.btnAddFiles.Name = "btnAddFiles";
            this.btnAddFiles.Size = new System.Drawing.Size(89, 23);
            this.btnAddFiles.TabIndex = 0;
            this.btnAddFiles.Text = "Add Files...";
            this.btnAddFiles.UseVisualStyleBackColor = true;
            this.btnAddFiles.Click += new System.EventHandler(this.btnAddFiles_Click);
            // 
            // tabPageAlbumArt
            // 
            this.tabPageAlbumArt.Controls.Add(this.btnGetAlbumArt);
            this.tabPageAlbumArt.Controls.Add(this.iAlbumArt);
            this.tabPageAlbumArt.Location = new System.Drawing.Point(4, 22);
            this.tabPageAlbumArt.Name = "tabPageAlbumArt";
            this.tabPageAlbumArt.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAlbumArt.Size = new System.Drawing.Size(387, 316);
            this.tabPageAlbumArt.TabIndex = 3;
            this.tabPageAlbumArt.Text = "Album Art";
            this.tabPageAlbumArt.UseVisualStyleBackColor = true;
            // 
            // btnGetAlbumArt
            // 
            this.btnGetAlbumArt.Location = new System.Drawing.Point(6, 287);
            this.btnGetAlbumArt.Name = "btnGetAlbumArt";
            this.btnGetAlbumArt.Size = new System.Drawing.Size(375, 23);
            this.btnGetAlbumArt.TabIndex = 1;
            this.btnGetAlbumArt.Text = "Get Album Art Image";
            this.btnGetAlbumArt.UseVisualStyleBackColor = true;
            this.btnGetAlbumArt.Click += new System.EventHandler(this.btnGetAlbumArt_Click);
            // 
            // iAlbumArt
            // 
            this.iAlbumArt.Location = new System.Drawing.Point(6, 6);
            this.iAlbumArt.Name = "iAlbumArt";
            this.iAlbumArt.Size = new System.Drawing.Size(375, 275);
            this.iAlbumArt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iAlbumArt.TabIndex = 0;
            this.iAlbumArt.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 366);
            this.Controls.Add(this.tabs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AIMP Remote";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.tabs.ResumeLayout(false);
            this.tabPageProperties.ResumeLayout(false);
            this.tabPageProperties.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trBarVolume)).EndInit();
            this.tabPageCommands.ResumeLayout(false);
            this.tabPageAlbumArt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iAlbumArt)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tabPageProperties;
        private System.Windows.Forms.TabPage tabPageCommands;
        private System.Windows.Forms.Button btnAddFiles;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnVisPrev;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnVisStop;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnVisStart;
        private System.Windows.Forms.Button btnVisNext;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnOpenFiles;
        private System.Windows.Forms.Button btnPlayPause;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Label lblVolume;
        private System.Windows.Forms.TrackBar trBarVolume;
        private System.Windows.Forms.TabPage tabPageAlbumArt;
        private System.Windows.Forms.Button btnGetAlbumArt;
        private System.Windows.Forms.PictureBox iAlbumArt;
        private System.Windows.Forms.Button btnGetTrackInfo;
        private System.Windows.Forms.Button btnTryStart;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.CheckBox chbRadioCap;
        private System.Windows.Forms.CheckBox chbRepeat;
        private System.Windows.Forms.CheckBox chbShuffle;
        private System.Windows.Forms.CheckBox chbMute;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chbVisualFullScr;
    }
}

