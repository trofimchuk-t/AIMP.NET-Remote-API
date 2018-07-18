using AIMP.NET.RemoteAPI.Interop;
using AIMP.NET.RemoteAPI.RemoteAPI;
using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;

namespace AIMP.NET.RemoteAPI
{
    public class AimpRemote : IAimpRemote
    {
        protected IntPtr _hostHandle;
        protected bool _isRegisteredForNotifications;

        public AimpRemote()
        {
            var moWindow = new AimpMessageOnlyWindow();
            moWindow.WndMessageReceived += ProcessWndMessage;

            Init(moWindow.Handle);
        }

        public AimpRemote(IntPtr hostHandle)
        {
            Init(hostHandle);
        }

        private void Init(IntPtr hostHandle)
        {
            _hostHandle = hostHandle;

            if (hostHandle != IntPtr.Zero)
            {
                RegisterNotify();
            }
        }

        #region IAimpRemote Implementation

        #region AIMP Properties

        /// <see cref="IAimpRemote.Duration"/>
        public TimeSpan Duration
        {
            get
            {
                IntPtr result = GetPropertyValue(AimpRemoteNetApi.AimpRemoteProperty.AIMP_RA_PROPERTY_PLAYER_DURATION);
                return TimeSpan.FromMilliseconds((double)result);
            }
        }

        /// <see cref="IAimpRemote.Position"/>
        public TimeSpan Position
        {
            get
            {
                IntPtr result = GetPropertyValue(AimpRemoteNetApi.AimpRemoteProperty.AIMP_RA_PROPERTY_PLAYER_POSITION);
                return TimeSpan.FromMilliseconds((double)result);
            }
            set
            {
                int milliseconds = (int)value.TotalMilliseconds;
                SetPropertyValue(AimpRemoteNetApi.AimpRemoteProperty.AIMP_RA_PROPERTY_PLAYER_POSITION, (IntPtr)milliseconds);
            }
        }

        ///<see cref="IAimpRemote.PlayerState"/>
        public PlayerState PlayerState
        {
            get
            {
                IntPtr result = GetPropertyValue(AimpRemoteNetApi.AimpRemoteProperty.AIMP_RA_PROPERTY_PLAYER_STATE);
                return (PlayerState)result;
            }
        }

        /// <see cref="IAimpRemote.IsMuteEnabled"/>
        public bool IsMuteEnabled
        {
            get
            {
                IntPtr result = GetPropertyValue(AimpRemoteNetApi.AimpRemoteProperty.AIMP_RA_PROPERTY_MUTE);
                return (result != IntPtr.Zero);
            }
            set
            {
                SetPropertyValue(AimpRemoteNetApi.AimpRemoteProperty.AIMP_RA_PROPERTY_MUTE, (IntPtr)Convert.ToInt32(value));
            }
        }

        /// <see cref="IAimpRemote.IsRadioCapEnabled"/>
        public bool IsRadioCapEnabled
        {
            get
            {
                IntPtr result = GetPropertyValue(AimpRemoteNetApi.AimpRemoteProperty.AIMP_RA_PROPERTY_RADIOCAP);
                return (result != IntPtr.Zero);
            }
            set
            {
                SetPropertyValue(AimpRemoteNetApi.AimpRemoteProperty.AIMP_RA_PROPERTY_RADIOCAP, (IntPtr)Convert.ToInt32(value));
            }
        }

        /// <see cref="IAimpRemote.IsRepeatEnabled"/>
        public bool IsRepeatEnabled
        {
            get
            {
                IntPtr result = GetPropertyValue(AimpRemoteNetApi.AimpRemoteProperty.AIMP_RA_PROPERTY_TRACK_REPEAT);
                return (result != IntPtr.Zero);
            }
            set
            {
                SetPropertyValue(AimpRemoteNetApi.AimpRemoteProperty.AIMP_RA_PROPERTY_TRACK_REPEAT, (IntPtr)Convert.ToInt32(value));
            }
        }

