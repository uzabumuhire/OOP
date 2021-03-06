namespace DoubleDispatch.Ships
{
    using System;

    public class ImperialShip : IShip
    {
        public virtual void FiredUponBy(IShip enemy)
        {
            // Switches around the enemy parameter with the object that was called.
            // This is single dispatch twice
            enemy.FireUpon(this);
        }

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
