using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class Node
    {
        public int data;
        public Node next;
        // Constructor
        public Node(int data)
        {
            this.data = data;
            this.next = null;
        }
    }
    class LinkedList
    {
        int length;
        Node head;
        Node tail;
        LinkedList()
        {
            this.head = null;
            this.tail = null;
            this.length = 0;
        }
        void Traverse()
        {
            Node currentNode = this.head;
            int currentInt = 1;
            while (currentNode != null)
            {
                if (currentNode == this.head)
                {
                    Console.WriteLine("| Head (node " + currentInt + ") : " + currentNode.data);
                }
                if (currentNode == this.tail)
                {
                    Console.WriteLine("| Tail (node " + currentInt + ") : " + currentNode.data);
                }
                else if (currentNode != this.head && currentNode != this.tail)
                {
                    Console.WriteLine("| Node " + currentInt + ": " + currentNode.data);
                }
                currentInt++;
                if (currentNode.next == null)
                {
                    break;
                }
                currentNode = currentNode.next;
            }
        }
        void Push(int data) // Push new node to end of list
        {
            Node newNode = new Node(data);
            if (this.head == null)
            {
                this.head = newNode;
                this.tail = newNode;
            }
            else
            {
                this.tail.next = newNode;
                this.tail = newNode;
            }
            this.length++;
        }
        object Pop() // Remove last Node from list and return it
        {
            if (this.head == null)
            {
                return "This list is empty";
            }
            else
            {
                Node currentNode = this.head;
                if (this.head == this.tail)
                {
                    this.head = null;
                    this.tail = null;
                    this.length--;
                    return currentNode;
                }
                Node returnNode = currentNode.next;
                while (returnNode != this.tail)
                {
                    currentNode = returnNode;
                    returnNode = returnNode.next;
                }
                this.tail = currentNode;
                this.tail.next = null;
                this.length--;
                return returnNode;
            }
        }
        object Shift() // Remove node from beginning of list and return it
        {
            if (this.head == null)
            {
                this.tail = null;
                return "This list is empty";
            }
            else
            {
                Node result = this.head;
                this.head = this.head.next;
                this.length--;
                if (this.length == 0)
                {
                    this.tail = null;
                    this.head = null;
                }
                return result;
            }
        }
        void Unshift(int val) // Add to the beginning of list
        {
            Node newNode = new Node(val);
            if (this.head == null)
            {
                this.head = newNode;
                this.tail = newNode;
            }
            else
            {
                newNode.next = this.head;
                this.head = newNode;
            }
            this.length++;
        }

        object Get(int index) // returns item in the inputted position
        {
            if (index < 0 || index >= this.length)
            {
                return null;
            }
            else
            {
                int currentPos = 0;
                Node currentNode = this.head;
                while (currentPos != index)
                {
                    currentPos++;
                    currentNode = currentNode.next;
                }
                return currentNode;
            }
        }
        void Set(int index, int val) // change existing Node to a new value
        {
            Node selectedNode = this.Get(index) as Node;
            if (selectedNode == null)
            {
                Console.WriteLine("This index is out of range");
            }
            else
            {
                selectedNode.data = val;

            }
        }

        object Insert(int index, int val) // Insert item at specified index
        {
            if (index > this.length || index < 0) return false;
            else if (index == 0)
            {
                this.Unshift(val);
                return true;
            }
            else if (index == this.length)
            {
                this.Push(val);
                return true;
            }
            else
            {
                Node newNode = new Node(val);
                Node prevNode = (Node)(this.Get(index - 1));
                newNode.next = prevNode.next;
                prevNode.next = newNode;
                this.length++;
                return true;
            }
        }

        object Remove(int index) // Remove from specified index and return 
        {
            if (index == this.length - 1) return this.Pop();
            if (index == 0) return this.Shift();
            if (index < 0 || index >= this.length) return false;
            else
            {
                Node prevNode = (Node)(this.Get(index - 1));
                Node nodeToRemove = prevNode.next;
                prevNode.next = nodeToRemove.next;
                return prevNode;
            }
        }

        void Reverse() // Reverse the order of a Linked List 
        {
            Node prevNode = null;
            Node currentNode = this.head;
            this.head = this.tail;
            this.tail = currentNode;
            while (currentNode != null)
            {
                if (currentNode == this.head)
                {
                    currentNode.next = prevNode;
                    this.head = currentNode;
                    break;
                }
                Node nextNode = currentNode.next;
                currentNode.next = prevNode;
                prevNode = currentNode;
                currentNode = nextNode;
            }
        }
        public static void Main()
        {
            LinkedList list = new LinkedList();
            list.Push(10); list.Push(20); list.Push(30);
            list.Traverse();
            //Console.WriteLine("Push 10, 20, 30 to new linked list.");
            //list.Traverse();
            //Node newNode = list.Pop() as Node;
            //Console.WriteLine("Pop " + newNode.data); list.Traverse();
            //newNode = list.Shift() as Node;
            //Console.WriteLine("Shift " + newNode.data); list.Traverse();
            //Console.WriteLine("Unshift 30 and 40"); list.Unshift(30); list.Unshift(40); list.Traverse();
            //Console.WriteLine("Set index 0 to -40"); list.Set(0, -40); list.Traverse();
            //Console.WriteLine("Insert 35 at index 1"); list.Insert(1, 35); list.Traverse();
            //Console.WriteLine("Reverse List"); list.Reverse(); list.Traverse();
        }
    }
}
