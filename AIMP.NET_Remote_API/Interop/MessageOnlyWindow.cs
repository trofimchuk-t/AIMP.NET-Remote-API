using System;
using System.Windows.Forms;

namespace AIMP.NET.RemoteAPI.Interop
{
    internal class MessageOnlyWindow : NativeWindow
    {
        public MessageOnlyWindow()
        {
            CreateParams cp = new CreateParams();
            cp.Parent = (IntPtr)(-3); // HWND Message
            this.CreateHandle(cp);
        }
    }

    internal class AimpMessageOnlyWindow : MessageOnlyWindow
    {
        public delegate bool OnWndMessageHandler(int msg, IntPtr wParam, IntPtr lParam);

        public event OnWndMessageHandler WndMessageReceived;

        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            if (WndMessageReceived != null) WndMessageReceived(m.Msg, m.WParam, m.LParam);
            base.WndProc(ref m);
        }
    }
}
