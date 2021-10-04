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
