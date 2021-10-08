namespace DoubleDispatch.Shapes.LowCoupling
{
    using System.Collections.Generic;

    class Parallelogram : IShape
    {
        public IList<LineSegment> GetLineSegments()
        {
            var segments = new List<LineSegment>();
            segments.Add(new LineSegment(new Point(0, 4), new Point(0, 9)));
            segments.Add(new LineSegment(new Point(0, 9), new Point(4, 5)));
            segments.Add(new LineSegment(new Point(4, 0), new Point(4, 5)));
            segments.Add(new LineSegment(new Point(4, 0), new Point(0, 4)));

            return segments;

        }
    }
}
