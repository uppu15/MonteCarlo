using System;

namespace MonteCarlo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            try
            {
                Pi(getSize());
            }
            catch (OutOfMemoryException)
            {
                Console.WriteLine("\nLet's try with smaller number.");
                Pi(getSize());
            }
            catch (FormatException)
            {
                Console.WriteLine("\nPlease check your input.");
                Pi(getSize());
            }
        }

        static double getSize()
        {
            Console.Write("How many elements in an array?: ");

            double size = int.Parse(Console.ReadLine());

            return size;
        }

        static double Pi(double size)
        {
            coordinate[] point = new coordinate[(int)size];
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
            double myPi = ((double)count / point.Length) * 4.0;

            Console.WriteLine($"The average of my pi is {myPi}");
            Console.WriteLine($"precision of this exercise is {diffPi(myPi)}");

            return myPi;
        }

        static double diffPi(double myPi)
        {
            return Math.Abs(Math.PI - myPi);
        }

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


