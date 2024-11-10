using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresTest
{
    public class Stacks
    {
        //stack - LIFO, Last in first out (top, bottom)
        //add item - push
        //remove item - pop
        Stack newStack = new Stack(); //Stack od Objects
        Stack<int> newIntStack = new Stack<int>(); //constructor

        public void PushElement(string newElement)
        {
            newStack.Push(newElement); //O(1)
            //total numer of elements 
            if(newStack.Count > 0) //If stack is not empty
            {
                Console.WriteLine("Total number of elemetns int stack:", newStack.Count);
            }
        }

        public void PopElement()
        {
            var removedElement = newStack.Pop();
            Console.WriteLine("Popped element from stack: " + removedElement);
        }

        public void PeekElement()
        {
            Console.WriteLine("Display top element of stack:", newStack.Peek());
        }

        // A
        // B
        // C
        //Display: C, B, A - from top, last element that is pushed 
        public void DisplayElements()
        {
            foreach (var element in newStack)
            {
                Console.WriteLine(element);
            }

            //stack to array 
            int[] newArray = newIntStack.ToArray();
            //check if contains number
            bool contains = newIntStack.Contains(6);
        }

    }
}
