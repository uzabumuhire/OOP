namespace DoubleDispatch.Ships
{
    using System;

    public class ImperialShip
    {
        public virtual void FireUpon(ImperialShip enemy)
        {
            Console.WriteLine("Do not know the specifics our vessel, nor the enemy");
        }

        public virtual void FireUpon(DauntlessCruiser enemy)
        {
            Console.WriteLine("Do not know the specifics our vessel but knows the enemy");
        }
    }
}
