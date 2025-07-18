using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_Dynamic_Array
{
    public class DynamicArray
    {
        private int [] arr;
        private int size;
        private const int firstSize = 10;
        

        public DynamicArray()
        {
            arr = new int[firstSize];
            size = 0;
        }
        public int Size()
        {
            return size;
        }
        public void Add(int value)
        {
            if (size == arr.Length) ReSize();
            arr[size] = value;
            size++;
            
        }
        public void ReSize()
        {
            int[] arr2 = new int[size + 1];
            for (int i = 0; i < size; i++)
            {
                arr2[i] = arr[i];
            }
            arr = arr2;
        }
        public double GetAverage() 
        {
            if (size == 0) return 0;
            int sum = 0;
            for(int i = 0; i < size; i++) sum+= arr[i];
            return Convert.ToDouble(sum) / size;
        
        }

    }
}