        /// <see cref="IAimpRemote.IsShuffleEnabled"/>
        public bool IsShuffleEnabled
        {
            get
            {
                IntPtr result = GetPropertyValue(AimpRemoteNetApi.AimpRemoteProperty.AIMP_RA_PROPERTY_TRACK_SHUFFLE);
                return (result != IntPtr.Zero);
            }
            set
            {
                SetPropertyValue(AimpRemoteNetApi.AimpRemoteProperty.AIMP_RA_PROPERTY_TRACK_SHUFFLE, (IntPtr)Convert.ToInt32(value));
            }
        }

        /// <see cref="IAimpRemote.Version"/>
        public AimpVersion Version
        {
            get
            {
                IntPtr result = GetPropertyValue(AimpRemoteNetApi.AimpRemoteProperty.AIMP_RA_PROPERTY_VERSION);
                return new AimpVersion((int)result);
            }
        }

        /// <see cref="IAimpRemote.IsVisualInFullScreen"/>
        public bool IsVisualInFullScreen
        {
            get
            {
                IntPtr result = GetPropertyValue(AimpRemoteNetApi.AimpRemoteProperty.AIMP_RA_PROPERTY_VISUAL_FULLSCREEN);
                return (result != IntPtr.Zero);
            }
            set
            {
                SetPropertyValue(AimpRemoteNetApi.AimpRemoteProperty.AIMP_RA_PROPERTY_VISUAL_FULLSCREEN, (IntPtr)Convert.ToInt32(value));
            }
        }

        /// <see cref="IAimpRemote.Volume"/>
        public int Volume
        {
            get
            {
                IntPtr result = GetPropertyValue(AimpRemoteNetApi.AimpRemoteProperty.AIMP_RA_PROPERTY_VOLUME);
                return (int)result;
            }
            set
            {
                SetPropertyValue(AimpRemoteNetApi.AimpRemoteProperty.AIMP_RA_PROPERTY_VOLUME, (IntPtr)value);
            }
        }

        #endregion Player Properties

        /// <see cref="IAimpRemote.IsStarted"/>
        public bool IsStarted { get { return AimpHwnd != IntPtr.Zero; } }

        #region AIMP Commands

        /// <see cref="IAimpRemote.RegisterNotify"/>
        public void RegisterNotify()
        {
            if (IsStarted)
            {
                Win32.SendMessage(AimpHwnd, AimpRemoteNetApi.WM_AIMP_COMMAND, (IntPtr)AimpRemoteNetApi.AimpRemoteCommand.AIMP_RA_CMD_REGISTER_NOTIFY, _hostHandle);
                _isRegisteredForNotifications = true;
            }
            _isRegisteredForNotifications = false;
        }

        /// <see cref="IAimpRemote.UnRegisterNotify"/>
        public void UnRegisterNotify()
        {
            Win32.SendMessage(AimpHwnd, AimpRemoteNetApi.WM_AIMP_COMMAND, (IntPtr)AimpRemoteNetApi.AimpRemoteCommand.AIMP_RA_CMD_UNREGISTER_NOTIFY, _hostHandle);
            _isRegisteredForNotifications = false;
        }

        /// <see cref="IAimpRemote.ExecuteAddFilesDialog"/>
        public void ExecuteAddFilesDialog()
        {
            SendCommand(AimpRemoteNetApi.AimpRemoteCommand.AIMP_RA_CMD_ADD_FILES);
        }

        /// <see cref="IAimpRemote.ExecuteAddFoldersDialog"/>
        public void ExecuteAddFoldersDialog()
        {
            SendCommand(AimpRemoteNetApi.AimpRemoteCommand.AIMP_RA_CMD_ADD_FOLDERS);
        }

        /// <see cref="IAimpRemote.ExecuteAddPlaylistsDialog"/>
        public void ExecuteAddPlaylistsDialog()
        {
            SendCommand(AimpRemoteNetApi.AimpRemoteCommand.AIMP_RA_CMD_ADD_PLAYLISTS);
        }

        /// <see cref="IAimpRemote.ExecuteAddUrlDialog"/>
        public void ExecuteAddUrlDialog()
        {
            SendCommand(AimpRemoteNetApi.AimpRemoteCommand.AIMP_RA_CMD_ADD_URL);
        }

