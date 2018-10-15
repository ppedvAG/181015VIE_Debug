using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalloDebugging
{
    class Program
    {
        static void Main(string[] args)
        {
            // Breakpoints mit Condition: Rechtsklick auf Breakpoint
            // Breakpoint-Fenster: 
            Console.WriteLine("Hallo Debugger");

            HalloWelt();

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }

        private static void HalloWelt()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Hallo Welt");
            }
        }
    }
}
