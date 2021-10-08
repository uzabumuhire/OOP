namespace DoubleDispatch.Shapes.LowCoupling
{
    using System;
    using System.Collections.Generic;

    class EtchASketchKnobs : IBrush
    {
        public void Draw(ISurface surface, IList<LineSegment> segments)
        {
            foreach (LineSegment segment in segments)
            {
                Console.WriteLine(
                    string.Format("Knobs used to produce line segment ({0},{1}) to ({2},{3}).",
                        segment.Point1.X, segment.Point1.Y,
                        segment.Point2.X, segment.Point2.Y
                    )
                );
            }
        }
    }
}
