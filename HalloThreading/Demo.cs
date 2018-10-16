using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HalloThreading
{
    class Demo
    {
        private int zähler = 0;
        private object syncObject = new object();
        public void MachEtwas()
        {
            while (true)
            {

                // Monitor.Enter(syncObject);
                lock (syncObject)
                {
                    zähler++;
                    if (zähler > 100)
                        break;
                    Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: Zähler: {zähler}");
                }
                // Monitor.Exit(syncObject);

                // Alternative: Interlocked für einfache operationen wie increment/decrement usw...

            }

        }
    }
}