        /// <see cref="IAimpRemote.SendAlbumArtRequest"/>
        public void SendAlbumArtRequest()
        {
            if (Win32.SendMessage(AimpHwnd, AimpRemoteNetApi.WM_AIMP_COMMAND, (IntPtr)AimpRemoteNetApi.AimpRemoteCommand.AIMP_RA_CMD_GET_ALBUMART, _hostHandle) == IntPtr.Zero)
            {
                //Clear current album art
                AlbumArtChanged?.Invoke(this, new AimpEventArgs<Image>(null));
            }
        }

        /// <see cref="IAimpRemote.Next"/>
        public void Next()
        {
            SendCommand(AimpRemoteNetApi.AimpRemoteCommand.AIMP_RA_CMD_NEXT);
        }

        /// <see cref="IAimpRemote.Prev"/>
        public void Prev()
        {
            SendCommand(AimpRemoteNetApi.AimpRemoteCommand.AIMP_RA_CMD_PREV);
        }

        /// <see cref="IAimpRemote.Play"/>
        public void Play()
        {
            SendCommand(AimpRemoteNetApi.AimpRemoteCommand.AIMP_RA_CMD_PLAY);
        }

        /// <see cref="IAimpRemote.Pause"/>
        public void Pause()
        {
            SendCommand(AimpRemoteNetApi.AimpRemoteCommand.AIMP_RA_CMD_PAUSE);
        }

        /// <see cref="IAimpRemote.PlayOrPause"/>
        public void PlayOrPause()
        {
            SendCommand(AimpRemoteNetApi.AimpRemoteCommand.AIMP_RA_CMD_PLAYPAUSE);
        }

        /// <see cref="IAimpRemote.Stop"/>
        public void Stop()
        {
            SendCommand(AimpRemoteNetApi.AimpRemoteCommand.AIMP_RA_CMD_STOP);
        }

        /// <see cref="IAimpRemote.Close"/>
        public void Close()
        {
            SendCommand(AimpRemoteNetApi.AimpRemoteCommand.AIMP_RA_CMD_QUIT);
            _isRegisteredForNotifications = false;
        }

        /// <see cref="IAimpRemote.NextVisualization"/>
        public void NextVisualization()
        {
            SendCommand(AimpRemoteNetApi.AimpRemoteCommand.AIMP_RA_CMD_VISUAL_NEXT);
        }

        /// <see cref="IAimpRemote.PrevVisualization"/>
        public void PrevVisualization()
        {
            SendCommand(AimpRemoteNetApi.AimpRemoteCommand.AIMP_RA_CMD_VISUAL_PREV);
        }

        /// <see cref="IAimpRemote.StartVisualization"/>
        public void StartVisualization()
        {
            SendCommand(AimpRemoteNetApi.AimpRemoteCommand.AIMP_RA_CMD_VISUAL_START);
        }

        /// <see cref="IAimpRemote.StopVisualization"/>
        public void StopVisualization()
        {
            SendCommand(AimpRemoteNetApi.AimpRemoteCommand.AIMP_RA_CMD_VISUAL_STOP);
        }

        /// <see cref="IAimpRemote.ExecuteOpenFilesDialog"/>
        public void ExecuteOpenFilesDialog()
        {
            PostCommand(AimpRemoteNetApi.AimpRemoteCommand.AIMP_RA_CMD_OPEN_FILES);
        }

        /// <see cref="IAimpRemote.ExecuteOpenFoldersDialog"/>
        public void ExecuteOpenFoldersDialog()
        {
            PostCommand(AimpRemoteNetApi.AimpRemoteCommand.AIMP_RA_CMD_OPEN_FOLDERS);
        }

        /// <see cref="IAimpRemote.ExecuteOpenPlaylistsDialog"/>
        public void ExecuteOpenPlaylistsDialog()
        {
            PostCommand(AimpRemoteNetApi.AimpRemoteCommand.AIMP_RA_CMD_OPEN_PLAYLISTS);
        }

