using System;
using System.Threading;

// Приоритеты потоков

namespace Priority
{
    class PriorityTest
    {
        public bool stop = false;

        public void Method()
        {
            Console.WriteLine("Thrad {0,3} prioriteti ilə olan {1,11} işə başladı",
                Thread.CurrentThread.ManagedThreadId,
                Thread.CurrentThread.Priority);

            long count = 0;

            while (!stop)
                count++;

            Console.WriteLine("Thread {0,3} prioritet ilə olan {1,11} işini dayandırdı. Count = {2,13}",
                Thread.CurrentThread.ManagedThreadId,
                Thread.CurrentThread.Priority,
                count.ToString("N0"));
        }
    }

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Press any key...");
            Console.ReadKey();

            Console.WriteLine("Əsas  thread-ın default prioriteti: {0}",
                Thread.CurrentThread.Priority);

            PriorityTest priorityTest = new PriorityTest();

            Thread[] threads = new Thread[9];

            for (int i = 0; i < 9; i++)
                threads[i] = new Thread(priorityTest.Method);

            // Thread-lara prioritetin verilməsi
            threads[0].Priority = ThreadPriority.Lowest;

            for (int i = 1; i < 9; i++)
                threads[i].Priority = ThreadPriority.Highest;

            // Aşağı prioriteti olan birinci thread-ı işə salmaq
            threads[0].Start();

            // Yüksək prioriteti olan thread-ları 2 saniyə gözləmək
            //Thread.Sleep(2000);

            // Digər 8 yüksək prioriteti olan thread-ları işə salmaq
            for (int i = 1; i < 9; i++)
                threads[i].Start();

            // Thread-ların işləməsi üçün 10 saniyə gözləmək
            Thread.Sleep(10000);

            // Bütün thread-ların işini dayandırmaq
            priorityTest.stop = true;

            // Delay
            Console.ReadKey();
        }
    }
}