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
            Car car3 = new Car("Car 3", 100, 0);


            Thread thread1 = new Thread(new ThreadStart(car1.StartRace));
            Thread thread2 = new Thread(new ThreadStart(car2.StartRace));
            Thread thread3 = new Thread(new ThreadStart(car3.StartRace));


            Thread thread4 = new Thread(new ThreadStart(() => PrintCarInfo(car1, car2, car3)));

            Console.WriteLine("Press any key to view the the scores of the race");

            thread1.Start();
            thread2.Start();
            thread3.Start();

            thread4.Start();

            thread1.Join();
            thread2.Join();
            thread3.Join();


            Console.WriteLine("Scores: ");
            Console.WriteLine($"Car: {car1.Name} Time: {car1.RaceTime} ");
            Console.WriteLine($"Car: {car2.Name} Time: {car2.RaceTime} ");
            Console.WriteLine($"Car: {car3.Name} Time: {car3.RaceTime} ");


        }

        public static void PrintCarInfo(Car car1, Car car2, Car car3)
        {
            while (Car.Winner == null)
            {
                Console.ReadKey();
                Console.WriteLine($"{car1.Name} distance in kilometers: {car1.DistanceInKm} speed: {car1.Speed} time elapsed: {car1.RaceTime.Seconds}");
                Console.WriteLine($"{car2.Name} distance in kilometers: {car2.DistanceInKm} speed: {car2.Speed} time elapsed: {car2.RaceTime.Seconds}");
                Console.WriteLine($"{car3.Name} distance in kilometers: {car3.DistanceInKm} speed: {car3.Speed} time elapsed: {car3.RaceTime.Seconds}");

            }

        }

    }
}