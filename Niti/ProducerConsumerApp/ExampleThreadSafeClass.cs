using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProducerConsumerApp
{
    public class ExampleThreadSafeClass
    {
        private readonly List<int> numbers; //thread safe list
        private readonly object lockObject = new object();
        private readonly int capacity; 

        public ExampleThreadSafeClass(int boundedCapacity) 
        {
            numbers = new List<int>();
            capacity = boundedCapacity;
        }

        //Umesto da nit neprestano proverava stanje u petlji, ona se uspava dok ne dobije obaveštenje o promeni stanja
        public void put(int number)
        {
            lock(lockObject)
            {
                while (numbers.Count >= capacity) // Ako je lista puna, čekaj
                {
                    Monitor.Wait(lockObject); // Oslobađa lock, nit prelazi u stanje ceka i čeka signal da moze da nastavi, dobija signal od Monit.Pulse
                }
                numbers.Add(number);
                Console.WriteLine($"Dodao broj {number} u listu");
                Monitor.Pulse(lockObject); // Obaveštava čekajuće niti da je dodat broj
            }
            
        }

        public int get()
        { 
            lock(lockObject)
            {
                while (numbers.Count == 0) // Ako je lista prazna, čekaj
                {
                    Monitor.Wait(lockObject); // Oslobađa lock i čeka signal
                }
                Console.WriteLine($"Uzeo iz liste {numbers[numbers.Count - 1]} broj");

                int indexOfLastNumber =  numbers.Count - 1;
                int lastNumber = numbers[indexOfLastNumber];
                numbers.RemoveAt(indexOfLastNumber);
                Monitor.Pulse(lockObject); // Obaveštava čekajuće niti da je uklonjen broj
                return lastNumber; //uzmi poslednji dodat u listi
            }
        }
    }
}
