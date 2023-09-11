using System;
using System.Threading;

namespace ThreadSampleMul
{
    class Program
    {
        // Ümumi iterasiya dəyişəni
        //[ThreadStatic] //TODO Şərhdən çıxarmaq
        public static int counter;

        // Thread-ların rekursiv çağırılması
        public static void Method()
        {
            if (counter < 100)
            {
                counter++; // Çağırılan metodların iterasiya dəyişənin artırıması
                Console.WriteLine(counter + " - START --- " + Thread.CurrentThread.GetHashCode());

                Thread thread = new Thread(Method);
                thread.Start();
                thread.Join(); // Şərhə salmaq
            }

            Console.WriteLine("Thread {0} işini bitirdi.", Thread.CurrentThread.GetHashCode());
        }

        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Thread thread = new Thread(Method);
            thread.Start();
            thread.Join();

            Console.WriteLine("Əsas thread işini bitirdi.");

            // Delay
            Console.ReadKey();
        }
    }
}
