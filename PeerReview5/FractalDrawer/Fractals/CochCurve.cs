using System;
using System.Collections.Generic;
using System.Drawing;
using FractalDrawer.Figures;

namespace FractalDrawer.Fractals
{
    /// <summary>
    /// Implementation of coch curve fractal
    /// </summary>
    public class CochCurve : Fractal
    {
        /// <summary>
        /// Pen to draw
        /// </summary>
        private readonly Pen _pen = new Pen(Color.Black, 2);

        /// <summary>
        /// Draws coch curve
        /// </summary>
        /// <returns>Image with drawn coch curve</returns>
        public override Bitmap Draw()
        {
            var initial = new Line()
            {
                Start = new PointF(0, SurfaceSize.Height / 1.5f),
                End = new PointF(SurfaceSize.Width, SurfaceSize.Height / 1.5f),
                Angle = 0
            };

            DrawLine(initial, Depth);
            return Bitmap;
        }

        /// <summary>
        /// Draws simple element of coch curve
        /// </summary>
        /// <param name="line">Previous line</param>
        /// <param name="count">Recursion depth</param>
        private void DrawLine(Line line, int count)
        {
            if (count == 0)
            {
                Graphics.DrawLine(_pen, line.Start, line.End);
                return;
            }

            foreach (var newLine in SplitLine(line))
            {
                DrawLine(newLine, count - 1);
            }
        }

        /// <summary>
        /// Splits line into 4 lines
        /// </summary>
        /// <param name="line">Previous line</param>
        /// <returns>List with new lines</returns>
        private static IEnumerable<Line> SplitLine(Line line)
        {
            var newLength = line.Length / 3;
            var line1 = new Line()
            {
                Start = line.Start,
                Angle = line.Angle,
                End = new PointF(
                    (float) (line.Start.X + newLength * Math.Cos(line.Angle)),
                    (float) (line.Start.Y - newLength * Math.Sin(line.Angle))
                )
            };

            yield return line1;

            var angle2 = (float) (line1.Angle + Math.PI / 3f);
            var line2 = new Line()
            {
                Start = line1.End,
                Angle = angle2,
                End = new PointF(
                    (float) (line1.End.X + newLength * Math.Cos(angle2)),
                    (float) (line1.End.Y - newLength * Math.Sin(angle2))
                )
            };

            yield return line2;

            var angle3 = (float) (line2.Angle - 2f * Math.PI / 3f);
            var line3 = new Line()
            {
                Start = line2.End,
                Angle = angle3,
                End = new PointF(
                    (float) (line2.End.X + newLength * Math.Cos(angle3)),
                    (float) (line2.End.Y - newLength * Math.Sin(angle3))
                )
            };

            yield return line3;

            var angle4 = (float) (line3.Angle + Math.PI / 3f);
            var line4 = new Line()
            {
                Start = line3.End,
                Angle = angle4,
                End = new PointF(
                    (float) (line3.End.X + newLength * Math.Cos(angle4)),
                    (float) (line3.End.Y - newLength * Math.Sin(angle4))
                )
            };

            yield return line4;
        }
    }
}