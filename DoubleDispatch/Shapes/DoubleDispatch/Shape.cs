namespace DoubleDispatch.Shapes.DoubleDispatch
{
    using System;

    public class Shape
    {
        public virtual void Draw(Surface surface)
        {
            Console.WriteLine("A shape is drawn on the surface with ink.");
        }

        public virtual void Draw(EtchASketch etchASketch)
        {
            Console.WriteLine("The knobs are moved in attempt to draw a shape.");
        }
    }
}
