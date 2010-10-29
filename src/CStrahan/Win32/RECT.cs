using System.Runtime.InteropServices;

namespace CStrahan.Win32
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    internal struct RECT
    {
        public readonly int Left;
        public readonly int Top;
        public readonly int Right;
        public readonly int Bottom;
    }
}