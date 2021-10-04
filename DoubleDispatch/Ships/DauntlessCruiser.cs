namespace DoubleDispatch.Ships
{
    using System;

    public class DauntlessCruiser : ImperialShip
    {
        public override void FireUpon(ImperialShip enemy)
        {
            Console.WriteLine("Know the specifics of our vessel but not the enemy");
        }

        public override void FireUpon(DauntlessCruiser enemy)
        {
            Console.WriteLine("Know the specifics of our vessel and the enemy");
        }
    }
}
