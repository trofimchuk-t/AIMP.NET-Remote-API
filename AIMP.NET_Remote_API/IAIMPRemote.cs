using System;
using System.Drawing;

namespace AIMP.NET.RemoteAPI
{
    public delegate void AimpEventHandler<T>(object sender, AimpEventArgs<T> e);

    public interface IAimpRemote : IDisposable
    {
        #region AIMP Properties

        /// <summary>
        /// Get or set mute state
        /// </summary>
        bool IsMuteEnabled { get; set; }

        /// <summary>
        /// Get or set radio capture state
        /// </summary>
        bool IsRadioCapEnabled { get; set; }

        /// <summary>
        /// Get or set repeat state
        /// </summary>
        bool IsRepeatEnabled { get; set; }

        /// <summary>
        /// Get or set shuffle state
        /// </summary>
        bool IsShuffleEnabled { get; set; }

        /// <summary>
        /// Get or set full screen visualization mode
        /// </summary>
        bool IsVisualInFullScreen { get; set; }

        /// <summary>
        /// Get or set current volume
        /// </summary>
        /// <value>Volume in % [0..100]</value>
        int Volume { get; set; }

        /// <summary>
        /// Get or set current position of now playing track
        /// </summary>
        TimeSpan Position { get; set; }

        /// <summary>
        /// Get duration of now playing track
        /// </summary>
        TimeSpan Duration { get; }

        /// <summary>
        /// Get current player state
        /// </summary>
        PlayerState PlayerState { get; }

        /// <summary>
        /// Get player version
        /// </summary>
        /// <seealso cref="AimpVersion"/>
        AimpVersion Version { get; }

        /// <summary>
        /// Get current track information
        /// </summary>
        /// <seealso cref="AimpTrackInfo"/>
        /// <remarks>Return AimpTrackInfo.EmptyAimpTrackInfo (not null), if player is stopped</remarks>
        AimpTrackInfo CurrentTrackInfo { get; }

        /// <summary>
        /// Return true, if AIMP is started
        /// </summary>
        bool IsStarted { get; }

        #endregion

        #region AIMP Commands
        void RegisterNotify();

        /// <summary>
        /// Execute the "Files Adding" dialog
        /// </summary>
        void ExecuteAddFilesDialog();

        /// <summary>
        /// Execute the "Folders Adding" dialogue
        /// </summary>
        void ExecuteAddFoldersDialog();

        /// <summary>
        /// Execute the "Playlists Adding" dialog
        /// </summary>
        void ExecuteAddPlaylistsDialog();

        /// <summary>
        /// Execute "URL Adding" dialog
        /// </summary>
        void ExecuteAddUrlDialog();

        /// <summary>
        /// Execute request, which provides for an ability to get album art for playable file.
        /// </summary>
        void SendAlbumArtRequest();

        /// <summary>
        /// Next track
        /// </summary>
        void Next();

        /// <summary>
        /// Previous track
        /// </summary>
        void Prev();

        /// <summary>
        /// Start playback if player is stopped, resumes playback is player is paused or starts playback from beginning if player is playing
        /// </summary>
        void Play();

        /// <summary>
        /// Pauses playback or resume paused playback
        /// </summary>
        void Pause();

        /// <summary>
        /// Start playback if player is stopped, resumes playback is player is paused or paused playback if player is playing
        /// </summary>
        void PlayOrPause();

        /// <summary>
        /// Stop playback
        /// </summary>
        void Stop();

        /// <summary>
        /// Close player
        /// </summary>
        void Close();

        /// <summary>
        /// Next visualization
        /// </summary>
        void NextVisualization();

        /// <summary>
        /// Previous visualization
        /// </summary>
        void PrevVisualization();

        /// <summary>
        /// Starts previous selected by user visualization.
        /// </summary>
        /// <remarks>If visualization is not found - first will be started</remarks>
        void StartVisualization();

        /// <summary>
        /// Stop visualization
        /// </summary>
        void StopVisualization();

        /// <summary>
        /// Execute "Files Opening" dialog
        /// </summary>
        void ExecuteOpenFilesDialog();

        /// <summary>
        /// Execute "Folders Opening" dialog
        /// </summary>
        void ExecuteOpenFoldersDialog();

        /// <summary>
        /// Execute "Playlists Opening" dialog
        /// </summary>
        void ExecuteOpenPlaylistsDialog();

        //void ShowHide();
        //bool Start(string aimpName);
        #endregion

        #region AIMP Events
        bool ProcessWndMessage(int message, IntPtr wParam, IntPtr lParam);

        /// <summary>
        /// Occurs when audio stream starts playing or when an Internet radio station changes the track
        /// </summary>
        event AimpEventHandler<AimpTrackInfo> TrackStarted;

        /// <summary>
        /// Occurs when new track was started
        /// </summary>
        event AimpEventHandler<AimpTrackInfo> TrackInfoChanged;

        /// <summary>
        /// Occurs when property value has been changed 
        /// </summary>
        event AimpEventHandler<AimpPropertyType> AimpPropertyChanged;

        /// <summary>
        /// Event occurs when Album Art has been changed 
        /// </summary>
        event AimpEventHandler<Image> AlbumArtChanged;

        #endregion
    }
}