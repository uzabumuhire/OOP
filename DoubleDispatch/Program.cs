namespace DoubleDispatch
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

            unscannedShip.FireUpon(enemyUnscannedShip);

            // The whole business of dynamic was added to C# in order to support dynamically
            // languages. One aspect of some of those languages is the ability to dynamically
            // dispatch, i.e., to make call decisions at runtime as opposed to compile-time.

            // By casting a variable to dynamic, we defer dispatch decisions until runtime. 
            // Thus, we get the correct calls happening.

            // Support of double dispatch by using the dynamic keyword.
            unscannedShip.FireUpon((dynamic)enemyScannedShip); 

            unscannedShip.FireUpon(enemyShipInVisualRange);
            scannedShip.FireUpon(enemyUnscannedShip);

            // Support of double dispatch by using the dynamic keyword
            scannedShip.FireUpon((dynamic)enemyScannedShip);

            scannedShip.FireUpon(enemyShipInVisualRange);
        }

        static void PrintInfo(string info)
        {
            Console.WriteLine($"\n{info}\n");
        }
    }
}
