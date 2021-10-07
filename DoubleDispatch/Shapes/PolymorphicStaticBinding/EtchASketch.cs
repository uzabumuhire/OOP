namespace DoubleDispatch.Shapes.PolymorphicStaticBinding
{
    public class EtchASketch : Surface
    {
        public override void Draw(Shape shape)
        {
            shape.Draw(this);
        }
    }
}
