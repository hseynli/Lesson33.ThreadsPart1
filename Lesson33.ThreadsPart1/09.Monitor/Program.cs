using System;
using System.Threading;

// Qeyd: Monitor klasından istifadə zamanı blokirovka obyektləri üçün struktur tiplərdən istifafə etmək olmaz.

// Lock - struktur tiplərlə düzgün işləmir, ancaq reference tiplərdən istifadəyə yol verilir.

namespace monitor
{
    class Program
    {
        static int counter = 0;

        static int block = 0; // block - struktur tip olmamalıdır.

        static void Function()
        {
            for (int i = 0; i < 50; ++i)
            {               
                Monitor.Enter((object)block); // boxing hər dəfə yeni obyekt yaradır (50! obyekt).

                // Thread tərəfindən hər-hansı işin yerinə yetirilməsi...
                Console.WriteLine(++counter);

                // blokirovka obyekti olmayan obyekti blokdan çıxarmağa çalışmaq.
                Monitor.Exit((object)block); // boxing tamamilə yeni obyekt yaradır.
            }
        }

        static void Main()
        {
            Thread[] threads = { new Thread(Function), new Thread(Function), new Thread(Function) };

            foreach (Thread thread in threads)
                thread.Start();

            // Delay
            Console.ReadKey();
        }
    }
}
