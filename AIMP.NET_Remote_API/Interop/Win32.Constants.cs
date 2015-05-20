using System;
using System.Runtime.InteropServices;

namespace AIMP.NET.RemoteAPI.Interop
{
    public static partial class Win32
    {
        public const int WM_USER = 0x0400;
        public const int WM_COPYDATA = 0x004A;
        public const int WM_SYSCOMMAND = 0x0112;

        public const int SC_MINIMIZE = 0xF020;
        public const int SC_MAXIMIZE = 0xF030;
        public const int SC_CLOSE = 0xF060;
        public const int SC_RESTORE = 0xF120;
    }
}
