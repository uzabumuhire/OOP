﻿namespace DoubleDispatch
{
    using System;

    using Ships;

    class Program
    {
        static void Main(string[] args)
        {
            PrintInfo("SHIPS");
            RunShips();
        }

        static void RunShips()
        {
            ImperialShip unscannedShip = new ImperialShip();
            ImperialShip enemyUnscannedShip = new ImperialShip();

            ImperialShip scannedShip = new DauntlessCruiser();
            ImperialShip enemyScannedShip = new DauntlessCruiser();

            DauntlessCruiser enemyShipInVisualRange = new DauntlessCruiser();

            // 'Dispatch' is a problem of figuring out which methods to call –
            // specifically, how many pieces of information are required in order to
            // make the call.

            // Polymorphically: there is a way we can coerce the system to invoke the
            // correct overload without any runtime checks. A polymorphic call can be
            // dispatched right to the necessary component. Which in turn can call the
            // necessary overload. This is called 'double dispatch' because:
            // 1. First you do a polymorphic call on the actual object
            // 2. Inside the polymorphic call, you call the overload. Since, inside
            //    the object, 'this' has a precise type, the right overload is triggered.
            //    The polymorphic call must be inside each distinct implementation so 
            //    'this' pointer is suitably typed.

            // Double dispatch is when methods are dispatched based on the run time (or
            // dynamic) type of two things; the object being called and its parameters.

            // Single disaptch only pays attention to the type of one thing, the object
            // that the method was called upon. For the arguments, it just uses the 
            // compile time types. 

            enemyUnscannedShip.FiredUponBy(unscannedShip);
            enemyScannedShip.FiredUponBy(unscannedShip);
            enemyShipInVisualRange.FiredUponBy(unscannedShip);
            enemyUnscannedShip.FiredUponBy(scannedShip);
            enemyScannedShip.FiredUponBy(scannedShip);
            enemyShipInVisualRange.FiredUponBy(scannedShip);
        }

        static void PrintInfo(string info)
        {
            Console.WriteLine($"\n{info}\n");
        }
    }
}
