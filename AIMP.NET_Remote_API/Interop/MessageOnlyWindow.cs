using System;
using System.Windows.Forms;

namespace AIMP.NET.RemoteAPI.Interop
{
    internal class MessageOnlyWindow : NativeWindow
    {
        public MessageOnlyWindow()
        {
            var cp = new CreateParams
            {
                Parent = (IntPtr)(-3) // HWND Message
            };

            CreateHandle(cp);
        }
    }

    internal class AimpMessageOnlyWindow : MessageOnlyWindow
    {
        public delegate bool OnWndMessageHandler(int msg, IntPtr wParam, IntPtr lParam);

        public event OnWndMessageHandler WndMessageReceived;

        protected override void WndProc(ref Message m)
        {
            WndMessageReceived?.Invoke(m.Msg, m.WParam, m.LParam);
            base.WndProc(ref m);
        }
    }
}
