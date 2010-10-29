using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using CStrahan.Win32;

namespace Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            var windows = WindowInfo.GetWindows();

            foreach (var windowInfo in windows.Where(x => x.IsAltTabWindow))
            {
                Console.WriteLine(windowInfo.Title);
            }

            Console.WriteLine(".......");
            Console.ReadKey(true);
        }
    }
}
