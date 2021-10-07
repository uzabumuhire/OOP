namespace DoubleDispatch.Shapes.PolymorphicStaticBinding
{
    using System;

    public class Shape
    {
        public void Draw(Surface surface)
        {
            Console.WriteLine("A shape is drawn on the surface with ink.");
        }

        public void Draw(EtchASketch etchASketch)
        {
            Console.WriteLine("The knobs are moved in attempt to draw a shape.");
        }
    }
}
