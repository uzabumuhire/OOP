namespace DoubleDispatch.Shapes.LowCoupling
{
    using System.Collections.Generic;

    class Paper : ISurface
    {
        readonly IList<LineSegment> _segments = new List<LineSegment>();
        public void Add(LineSegment segment)
        {
            _segments.Add(segment);
        }
    }
}
