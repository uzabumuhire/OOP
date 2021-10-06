namespace DoubleDispatch.Shapes.Polymorphic
{
    using System;

    public class Rectangle : Parallelogram
    {
        public override void Draw()
        {
            Console.WriteLine("A rectangle is drawn.");
        }
    }
}
