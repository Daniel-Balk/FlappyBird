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
            
        }

        public void Click()
        {
            
        }

        public void DoPhysics()
        {
            
        }

        public RotateFlipType Rotation { get; set; } = RotateFlipType.RotateNoneFlipNone;
        public Bitmap GetFrame()
        {
            Bitmap b = new Bitmap(Rectangle.Width, Rectangle.Height);
            var g = Graphics.FromImage(b);

            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;

            var topleft = Resources.TopLeft;
            var topcent = Resources.TopCenter;
            var toprigh = Resources.TopRight;
            var cenleft = Resources.CenterLeft;
            var cencent = Resources.Center;
            var cenrigh = Resources.CenterRight;

            g.DrawImage(topleft, 0, 0,topleft.Width,topleft.Height);
            g.DrawImage(cenleft, 0, topleft.Height, cenleft.Width, b.Height - topleft.Height);

            g.DrawImage(topcent, topleft.Width, 0, b.Width - topleft.Width - toprigh.Width, topcent.Height);
            g.DrawImage(cencent, topleft.Width, topcent.Height, b.Width - topleft.Width - toprigh.Width, b.Height - topcent.Height);

            g.DrawImage(toprigh, b.Width - toprigh.Width - 1, 0);
            g.DrawImage(cenrigh, b.Width - toprigh.Width - 1, toprigh.Height, cenrigh.Width, b.Height - toprigh.Height);

            g.Dispose();

            b.RotateFlip(Rotation);
            return b;
        }

        public Rectangle Rectangle { get; set; } = new Rectangle(32, 32, 32, 128);
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
