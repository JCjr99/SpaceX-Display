using System;
using Oddity;

namespace SpaceX_Display
{
    
    class Program
    {
        static OddityCore oddity = new OddityCore();
        static Oddity.Models.Launches.LaunchInfo launch = oddity.LaunchesEndpoint.GetLatest().Execute();
        
        static void Main(string[] args)
        {
            Console.WriteLine("Information about the latest SpaceX launch\n");
            Console.WriteLine("Launch Name: " + launch.Name);
            Console.WriteLine("Launch Date: " + launch.DateLocal);
            Console.WriteLine("Launch Details:" + launch.Details +"\n");

            Console.WriteLine("Information about the ships involved in this launch\n");
            foreach (System.Lazy<Oddity.Models.Ships.ShipInfo> ship in launch.Ships)
            {
                Console.WriteLine("Ship Name:" + ship.Value.Name);
                Console.WriteLine("Ship Type: " + ship.Value.Type);
                Console.WriteLine( "Ship Home Port: " + ship.Value.HomePort + "\n");
            }

        }
    }
}
