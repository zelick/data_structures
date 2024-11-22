using System;
using System.Collections.Concurrent;
using System.Threading;

using System.Threading.Tasks;

class Program
{
    static Queue<int> queue = new Queue<int>(); // Deljeni resurs
    static readonly object lockObject = new object(); // Lock objekat za sinhronizaciju niti

    static void Main(string[] args)
    {
        // Kreiramo konkurentni red (BlockingCollection) , buffer
        BlockingCollection<int> red = new BlockingCollection<int>(boundedCapacity: 10);  //thread-safe, samo jedna nit moze da pristupi

        // Pokrećemo proizvođača i potrošača kao različite niti
        Task producerTask = Task.Run(() => Proizvodjac(red));
        Task consumerTask = Task.Run(() => Potrosac(red));

        // Sačekaj obe niti da završe rad
        Task.WaitAll(producerTask, consumerTask);

        //zamena za Task
        //Thread producerThread = new Thread(() => Proizvodjac(red)); - posebno se pokrecu niti 
        //Thread consumerThread = new Thread(() => Potrosac(red));

        // Startujemo niti
       // producerThread.Start();
       // consumerThread.Start();

        // Čekamo da se niti završe
       // producerThread.Join();
       // consumerThread.Join();
    }

    static void Proizvodjac(BlockingCollection<int> red)
    {
        Random random = new Random();

        for (int i = 0; i < 20; i++)
        {
            int broj = random.Next(1, 100); // Generiši nasumičan broj

            Console.WriteLine($"Proizvođač: Dodajem broj {broj} u red.");

            red.Add(broj); // Dodaj broj u red

          /*  lock (lockObject)
            {
                Console.WriteLine($"Proizvođač: Dodajem broj {broj} u red.");
                queue.Enqueue(broj); // Dodaj broj u red
            }*/

            Thread.Sleep(100); // Simuliraj kašnjenje proizvođača
        }

        red.CompleteAdding(); // Obeleži da je dodavanje završeno
    }

    static void Potrosac(BlockingCollection<int> red)
    {
        while (!red.IsCompleted) // Proveri da li je red zatvoren za dodavanje
        {
            try
            {
                int broj = red.Take(); // Uzimaj broj iz reda
                Console.WriteLine($"Potrošač: Obradio broj {broj}");

                // Lockujemo red da bismo sigurno uzeli broj
               /* lock (lockObject)
                {
                    if (red.Count == 0) break; // Prestanite kad je red prazan
                    broj = queue.Dequeue(); // Uzmi broj iz reda
                }*/

                Thread.Sleep(150); // Simuliraj obradu
            }
            catch (InvalidOperationException)
            {
                // Ignoriši grešku ako je red prazan i zatvoren
                break;
            }
        }
    }
}
