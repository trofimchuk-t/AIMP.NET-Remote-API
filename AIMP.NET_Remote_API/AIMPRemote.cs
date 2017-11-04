using AIMP.NET.RemoteAPI.Interop;
using AIMP.NET.RemoteAPI.RemoteAPI;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;

namespace AIMP.NET.RemoteAPI
{
    public class AimpRemote : IAimpRemote
    {
        protected IntPtr _hostHandle;
        protected bool _isRegisteredForNotifications;
        private AimpMessageOnlyWindow moWindow;

        public AimpRemote()
        {
            this.moWindow = new AimpMessageOnlyWindow();
            Init(this.moWindow.Handle);
            this.moWindow.WndMessageReceived += ProcessWndMessage;
        }

        public AimpRemote(IntPtr hostHandle)
        {
            Init(hostHandle);
        }

        private void Init(IntPtr hostHandle)
        {
            _hostHandle = hostHandle;
            if (hostHandle != IntPtr.Zero) RegisterNotify();

            InitEvents();
        }

        #region IAimpRemote Implementation

        #region AIMP Properties ===============================================

        /// <summary>
        /// Свойство, позволяющее узнать длительность текущего трека
        /// </summary>
        public TimeSpan Duration
        {
            get
            {
                IntPtr result = GetPropertyValue(AimpRemoteNetApi.AimpRemoteProperty.AIMP_RA_PROPERTY_PLAYER_DURATION);
                return TimeSpan.FromMilliseconds((double)result);
            }
        }

