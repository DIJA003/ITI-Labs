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
        public MyStack(int capacity) 
        {
            items = new T[capacity];
            top = -1;
        }
        public bool isEmpty() { return top == -1; }
        public bool isFull() { return top == items.Length - 1; }
        public void Push(T item)
        {
            if (isFull()) throw new InvalidOperationException("Stack is full");
            items[++top] = item;
        }
        public T Pop()
        {
            if (isEmpty()) throw new InvalidOperationException("Stack is empty");
            return items[top--];
        }
        public T Peek()
        {
            if (isEmpty()) throw new InvalidOperationException("Stack is empty");
            return items[top];
        }


    }
}
