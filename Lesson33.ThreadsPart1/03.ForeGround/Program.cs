using System;
using System.Threading;

// Thread-ların iki işləmə növü var: Foreground və Background
// Foreground - Əsas thread işini bitirdikdən sonra da işinə davam edəcək.
// Background - Əsas thread ilə birlikdə işini bitirəcək.

namespace ForeGround
{
    class Program
    {
        static void Procedure()
        {
            for (int i = 0; i < 1000; i++)
            {
                Thread.Sleep(10);
                Console.Write(".");
            }
            Console.WriteLine("\nİkinci thread işini bitirdi.");
        }

        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Thread thread = new Thread(Procedure);

            // IsBackground - thread-ı fonda işlədir. Cari vəziyyətdə thread-ın işini bitirməsini gözləmirik.
            // Default olaraq - thread.IsBackground = false; 

            //thread.IsBackground = true; // Şərhə salmaq.
            thread.Start();

            Thread.Sleep(500);

            Console.WriteLine("\nƏsas thread işini bitirdi.");
        }
    }
}
