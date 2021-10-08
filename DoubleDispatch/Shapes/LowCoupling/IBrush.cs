namespace DoubleDispatch.Shapes.LowCoupling
{
    using System.Collections.Generic;

    interface IBrush
    {
        void Draw(ISurface surface, IList<LineSegment> segments);
    }
}
