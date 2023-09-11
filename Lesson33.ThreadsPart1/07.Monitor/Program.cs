using System;
using System.Threading;

namespace monitor
{
    class Program
    {
        // Blokirovka üçün obyekt.
        static object block = new object();

        // Thread-ların iterasiya dəyişəni.
        static int counter;
        static Random random = new Random();

        // Ayrıca thread-da icra olunacaqdır.
        private static void Function()
        {
            try
            {
                Monitor.Enter(block); // Blokirovkanın başlanğıcı. lock(block){
                counter++;
            }
            finally
            {
                Monitor.Exit(block);  // Blokirovkanın sonu. }
            }

            int wait = random.Next(1000, 12000);
            Thread.Sleep(wait);

            try
            {
                Monitor.Enter(block); // Blokirovkanın başlanğıcı.
                counter--;
            }
            finally
            {
                Monitor.Exit(block);  // Blokirovkanın sonu.
            }
        }

        // Yaradılmış thread-ların monitorinqi.
        static void Report()
        {
            while (true)
            {
                int count;

                try
                {
                    Monitor.Enter(block); // Blokirovkanın başlanğıcı.
                    count = counter;
                }
                finally
                {
                    Monitor.Exit(block);  // Blokirovkanın sonu.
                }

                Console.WriteLine("{0} sayda thread aktivdir", count);
                Thread.Sleep(100);
            }
        }

        static void Main()
        {
            var reporter = new Thread(Report) { IsBackground = true };
            reporter.Start();

            var threads = new Thread[150];

            for (uint i = 0; i < 150; ++i)
            {
                threads[i] = new Thread(Function);
                threads[i].Start();
            }

            Thread.Sleep(15000);
        }
    }
}
