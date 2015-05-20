using System;
using System.Runtime.InteropServices;

namespace AIMP.NET.RemoteAPI.Interop
{
    public static partial class Win32
    {
        [Flags]
        public enum FileMapAccess : uint
        {
            FileMapCopy = 0x0001,
            FileMapWrite = 0x0002,
            FileMapRead = 0x0004,
            FileMapAllAccess = 0x001F,
            FileMapExecute = 0x0020,
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct COPYDATASTRUCT
        {
            public IntPtr dwData;
            public int cbData;
            public IntPtr lpData;
        }
    }
}
