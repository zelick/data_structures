using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresTest
{
    public class Node
    {
        public int Data { get; set; } //diffrent types
        public Node? Next { get; set; }

        public Node(int data)
        {
            Data = data;
            Next = null;
        }
    }

    //Singly Linked List
    public class LinkedList
    {
        public Node? Start { get; set; }
        public LinkedList() 
        { 
            Start = null;
        }

        //Is linked list is empty - O(1)
        public bool IsEmpty()
        {
            return Start == null;
        }

        //Traversal - display all the nodes from linked list  - O(n)
        public void Traversal() 
        {
            if (IsEmpty())
            {
                Console.WriteLine("List is empty");
                return;
            }
            
            Node? temp = Start;
            int length = 0;
            while(temp != null)
            {
                Console.WriteLine("Node: " + length + " data: " + temp.Data);
                temp = temp.Next;
                length++;
            }
        }

        //Insertion at the beginning  - O(1)
        public void InsertAtBeginning(int data)
        {
            Node newNode = new Node(data);
            if(Start != null) 
            {
                newNode.Next = Start.Next;
                Start = newNode;
            }
        }

        //Insertion at the end - O(n)
        public void InsertAtEnd(int data)
        {
            Node node = new Node(data);
            Node? temp = Start;

            while(temp != null)
            {
                if(temp.Next == null)
                {
                    temp.Next = node;
                }
                temp = temp.Next;
            }
        }

        //Insertion at specific position - O(n)
        //da li mi ovo treba ?? 
        public void InsertAtPosition(int data, int position) //position beginnes at 1 
        {
            Node newNode = new Node(data);

            if (position == 1)
            {
                if (Start != null)
                {
                    newNode.Next = Start.Next;
                    Start = newNode;
                    Console.WriteLine("Node inserted at first postion");
                    return;
                }
            }

            Node temp = Start!;

            for (int i = 1; i < position - 1; i++) 
            {
               if(temp == null || temp.Next == null)
               {
                    Console.WriteLine("Positon not exist");
                    return;
               }
               temp = temp.Next;
            }

            newNode.Next = temp.Next;
            temp = newNode;
            Console.WriteLine("Node inserted at position: " + position);
        }

        //Delete from beginning - O(1)
        public void DeleteFromBeginning()
        {
            if(Start != null)
            {
                Start = Start.Next;
                Console.WriteLine("Node deleted at beginning");
            }
        }

        //Delete from end - O(n)
        //solution with previous, not good if list has one element!!! - NAPOMENA
        public void DeleteFromEnd()
        {
            if(Start == null)
            {
                Console.WriteLine("List is empty");
            }

            Node? temp = Start;
            while(temp!.Next!.Next != null)
            {
                temp = temp.Next;
            }

            temp.Next = null;
            Console.WriteLine("Node deleted at end");
        }

        //Delete from position - O(n)
        //!!
        public void DeleteAtPosition(int position)
        {
            if(Start == null)
            {
                Console.WriteLine("List is empty");
                return;
            }

            if(position == 1)
            {
                Start = null;
                Console.WriteLine("Deleted from first position");
                return;
            }

            Node? temp = Start;
            for(int i = 1; i < position - 1 && temp.Next != null; i++) //find the node before the one to delete
            {
                temp = temp.Next;
            }
            if (temp.Next == null)
            {
                Console.WriteLine("Position out of bounds");
                return;
            }
            temp = temp.Next.Next; //prevezi cvor
        }

       //Reverse - O(n)
       //!!
       public void Reverse()
       {
            if(Start == null)
            {
                Console.WriteLine("List is empty");
            }

            Node? previous = null;
            Node? current = Start;
            Node? next = null;

            while(current != null) 
            {
                next = current.Next; 
                current.Next = previous;
                previous = current;
                current = next;
            }

            Start = previous; 
       }
    }


}
