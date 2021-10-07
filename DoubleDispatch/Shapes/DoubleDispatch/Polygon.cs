namespace DoubleDispatch.Shapes.DoubleDispatch
{
    using System;

    public class Polygon : Shape
    {
        public override void Draw(Surface surface)
        {
            Console.WriteLine("A polygon is drawn on the surface with ink.");
        }

        public override void Draw(EtchASketch etchASketch)
        {
            Console.WriteLine("The knobs are moved in attempt to draw a polygon.");
        }
    }
}
