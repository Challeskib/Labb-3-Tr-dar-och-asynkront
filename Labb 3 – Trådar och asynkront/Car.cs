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

            int i;

            for (i = 0; i <= 300; i++) // 1i = seconds
            {
                Thread.Sleep(1000); //Every iteration is 1 second long

                DistanceInKm += (double)Speed / 3600; // //Divide by 3600 to get km/seconds

                Console.WriteLine($"{Name} distance in kilometers: {DistanceInKm}");

                if (DistanceInKm >= 1)
                {
                    break;
                }
            }

            
            Console.WriteLine($"{Name} has finished the race in {sw.Elapsed} milli seconds!");
            sw.Stop();
        }

    }

}
