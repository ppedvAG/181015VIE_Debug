using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HalloDebugging
{
    class Program
    {
        static string text = "Start";
        static void Main(string[] args)
        {
            // Breakpoints mit Condition: Rechtsklick auf Breakpoint
            // Breakpoint-Fenster: Debug/Windows/Breakpoints (Export usw...)
            // https://referencesource.microsoft.com/
            Console.WriteLine("Hallo Debugger");

            text = "Main";
            // MachFehler();

#if DEBUG
            Console.WriteLine("DEBUG");
#endif
#if KÄSE
            Console.WriteLine("KÄSE");
#endif
#if WURST
            Console.WriteLine("WURST");
#endif

            HalloWelt();

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }


        private static void MachFehler()
        {
            throw new DivideByZeroException();
        }

        private static void HalloWelt()
        {
            text = "HalloWelt";
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine($"Hallo Welt {i}");
            }
        }
    }
}
