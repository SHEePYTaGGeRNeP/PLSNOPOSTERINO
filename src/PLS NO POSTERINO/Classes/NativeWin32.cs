using System;
using System.Runtime.InteropServices;
using System.Text;

namespace PLS_NO_POSTERINO.Classes
{
    public class NativeWin32
    {
        public struct ProcessWindow
        {
            public IntPtr hWnd;
            public string Title;
            public ProcessWindow(IntPtr p_hwnd, string p_title)
            {
                hWnd = p_hwnd;
                Title = p_title;
            }
        }

        public const int WM_SETTEXT = 0x000c;
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_CLOSE = 0xF060;

        [DllImport("user32.dll", EntryPoint = "FindWindowEx")]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("user32.dll")]
        public static extern int FindWindow(
            string lpClassName, // class name 
            string lpWindowName // window name 
        );


        [DllImport("user32.dll")]
        public static extern int SendMessage(
            int hWnd, // handle to destination window 
            uint Msg, // message 
            int wParam, // first message parameter 
            int lParam // second message parameter 
        );

        [DllImport("user32.dll")]
        public static extern int SetForegroundWindow(
            int hWnd // handle to window
            );

        private const int GWL_EXSTYLE = (-20);
        private const int WS_EX_TOOLWINDOW = 0x80;
        private const int WS_EX_APPWINDOW = 0x40000;

        public const int GW_HWNDFIRST = 0;
        public const int GW_HWNDLAST = 1;
        public const int GW_HWNDNEXT = 2;
        public const int GW_HWNDPREV = 3;
        public const int GW_OWNER = 4;
        public const int GW_CHILD = 5;

        public static void SetTitle(IntPtr p_hwnd, string p_text)
        {
            const int WM_SETTEXT = 0x000C;
            SendMessage(p_hwnd, WM_SETTEXT, (IntPtr)p_text.Length, p_text);
        }
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int uMsg, int wParam, string lParam);

        [DllImport("user32.dll")]
        static extern int SendMessage(IntPtr hwnd, int msg, IntPtr wParam, [MarshalAs(UnmanagedType.LPStr)] string lParam);

        public delegate int EnumWindowsProcDelegate(int hWnd, int lParam);

        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        public static ProcessWindow GetActiveProcessWindow()
        {
            const int nChars = 256;
            StringBuilder Buff = new StringBuilder(nChars);
            IntPtr handle = GetForegroundWindow();

            if (GetWindowText(handle, Buff, nChars) > 0)
            {
                return new ProcessWindow(handle, Buff.ToString());
            }
            return new ProcessWindow();
        }


        [DllImport("user32")]
        public static extern int EnumWindows(EnumWindowsProcDelegate lpEnumFunc, int lParam);

        [DllImport("User32.Dll")]
        public static extern void GetWindowText(int h, StringBuilder s, int nMaxCount);

        [DllImport("user32", EntryPoint = "GetWindowLongA")]
        public static extern int GetWindowLongPtr(int hwnd, int nIndex);

        [DllImport("user32")]
        public static extern int GetParent(int hwnd);

        [DllImport("user32")]
        public static extern int GetWindow(int hwnd, int wCmd);

        [DllImport("user32")]
        public static extern int IsWindowVisible(int hwnd);

        [DllImport("user32")]
        public static extern int GetDesktopWindow();


        // Used to get User Idle time
        [DllImport("user32.dll")]
        public static extern bool GetLastInputInfo(out LASTINPUTINFO plii);

        [StructLayout(LayoutKind.Sequential)]
        public struct LASTINPUTINFO
        {
            public static readonly int SizeOf =
                   Marshal.SizeOf(typeof(LASTINPUTINFO));

            [MarshalAs(UnmanagedType.U4)]
            public int cbSize;
            [MarshalAs(UnmanagedType.U4)]
            public int dwTime;
        }
    }
}
