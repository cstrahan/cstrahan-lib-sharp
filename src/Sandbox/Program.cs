using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using CStrahan;
using CStrahan.Win32;

namespace Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            //var windows = WindowInfo.GetWindows();

            //foreach (var windowInfo in windows.Where(x => x.IsAltTabWindow))
            //{
            //    Console.WriteLine(windowInfo.Title);
            //}


            var fib = Lambda.Y<int, int>(f => n => n < 2 ? n : f(n - 1) + f(n - 2));

            foreach (var n in Enumerable.Range(0, 10))
            {
                Console.WriteLine("fib({0}) = {1}", n, fib(n));
            }



            Console.WriteLine(".......");
            Console.ReadKey(true);
        }
    }
}
