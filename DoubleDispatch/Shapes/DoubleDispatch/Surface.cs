namespace DoubleDispatch.Shapes.DoubleDispatch
{
    public class Surface
    {
        public virtual void Draw(Shape shape)
        {
            shape.Draw(this);
        }
    }
}
