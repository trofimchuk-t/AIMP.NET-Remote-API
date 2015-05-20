using AIMP.NET.RemoteAPI.Interop;
using System.Runtime.InteropServices;

namespace AIMP.NET.RemoteAPI.RemoteAPI
{
    public partial class AimpRemoteNetApi
    {
        public const string AIMPRemoteAccessClass = "AIMP2_RemoteInfo";
        public const int AIMPRemoteAccessMapFileSize = 2048;

        // Messages, which you can send to window with "AIMPRemoteAccessClass" class
        // You can receive Window Handle via FindWindow function (see MSDN for details)
        public const int WM_AIMP_COMMAND = Win32.WM_USER + 0x75;
        public const int WM_AIMP_NOTIFY = Win32.WM_USER + 0x76;
        public const int WM_AIMP_PROPERTY = Win32.WM_USER + 0x77;

        // See AIMP_RA_CMD_GET_ALBUMART command
        public const int WM_AIMP_COPYDATA_ALBUMART_ID = 0x41495043;

        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Unicode)]
        public struct AimpRemoteFileInfoStruct
        {
            public int Deprecated1;
            public bool Active;
            public int BitRate;
            public int Channels;
            public int Duration;
            public long FileSize;
            public int FileMark;
            public int SampleRate;
            public int TrackNumber;
            public int AlbumLength;
            public int ArtistLength;
            public int DateLength;
            public int FileNameLength;
            public int GenreLength;
            public int TitleLength;

            //DWORD Deprecated2[6];
            public int Deprecated2_0;
            public int Deprecated2_1;
            public int Deprecated2_2;
            public int Deprecated2_3;
            public int Deprecated2_4;
            public int Deprecated2_5;
        }
    }

}
