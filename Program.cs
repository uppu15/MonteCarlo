using System;

namespace MonteCarlo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.Write("How many elements in an array?: ");

            int size = Console.Read();

            Pi(size);
        }

        static double Pi(int size)
        {
            coordinate[] point = new coordinate[size];
            int count = 0;

            for (int i = 0; i < point.Length; i++)
            {
                Random r = new Random();
                point[i] = new coordinate(r);

                if (point[i].Hypotenuse() <= 1)
                {
                    count++;
                }
            }
            double myPi = ((double)count / point.Length) * 4;

            Console.WriteLine($"The average of my pi is {myPi}");
            Console.WriteLine($"precision of this exercise is {diffPi(size)}");

            return myPi;
        }

        static double diffPi(int size) => Math.Abs(Math.PI - Pi(size));

        struct coordinate
        {
            private double x;
            private double y;

            public coordinate(double x, double y)
            {
                this.x = x;
                this.y = y;
            }

            public coordinate(Random r)
            {
                this.x = r.NextDouble();
                this.y = r.NextDouble();
            }

            public double Hypotenuse()
            {
                return Math.Sqrt((Math.Pow(x, 2)) + (Math.Pow(y, 2)));
            }
        }
    }
}


