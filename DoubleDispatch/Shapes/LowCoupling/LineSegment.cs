namespace DoubleDispatch.Shapes.LowCoupling
{
    class LineSegment
    {
        public LineSegment(Point point1, Point point2)
        {
            Point1 = point1;
            Point2 = point2;
        }

        public Point Point1 { get; set; }

        public Point Point2 { get; set; }
    }
}