        /// <summary>
        /// Свойство, позволяющее узнать/установить текущую позицию проигрываемого трека
        /// </summary>
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
                SetPropertyValue(AimpRemoteNetApi.AimpRemoteProperty.AIMP_RA_PROPERTY_PLAYER_POSITION,
                    (IntPtr)milliseconds);
            }
        }

        /// <summary>
        /// Свойство, позволяющее узнать текущее состояние плеера
        /// </summary>
        public PlayerState PlayerState
        {
            get
            {
                IntPtr result = GetPropertyValue(AimpRemoteNetApi.AimpRemoteProperty.AIMP_RA_PROPERTY_PLAYER_STATE);
                return (PlayerState)result;
            }
        }

        /// <summary>
        /// Свойство, позволяющее узнать/установить режим MUTE
        /// </summary>
        public bool IsMuteEnabled
        {
            get
            {
                IntPtr result = GetPropertyValue(AimpRemoteNetApi.AimpRemoteProperty.AIMP_RA_PROPERTY_MUTE);
                return (result != IntPtr.Zero);
            }
            set
            {
                SetPropertyValue(AimpRemoteNetApi.AimpRemoteProperty.AIMP_RA_PROPERTY_MUTE,
                    (IntPtr)Convert.ToInt32(value));
            }
        }

        /// <summary>
        /// Свойство, позволяющее узнать/установить режим записи радиостанции
        /// </summary>
        public bool IsRadioCapEnabled
        {
            get
            {
                IntPtr result = GetPropertyValue(AimpRemoteNetApi.AimpRemoteProperty.AIMP_RA_PROPERTY_RADIOCAP);
                return (result != IntPtr.Zero);
            }
            set
            {
                SetPropertyValue(AimpRemoteNetApi.AimpRemoteProperty.AIMP_RA_PROPERTY_RADIOCAP,
                    (IntPtr)Convert.ToInt32(value));
            }
        }

        /// <summary>
        /// Свойство, позволяющее узнать/установить режим Repeat
        /// </summary>
        public bool IsRepeatEnabled
        {
            get
            {
                IntPtr result = GetPropertyValue(AimpRemoteNetApi.AimpRemoteProperty.AIMP_RA_PROPERTY_TRACK_REPEAT);
                return (result != IntPtr.Zero);
            }
            set
            {
                SetPropertyValue(AimpRemoteNetApi.AimpRemoteProperty.AIMP_RA_PROPERTY_TRACK_REPEAT,
                    (IntPtr)Convert.ToInt32(value));
            }
        }

        /// <summary>
        /// Свойство, позволяющее узнать/установить режим Shuffle
        /// </summary>
        public bool IsShuffleEnabled
        {
            get
            {
                IntPtr result = GetPropertyValue(AimpRemoteNetApi.AimpRemoteProperty.AIMP_RA_PROPERTY_TRACK_SHUFFLE);
                return (result != IntPtr.Zero);
            }
            set
            {
                SetPropertyValue(AimpRemoteNetApi.AimpRemoteProperty.AIMP_RA_PROPERTY_TRACK_SHUFFLE,
                    (IntPtr)Convert.ToInt32(value));
            }
        }

        /// <summary>
        /// Возвращает версию плеера
        /// </summary>
        public AimpVersion Version
        {
            get
            {
                //if (_aimpVersion == null)
                //{
                IntPtr result = GetPropertyValue(AimpRemoteNetApi.AimpRemoteProperty.AIMP_RA_PROPERTY_VERSION);
                //_aimpVersion = new AimpVersion((int)result);
                return new AimpVersion((int)result);
                //}
                //return _aimpVersion;
            }
        }

        /// <summary>
        /// Свойство, позволяющее узнать/установить полноэкранный режим визуализации
        /// </summary>
        public bool IsVisualInFullScreen
        {
            get
            {
                IntPtr result = GetPropertyValue(AimpRemoteNetApi.AimpRemoteProperty.AIMP_RA_PROPERTY_VISUAL_FULLSCREEN);
                return (result != IntPtr.Zero);
            }
            set
            {
                SetPropertyValue(AimpRemoteNetApi.AimpRemoteProperty.AIMP_RA_PROPERTY_VISUAL_FULLSCREEN,
                    (IntPtr)Convert.ToInt32(value));
            }
        }

        /// <summary>
        /// Свойство, позволяющее узнать/установить громкость плеера
        /// </summary>
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


        public bool IsStarted { get { return AimpHwnd != IntPtr.Zero; } }
        #endregion Player Properties

        #region AIMP Commands =================================================

        public void RegisterNotify()
        {
            if (this.IsStarted)
            {
                Win32.SendMessage(AimpHwnd, AimpRemoteNetApi.WM_AIMP_COMMAND,
                    (IntPtr)AimpRemoteNetApi.AimpRemoteCommand.AIMP_RA_CMD_REGISTER_NOTIFY, _hostHandle);
                this._isRegisteredForNotifications = true;
            }
            this._isRegisteredForNotifications = false;
        }

        public void UnRegisterNotify()
        {
            Win32.SendMessage(AimpHwnd, AimpRemoteNetApi.WM_AIMP_COMMAND,
                (IntPtr)AimpRemoteNetApi.AimpRemoteCommand.AIMP_RA_CMD_UNREGISTER_NOTIFY, _hostHandle);
            this._isRegisteredForNotifications = false;
        }


        public void ExecuteAddFilesDialog()
        {
            SendCommand(AimpRemoteNetApi.AimpRemoteCommand.AIMP_RA_CMD_ADD_FILES);
        }

        public void ExecuteAddFoldersDialog()
        {
            SendCommand(AimpRemoteNetApi.AimpRemoteCommand.AIMP_RA_CMD_ADD_FOLDERS);
        }

        public void ExecuteAddPlaylistsDialog()
        {
            SendCommand(AimpRemoteNetApi.AimpRemoteCommand.AIMP_RA_CMD_ADD_PLAYLISTS);
        }

        public void ExecuteAddUrlDialog()
        {
            SendCommand(AimpRemoteNetApi.AimpRemoteCommand.AIMP_RA_CMD_ADD_URL);
        }

        public void SendAlbumArtRequest()
        {
            if (Win32.SendMessage(AimpHwnd, AimpRemoteNetApi.WM_AIMP_COMMAND,
                        (IntPtr)AimpRemoteNetApi.AimpRemoteCommand.AIMP_RA_CMD_GET_ALBUMART, _hostHandle) == IntPtr.Zero)
            {
                //Clear current album art
                AlbumArtChanged.Invoke(this, new AimpEventArgs<Image>(null));
            }
        }

        public void Next()
        {
            SendCommand(AimpRemoteNetApi.AimpRemoteCommand.AIMP_RA_CMD_NEXT);
        }

        public void Prev()
        {
            SendCommand(AimpRemoteNetApi.AimpRemoteCommand.AIMP_RA_CMD_PREV);
        }

        //Если плеер остановлен - начинает воспроизведение.
        //Если плеер на паузе - продолжает воспроизведение.
        //Если плеер проигрывает трек - начинает трек с начала. 
        public void Play()
        {
            SendCommand(AimpRemoteNetApi.AimpRemoteCommand.AIMP_RA_CMD_PLAY);
        }

        //Если плеер проигрывает трек - ставит на паузу.
        //Если плеер на паузе - продолжает воспроизведение.
        public void Pause()
        {
            SendCommand(AimpRemoteNetApi.AimpRemoteCommand.AIMP_RA_CMD_PAUSE);
        }

        //Если плеер остановлен - начинает воспроизведение.
        //Если плеер на паузе - продолжает воспроизведение.
        //Если плеер проигрывает трек - ставит на паузу.
        public void PlayOrPause()
        {
            SendCommand(AimpRemoteNetApi.AimpRemoteCommand.AIMP_RA_CMD_PLAYPAUSE);
        }

        public void Stop()
        {
            SendCommand(AimpRemoteNetApi.AimpRemoteCommand.AIMP_RA_CMD_STOP);
        }

        /// <summary>
        /// Закрыть программу
        /// </summary>
        public void Close()
        {
            SendCommand(AimpRemoteNetApi.AimpRemoteCommand.AIMP_RA_CMD_QUIT);
            _isRegisteredForNotifications = false;
        }

        /// <summary>
        /// Следующая визуализация
        /// </summary>
        public void NextVisualization()
        {
            SendCommand(AimpRemoteNetApi.AimpRemoteCommand.AIMP_RA_CMD_VISUAL_NEXT);
        }

        /// <summary>
        /// Предыдущая визуализация
        /// </summary>
        public void PrevVisualization()
        {
            SendCommand(AimpRemoteNetApi.AimpRemoteCommand.AIMP_RA_CMD_VISUAL_PREV);
        }

        /// <summary>
        /// Запускает визуализацию, выбранную до этого пользователем. Если визуализации нет - запускает первую. 
        /// </summary>
        public void StartVisualization()
        {
            SendCommand(AimpRemoteNetApi.AimpRemoteCommand.AIMP_RA_CMD_VISUAL_START);
        }

        /// <summary>
        /// Выключает визуализацию
        /// </summary>
        public void StopVisualization()
        {
            SendCommand(AimpRemoteNetApi.AimpRemoteCommand.AIMP_RA_CMD_VISUAL_STOP);
        }

        public void ExecuteOpenFilesDialog()
        {
            PostCommand(AimpRemoteNetApi.AimpRemoteCommand.AIMP_RA_CMD_OPEN_FILES);
        }

        public void ExecuteOpenFoldersDialog()
        {
            PostCommand(AimpRemoteNetApi.AimpRemoteCommand.AIMP_RA_CMD_OPEN_FOLDERS);
        }

        public void ExecuteOpenPlaylistsDialog()
        {
            PostCommand(AimpRemoteNetApi.AimpRemoteCommand.AIMP_RA_CMD_OPEN_PLAYLISTS);
        }

        public void ShowHide()
        {
            Win32.SendMessage(AimpHwnd, Win32.WM_SYSCOMMAND, (IntPtr)Win32.SC_RESTORE, IntPtr.Zero);
        }
        #endregion Commands

        #region AIMP Events ===================================================

        public bool ProcessWndMessage(int message, IntPtr wParam, IntPtr lParam)
        {
            switch (message)
            {
                case AimpRemoteNetApi.WM_AIMP_NOTIFY:
                    ProcessWndMessages(wParam, lParam);
                    return true;
                case Win32.WM_COPYDATA:
                    OnCopyDataMessage(lParam);
                    return true;
            }
            return false;
        }


        public event AimpEventHandler<AimpTrackInfo> TrackStarted;
        public event AimpEventHandler<AimpTrackInfo> TrackInfoChanged;
        public event AimpEventHandler<AimpPropertyType> AimpPropertyChanged;
        public event AimpEventHandler<Image> AlbumArtChanged;

        #endregion Events

        // ============================================================

        public AimpTrackInfo CurrentTrackInfo
        {
            get
            {
                // http://www.ramsmusings.com/2013/11/12/memory-mapped-files-with-c/ - Memory Mapped Files with C#
                // http://msdn.microsoft.com/en-us/library/dd267591.aspx - MemoryMappedFile.OpenExisting Method (String, MemoryMappedFileRights)

                IntPtr AFile = IntPtr.Zero;

                try
                {
                    AFile = Win32.OpenFileMapping(
                        (uint)Win32.FileMapAccess.FileMapRead,
                        true,
                        AimpRemoteNetApi.AIMPRemoteAccessClass);

                    if (AFile == IntPtr.Zero) return AimpTrackInfo.EmptyAimpTrackInfo;

                    IntPtr AInfo = IntPtr.Zero;
                    try
                    {
                        AInfo = Win32.MapViewOfFile(AFile,
                            Win32.FileMapAccess.FileMapRead,
                            0, 0,
                            (UIntPtr)AimpRemoteNetApi.AIMPRemoteAccessMapFileSize);

                        AimpRemoteNetApi.AimpRemoteFileInfoStruct sInfo = (AimpRemoteNetApi.AimpRemoteFileInfoStruct)
                            Marshal.PtrToStructure(AInfo, typeof(AimpRemoteNetApi.AimpRemoteFileInfoStruct));

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

        #endregion

        #region Private helper methods ========================================

        private void InitEvents()
        {
            TrackStarted += (s, e) => { };
            TrackInfoChanged += (s, e) => { };
            AimpPropertyChanged += (s, e) => { };
            AlbumArtChanged += (s, e) => { };
        }

        /// <summary>
        /// Get AIMP window HANDLE
        /// </summary>
        private IntPtr AimpHwnd
        {
            get { return Win32.FindWindow(AimpRemoteNetApi.AIMPRemoteAccessClass, null); }
        }

        /// <summary>
        /// Вспомогательный метод для отправки сообщений плееру с целью получить значение указанного свойства
        /// </summary>
        /// <param name="propertyId">Свойство, значение которого необходимо получить</param>
        /// <returns>Значение свойства</returns>
        private IntPtr GetPropertyValue(AimpRemoteNetApi.AimpRemoteProperty propertyId)
        {
            return Win32.SendMessage(AimpHwnd,
                                     AimpRemoteNetApi.WM_AIMP_PROPERTY,
                                     (IntPtr)((int)propertyId | AimpRemoteNetApi.AIMP_RA_PROPVALUE_GET),
                                     IntPtr.Zero);
        }

        /// <summary>
        /// Вспомогательный метод для отправки сообщений плееру с целью установить значение указанного свойства
        /// </summary>
        /// <param name="propertyId">Свойство, значение которого нужно установить</param>
        /// <param name="value">Значение свойства</param>
        private void SetPropertyValue(AimpRemoteNetApi.AimpRemoteProperty propertyId, IntPtr value)
        {
            Win32.SendMessage(AimpHwnd,
                              AimpRemoteNetApi.WM_AIMP_PROPERTY,
                              (IntPtr)((int)propertyId | AimpRemoteNetApi.AIMP_RA_PROPVALUE_SET),
                              value);
        }

        /// <summary>
        /// Вспомогательный метод для отправки сообщений плееру с целью вызвать указанную комманду
        /// </summary>
        /// <param name="commandId">Идентификатор комманды</param>
        private void SendCommand(AimpRemoteNetApi.AimpRemoteCommand commandId)
        {
            Win32.SendMessage(AimpHwnd, AimpRemoteNetApi.WM_AIMP_COMMAND, (IntPtr)commandId, IntPtr.Zero);
        }

        /// <summary>
        /// Вспомогательный метод для отправки post-сообщений плееру с целью вызвать указанную комманду
        /// </summary>
        /// <param name="commandId">Идентификатор комманды</param>
        private void PostCommand(AimpRemoteNetApi.AimpRemoteCommand commandId)
        {
            Win32.PostMessage(AimpHwnd, AimpRemoteNetApi.WM_AIMP_COMMAND, (IntPtr)commandId, IntPtr.Zero);
        }

        /// <summary>
        /// Process events from AIMP
        /// </summary>
        /// <param name="wParam">wParam</param>
        /// <param name="lParam">lParam</param>
        private void ProcessWndMessages(IntPtr wParam, IntPtr lParam)
        {
            switch (wParam.ToInt32())
            {
                case (int)AimpRemoteNetApi.AimpRemoteEvent.AIMP_RA_NOTIFY_TRACK_START:
                    TrackStarted.Invoke(this,
                        new AimpEventArgs<AimpTrackInfo>(this.CurrentTrackInfo));
                    break;
                case (int)AimpRemoteNetApi.AimpRemoteEvent.AIMP_RA_NOTIFY_TRACK_INFO:
                    switch (lParam.ToInt32())
                    {
                        case 0:
                            TrackInfoChanged.Invoke(this,
                                new AimpEventArgs<AimpTrackInfo>(this.CurrentTrackInfo));
                            break;
                        case 1:
                            //TrackCoverArtChanged.Invoke(this, EventArgs.Empty);
                            SendAlbumArtRequest();
                            break;
                    }
                    break;
                case (int)AimpRemoteNetApi.AimpRemoteEvent.AIMP_RA_NOTIFY_PROPERTY:
                    AimpPropertyChanged.Invoke(this, new AimpEventArgs<AimpPropertyType>(ConvertToAimpPropertyType(lParam)));
                    break;
            }
        }

        /// <summary>
        /// Process WM_COPYDATA message from AIMP
        /// </summary>
        /// <param name="lParam"></param>
        private void OnCopyDataMessage(IntPtr lParam)
        {
            Win32.COPYDATASTRUCT cds = (Win32.COPYDATASTRUCT)Marshal.PtrToStructure(lParam, typeof(Win32.COPYDATASTRUCT));
            if (cds.dwData.ToInt32() != AimpRemoteNetApi.WM_AIMP_COPYDATA_ALBUMART_ID) return;

            var image = CreateAlbumArt(cds);
            AlbumArtChanged.Invoke(this, new AimpEventArgs<Image>(image));
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

        #endregion

        public void Dispose()
        {
            if (_isRegisteredForNotifications && this.IsStarted)
            {
                UnRegisterNotify();
            }
        }
    }
}
