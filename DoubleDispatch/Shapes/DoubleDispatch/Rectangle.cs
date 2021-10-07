namespace DoubleDispatch.Shapes.DoubleDispatch
{
    using System;

    public class Rectangle : Parallelogram
    {
        public override void Draw(Surface surface)
        {
            Console.WriteLine("A rectangle is drawn on the surface with ink.");
        }

        public override void Draw(EtchASketch etchASketch)
        {
            Console.WriteLine("The knobs are moved in attempt to draw a rectangle.");
        }
    }
}
