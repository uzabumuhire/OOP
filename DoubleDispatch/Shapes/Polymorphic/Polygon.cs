namespace DoubleDispatch.Shapes.Polymorphic
{
    using System;

    public class Polygon : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("A polygon is drawn.");
        }
    }
}
