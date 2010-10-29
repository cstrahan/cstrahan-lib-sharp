using System;
using System.Runtime.InteropServices;
using System.Text;

namespace CStrahan.Win32
{
    internal class UnManagedMethods
    {
        public delegate int EnumWindowsProc(IntPtr hwnd, int lParam);

        public const int WM_COMMAND = 0x111;
        public const int WM_SYSCOMMAND = 0x112;

        public const int SC_RESTORE = 0xF120;
        public const int SC_CLOSE = 0xF060;
        public const int SC_MAXIMIZE = 0xF030;
        public const int SC_MINIMIZE = 0xF020;

        public const int GWL_STYLE = (-16);
        public const int GWL_EXSTYLE = (-20);

        /// <summary>
        /// Stop flashing. The system restores the window to its original state.
        /// </summary>
        public const int FLASHW_STOP = 0;

        /// <summary>
        /// Flash the window caption. 
        /// </summary>
        public const int FLASHW_CAPTION = 0x00000001;

        /// <summary>
        /// Flash the taskbar button.
        /// </summary>
        public const int FLASHW_TRAY = 0x00000002;

        /// <summary>
        /// Flash both the window caption and taskbar button.
        /// </summary>
        public const int FLASHW_ALL = (FLASHW_CAPTION | FLASHW_TRAY);

        /// <summary>
        /// Flash continuously, until the FLASHW_STOP flag is set.
        /// </summary>
        public const int FLASHW_TIMER = 0x00000004;

        /// <summary>
        /// Flash continuously until the window comes to the foreground. 
        /// </summary>
        public const int FLASHW_TIMERNOFG = 0x0000000C;

        [DllImport("user32")]
        public static extern int IsWindowVisible(
            IntPtr hWnd);

        [DllImport("user32", CharSet = CharSet.Auto)]
        public static extern int GetWindowText(
            IntPtr hWnd,
            StringBuilder lpString,
            int cch);

        [DllImport("user32", CharSet = CharSet.Auto)]
        public static extern int GetWindowTextLength(
            IntPtr hWnd);

        [DllImport("user32")]
        public static extern int BringWindowToTop(IntPtr hWnd);

        [DllImport("user32")]
        public static extern int SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32")]
        public static extern int IsIconic(IntPtr hWnd);

        [DllImport("user32")]
        public static extern int IsZoomed(IntPtr hwnd);

        [DllImport("user32", CharSet = CharSet.Auto)]
        public static extern int GetClassName(
            IntPtr hWnd,
            StringBuilder lpClassName,
            int nMaxCount);

        [DllImport("user32")]
        public static extern int FlashWindow(
            IntPtr hWnd,
            ref FLASHWINFO pwfi);

        [DllImport("user32")]
        public static extern int GetWindowRect(
            IntPtr hWnd,
            ref RECT lpRect);

        [DllImport("user32", CharSet = CharSet.Auto)]
        public static extern int SendMessage(
            IntPtr hWnd,
            int wMsg,
            IntPtr wParam,
            IntPtr lParam);

        [DllImport("user32", CharSet = CharSet.Auto)]
        public static extern uint GetWindowLong(
            IntPtr hwnd,
            int nIndex);

        [DllImport("user32.dll")]
        public static extern IntPtr GetLastActivePopup(IntPtr hWnd);

        [DllImport("user32.dll", ExactSpelling = true)]
        public static extern IntPtr GetAncestor(IntPtr hwnd, GetAncestor_Flags gaFlags);

        [DllImport("user32.dll", ExactSpelling = true)]
        public static extern IntPtr GetParent(IntPtr hWnd);

        [DllImport("user32")]
        public extern static int EnumWindows(
            EnumWindowsProc lpEnumFunc,
            int lParam);
        [DllImport("user32")]
        public extern static int EnumChildWindows(
            IntPtr hWndParent,
            EnumWindowsProc lpEnumFunc,
            int lParam);
    }
}