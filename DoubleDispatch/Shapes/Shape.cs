namespace DoubleDispatch.Shapes
{
    using System;

    public class Shape
    {
        public virtual void Draw()
        {
            Console.WriteLine("A shape is drawn.");
        }
    }
}