        /// <see cref="IAimpRemote.ShowHide"/>
        public void ShowHide()
        {
            Win32.SendMessage(AimpHwnd, Win32.WM_SYSCOMMAND, (IntPtr)Win32.SC_RESTORE, IntPtr.Zero);
        }

        #endregion Commands

        #region AIMP Events

        /// <see cref="IAimpRemote.ProcessWndMessage"/>
        public bool ProcessWndMessage(int message, IntPtr wParam, IntPtr lParam)
        {
            switch (message)
            {
                case AimpRemoteNetApi.WM_AIMP_NOTIFY:
                    ProcessAimpWndMessages(wParam, lParam);
                    return true;
                case Win32.WM_COPYDATA:
                    OnCopyDataMessage(lParam);
                    return true;
            }
            return false;
        }

        /// <see cref="IAimpRemote.TrackStarted"/>
        public event AimpEventHandler<AimpTrackInfo> TrackStarted;

        /// <see cref="IAimpRemote.TrackInfoChanged"/>
        public event AimpEventHandler<AimpTrackInfo> TrackInfoChanged;

        /// <see cref="IAimpRemote.AimpPropertyChanged"/>
        public event AimpEventHandler<AimpPropertyType> AimpPropertyChanged;

        /// <see cref="IAimpRemote.AlbumArtChanged"/>
        public event AimpEventHandler<Image> AlbumArtChanged;

        #endregion Events

        /// <see cref="IAimpRemote.CurrentTrackInfo"
        public AimpTrackInfo CurrentTrackInfo
        {
            get
            {
                // http://www.ramsmusings.com/2013/11/12/memory-mapped-files-with-c/ - Memory Mapped Files with C#
                // http://msdn.microsoft.com/en-us/library/dd267591.aspx - MemoryMappedFile.OpenExisting Method (String, MemoryMappedFileRights)

                IntPtr AFile = IntPtr.Zero;

                try
                {
                    AFile = Win32.OpenFileMapping((uint)Win32.FileMapAccess.FileMapRead, true, AimpRemoteNetApi.AIMPRemoteAccessClass);

                    if (AFile == IntPtr.Zero) return AimpTrackInfo.EmptyAimpTrackInfo;

                    IntPtr AInfo = IntPtr.Zero;
                    try
                    {
                        AInfo = Win32.MapViewOfFile(AFile, Win32.FileMapAccess.FileMapRead, 0, 0, (UIntPtr)AimpRemoteNetApi.AIMPRemoteAccessMapFileSize);

                        var sInfo = (AimpRemoteNetApi.AimpRemoteFileInfoStruct)Marshal.PtrToStructure(AInfo, typeof(AimpRemoteNetApi.AimpRemoteFileInfoStruct));

                        return CreateAimpTrackInfo(AInfo, sInfo);
                    }
                    finally
                    {
                        Win32.UnmapViewOfFile(AInfo);
                    }

                }
                finally
                {
                    Win32.CloseHandle(AFile);
                }
            }
        }

        private static AimpTrackInfo CreateAimpTrackInfo(IntPtr AInfo, AimpRemoteNetApi.AimpRemoteFileInfoStruct sInfo)
        {
            AimpTrackInfo aimpTrackInfo = new AimpTrackInfo();

            int sSize = Marshal.SizeOf(sInfo);
            int offset = sSize;

            aimpTrackInfo.Album = Marshal.PtrToStringAuto((IntPtr)AInfo.ToInt64() + offset, sInfo.AlbumLength);
            offset += sInfo.AlbumLength * sizeof(char);
            aimpTrackInfo.Artist = Marshal.PtrToStringAuto((IntPtr)AInfo.ToInt64() + offset, sInfo.ArtistLength);
            offset += sInfo.ArtistLength * sizeof(char);
            aimpTrackInfo.Year = Marshal.PtrToStringAuto((IntPtr)AInfo.ToInt64() + offset, sInfo.DateLength);
            offset += sInfo.DateLength * sizeof(char);
            aimpTrackInfo.FileName = Marshal.PtrToStringAuto((IntPtr)AInfo.ToInt64() + offset, sInfo.FileNameLength);
            offset += sInfo.FileNameLength * sizeof(char);
            aimpTrackInfo.Genre = Marshal.PtrToStringAuto((IntPtr)AInfo.ToInt64() + offset, sInfo.GenreLength);
            offset += sInfo.GenreLength * sizeof(char);
            aimpTrackInfo.Title = Marshal.PtrToStringAuto((IntPtr)AInfo.ToInt64() + offset, sInfo.TitleLength);
            offset += sInfo.TitleLength * sizeof(char);

            aimpTrackInfo.Active = sInfo.Active;
            aimpTrackInfo.BitRate = sInfo.BitRate;
            aimpTrackInfo.Channels = sInfo.Channels;
            aimpTrackInfo.Duration = TimeSpan.FromMilliseconds(sInfo.Duration);
            aimpTrackInfo.FileMark = sInfo.FileMark;
            aimpTrackInfo.FileSize = sInfo.FileSize;
            aimpTrackInfo.SampleRate = sInfo.SampleRate;
            aimpTrackInfo.TrackNumber = sInfo.TrackNumber;
            return aimpTrackInfo;
        }

