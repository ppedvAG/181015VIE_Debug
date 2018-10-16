using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HalloThreading
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Threads
            //Thread t1 = new Thread(MeineMethode);
            //Thread t2 = new Thread(MeineMethode);

            //t1.Start();
            //t2.Start();

            //// Warten auf einen Thread
            ////t1.Join();
            ////t2.Join();

            //Thread.Sleep(1000);
            //// Abbrechen

            //while (t1.IsAlive)
            //    Thread.Sleep(500);

            //t1.Abort();
            //t2.Abort(); 
            #endregion

            #region 2 Threads 1 Variable
            //Demo d1 = new Demo();

            //Thread t1 = new Thread(d1.MachEtwas);
            //Thread t2 = new Thread(d1.MachEtwas);

            //t1.Start();
            //t2.Start(); 
            #endregion

            #region ThreadPool und BackgroundWorker
            // ThreadPool.QueueUserWorkItem(MeineMethode);

            //BackgroundWorker bw = new BackgroundWorker();
            //bw.DoWork += MachEtwasImHintergrund;
            //bw.RunWorkerAsync(); 
            #endregion

            #region Tasks
            //Task t1 = new Task(() => 
            //{
            //    Console.WriteLine("Ich mache etwas in meinem Task");
            //    Thread.Sleep(1000);
            //    Console.WriteLine("Fertig");

            //});
            //t1.Start();

            //Task<string> t2 = new Task<string>(() =>
            //{
            //    Thread.Sleep(3000);
            //    return DateTime.Now.ToLongDateString();
            //});

            //t2.Start();
            ////Thread.Sleep(8000);
            ////string ergebis = t2.Result;
            ////Console.WriteLine(ergebis);

            //Task.WaitAny(t1, t2); 
            #endregion

            #region Tasks mit Exceptions
            //Task t1 = new Task(() => throw new FormatException());
            //t1.Start();

            //Task t2 = Task.Run(() => throw new DivideByZeroException());
            //Task t3 = Task.Factory.StartNew(() => throw new StackOverflowException());

            //// if(t1.IsFaulted)

            //try
            //{
            //    Task.WaitAll(t1, t2, t3);
            //}
            //catch (AggregateException ex)
            //{
            //    AggregateException flat = ex.Flatten();

            //    flat.Handle(x =>
            //    {
            //        switch (x)
            //        {
            //            case FormatException f:
            //                Console.WriteLine("Falsches Format");
            //                return true;
            //            case DivideByZeroException f:
            //                Console.WriteLine("Nix durch 0 !!!!");
            //                return true;
            //            case StackOverflowException f:
            //                Console.WriteLine("Übertreib ned");
            //                return true;
            //            default:
            //                return false;
            //        }
            //    });
            //} 
            #endregion

            // Parallel.Invoke(Zähler, Zähler, Zähler);

            // CodeMap: Grafische Ansicht für alle Verweise und Aufrufe
            // FindReferencesOnCodeMap: wenn man eine Variable x hat, kann man so sehr leicht nachverfolgen, wo x überall verwendet wird (zB Übergabe per Referenz an Methode Y)
            //Parallel.For(0, 10_000, new ParallelOptions { MaxDegreeOfParallelism = 2 }, i => Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: {i}"));

            //List<int> zahlen = new List<int>();
            ConcurrentBag<int> zahlen = new ConcurrentBag<int>(); // Ideal für Tasks und Threads
            Parallel.For(0, 10_000_000, i => zahlen.Add(new Random().Next(i)));
            
            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }

        public static void Zähler()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: {i}");
            }
        }



        private static void MachEtwasImHintergrund(object sender, DoWorkEventArgs e)
        {
            throw new DivideByZeroException();
            // ....
            //Console.WriteLine("ich mach was ...");
        }

        private static void MeineMethode(object item)
        {
            for (int i = 0; i < 100; i++)
            {
                try
                {
                    Thread.Sleep(100);
                    Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: {i}");
                }
                catch (ThreadAbortException)
                {
                    Thread.ResetAbort(); // z.B. hilfreich wenn man noch Drittressourcen freigeben muss
                }
            }
        }
    }
}
