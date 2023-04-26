using System.Diagnostics;
using System.Xml.Linq;

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

            Thread thread3 = new Thread(new ThreadStart(() => PrintCarInfo(car1, car2)));

            Console.WriteLine("Press any key to view the the scores of the race");

            thread1.Start();
            thread2.Start();
            thread3.Start();

            

            thread1.Join();
            thread2.Join();

            Console.WriteLine("Scores: ");
            Console.WriteLine($"Car: {car1.Name} Time: {car1.RaceTime} ");
            Console.WriteLine($"Car: {car2.Name} Time: {car2.RaceTime} ");

        }

        public static void PrintCarInfo(Car car1, Car car2)
        {
            while (Car.Winner == null)
            {
                Console.ReadKey();
                Console.WriteLine($"{car1.Name} distance in kilometers: {car1.DistanceInKm} speed: {car1.Speed}");
                Console.WriteLine($"{car2.Name} distance in kilometers: {car2.DistanceInKm} speed: {car2.Speed}");
            }

        }

    }
}