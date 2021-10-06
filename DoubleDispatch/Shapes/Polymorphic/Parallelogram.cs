namespace DoubleDispatch.Shapes.Polymorphic
{
    using System;

    public class Parallelogram : Quadrilateral
    {
        public override void Draw()
        {
            Console.WriteLine("A parallelogram is drawn.");
        }
    }
}