        #endregion IAimpRemote Implementation

        #region Private helper methods

        /// <summary>
        /// Get AIMP window handle
        /// </summary>
        private IntPtr AimpHwnd
        {
            get { return Win32.FindWindow(AimpRemoteNetApi.AIMPRemoteAccessClass, null); }
        }

        /// <summary>
        /// Helper method to send messages to the player in order to get the specified property value
        /// </summary>
        /// <param name="propertyId">The property ID</param>
        /// <returns>The property value</returns>
        private IntPtr GetPropertyValue(AimpRemoteNetApi.AimpRemoteProperty propertyId)
        {
            return Win32.SendMessage(AimpHwnd,
                                     AimpRemoteNetApi.WM_AIMP_PROPERTY,
                                     (IntPtr)((int)propertyId | AimpRemoteNetApi.AIMP_RA_PROPVALUE_GET),
                                     IntPtr.Zero);
        }

        /// <summary>
        /// Helper method to send messages to the player in order to set the specified property
        /// </summary>
        /// <param name="propertyId">The property ID</param>
        /// <param name="value">The property value</param>
        private void SetPropertyValue(AimpRemoteNetApi.AimpRemoteProperty propertyId, IntPtr value)
        {
            Win32.SendMessage(AimpHwnd,
                              AimpRemoteNetApi.WM_AIMP_PROPERTY,
                              (IntPtr)((int)propertyId | AimpRemoteNetApi.AIMP_RA_PROPVALUE_SET),
                              value);
        }

        /// <summary>
        /// Helper method to send messages to the player in order to call the specified command
        /// </summary>
        /// <param name="commandId">The command ID</param>
        private void SendCommand(AimpRemoteNetApi.AimpRemoteCommand commandId)
        {
            Win32.SendMessage(AimpHwnd, AimpRemoteNetApi.WM_AIMP_COMMAND, (IntPtr)commandId, IntPtr.Zero);
        }

        /// <summary>
        /// Helper method to send post-messages to the player in order to call the specified command
        /// </summary>
        /// <param name="commandId">The command ID</param>
        private void PostCommand(AimpRemoteNetApi.AimpRemoteCommand commandId)
        {
            Win32.PostMessage(AimpHwnd, AimpRemoteNetApi.WM_AIMP_COMMAND, (IntPtr)commandId, IntPtr.Zero);
        }

