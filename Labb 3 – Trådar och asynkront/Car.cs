using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Labb_3___Trådar_och_asynkront
{
    internal class Car
    {
        public string Name { get; set; }
        public int Speed { get; set; }
        public double DistanceInKm { get; set; }
        public static string Winner;

        public TimeSpan RaceTime { get; set; }

        public Car(string name, int speed, int distanceInKm)
        {
            Name = name;
            Speed = speed;
            DistanceInKm = distanceInKm;


        }

        public void StartRace()
        {
            Stopwatch sw = Stopwatch.StartNew();
            sw.Start();

            Console.WriteLine($"{Name} started");

            for (int i = 0; i <= 300; i++) // 1i = seconds
            {
                Thread.Sleep(1000); //Every iteration is 1 second long

                DistanceInKm += (double)Speed / 3600; // //Divide by 3600 to get km/seconds

                if (DistanceInKm >= 1)
                {
                    break;
                }


                if (i == 5 || i == 10 || i == 15 || i == 20 || i == 25 || i == 30 || i == 35 || i == 40 || i == 45 || i == 50 || i == 55 || i == 60)
                {
                    CarProblem();
                }
            }
            Console.WriteLine($"{Name} has finished the race");

            if (Car.Winner == null)
            {
                Car.Winner = Name;
                Console.WriteLine($"Car:{Name} is declared the Winner. Congratz!!!");
            }
            RaceTime = sw.Elapsed;
            sw.Stop();

            
        }

        

        public void CarProblem()
        {

            Random random = new Random();

            int randomIncident = random.Next(1, 101);


            ///ODDSEN ÄR FEL, FIXA SEN
            if (randomIncident > 0 && randomIncident <= 2)
            {
                IsOutOfGas();
            }
            else if (randomIncident > 2 && randomIncident <= 6)
            {
                HasFlatTire();
            }
            else if (randomIncident > 6 && randomIncident <= 16)
            {
                HasBirdOnWindShield();
            }
            else if(randomIncident > 16 && randomIncident <= 36)
            {
                HasEngineFailure();
            }

        }

        public void IsOutOfGas()
        {
            Console.WriteLine($"{Name} is out of gas, need 3 seconds to fill the gastank.");
            Thread.Sleep(3000);
        }

        public void HasFlatTire()
        {
            Console.WriteLine($"{Name} has a flat tire, it takes 2 seconds to fix it.");
            Thread.Sleep(2000);
        }

        public void HasBirdOnWindShield()
        {
            Console.WriteLine($"{Name} has a bird on the windshield, it takes 1 seconds to fix it.");
            Thread.Sleep(1000);
        }

        public void HasEngineFailure()
        {
            Speed = Speed - 1;
            Console.WriteLine($"{Name} has engine failure, the speed is reduced by 1km/h, new {Speed} km/h");
        }

    }

}
