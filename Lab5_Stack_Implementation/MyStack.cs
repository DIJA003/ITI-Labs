using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_Stack_Implementation
{
    public class MyStack <T>
    {
        private readonly T[] items;
        private int top;
        private const int capacity = 10;
        public MyStack() 
        {
            items = new T[capacity];
            top = -1;
        }
        public bool isEmpty()
        {
            return top == -1;
        }
        public bool isFull()
        {
            return top == items.Length-1;
        }
        public void Push(T item)
        {
            if (isFull())
            {
                Console.WriteLine("Stack is full");
                Console.ReadKey(true);
                return;
            }
            top++;
            items[top] = item;
        }
        public T Pop()
        {
            if (isEmpty())
            {
                Console.WriteLine("Stack is empty");
                return default(T)!;
            }   
            T item = items[top];
            top--;
            return item;
        }
        public T Peek()
        {
            if (isEmpty())
            {
                Console.WriteLine("Stack is empty");
                return default(T)!;
            }
            return items[top];
        }


    }
}
