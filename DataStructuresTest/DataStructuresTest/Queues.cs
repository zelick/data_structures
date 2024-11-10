using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresTest
{
    public class Queues
    {
        //Queue - FIFO, first in first out  (front, rear/back)
        //add item - enqueue - on the end 
        //remove item - dequeue - on the start

        Queue<string> newQueue = new Queue<string>();

        public void EnqueueElement(string element) // add the lement to the end of the queue
        {
            if(!newQueue.Contains(element))
            {
                newQueue.Enqueue(element);
            }
        }

        public void DequeueElement() //oldest elemnt from the start of queue
        {
            if(newQueue.Count > 0)
            {
                string dequeuedElement = newQueue.Dequeue();
                Console.WriteLine($"Dequeued item: {dequeuedElement}");
            }
           
        }

        public void Peek()
        {
            if(newQueue.Count > 0 )
            {
                Console.WriteLine("Peeked element:"+ newQueue.Peek());
            }
        }
    }
}
