using FlappyBird.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyBird
{
    public class Tube : IFlappyCompound
    {
        public void BeforeRender()
        {
            if (FlappyBirdApplication.Playing)
                Rectangle.X--;
        }

        public void Click()
        {
            
        }

        public void DoPhysics()
        {
            
        }

        public int Zoom { get; set; } = 4;
        public RotateFlipType Rotation { get; set; } = RotateFlipType.RotateNoneFlipY;
        public Bitmap GetFrame()
        {
            Bitmap b = new Bitmap(Rectangle.Width / Zoom, Rectangle.Height / Zoom);
            var g = Graphics.FromImage(b);

            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;

            var topleft = Resources.TopLeft;
            var topcent = Resources.TopCenter;
            var toprigh = Resources.TopRight;
            var cenleft = Resources.CenterLeft;
            var cencent = Resources.Center;
            var cenrigh = Resources.CenterRight;

            if (FlappyBirdApplication.Playing)
            {
                g.DrawImage(topleft, 0, 0, topleft.Width, topleft.Height);
                g.DrawImage(cenleft, 0, topleft.Height, cenleft.Width, b.Height - topleft.Height);

                g.DrawImage(topcent, topleft.Width, 0, b.Width - topleft.Width - toprigh.Width, topcent.Height);
                g.DrawImage(cencent, topleft.Width, topcent.Height, b.Width - topleft.Width - toprigh.Width, b.Height - topcent.Height);

                g.DrawImage(toprigh, b.Width - toprigh.Width - 1, 0);
                g.DrawImage(cenrigh, b.Width - toprigh.Width - 1, toprigh.Height, cenrigh.Width, b.Height - toprigh.Height);
            }

            g.Dispose();

            b.RotateFlip(Rotation);

            Bitmap returning = new Bitmap(Rectangle.Width, Rectangle.Height);
            var rg = Graphics.FromImage(returning);
            rg.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            rg.DrawImage(b, 0, 0, Rectangle.Width, Rectangle.Height);
            b.Dispose();
            rg.Dispose();

            return returning;
        }

        public Rectangle Rectangle = new Rectangle(32, 32, 128, 512);
        public Rectangle GetRectangle()
        {
            return Rectangle;
        }
        public int Z { get; set; } = 999;
        public int GetZ()
        {
            return Z;
        }

        public void Hover()
        {
            
        }

        public void Update()
        {
            
        }
    }
}
