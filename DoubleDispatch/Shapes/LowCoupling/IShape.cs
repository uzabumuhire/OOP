namespace DoubleDispatch.Shapes.LowCoupling
{
    using System.Collections.Generic;

    interface IShape
    {
        IList<LineSegment> GetLineSegments();
    }
}
