using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace percolation_threshold
{
    class Program
    {
        static void Main(string[] args)
        {
            Methods methods = new Methods();
            Console.WriteLine("enter array size");
            methods.size = int.Parse(Console.ReadLine());
            methods.ArrayBuilder();
            string temp = "";
            for (int y = 0; y <= methods.size-1; y++)
            {
                for (int x = 0; x <= methods.size - 1; x++)
                {
                    temp = temp + methods.array[x, y].ToString();
                }
                Console.WriteLine(temp);
                temp = "";
            }
            methods.Union(2, 1, 3, 1);//change these numbers to check union,root,connected
            methods.Union(2, 2, 3, 1);
            methods.Union(0, 0, 2, 2);
            if(methods.Connected(2, 1, 0, 0))//change these numbers to check union,root,connected
            {
                Console.WriteLine("ok");
            }
            Console.ReadLine();
        }
    }
    class Methods
    {
        public int[,] array;
        public int[] index;
        public int[] amount;
        public int size = 0;
        public int time = 0;
        public int x = 0;
        public int y = 0;
        public double tries = 0;
        Random rnd1 = new Random();
        Random rnd2 = new Random();
        public void ArrayBuilder()
        {
            int m = 0;
            array = new int[size, size];
            index = new int[size * size];
            amount = new int[size * size];
            for (int x = 0; x <= size - 1; x++)
            {
                for (int y = 0; y <= size - 1; y++)
                {
                    array[x, y] = 1;
                    index[(x * size) + y] = m;
                    amount[x * size + y] = 1;
                    m++;
                }
            }
            array[0, 1] = 0;
            array[0, 2] = 0;
        }

        private int Root(int x, int y)
        {
            int i = x * size + y;
            while (index[i] != i)
            {
                index[i] = index[index[i]];
                i = index[i];
            }
            return i;
        }
        public void Union(int x, int y, int a, int b)
        {
            int m = x * size + y;
            int n = a * size + b;
            int mroot = Root(x, y);
            int nroot = Root(a, b);
            if (amount[mroot] < amount[nroot])
            {
                index[m] = n;
                amount[nroot] += amount[mroot];
            }
            else
            {
                index[n] = m;
                amount[mroot] += amount[nroot];
            }
        }
        public bool Connected(int x, int y, int a, int b)
        {
            return Root(x, y) == Root(a, b);
        }
    }
}