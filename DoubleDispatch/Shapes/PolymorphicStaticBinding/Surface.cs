namespace DoubleDispatch.Shapes.PolymorphicStaticBinding
{
    public class Surface
    {
        public virtual void Draw(Shape shape)
        {
            shape.Draw(this);
        }
    }
}
