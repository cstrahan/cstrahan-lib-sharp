using System;
using System.Collections.Generic;
using System.Text;

namespace CStrahan.Win32
{
    public class WindowInfo
    {
        /// <summary>
        /// Gets all child windows of the specified window
        /// </summary>
        /// <param name="hWndParent">Window Handle to get children for</param>
        public static IList<WindowInfo> GetWindows(IntPtr hWndParent)
        {
            var windows = new List<WindowInfo>();
            UnManagedMethods.EnumChildWindows(
                hWndParent,
                (handle, param) =>
                {
                    windows.Add(new WindowInfo(handle));
                    return 1;
                },
                0);

            return windows;
        }

        /// <summary>
        /// Gets all top level windows on the system.
        /// </summary>
        public static IList<WindowInfo> GetWindows()
        {
            var windows = new List<WindowInfo>();
            UnManagedMethods.EnumWindows(
                (handle, param) =>
                {
                    windows.Add(new WindowInfo(handle));
                    return 1;
                },
                0);

            return windows;
        }

        /// <summary>
        ///  Constructs a new instance of this class for
        ///  the specified Window Handle.
        /// </summary>
        /// <param name="hWnd">The Window Handle</param>
        public WindowInfo(IntPtr hWnd)
        {
            Handle = hWnd;
        }

        /// <summary>
        /// Gets the window's handle
        /// </summary>
        public IntPtr Handle { get; private set; }

        /// <summary>
        /// Gets the window's title (caption)
        /// </summary>
        public string Title
        {
            get
            {
                var title = new StringBuilder(260, 260);
                UnManagedMethods.GetWindowText(Handle, title, title.Capacity);
                return title.ToString();
            }
        }

        private static IntPtr GetLastVisibleActivePopUpOfWindow(IntPtr window)
        {
            IntPtr lastPopUp = UnManagedMethods.GetLastActivePopup(window);
            if (new WindowInfo(lastPopUp).IsVisible)
                return lastPopUp;
            else if (lastPopUp == window)
                return IntPtr.Zero;
            else
                return GetLastVisibleActivePopUpOfWindow(lastPopUp);
        }

        public WindowInfo Parent
        {
            get
            {
                var parentHandle = UnManagedMethods.GetParent(Handle);
                if (parentHandle == IntPtr.Zero)
                {
                    return null;
                }

                return new WindowInfo(parentHandle);
            }
        }

        // http://blogs.msdn.com/b/oldnewthing/archive/2007/10/08/5351207.aspx
        // TODO: Need to account for WS_EX_APPWINDOW
        public bool IsAltTabWindow
        {
            get
            {
                if (IsToolWindow || !IsVisible)
                {
                    return false;
                }

                // Start at the root owner
                IntPtr root = UnManagedMethods.GetAncestor(Handle, GetAncestor_Flags.GA_ROOTOWNER);

                return GetLastVisibleActivePopUpOfWindow(root) == Handle;
            }
        }

        private bool IsToolWindow
        {
            get
            {
                bool isToolWindow = (ExtendedWindowStyle & ExtendedWindowStyleFlags.WS_EX_TOOLWINDOW) ==
                                    ExtendedWindowStyleFlags.WS_EX_TOOLWINDOW;

                return isToolWindow;
            }
        }

        /// <summary>
        /// Gets the window's class name.
        /// </summary>
        public string ClassName
        {
            get
            {
                var className = new StringBuilder(260, 260);
                UnManagedMethods.GetClassName(Handle, className, className.Capacity);
                return className.ToString();
            }
        }

        /// <summary>
        /// Gets/Sets whether the window is iconic (mimimised) or not.
        /// </summary>
        public bool IsMinimized
        {
            get { return ((UnManagedMethods.IsIconic(Handle) == 0) ? false : true); }
        }

        public void Minimize()
        {
            UnManagedMethods.SendMessage(
                Handle,
                UnManagedMethods.WM_SYSCOMMAND,
                (IntPtr)UnManagedMethods.SC_MINIMIZE,
                IntPtr.Zero);
        }

        /// <summary>
        /// Gets/Sets whether the window is maximized or not.
        /// </summary>
        public bool IsMaximized
        {
            get { return ((UnManagedMethods.IsZoomed(Handle) == 0) ? false : true); }
        }

        public void Maximize()
        {
            UnManagedMethods.SendMessage(
                    Handle,
                    UnManagedMethods.WM_SYSCOMMAND,
                    (IntPtr)UnManagedMethods.SC_MAXIMIZE,
                    IntPtr.Zero);
        }

        /// <summary>
        /// Gets whether the window is visible.
        /// </summary>
        public bool IsVisible
        {
            get { return ((UnManagedMethods.IsWindowVisible(Handle) == 0) ? false : true); }
        }

        /// <summary>
        /// Gets the bounding rectangle of the window
        /// </summary>
        public Rectangle Rect
        {
            get
            {
                var rc = new RECT();
                UnManagedMethods.GetWindowRect(
                    Handle,
                    ref rc);

                var rcRet = new Rectangle(
                    rc.Left, rc.Top,
                    rc.Right - rc.Left, rc.Bottom - rc.Top);

                return rcRet;
            }
        }

        public WindowStyleFlags WindowStyle
        {
            get
            {
                return (WindowStyleFlags)UnManagedMethods.GetWindowLong(
                    Handle, UnManagedMethods.GWL_STYLE);
            }
        }

        public ExtendedWindowStyleFlags ExtendedWindowStyle
        {
            get
            {
                return (ExtendedWindowStyleFlags)UnManagedMethods.GetWindowLong(
                    Handle, UnManagedMethods.GWL_EXSTYLE);
            }
        }

        public override bool Equals(object obj)
        {
            var other = obj as WindowInfo;
            if (other == null) return false;
            return (other.Handle == this.Handle);
        }

        /// <summary>
        /// To allow items to be compared, the hash code
        /// is set to the Window handle, so two EnumWindowsItem
        /// objects for the same Window will be equal.
        /// </summary>
        /// <returns>The Window Handle for this window</returns>
        public override int GetHashCode()
        {
            return (int)Handle;
        }

        /// <summary>
        /// Restores and Brings the window to the front, 
        /// assuming it is a visible application window.
        /// </summary>
        public void Restore()
        {
            UnManagedMethods.SendMessage(
                Handle,
                UnManagedMethods.WM_SYSCOMMAND,
                (IntPtr)UnManagedMethods.SC_RESTORE,
                IntPtr.Zero);
            UnManagedMethods.BringWindowToTop(Handle);
            UnManagedMethods.SetForegroundWindow(Handle);
        }

        public struct Rectangle
        {
            public Rectangle(int x, int y, int width, int height)
                : this()
            {
                Left = x;
                Top = y;
                Width = width;
                Height = height;
            }

            public int Left { get; private set; }
            public int Top { get; private set; }
            public int Width { get; private set; }
            public int Height { get; private set; }
        }
    }
}