using System;
using System.Threading;

// Interlocked - Bir neçə thread-lara aid olan ümumi dəyişənlər üzərində işləmək üçündür.

namespace InterLocked
{
    class Program
    {
        // İterasiya dəyişəni
        static long counter;
        static object block = new object();

        static void Procedure()
        {
            // İterasiyanın artırılması
            for (int i = 0; i < 1000000; i++)
            {
                counter++;
                //Interlocked.Increment(ref counter);

                //lock (block)
                //{
                //  counter++;
                //}
            }
        }

        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("İterasiyanın gözlənilən dəyəri = 10000000");

            Thread[] threads = new Thread[10];

            for (int i = 0; i < 10; ++i)
                (threads[i] = new Thread(Procedure)).Start();

            for (int i = 0; i < 10; ++i)
                threads[i].Join();

            Console.WriteLine("İterasiyanın real dəyəri = {0}", counter);

            // Delay
            Console.ReadKey();
        }
    }
}
