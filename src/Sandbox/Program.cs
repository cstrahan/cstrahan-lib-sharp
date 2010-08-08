using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using CStrahan;
using Microsoft.Win32;

namespace Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            ITypeLib typeLib;
            COMUtil.LoadTypeLibEx("C:/Program Files (x86)/Apple Software Update/SoftwareUpdateAdmin.dll", REGKIND.REGKIND_NONE, out typeLib);

            var progIds = COMUtil.GetProgIds(typeLib);

            typeof (Marshal).GetMethod("GetTypeLibName", new[] {typeof (ITypeLib)});
            Console.WriteLine(Marshal.GetTypeLibName(typeLib));
            foreach (var progId in progIds)
            {
                Console.WriteLine(progId);
            }

            var g =Guid.Parse("0AF768AC-4FBD-4914-B847-F4E13C984926");
            var lib = COMUtil.GetTypeLibByCLSID(g, 1, 0, 0);

            string name, docString, helpFile;
            int helpContext;
            lib.GetDocumentation(-1, 
				out name, 
 				out docString,
                out helpContext,
				out helpFile);

            

            Console.WriteLine(".......");
            Console.ReadKey(true);
        }
    }
}
