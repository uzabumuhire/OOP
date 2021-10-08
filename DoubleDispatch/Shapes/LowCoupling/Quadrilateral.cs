namespace DoubleDispatch.Shapes.LowCoupling
{
    using System.Collections.Generic;

    class Quadrilateral : IShape
    {
        public IList<LineSegment> GetLineSegments()
        {
            var segments = new List<LineSegment>();
            segments.Add(new LineSegment(new Point(0, 0), new Point(0, 9)));
            segments.Add(new LineSegment(new Point(0, 9), new Point(4, 5)));
            segments.Add(new LineSegment(new Point(4, 0), new Point(0, 4)));
            segments.Add(new LineSegment(new Point(4, 0), new Point(0, 0)));

            return segments;
        }
    }
}
