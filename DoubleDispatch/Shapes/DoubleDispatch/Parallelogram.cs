namespace DoubleDispatch.Shapes.DoubleDispatch
{
    using System;

    public class Parallelogram : Quadrilateral
    {
        public override void Draw(Surface surface)
        {
            Console.WriteLine("A parallelogram is drawn on the surface with ink.");
        }

        public override void Draw(EtchASketch etchASketch)
        {
            Console.WriteLine("The knobs are moved in attempt to draw a parallelogram.");
        }
    }
}
