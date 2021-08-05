using System;

namespace DoublyLinkedList
{
    public class Node
    {
        public int data;
        public Node previous;
        public Node next;
        public Node(int value)
        {
            data = value;
            previous = null;
            next = null;
        }
    }
    public class LinkedList
    {
        public Node Start { private set; get; }
        public Node End { private set; get; }
        public int Count { private set; get; }
        public LinkedList()
        {
            Start = null;
            End = null;
            Count = 0;
        }

        public void InsertFirst(int value)
        {
            Node newNode = new Node(value);
            if(Start == null)
            {
                Start = newNode;
                End = newNode;
            }
            else
            {
                Start.previous = newNode;
                newNode.next = Start;
                Start = newNode;
            }
            Count++;
        }
        private Node GetNodeAddressByValue(int value)
        {
            Node temp = Start;
            while(temp != null)
            {
                if(temp.data == value)
                {
                    return temp;
                }
                temp = temp.next;
            }
            return null;
        }

        public void InsertLast(int value)
        {
            Node newNode = new Node(value);
            if (Start == null)
            {
                Start = newNode;
                End = newNode;
            }
            else
            {
                End.next = newNode;
                newNode.previous = End;
                End = newNode;
            }
            Count++;
        }
        private Node GetNodeAddressByIndex(int index)
        {
            int ind = 0;
            Node temp = Start;
            while (temp != null)
            {
                if (ind == index)
                {
                    return temp;
                }
                ind++;
                temp = temp.next;
            }
            return null;
        }
        public void InsertAtIndex(int index,int value)
        {
            if(index == 0)
            {
                InsertFirst(value);
            }
            else if(index == Count-1)
            {
                InsertLast(value);
            }
            else
            {
                Node previousNode = GetNodeAddressByIndex(index - 1);
                if(previousNode != null)
                {
                    Node newNode = new Node(value);
                    Node tempNode = previousNode.next;
                    previousNode.next = newNode;
                    newNode.previous = previousNode;
                    newNode.next = tempNode;
                    Count++;
                }
            }

        }
        public bool IsEmpty()
        {
            if(Start == null)
            {
                return true;
            }

            return false;
        }
        public bool Contains(int searchValue)
        {
            Node temp = Start;
            while (temp != null)
            {
                if(temp.data == searchValue)
                {
                    return true;
                }
                temp = temp.next;
            }
            return false;
        }
       
        public void Reverse()
        {
            if(Start == null)
            {
                return;
            }
            else
            {
               Node currentNode = End; 

               while(currentNode != null)
                {
                    Node temp = currentNode.next;
                    currentNode.next = currentNode.previous;
                    currentNode.previous = temp;
                    currentNode = currentNode.next;
                }

                Node newEnd = Start;
                Start = End;
                End = newEnd;
            
            }

        }
        public void DeleteFirst()
        {
            if(Start == null)
            {
                return;
            }
            else if(Start == End)
            {
                Start = null;
                End = null;
                Count = 0;
            }
            else
            {
                Start = Start.next;
                Start.previous = null;
                Count--;
            }
        }

        public void DeleteLast()
        {
            if (Start == null)
            {
                return;
            }
            else if (Start == End)
            {
                Start = null;
                End = null;
                Count = 0;
            }
            else
            {
                End = End.previous;
                End.next = null;
                Count--;
            }
        }

        public void DeleteIndex(int index)
        {
            if (Start == null)
            {
                return;
            }
            else
            {
                if(index >= 0 && index < Count)
                {
                    if((index == 0 || index == Count - 1 ) && Start == End)
                    {
                        Start = null;
                        End = null;
                        Count = 0;
                    }
                    else if(index == 0 && Start != End)
                    {
                        DeleteFirst();
                    }
                    else if(index == Count-1 && Start != End)
                    {
                        DeleteLast();
                    }
                    else
                    {
                        Node nodeAddress = GetNodeAddressByIndex(index);
                        Node previousNode = nodeAddress.previous;
                        Node nextNode = nodeAddress.next;
                        previousNode.next = nextNode;
                        nextNode.previous = previousNode;
                        Count--;
                    }

                }
            }
        }
        public void Delete(int value)
        {

        }
        public void Print()
        {
            if(Start == null)
            {
                return ;
            }
           else 
            {
                Node temp = Start;
                while (temp != null)
                {
                    Console.WriteLine(temp.data);
                    temp = temp.next;
                }
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList list = new LinkedList();
            list.InsertLast(10);
            list.InsertFirst(20);
            list.InsertFirst(30);
            list.InsertAtIndex(2, 35);
            list.DeleteIndex(2);
            list.Print();
            Console.WriteLine(list.Contains(25));
            list.Reverse();
            list.InsertFirst(100);
            list.InsertLast(330);
            list.Print();
            Console.ReadKey();
        }
    }
}
