using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            // https://docs.microsoft.com/en-us/sysinternals/downloads/
            // https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.defaulttracelistener?view=netframework-4.7.2

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

            // System.Diagnostics : Trace (=> Logger, der immer geht !)
            // Listener -> Ausgabe steuern
            //Trace.AutoFlush = true;
            //Trace.Listeners.Add(new TextWriterTraceListener("log.txt"));
            //Trace.Listeners.Add(new EventLogTraceListener("Application"));

            #region Trace-Logdatei automatisch generieren:
            /*      Einfügen in app.config oder .config im output-verzeichnis
             * 
             *      <system.diagnostics>  
                        <trace autoflush="true" indentsize="4">  
                        <listeners>  
                            <remove name="Default" />  
                            <add name="myListener"  type="System.Diagnostics.TextWriterTraceListener"    initializeData="log.txt" />  
                        </listeners>  
                        </trace>  
                    </system.diagnostics>  
             * 
             * 
             * 
             * 
             */
            #endregion
            Trace.WriteLine("Trace #1: Programmstart");


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
                if (i == 55)
                    Debugger.Break();
                Thread.Sleep(1000);
                Console.WriteLine($"Hallo Welt {i}");
                Trace.WriteLine($"Trace #{i + 2}: Schleife mit Wert:{i}");
            }
        }
    }
}
