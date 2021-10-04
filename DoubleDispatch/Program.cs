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

            // Single Dispatch behaviour : calls the runtime object with the compile
            // time parameters. Compile time parameter do not match the runtime
            // parameter, that's why it's a bug.
            unscannedShip.FireUpon(enemyScannedShip); 

            unscannedShip.FireUpon(enemyShipInVisualRange);
            scannedShip.FireUpon(enemyUnscannedShip);

            // Single Dispatch behaviour : calls the runtime object with the compile
            // time parameters. Compile time parameter do not match the runtime
            // parameter, that's why it's a bug.
            scannedShip.FireUpon(enemyScannedShip);

            scannedShip.FireUpon(enemyShipInVisualRange);
        }

        static void PrintInfo(string info)
        {
            Console.WriteLine($"\n{info}\n");
        }
    }
}
