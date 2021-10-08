namespace DoubleDispatch.Shapes.LowCoupling
{
    using System.Collections.Generic;

    class Polygon : IShape
    {
        public IList<LineSegment> GetLineSegments()
        {
            var segments = new List<LineSegment>();
            segments.Add(new LineSegment(new Point(0, 0), new Point(0, 9)));
            segments.Add(new LineSegment(new Point(0, 9), new Point(3, 6)));
            segments.Add(new LineSegment(new Point(3, 6), new Point(6, 9)));
            segments.Add(new LineSegment(new Point(6, 0), new Point(6, 9)));
            segments.Add(new LineSegment(new Point(6, 0), new Point(3, 3)));
            segments.Add(new LineSegment(new Point(3, 3), new Point(0, 0)));

            return segments;
        }
    }
}
