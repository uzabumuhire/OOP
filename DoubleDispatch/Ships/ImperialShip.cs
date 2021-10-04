using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleDispatch.Ships
{
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
