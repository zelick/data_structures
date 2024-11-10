using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataStructuresTest
{
    public class DoublyNode
    {
        public int Data { get; set; }
        public DoublyNode? Next { get; set; }
        public DoublyNode? Prev { get; set; }

        public DoublyNode(int data) 
        {
            this.Data = data;
            this.Next = null;
            this.Prev = null;
        }
    }
    public class DoublyLinkedList
    {
        public DoublyNode? Head { get; set; }
        //Da li treba da imam tail ???  (optimizovano?)
        public DoublyLinkedList()
        {
            this.Head = null;
        }

        //Insert at beginning  - O(1)
        public void InsertAtBeginning(int data)
        {
            DoublyNode newNode = new DoublyNode(data);
            if (this.Head != null)
            {
                newNode.Next = this.Head;
                this.Head.Prev = newNode;
            }
            this.Head = newNode;
            Console.WriteLine("Inserted at beginning doubly linked list");
        }

        //Insert at the end - O(n)
        public void InsertAtEnd(int data)
        {
            DoublyNode newNode = new DoublyNode(data);
            if(this.Head == null)
            {
                this.Head = newNode;
                Console.WriteLine("Inserted at the end for empty list");
                return;
            }

            DoublyNode? temp = this.Head; //find tail
            while(temp.Next != null)
            {
                temp = temp.Next;
            }

            temp.Next = newNode;
            newNode.Prev = temp;
            Console.WriteLine("Inserted at the end of doubly linked list");
        }

        //Insert After − Adds an element after an item of the list. - O(n)
        //optimizuj ovu metodu...
        //da li je dobro ?
        public void InsertAfter(int data, int insertData)
        {
            if(this.Head == null)
            {
                Console.WriteLine("List is empty.");
                return;
            }

            //find the node with data 
            DoublyNode? temp = this.Head;
            DoublyNode? foundNode = null;
            while(temp.Next != null) 
            {
                if(temp.Data == data)
                {
                    foundNode = temp;
                    break;
                }
                temp = temp.Next;   
            }

            if(foundNode == null)
            {
                Console.WriteLine("Node dont exist");
                return;
            }
            //insert new node after found node
            DoublyNode newNode = new DoublyNode(insertData);
            newNode.Next = foundNode.Next;
            foundNode.Next = newNode;
            newNode.Prev = foundNode;
            Console.WriteLine("Node is inserted after found node");
        } 

        //Traverse forward - from head to tail - O(n)
        public void TraverseForward()
        {
            if(this.Head == null)
            {
                Console.WriteLine("List is empty");
                return;
            }
            DoublyNode? temp = this.Head;
            int position = 0;
            while(temp != null) //da bi ispisao ako ima jedan element u listi
            {
                Console.WriteLine("Element: " + position + " data: " + temp.Data);
                temp = temp.Next;
            }
        }

        //Traverse backward from tail to head - O(n)
        public void TraverseBackward()
        {
            if(this.Head == null)
            {
                Console.WriteLine("List is empty");
                return;
            }

            DoublyNode? temp = this.Head;
            DoublyNode? tail = null;
            int position = 0;
            //find a tail
            while(temp.Next != null)
            {
                temp = temp.Next;
                position++;
            }
            tail = temp;
            //iterate from tail to back
            while(tail != null) //da bi ispisao prvi
            {
                Console.WriteLine("Element: " + position + " data:" + tail.Data);
                tail = tail.Prev;
                position--;
            }
        }

        //Deletion from beginning - O(1)
        public void DeleteFromBeginning()
        {
            if(this.Head == null)
            {
                Console.WriteLine("List is empty");
                return;
            }
            this.Head = this.Head.Next;
            if(this.Head != null) 
            {
                this.Head.Prev = null;
            }
            Console.WriteLine("Deleted node from beginning");
        }

        //Delete last node from end - O(n)
        public void DeleteFromEnd()
        {
            if (this.Head == null)
            {
                Console.WriteLine("List is empty");
                return;
            }
            DoublyNode? last = this.Head;
            while (last.Next != null)
            {
                last = last.Next;
            }
            //last node 
            //ne zaboravi uslove
            if (last.Prev != null)
            {
                last.Prev.Next = null;
            }
            else
            {
                //list only one node
                this.Head = null;
            }
            Console.WriteLine("Deleted node from end of list");
        }

        //Reverse 
        public void Reverse()
        {

        }
    }
}
