using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace percolation_threshold
{
    class Program
    {
        //public int[,] array;
        //public int[] index;
        //public int[] amount;
        //public int size = 0;
        //public int time = 0;
        //public int x = 0;
        //public int y = 0;
        //public double tries = 0;
        //Random rnd1 = new Random();
        //Random rnd2 = new Random();
        //private Program program = new Program();
        static void Main(string[] args)
        {
            int size = new int();
            int time = new int();
            Methods methods = new Methods();
            double tries = new double();
            Console.WriteLine("enter array size");
            size = int.Parse(Console.ReadLine());
            methods.size = size;
            Console.WriteLine("enter simulation time");
            time = int.Parse(Console.ReadLine());
            methods.time = time;
            //ArrayBuilder();
            methods.ArrayBuilder();
            //Virtalpoint();
            methods.Virtalpoint();
            for(int i=0;i<time;i++)
            {
                while (methods.Connected(0, 0, 0, size - 1) == false)
                {
                    methods.RandomSelection();
                    //methods.Connector(methods.x, methods.y);
                    methods.Connector(Data.tempX, Data.tempY);
                    tries++;
                }
                Console.WriteLine(tries / Math.Pow(size, 2));
            }
        }

        /*
        public void ArrayBuilder()
        {
            int m = 0;
            array = new int[size - 1, size - 1];
            index = new int[size - 1 * size - 1];
            for (int x=0;x<=size-1; x++)
            {
                for (int y = 0; y <= size - 1; y++)
                {
                    array[x, y] = 1;
                    index[x * size + y] = m;
                    amount[x * size + y] = 1;
                    m++;
                }
            }
        }
        public void RandomSelection()
        {
            x = rnd1.Next(-1, size + 1);
            y = rnd2.Next(-1, size + 1);
            array[x, y] = 0;
        }
        public void Connector(int x, int y)
        {
            if (x - 1 >= 0)
            {
                if (array[x - 1, y] == 0)
                {
                    Union(x, y, x - 1, y);
                }
            }
            if (x + 1 <= size - 1)
            {
                if (array[x + 1, y] == 0)
                {
                    Union(x, y, x + 1, y);
                }
            }
            if (y - 1 >= 0)
            {
                if (array[x, y - 1] == 0)
                {
                    Union(x, y, x, y - 1);
                }
            }
            if (y + 1 <= size - 1)
            {
                if (array[x, y + 1] == 0) 
                {
                    Union(x, y, x, y + 1);
                }
            }
        }
        private int Root(int x, int y)
        {
            int i = x * size + y;
            while (index[i]!= i)
            {
                index[i] = index[index[i]];
                i = index[i];
            }
            return i;
        }
        public void Union(int x,int y,int a,int b)
        {
            int m = x * size + y;
            int n = a * size + b;
            int mroot = Root(x, y);
            int nroot = Root(a, b);
            if(amount[mroot]<amount[nroot])
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
        public void Virtalpoint()
        {
            for(int i=0;i<size;i++)
            {
                Union(i, 0, 0, 0);
                Union(i, size-1, 0, size - 1);
            }
        }
        */
    }

    class Data
    {
        public static int tempX { get; set; }
        public static int tempY { get; set; }
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
        private Program program = new Program();

        public void ArrayBuilder()
        {
            Console.WriteLine("size is: " + size);
            Console.ReadLine();
            int m = 0;

            array = new int[size - 1, size - 1];
            index = new int[size - 1 * size - 1];

            for (int x = 0; x <= size - 1; x++)
            {
                for (int y = 0; y <= size - 1; y++)
                {
                    array[x, y] = 1;
                    index[x * size + y] = m;
                    amount[x * size + y] = 1;
                    m++;
                }
            }
        }

        public void RandomSelection()
        {
            x = rnd1.Next(-1, size + 1);
            Data.tempX = x;
            y = rnd2.Next(-1, size + 1);
            Data.tempY = y;
            array[x, y] = 0;
        }

        public void Connector(int x, int y)
        {
            if (x - 1 >= 0)
            {
                if (array[x - 1, y] == 0)
                {
                    Union(x, y, x - 1, y);
                }
            }
            if (x + 1 <= size - 1)
            {
                if (array[x + 1, y] == 0)
                {
                    Union(x, y, x + 1, y);
                }
            }
            if (y - 1 >= 0)
            {
                if (array[x, y - 1] == 0)
                {
                    Union(x, y, x, y - 1);
                }
            }
            if (y + 1 <= size - 1)
            {
                if (array[x, y + 1] == 0)
                {
                    Union(x, y, x, y + 1);
                }
            }
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
        public void Virtalpoint()
        {
            for (int i = 0; i < size; i++)
            {
                Union(i, 0, 0, 0);
                Union(i, size - 1, 0, size - 1);
            }
        }
    }
}