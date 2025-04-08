using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    internal class Program
    {
        class Node
        {
            public int data;
            public Node next;

            public Node(int x)
            {
                data = x;
                next = null;
            }

        }


        class Lista
        {
            private Node head;

            public void dodajNaKraj(int n)
            {
                Node novi = new Node(n);

                if(head == null)
                {
                    head = novi;
                    return;
                }

                Node current = head;
                while(current.next != null)
                {
                    current = current.next;
                }

                if (current.next != null)
                {
                    current.next = current.next.next;
                }

            }
            
        }


        static void Main(string[] args)
        {
           Lista lista = new Lista();
           

        }


    }
}
