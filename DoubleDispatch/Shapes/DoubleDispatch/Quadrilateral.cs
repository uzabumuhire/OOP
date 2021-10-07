namespace DoubleDispatch.Shapes.DoubleDispatch
{
    using System;

    public class Quadrilateral : Polygon
    {
        public override void Draw(Surface surface)
        {
            Console.WriteLine("A quadrilateral is drawn on the surface with ink.");
        }


        public override void Draw(EtchASketch etchASketch)
        {
            Console.WriteLine("The knobs are moved in attempt to draw a quadrilateral.");
        }
    }
}
