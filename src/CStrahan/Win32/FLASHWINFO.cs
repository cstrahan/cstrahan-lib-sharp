using System;
using System.Runtime.InteropServices;

namespace CStrahan.Win32
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    internal struct FLASHWINFO
    {
        public readonly int cbSize;
        public readonly IntPtr hwnd;
        public readonly int dwFlags;
        public readonly int uCount;
        public readonly int dwTimeout;
    }
}