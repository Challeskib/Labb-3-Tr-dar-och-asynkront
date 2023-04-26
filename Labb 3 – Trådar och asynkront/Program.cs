using System.Diagnostics;

namespace Labb_3___Trådar_och_asynkront
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Car car1 = new Car("Car 1", 100, 0);
            Car car2 = new Car("Car 2", 100, 0);

            Thread thread1 = new Thread(new ThreadStart(car1.StartRace));
            Thread thread2 = new Thread(new ThreadStart(car2.StartRace));

            thread1.Start();
            thread2.Start();
        }

    }
}