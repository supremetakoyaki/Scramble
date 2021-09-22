using System;
using System.Drawing;
using System.Linq;

namespace Scramble.Util
{
    public static class BitmapUtil
    {
        public static Bitmap RotateImage(Bitmap b, float angle)
        {
            PointF[] corners = new[]
                {new PointF(0, 0), new Point(b.Width, 0), new PointF(0, b.Height), new PointF(b.Width, b.Height)};

            System.Collections.Generic.IEnumerable<float> xc = corners.Select(p => Rotate(p, angle).X);
            System.Collections.Generic.IEnumerable<float> yc = corners.Select(p => Rotate(p, angle).Y);

            //create a new empty bitmap to hold rotated image
            Bitmap returnBitmap = new Bitmap((int)Math.Abs(xc.Max() - xc.Min()), (int)Math.Abs(yc.Max() - yc.Min()));
            //make a graphics object from the empty bitmap
            using (Graphics g = Graphics.FromImage(returnBitmap))
            {
                //move rotation point to center of image
                g.TranslateTransform((float)returnBitmap.Width / 2, (float)returnBitmap.Height / 2);

                //rotate
                g.RotateTransform(angle);
                //move image back
                g.TranslateTransform(-(float)b.Width / 2, -(float)b.Height / 2);
                //draw passed in image onto graphics object
                g.DrawImage(b, new Rectangle(new Point(0, 0), new Size(b.Width, b.Height)));
            }

            return returnBitmap;
        }

        /// <summary>
        /// Rotates a point around the origin (0,0)
        /// </summary>
        public static PointF Rotate(PointF p, float angle)
        {
            // convert from angle to radians
            double theta = Math.PI * angle / 180;
            return new PointF(
                (float)(Math.Cos(theta) * (p.X) - Math.Sin(theta) * (p.Y)),
                (float)(Math.Sin(theta) * (p.X) + Math.Cos(theta) * (p.Y)));
        }
    }
}
