namespace DoubleDispatch.Shapes.Polymorphic
{
    using System;

    public class Quadrilateral : Polygon
    {
        public override void Draw()
        {
            Console.WriteLine("A quadrilateral is drawn.");
        }
    }
}