        /// <summary>
        /// Process windows messages from AIMP
        /// </summary>
        /// <param name="wParam">wParam</param>
        /// <param name="lParam">lParam</param>
        private void ProcessAimpWndMessages(IntPtr wParam, IntPtr lParam)
        {
            switch (wParam.ToInt32())
            {
                case (int)AimpRemoteNetApi.AimpRemoteEvent.AIMP_RA_NOTIFY_TRACK_START:
                    {
                        TrackStarted?.Invoke(this, new AimpEventArgs<AimpTrackInfo>(CurrentTrackInfo));
                        break;
                    }
                case (int)AimpRemoteNetApi.AimpRemoteEvent.AIMP_RA_NOTIFY_TRACK_INFO:
                    {
                        switch (lParam.ToInt32())
                        {
                            case 0:
                                {
                                    TrackInfoChanged?.Invoke(this, new AimpEventArgs<AimpTrackInfo>(CurrentTrackInfo));
                                    break;
                                }
                            case 1:
                                {
                                    SendAlbumArtRequest();
                                    break;
                                }
                        }
                        break;
                    }
                case (int)AimpRemoteNetApi.AimpRemoteEvent.AIMP_RA_NOTIFY_PROPERTY:
                    {
                        AimpPropertyChanged?.Invoke(this, new AimpEventArgs<AimpPropertyType>(ConvertToAimpPropertyType(lParam)));
                        break;
                    }
            }
        }

        /// <summary>
        /// Process WM_COPYDATA message from AIMP
        /// </summary>
        /// <param name="lParam"></param>
        private void OnCopyDataMessage(IntPtr lParam)
        {
            var cds = (Win32.COPYDATASTRUCT)Marshal.PtrToStructure(lParam, typeof(Win32.COPYDATASTRUCT));

            if (cds.dwData.ToInt32() != AimpRemoteNetApi.WM_AIMP_COPYDATA_ALBUMART_ID)
            {
                return;
            }

            var image = CreateAlbumArt(cds);

            AlbumArtChanged?.Invoke(this, new AimpEventArgs<Image>(image));
        }

        /// <summary>
        /// Create Image from COPYDATASTRUCT object and invoke AlbumArtLoaded event
        /// </summary>
        /// <param name="cds">COPYDATASTRUCT object, which contain album art image</param>
        private static Image CreateAlbumArt(Win32.COPYDATASTRUCT cds)
        {
            int length = cds.cbData;
            byte[] buffer = new byte[length];
            Image i = null;

            Marshal.Copy(cds.lpData, buffer, 0, length);

            using (MemoryStream ms = new MemoryStream(buffer))
            {
                ms.Seek(0, SeekOrigin.Begin);
                ms.Read(buffer, 0, length);

                i = new Bitmap(ms);
            }
            return i;
        }

        private static AimpPropertyType ConvertToAimpPropertyType(IntPtr lParam)
        {
            switch ((AimpRemoteNetApi.AimpRemoteProperty)lParam.ToInt32())
            {
                case AimpRemoteNetApi.AimpRemoteProperty.AIMP_RA_PROPERTY_MUTE:
                    return AimpPropertyType.Mute;
                case AimpRemoteNetApi.AimpRemoteProperty.AIMP_RA_PROPERTY_PLAYER_DURATION:
                    return AimpPropertyType.Duration;
                case AimpRemoteNetApi.AimpRemoteProperty.AIMP_RA_PROPERTY_PLAYER_POSITION:
                    return AimpPropertyType.Position;
                case AimpRemoteNetApi.AimpRemoteProperty.AIMP_RA_PROPERTY_PLAYER_STATE:
                    return AimpPropertyType.PlayerState;
                case AimpRemoteNetApi.AimpRemoteProperty.AIMP_RA_PROPERTY_RADIOCAP:
                    return AimpPropertyType.RadioCap;
                case AimpRemoteNetApi.AimpRemoteProperty.AIMP_RA_PROPERTY_TRACK_REPEAT:
                    return AimpPropertyType.Repeat;
                case AimpRemoteNetApi.AimpRemoteProperty.AIMP_RA_PROPERTY_TRACK_SHUFFLE:
                    return AimpPropertyType.Shuffle;
                case AimpRemoteNetApi.AimpRemoteProperty.AIMP_RA_PROPERTY_VISUAL_FULLSCREEN:
                    return AimpPropertyType.VisualMode;
                case AimpRemoteNetApi.AimpRemoteProperty.AIMP_RA_PROPERTY_VOLUME:
                    return AimpPropertyType.Volume;
            }
            return AimpPropertyType.None;
        }

        #endregion Private helper methods

        public void Dispose()
        {
            if (_isRegisteredForNotifications && IsStarted)
            {
                UnRegisterNotify();
            }
        }
    }
}
